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
using System.Windows.Media.Imaging;

namespace ElleseesUI
{
    /// <summary>
    /// Interaction logic for ImagePreview.xaml
    /// </summary>
    public partial class ImagePreview : Window
    {
        /// <summary>
        /// Checks whether no image is loaded or not.
        /// </summary>
        public bool IsEmpty { get; set; } = true;

        /// <summary>
        /// Window resolutions (by pixel) in order of incrementing and decrementing.
        /// </summary>
        public static readonly Dictionary<int, Resolution> ResolutionsByOrder = new()
        {
            { 0, new Resolution(240, 240) },
            { 1, new Resolution(360, 360) },
            { 2, new Resolution(480, 480) },
            { 3, new Resolution(560, 560) },
            { 4, new Resolution(640, 640) },
            { 5, new Resolution(720, 720) },
            { 6, new Resolution(840, 840) },
            { 7, new Resolution(960, 960) }
        };

        /// <summary>
        /// Image resolutions (by pixel) in order of incrementing and decrementing.
        /// </summary>
        public static readonly Dictionary<int, Resolution> ImageResolutionsByOrder = new()
        {
            { 0, new Resolution(240, 170) },
            { 1, new Resolution(360, 290) },
            { 2, new Resolution(480, 410) },
            { 3, new Resolution(560, 490) },
            { 4, new Resolution(640, 570) },
            { 5, new Resolution(720, 650) },
            { 6, new Resolution(840, 770) },
            { 7, new Resolution(960, 890) }
        };

        /// <summary>
        /// Empty image placeholders in order of window size.
        /// </summary>
        public static readonly Dictionary<int, BitmapImage> EmptyImagesByOrder = new()
        {
            { 0, new BitmapImage(new Uri("pack://application:,,,/ElleseesUI;component/Assets/ImagePreview/Empty240x170.png")) },
            { 1, new BitmapImage(new Uri("pack://application:,,,/ElleseesUI;component/Assets/ImagePreview/Empty360x290.png")) },
            { 2, new BitmapImage(new Uri("pack://application:,,,/ElleseesUI;component/Assets/ImagePreview/Empty480x410.png")) },
            { 3, new BitmapImage(new Uri("pack://application:,,,/ElleseesUI;component/Assets/ImagePreview/Empty560x490.png")) },
            { 4, new BitmapImage(new Uri("pack://application:,,,/ElleseesUI;component/Assets/ImagePreview/Empty640x570.png")) },
            { 5, new BitmapImage(new Uri("pack://application:,,,/ElleseesUI;component/Assets/ImagePreview/Empty720x650.png")) },
            { 6, new BitmapImage(new Uri("pack://application:,,,/ElleseesUI;component/Assets/ImagePreview/Empty840x770.png")) },
            { 7, new BitmapImage(new Uri("pack://application:,,,/ElleseesUI;component/Assets/ImagePreview/Empty960x890.png")) }
        };

        private int _order;

        /// <summary>
        /// Initializes a new instance of <see cref="ImagePreview" />.
        /// </summary>
        public ImagePreview()
        {
            _order = 0;

            InitializeComponent();
        }

        private void StepUpOrder()
        {
            if (_order != 7)
            {
                _order++;
            }
        }

        private void StepDownOrder()
        {
            if (_order != 0)
            {
                _order--;
            }
        }

        private void UpdateWindowSize()
        {
            var res = ResolutionsByOrder[_order];

            Width = res.X;
            Height = res.Y;
        }

        private void UpdateImage()
        {
            var res = ImageResolutionsByOrder[_order];

            Preview.Width = res.X;
            Preview.Height = res.Y;

            if (IsEmpty)
            {
                Preview.Source = EmptyImagesByOrder[_order];
            }
        }

        private static void Error(Exception ex)
        {
            var errdlg = new ExceptionNotifyWindow();
            errdlg.ShowDialog();

            MessageBox.Show(
                $"{ex.Source ?? "Something unknown "}: {ex.Message}",
                "Exception occurred",
                MessageBoxButton.OK,
                MessageBoxImage.Error
            );
        }

        // +
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                StepUpOrder();
                UpdateWindowSize();
                UpdateImage();
            }
            catch (Exception ex)
            {
                Error(ex);
            }
        }

        // -
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                StepDownOrder();
                UpdateWindowSize();
                UpdateImage();
            }
            catch (Exception ex)
            {
                Error(ex);
            }
        }
    }
}
