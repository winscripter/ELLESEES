// MIT License
// 
// Copyright (c) 2024 winscripter
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.
//

using Ellesees.Base.Logging;
using ElleseesUI.Core;
using ElleseesUI.ProjectInfrastructure;
using ElleseesUI.SharedControllers;
using ElleseesUI.Tools;
using ElleseesUI.Views;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace ElleseesUI.Home;

/// <summary>
/// Interaction logic for ProjectCreationDialog.xaml
/// </summary>
public partial class ProjectCreationDialog : Window
{
    /// <summary>
    /// Naming stat kind, e.g. foreground color of the naming stat
    /// </summary>
    public enum NamingStatKind
    {
        /// <summary>
        /// Green foreground
        /// </summary>
        Green,

        /// <summary>
        /// Red foreground
        /// </summary>
        Red
    }

    /// <summary>
    /// List of filenames that cannot appear in Windows path names.
    /// </summary>
    public static readonly string[] InvalidWindowsFileNames =
    {
        "con", "nul", "aux", "prn", "lpt1", "lpt2", "lpt3", "lpt4", "lpt5", "lpt6",
        "lpt7", "lpt8", "lpt9", "com1", "com2", "com3", "com4", "com5", "com6", "com7",
        "com8", "com9", "lpt0", "com0"
    };

    /// <summary>
    /// A list of random strings that appear whenever the project with that name can be created.
    /// </summary>
    public static readonly string[] CompletionStrings =
    {
        "That path name is valid! Let's create the project!",
        "Project can be created! Let's do that!",
        "\"If a project can be created with that name, create it\" - winscripter, the developer of ELLESEES",
        "Project with this name can be created."
    };

    /// <summary>
    /// Represents characters that can't be used in Windows paths.
    /// </summary>
    public const string BannedWindowsPathChars = "<>:\"/\\|?*";

    /// <summary>
    /// Maximum Windows path length.
    /// </summary>
    public const int MAX_PATH = 256;

    private bool isOkToProceed = false;
    private bool IsOkToProceed
    {
        get
        {
            return isOkToProceed;
        }
        set
        {
            isOkToProceed = value;

            ContinueButton.IsEnabled = isOkToProceed;
        }
    }
    private string _fileName;

    /// <summary>
    /// Initializes a new instance of <see cref="ProjectCreationDialog" />.
    /// </summary>
    public ProjectCreationDialog()
    {
        InitializeComponent();

        _fileName = string.Empty;
        UpdatePath(string.Empty);
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        Close();
    }

    private void ProjectName_TextChanged(object sender, TextChangedEventArgs e)
    {
        if (sender is not TextBox)
        {
            MessageBoxCommon.ErrorOk($"sender is not TextBox, but rather {sender.GetType().Name}.\n\nIf you changed the source code, the problem probably lies in ElleseesUI/Home/ProjectCreationDialog.xaml.");

            return;
        }

        var text = (sender as TextBox)!.Text;
        UpdateNamingStat(text);

        if (IsOkToProceed)
        {
            UpdatePath(text);
        }
    }

    private void Button_Click_1(object sender, RoutedEventArgs e)
    {
        if (!isOkToProceed)
        {
            MessageBoxCommon.ErrorOk($"Invalid project name");

            return;
        }

        if (!CreateNewProject.ComponentsExist())
        {
            MessageBoxCommon.ErrorOk("One or more required components could not be found. Please re-download the application.");

            return;
        }

        if (!Directory.Exists(_fileName))
        {
            Directory.CreateDirectory(_fileName);
        }

        Locations.EnsureProjectsFolderExists();
        var chooser = new PrimaryVideoChooser();
        chooser.ShowDialog();

        if (chooser.PathToPrimaryVideo != null)
        {
            var process = new Process();

            process.StartInfo.FileName = "CreateNewProject.exe";
            process.StartInfo.Arguments = $"\"{_fileName}\"";

            process.StartInfo.UseShellExecute = false;
            process.StartInfo.CreateNoWindow = true;

            process.Start();
            process.WaitForExit();

            string infoContent = $@"<?xml version=""1.0"" encoding=""UTF-8"" ?>
<ProjectTimeline>
    <PrimaryVideo Path=""{Path.GetFullPath(chooser.PathToPrimaryVideo)}"" />
</ProjectTimeline>";
            File.WriteAllText(Path.Combine(_fileName, $"timeline", $"timeline_info.xml"), infoContent);

            try
            {
                File.Copy(chooser.PathToPrimaryVideo, Path.Combine(_fileName, $"out", Path.GetFileName(chooser.PathToPrimaryVideo)));
            }
            catch (Exception ex)
            {
                Logger.Log(ex.ToString(), LoggerFlags.AppendPriority | LoggerFlags.AppendDateTime, LogPriority.Fatal);
            }

            var editor = VideoEditorUILoader.LoadNormallyWithoutProjects();
            editor.WindowTitle.Content = $"{ProjectName.Text} - {SharedBackgroundController.Version!.DisplayName!.DisplayName}";
            editor.Title = $"{ProjectName.Text} - {SharedBackgroundController.Version!.DisplayName!.DisplayName}";

            var timeline = new Timeline
            {
                Project = new VideoProject(_fileName)
            };

            editor.Project = timeline.Project;

            if (timeline.Project.Project == null)
            {
                timeline.Project = null;
            }

            timeline.EditAreaView.Content = new EditingAreaFM();

            editor.CommonViewFrame.Content = timeline;

            editor.Show();
        }
    }

