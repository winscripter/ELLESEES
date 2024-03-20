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

using ElleseesUI.Core;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Input;
using ElleseesUI.Services.Time;
using ElleseesUI.ProjectInfrastructure;
using ElleseesUI.Tasks.Helpers;
using ElleseesUI.Tasks;
using ElleseesUI.Abstractions;
using ElleseesUI.ThemeManager;
using ElleseesUI.Exceptions;

namespace ElleseesUI.Views
{
    /// <summary>
    /// Interaction logic for Timeline.xaml
    /// </summary>
    public partial class Timeline : Page, ICanInitializeThemes
    {
        /// <summary>
        /// An instance of a file manager UI
        /// </summary>
        public EditingAreaFM? FileManager = null;

        /// <summary>
        /// List of text
        /// </summary>
        public List<TimelineObject> Text = new();

        /// <summary>
        /// List of images
        /// </summary>
        public List<TimelineObject> Images = new();

        /// <summary>
        /// List of videos
        /// </summary>
        public List<TimelineObject> Videos = new();

        /// <summary>
        /// List of audios
        /// </summary>
        public List<TimelineObject> Audios = new();

        /// <summary>
        /// List of effects
        /// </summary>
        public List<TimelineObject> Effects = new();

        /// <summary>
        /// Represents a project loaded into the timeline.
        /// </summary>
        public VideoProject? Project { get; set; } = null;

        private readonly ITimeService _timeService;

        /// <summary>
        /// Time service used in the timeline.
        /// </summary>
        public ITimeService TimeService => _timeService;

        /// <summary>
        /// Checks whether Do Not Disturb is enabled on the status bar, so that
        /// the status bar will not update until the user turns off Do Not Disturb.
        /// </summary>
        public bool DoNotDisturb { get; set; } = false;

        /// <summary>
        /// Initializes a new instance of <see cref="Timeline" />.
        /// </summary>
        public Timeline()
        {
            InitializeComponent();

            _timeService = new TimeService();
            InitializeThemes();

            Activate(0);
        }

        /// <inheritdoc />
        public void InitializeThemes()
            => ThemeInitializer.Initialize(this);

        /// <inheritdoc />
        public bool AreThemesInitialized => true;

        /// <inheritdoc />
        public ITheme UITheme => ThemeManager.ThemeManager.Current;

        /// <inheritdoc />
        public void RequireThemeInitialization()
            => ThemeInitializationException.ThrowIf(!AreThemesInitialized);

        /// <summary>
        /// Shifts display timestamps in the timeline to the right.
        /// </summary>
        public void TimelineShiftSpans()
        {
            _timeService.AddSecond();
            var _ts = (ITimeService)_timeService.Clone();

            int s = _ts.Seconds;
            int m = _ts.Minutes;
            int h = _ts.Hours;

            string f0 = $"{FormatNumForTimeline(h)}:{FormatNumForTimeline(m)}:{FormatNumForTimeline(s)}";
            LocalAddSecond();
            string f1 = $"{FormatNumForTimeline(h)}:{FormatNumForTimeline(m)}:{FormatNumForTimeline(s)}";
            LocalAddSecond();
            string f2 = $"{FormatNumForTimeline(h)}:{FormatNumForTimeline(m)}:{FormatNumForTimeline(s)}";
            LocalAddSecond();
            string f3 = $"{FormatNumForTimeline(h)}:{FormatNumForTimeline(m)}:{FormatNumForTimeline(s)}";

            Time1.Content = f0;
            Time2.Content = f1;
            Time3.Content = f2;
            Time4.Content = f3;

            void LocalAddSecond()
            {
                s++;

                if (s >= 60)
                {
                    s = 0;
                    LocalAddMinute();
                }
            }

            void LocalAddMinute()
            {
                m++;

                if (m > 60)
                {
                    m = 0;
                    LocalAddHour();
                }
            }

            void LocalAddHour()
            {
                h++;
            }

            string FormatNumForTimeline(int num)
            {
                return num > 9 ? num.ToString() : $"0{num}";
            }
        }

        /// <summary>
        /// Shifts display timestamps in the timeline to the left.
        /// </summary>
        public void TimelineShiftSpansBack()
        {
            if (_timeService.Seconds == 0 && _timeService.Minutes == 0 && _timeService.Hours == 0)
            {
                return;
            }

            var tsnew = (ITimeService)_timeService.Clone();

            tsnew.Span = tsnew.Span.Add(new TimeSpan(0, 0, 2));

            Time4.Content = FormatForTimeline(tsnew.Span);

            tsnew.Span = tsnew.Span.Subtract(new TimeSpan(0, 0, 1));
            Time3.Content = FormatForTimeline(tsnew.Span);

            tsnew.Span = tsnew.Span.Subtract(new TimeSpan(0, 0, 1));
            Time2.Content = FormatForTimeline(tsnew.Span);

            tsnew.Span = tsnew.Span.Subtract(new TimeSpan(0, 0, 1));
            Time1.Content = FormatForTimeline(tsnew.Span);

            _timeService.Change(Convert.ToInt32(tsnew.Span.Hours), tsnew.Span.Minutes, tsnew.Span.Seconds);

            static string FormatForTimeline(TimeSpan span)
            {
                return $"{FormatNumForTimeline(span.Hours)}:{FormatNumForTimeline(span.Minutes)}:{FormatNumForTimeline(span.Seconds)}";
            }

            static string FormatNumForTimeline(int num)
            {
                return num > 9 ? num.ToString("00") : $"0{num}";
            }
        }


