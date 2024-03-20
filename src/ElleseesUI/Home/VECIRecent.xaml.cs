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
using ElleseesUI.FileSystem;
using ElleseesUI.VECI;
using ElleseesUI.VECI.UI;
using System.Collections.ObjectModel;
using System.Windows;

namespace ElleseesUI.Home;

/// <summary>
/// Interaction logic for VECIRecent.xaml
/// </summary>
public partial class VECIRecent : Window
{
    internal ObservableCollection<DisplayFile> Files;

    /// <summary>
    /// Initializes a new instance of <see cref="VECIRecent" />.
    /// </summary>
    public VECIRecent()
    {
        InitializeComponent();
        Files = new();
        RecentVECIProjects.ItemsSource = this.Files;

        LoadProjectViews();
    }

    private void LoadProjectViews()
    {
        foreach (string directory in Directory.GetDirectories(Path.Combine(Directory.GetCurrentDirectory(), "veci_projects")))
        {
            this.Files.Add(new DisplayFile
            {
                ShortName = Path.GetFileName(directory)!,
                FullName = Path.GetFullPath(directory)
            });
        }
    }

    /// <summary>
    /// Event handler for the Close button.
    /// </summary>
    protected void OnCloseButtonClick(object sender, RoutedEventArgs e)
    {
        this.Close();
    }

    /// <summary>
    /// Event handler for the Load button.
    /// </summary>
    protected void OnLoadButtonClick(object sender, RoutedEventArgs e)
    {
        if (RecentVECIProjects.SelectedItem is not DisplayFile file)
        {
            MessageBoxCommon.ErrorOk("Please select a project to load.");

            return;
        }
        else
        {
            try
            {
                var window = new VECIEditor();
                window.LoadVECI(VECIFile.Load(file.FullName));
                window.ShowDialog();
            }
            catch (Exception ex)
            {
                Logger.Log(ex.ToString(), LoggerFlags.AppendPriority | LoggerFlags.AppendDateTime, LogPriority.Fatal);

                MessageBoxCommon.ErrorOk($"Cannot load this project. We're sorry for the inconvenience. :(\n\nDetails were logged in file Ellesees.log.");
            }
        }
    }
}
