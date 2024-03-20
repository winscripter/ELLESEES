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
using ElleseesUI.CommonViewFramePages;
using ElleseesUI.Core;
using ElleseesUI.Crashes;
using ElleseesUI.Exceptions;
using ElleseesUI.Home;
using ElleseesUI.Initialization;
using ElleseesUI.ProjectInfrastructure;
using ElleseesUI.Recent;
using ElleseesUI.ServiceInitializers;
using ElleseesUI.Services.FTU;
using ElleseesUI.Services.PropertyEditor;
using ElleseesUI.SharedControllers;
using ElleseesUI.Tasks;
using ElleseesUI.ThemeManager.PredefinedThemes;
using ElleseesUI.VECI.UI;
using ElleseesUI.VideoContext;
using ElleseesUI.Views;
using System.Windows;
using System.Windows.Input;

namespace ElleseesUI
{
    /// <summary>
    /// Home window.
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Initializes this application.
        /// </summary>
        /// <exception cref="VersioningException">Thrown when versioning service failed.</exception>
        public MainWindow()
        {
            InitializeComponent();

            var screen = new Home.SplashScreen();
            screen.Show();

            RecentStore.InstallAll();
            RecentProjects.ItemsSource = RecentStore.Recent;

            try
            {
                WelcomeText.Text = GreetingChooser.Select();
            }
            catch (Exception ex)
            {
                Logger.Log($"Unable to use a unique string as a greeting due to the following exception: {Environment.NewLine}{ex}", LoggerFlags.AppendPriority | LoggerFlags.AppendDateTime, LogPriority.Fatal);
            }

            SharedTaskController.SetCorruptProjectMode = new SetCorruptProjectMode();

            Configuration cfg;
            try
            {
                cfg = new("settings.ini");
            }
            catch (Exception ex)
            {
                MessageBoxCommon.ErrorOk($"Cannot read settings file. We're sorry. :(\n{ex.Message}\n\nELLESEES will now use default settings and will restore the settings file with default preferences.");

                Logger.Log($"Configuration file failed to parse with the following exception:{Environment.NewLine}{ex}",
                             LoggerFlags.AppendPriority | LoggerFlags.AppendDateTime,
                             LogPriority.Fatal);

                cfg = new(null);
                cfg.UseDefaultSettings();
                ConfigurationRecovery.OverwriteToDefaults("settings.ini");
            }

            SharedBackgroundController.Configuration = cfg;
            ThemeManager.ThemeManager.Current = new Default();

            try
            {
                Versioning.Version version = new();

                SharedBackgroundController.Version = version;
            }
            catch (Exception ex)
            {
                Logger.Log($"Failed to initialize ELLESEES due to a versioning error:{Environment.NewLine}{ex}",
                             LoggerFlags.AppendPriority | LoggerFlags.AppendDateTime,
                             LogPriority.Fatal);

                MessageBoxCommon.ErrorOk("Versioning failed to initialize. ELLESEES cannot start.");
                screen.Close();

                throw new VersioningException("Versioning configuration is currently unavailable.");
            }

            // Most computers nowadays are too fast to complete background tasks before the
            // splash screen even had time to display. Splash screen attracts more people
            // into using the editor. To ensure the splash screen will always show, we must
            // add an intentional 1-second delay.
            Thread.Sleep(1000);

            CrashService.Initialize();

            screen.Close();
        }

        /// <summary>
        /// Event handler for button "Continue without projects".
        /// </summary>
        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            var window = new VideoEditorUI();

            var timeline = new NoProjectLoadedView();

            window.CommonViewFrame.Content = timeline;

            var propEditorService = new PropertyEditorService(window.PropertyEditorVisibility);
            SharedUIController.PropertyEditorService = propEditorService;

            propEditorService.ShowPlaceholder();

            var ftuService = new FtuService();
            SharedBackgroundController.FtuService = ftuService;

            window.Show();
        }

        /// <summary>
        /// Event handler for button "Create new project".
        /// </summary>
        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            var dlg = new Home.ProjectCreationDialog();
            dlg.ShowDialog();
        }

        /// <summary>
        /// Event handler for button "Load selected project".
        /// </summary>
        private void LoadSelectedProjectButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (RecentProjects.SelectedItem is not RecentProject selectedProject)
                {
                    MessageBoxCommon.ErrorOk("Please select a project to load.");

                    return;
                }
                else
                {
                    var window = VideoEditorUILoader.LoadNormallyWithoutProjects();
                    var timeline = new Timeline
                    {
                        Project = new VideoProject(Path.Combine(
                            Directory.GetCurrentDirectory(),
                            Locations.ProjectsFolder,
                            selectedProject.Path
                        ))
                    };

                    window.Project = timeline.Project;

                    if (timeline.Project.Project == null)
                    {
                        timeline.Project = null;
                        window.CommonViewFrame.Content = new Error();
                    }
                    else
                    {
                        if (!File.Exists(Path.Combine(
                            Directory.GetCurrentDirectory(),
                            Locations.ProjectsFolder,
                            selectedProject.Path,
                            "out",
                            timeline.Project.Project.PrimaryVideo
                         )))
                        {
                            MessageBoxCommon.ErrorOk($"This project is corrupt. We're sorry for the inconvenience. :(");
                            window.Close(); // Prevent ELLESEES from permanently running in the background doing nothing after the project load failure anomaly.

                            return;
                        }

                        // Update all objects in the timeline by scrolling
                        // right once and then left once.

                        timeline.TimelineScrollRight();
                        timeline.TimelineScrollLeft();

                        // Initialize the rest of the window.

                        window.CommonViewFrame.Content = timeline;
                        timeline.EditAreaView.Content = new EditingAreaFM();
                        window.Title = $"{selectedProject.Path} - {SharedBackgroundController.Version!.DisplayName!.DisplayName}";
                        window.WindowTitle.Content = $"{selectedProject.Path} - {SharedBackgroundController.Version!.DisplayName!.DisplayName}";
                        timeline.Activate(0);
                    }

                    StatusBar.Initialize(timeline.Status, timeline);

                    FTU.Initialize();
                    SharedBackgroundController.FtuService!.ValidateAndSendFtuNotification();

                    window.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                Logger.Log(ex.ToString(), LoggerFlags.AppendPriority | LoggerFlags.AppendDateTime, LogPriority.Fatal);
                throw;
            }
        }

        /// <summary>
        /// Event handler for Close window button.
        /// </summary>
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            CrashService.Shutdown();
            Close();
        }

        /// <summary>
        /// Event handler for "Debugging purposes" button.
        /// </summary>
        private void OpenVECIProjectClick(object sender, RoutedEventArgs e)
        {
            var dialog = new VECIRecent();
            dialog.ShowDialog();
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var veci = new VECIEditor();
            veci.ShowDialog();
        }

        /// <summary>
        /// Event handler for NEW veci project button.
        /// </summary>
        protected void OnNewVECIProjectClick(object sender, RoutedEventArgs e)
        {
            var dialog = new VECI.UI.ProjectCreationDialog();
            dialog.ShowDialog();
        }

        /// <summary>
        /// Event handler for the Video Context button.
        /// </summary>
        protected void OnVideoContextClick(object sender, RoutedEventArgs e)
        {
            VideoContextQuery.LaunchTask();
        }
    }
}
