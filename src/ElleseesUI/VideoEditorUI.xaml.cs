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
using ElleseesUI.Abstractions;
using ElleseesUI.Core;
using ElleseesUI.Exceptions;
using ElleseesUI.Export;
using ElleseesUI.Generator;
using ElleseesUI.Notifications.UI;
using ElleseesUI.ProjectInfrastructure;
using ElleseesUI.SharedControllers;
using ElleseesUI.ThemeManager;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ElleseesUI
{
    /// <summary>
    /// Interaction logic for VideoEditorUI.xaml
    /// </summary>
    public partial class VideoEditorUI : Window, ICanInitializeThemes
    {
        /// <summary>
        /// Project that's currently loaded.
        /// </summary>
        public VideoProject? Project;
        private ITheme? _theme;

        /// <summary>
        /// Initializes a new instance of <see cref="VideoEditorUI" />.
        /// </summary>
        public VideoEditorUI()
        {
            InitializeComponent();
            InitializeThemes();
        }

        /// <inheritdoc />
        public void InitializeThemes()
        {
            _theme = ThemeManager.ThemeManager.Current;

            ThemeInitializer.Initialize(this);
        }

        /// <summary>
        /// Gets all menus.
        /// </summary>
        public MenuItem[] MenuRootChildItems
        {
            get => new MenuItem[]
            {
                FileMenu, ViewMenu, ProjectMenu, HelpMenu
            };
        }

        /// <summary>
        /// Gets all child items from the Management Panel.
        /// </summary>
        public Label[] ManagementPanelChildItems
        {
            get => new Label[]
            {
                ManagementPanelItem5
            };
        }

        /// <inheritdoc />
        public bool AreThemesInitialized => true; // Constructor calls InitializeThemes() which will ALWAYS initialize a theme.

        /// <inheritdoc />
        public void RequireThemeInitialization()
            => ThemeInitializationException.ThrowIf(_theme == null);

        /// <inheritdoc />
        public ITheme UITheme => _theme!;

        /// <summary>
        /// Initializes the project.
        /// </summary>
        /// <param name="project">Project to initialize.</param>
        public void InitializeProject(VideoProject project)
            => Project = project;

        /// <summary>
        /// Event handler for Close button.
        /// </summary>
        private void Button_Click(object sender, RoutedEventArgs e)
            => Close();

        private void Label_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            var about = new AboutWindow();
            about.ShowDialog();
        }

        private void MiAboutEllesees_Click(object sender, RoutedEventArgs e)
        {
            var window = new AboutWindow();
            window.ShowDialog();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            var window = new NotificationViewUI();
            window.InitializeBindings();
            window.ShowDialog();
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            if (SharedBackgroundController.Configuration!.IEnjoyUsingEllesees == true)
            {
                // Here's an easter egg. By setting "IEnjoyUsingELLESEES" under section "lol" in the settings.ini
                // file to this loooooooooooooooooooong value:
                // oksowithoutlookingintothesourcecodenobodywilleverfindthisstringandsetitintotheconfigurationfilelikeitssolongwhoisevengoingtotrythis
                // and then attempting to select File -> Crash ELLESEES!, it simply won't. You'll get a warning message box
                // with text "No." and ELLESEES simply will deny your request.
                // 
                // This is just a funky prank. This setting isn't included or documented anywhere in ELLESEES or
                // its official associations, so an average user who's not aware of this easter egg will simply
                // never be able to see this, unless they find out on the internet or be told somewhere.

                MessageBoxCommon.WarnOk("No.");

                return;
            }

            if (MessageBoxCommon.WarnYesNo("This will intentionally crash ELLESEES. This setting should ONLY BE USED AS A LAST RESORT in case you're unable to shut down ELLESEES. All unsaved data will be lost.\n\nClick Yes to crash ELLESEES now.") == MessageBoxResult.Yes)
            {
                Logger.Log("User manually triggered crash by selecting File - Crash ELLESEES!. Application crashed.", LoggerFlags.AppendPriority, LogPriority.Error);

                throw new IntentionalCrashException("User manually triggered crash by selecting File - Crash ELLESEES!.");
            }
        }

        private void MiViewSrc_Click(object sender, RoutedEventArgs e)
        {
            var proc = new Process();
            proc.StartInfo.UseShellExecute = true;
            proc.StartInfo.FileName = "https://github.com/winscripter/ELLESEES";
            proc.Start();
        }

        private void TitleBarBackground_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        // Generate ERD
        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Project == null)
                {
                    MessageBoxCommon.ErrorOk($"Please load a project first to generate ERDs.");

                    return;
                }

                var generator = new ProjectToErdGenerator(Project!);

                foreach (KeyValuePair<string, string> erds in generator.ErdFiles)
                {
                    string erdDirPath = Path.Combine(Project!.AbsolutePath, "RenderingData");

                    if (!Directory.Exists(erdDirPath))
                    {
                        Directory.CreateDirectory(erdDirPath);
                    }
                    else
                    {
                        foreach (string file in Directory.GetFiles(erdDirPath))
                        {
                            File.Delete(file);
                        }
                    }

                    File.AppendAllText(Path.Combine(erdDirPath, erds.Key), erds.Value);
                }

                if (SharedUIController.IsStatusBarServiceLoaded())
                {
                    SharedUIController.StatusBarService!.SetText($"Rendering Data successfully exported into \"{Project!.AbsolutePath}/RenderingData.");
                }
            }
            catch (Exception ex)
            {
                Logger.Log(ex.ToString(), LoggerFlags.AppendPriority | LoggerFlags.AppendDateTime, LogPriority.Fatal);
                throw;
            }
        }

        /// <summary>
        /// Event handler for "Begin Export" under "Project".
        /// </summary>
        protected void OnBeginExportClick(object sender, RoutedEventArgs e)
        {
            var dialog = new ExportDialog
            {
                Project = Project
            };
            dialog.ShowDialog();
        }

        /// <summary>
        /// Event handler for "Help" &gt; "Tour".
        /// </summary>
        protected void OnTourClick(object sender, RoutedEventArgs e)
        {
            var proc = new Process();
            proc.StartInfo.UseShellExecute = true;
            proc.StartInfo.FileName = "https://github.com/winscripter/ELLESEES/tree/main/docs";
            proc.Start();
        }
    }
}