        private void InactivateByIndex(int index)
        {
            switch (index)
            {
                case 0: Files.Background = ThemeManager.ThemeManager.Current.EditorTabInactiveBackground; break;
                case 1: Objects.Background = ThemeManager.ThemeManager.Current.EditorTabInactiveBackground; break;
                case 2: Export.Background = ThemeManager.ThemeManager.Current.EditorTabInactiveBackground; break;
                case 3: About.Background = ThemeManager.ThemeManager.Current.EditorTabInactiveBackground; break;
                case 4: EditElsewhere.Background = ThemeManager.ThemeManager.Current.EditorTabInactiveBackground; break;
            }
        }

        private void ActivateByIndex(int index)
        {
            switch (index)
            {
                case 0: Files.Background = ThemeManager.ThemeManager.Current.EditorTabActiveBackground; break;
                case 1: Objects.Background = ThemeManager.ThemeManager.Current.EditorTabActiveBackground; break;
                case 2: Export.Background = ThemeManager.ThemeManager.Current.EditorTabActiveBackground; break;
                case 3: About.Background = ThemeManager.ThemeManager.Current.EditorTabActiveBackground; break;
                case 4: EditElsewhere.Background = ThemeManager.ThemeManager.Current.EditorTabActiveBackground; break;
            }
        }

        /// <summary>
        /// Activates a tab in the editing area by its index.
        /// </summary>
        /// <param name="index">Tab index.</param>
        public void Activate(int index)
        {
            var indexes = new[] { 0, 1, 2, 3, 4 };

            foreach (int idx in indexes)
            {
                if (idx != index)
                {
                    InactivateByIndex(idx);
                }
                else
                {
                    ActivateByIndex(index);
                }
            }
        }

        private void EditElsewhere_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Activate(4);
        }

        private void About_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Activate(3);
        }

        private void Export_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Activate(2);
        }

        private void Objects_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Activate(1);
        }

        private void Files_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Activate(0);
        }

        private void TimelineForwardButton_Click(object sender, RoutedEventArgs e)
        {
            TimelineScrollRight();
        }

        private void TimelineBackButton_Click(object sender, RoutedEventArgs e)
        {
            TimelineScrollLeft();
        }

        /// <summary>
        /// Scrolls left once in the Timeline.
        /// </summary>
        public void TimelineScrollLeft()
        {
            if (Project == null)
            {
                MessageBoxCommon.ErrorOk("This task cannot be completed because no project is loaded.");

                return;
            }

            TaskExecutionHelper.TryExecute(new ScrollLeft(this, Project));
        }

        /// <summary>
        /// Scrolls right once in the Timeline.
        /// </summary>
        public void TimelineScrollRight()
        {
            if (Project == null)
            {
                MessageBoxCommon.ErrorOk("This task cannot be completed because no project is loaded.");

                return;
            }

            TaskExecutionHelper.TryExecute(new ScrollRight(this, Project));
        }

        /// <summary>
        /// Hides all child objects in the timeline.
        /// </summary>
        public void HideTimelineChildObjects()
        {
            Text1.Visibility = Text2.Visibility = Text3.Visibility = Text4.Visibility =
                Effect1.Visibility = Effect2.Visibility = Effect3.Visibility = Effect4.Visibility =
                    Audio1.Visibility = Audio2.Visibility = Audio3.Visibility = Audio4.Visibility =
                        Video1.Visibility = Video2.Visibility = Video3.Visibility = Video4.Visibility =
                            Image1.Visibility = Image2.Visibility = Image3.Visibility = Image4.Visibility =
                                Visibility.Hidden;
        }

        /// <summary>
        /// Ensures the project is loaded, otherwise shows an error.
        /// </summary>
        /// <returns><see langword="TRUE" /> if the project is loaded, <see langword="FALSE" /> if the project is not loaded.</returns>
        public bool EnsureProjectLoaded()
        {
            if (Project == null)
            {
                MessageBoxCommon.ErrorOk($"This task could not be completed because no project is loaded.");
            }

            return Project != null;
        }

        private void EditAreaView_PreviewMouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            e.Handled = true;
        }

        private void ToggleDoNotDisturb(object sender, RoutedEventArgs e)
        {
            DoNotDisturb = !DoNotDisturb;
            Status.Content = DoNotDisturb
                             ? "Enabled \"Do Not Disturb\". The status bar won't update."
                             : "Idle";
        }

        private void SetStatusBarBackground(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBoxCommon.InfoYesNoCancel("Would you like to set background color to default?\n\nYes - Use default status bar background\nNo - Use custom background\nCancel - Don't change status bar background");

            if (result == MessageBoxResult.Yes)
            {
                StatusBackground.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#282828")!;
            }
            else if (result == MessageBoxResult.No)
            {
                var color = ColorPickerCaller.Call();
                if (color != null)
                {
                    StatusBackground.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#" + color!.Value.ToHex())!;
                }
            }
        }

        private void SetStatusBarForeground(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBoxCommon.InfoYesNoCancel("Would you like to set foreground color to default?\n\nYes - Use default status bar foreground\nNo - Use custom foreground\nCancel - Don't change status bar foreground");

            if (result == MessageBoxResult.Yes)
            {
                Status.Foreground = Brushes.White;
            }
            else if (result == MessageBoxResult.No)
            {
                var color = ColorPickerCaller.Call();
                if (color != null)
                {
                    Status.Foreground = (SolidColorBrush)new BrushConverter().ConvertFrom("#" + color!.Value.ToHex())!;
                }
            }
        }
    }
}