    /// <summary>
    /// Chooses a random string as a string displayed during a valid project name.
    /// </summary>
    /// <returns>Random string used to signify valid project name,</returns>
    public static string ChooseSuccessPathNameString()
        => CompletionStrings[Random.Shared.Next(1, CompletionStrings.Length) - 1];

    private void UpdateNamingStat(string name)
    {
        if (InvalidWindowsFileNames.Contains(name.ToLower()))
        {
            SetNamingStatText(NamingStatKind.Red, "Path contains device name");

            return;
        }
        
        if (name.Contains('.'))
        {
            foreach (string s in name.Split('.'))
            {
                if (InvalidWindowsFileNames.Contains(s.ToLower()))
                {
                    SetNamingStatText(NamingStatKind.Red, "Path contains device name");

                    return;
                }
            }
        }

        foreach (char c in BannedWindowsPathChars)
        {
            if (name.Contains(c))
            {
                SetNamingStatText(NamingStatKind.Red, $"These characters can't be used in path name:\n{BannedWindowsPathChars}");

                return;
            }
        }

        if (name.EndsWith(' ') || name.StartsWith(' '))
        {
            SetNamingStatText(NamingStatKind.Red, $"Project name starts with or ends with a space");

            return;
        }

        if (Path.Combine(Directory.GetCurrentDirectory(), Locations.ProjectsFolder, name).Length + 2 > MAX_PATH)
        {
            SetNamingStatText(NamingStatKind.Red, $"Project name is too long, please shorten it.");

            return;
        }

        if (string.IsNullOrWhiteSpace(name) || string.IsNullOrEmpty(name))
        {
            SetNamingStatText(NamingStatKind.Red, "Project name must be specified");

            return;
        }

        if (Directory.Exists(Path.Combine(Directory.GetCurrentDirectory(), Locations.ProjectsFolder, name)) ||
            File.Exists(Path.Combine(Directory.GetCurrentDirectory(), Locations.ProjectsFolder, name)))
        {
            SetNamingStatText(NamingStatKind.Red, $"The project named {name} already exists");

            return;
        }

        if (name.EndsWith(".") || name.StartsWith("."))
        {
            SetNamingStatText(NamingStatKind.Red, $"Project name starts or ends with a dot");

            return;
        }

        SetNamingStatText(NamingStatKind.Green, ChooseSuccessPathNameString());
        _fileName = Path.Combine(Directory.GetCurrentDirectory(), Locations.ProjectsFolder, name);
    }

    private void SetNamingStatText(NamingStatKind kind, string text)
    {
        FileNamingOk.Text = text;
        
        switch ((int)kind)
        {
            case 1:
                FileNamingOk.Foreground = Brushes.Red;
                IsOkToProceed = false;
                break;
            case 0:
                FileNamingOk.Foreground = Brushes.Green;
                IsOkToProceed = true;
                break;
        }
    }

    /// <summary>
    /// Updates a WPF label that informs the user where the project will be saved.
    /// </summary>
    /// <param name="path">Where the project will be saved.</param>
    public void UpdatePath(string path)
    {
        OutputPath.Text = $"Will be saved in: {Path.Combine(Directory.GetCurrentDirectory(), Locations.ProjectsFolder, path)}";
    }
}
