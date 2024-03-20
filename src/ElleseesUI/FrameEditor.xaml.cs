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

using Ellesees.Base.IO;
using ElleseesUI.Core;
using ElleseesUI.Core.Common.ImageTasks;
using ElleseesUI.Core.FrameEditor;
using ElleseesUI.Core.ImageEditor;
using Microsoft.Win32;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using System.Windows;
using System.Windows.Media.Imaging;

namespace ElleseesUI
{
    /// <summary>
    /// Interaction logic for FrameEditor.xaml
    /// </summary>
    public partial class FrameEditor : Window
    {
        private Settings _settings;

        /// <summary>
        /// Path to the initial image.
        /// </summary>
        public string? ImagePath { get; set; } = null;

        private const string DefaultImageTemplatePath = "./_assets/DefaultTemplate.png";

        private Image<Rgba32>? LoadedImage = null;
        private string directoryPath = string.Empty;

        private int _lastImageIndex = 0;
        private readonly ActionList actionList;

        internal readonly TaskStack Interactions;

        private static readonly Action<Exception> DefaultOnException = (ex) =>
        {
            if (MessageBox.Show(
                    "Unable to load the specified image. :(\n\nPlease make sure the selected image exists and is accessiable by ELLESEES.\n\nWould you like to view the exception message for debugging purposes? This is primarily useful when trying to troubleshoot the problem.",
                    "ELLESEES",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Error
                ) == MessageBoxResult.Yes)
            {
                try
                {
                    MessageBox.Show(
                        $"{ex.TargetSite?.DeclaringType?.Name}: {ex.Message}",
                        "ELLESEES",
                        MessageBoxButton.OK,
                        MessageBoxImage.Information
                    );
                }
                catch
                {
                    MessageBox.Show(
                        "The exception message could not be displayed. Oof!",
                        "ELLESEES",
                        MessageBoxButton.OK,
                        MessageBoxImage.Error
                    );
                }
            }
        };

        /// <summary>
        /// Absolute path to the image file used as a placeholder for tasks
        /// that are executing.
        /// </summary>
        public static string WaitingView
        {
            get
            {
                return Path.GetFullPath("./_assets/TaskPending.png");
            }
        }

        /// <summary>
        /// Initializes a new instance of <see cref="FrameEditor" />.
        /// </summary>
        public FrameEditor()
        {
            _settings = new();
            actionList = new();
            Interactions = new();

            InitializeComponent();
        }

        private void Do(CommonAction file)
        {
            actionList.Do(file);
        }

        private void Undo()
        {
            try
            {
                _ = actionList.Undo();
                var obj = actionList.Current;

                Preview.Source = new BitmapImage(new Uri(obj.Image, UriKind.RelativeOrAbsolute));
                ImagePath = obj.Image;

                directoryPath = obj.Directory;
                LoadedImage = Image.Load<Rgba32>(ImagePath);
            }
            catch
            {
            }
        }

        private void Redo()
        {
            try
            {
                var obj = actionList.Redo();

                Preview.Source = new BitmapImage(new Uri(obj.Image, UriKind.RelativeOrAbsolute));
                ImagePath = obj.Image;

                directoryPath = obj.Directory;
                LoadedImage = Image.Load<Rgba32>(ImagePath);
            }
            catch
            {
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private string GetAndIncrementLastImageIndex()
        {
            return $"image{_lastImageIndex++}.png";
        }

        private static string GetImageNotFoundMessage()
            => $"The default image template could not be loaded. :(\n\nPlease make sure the following file exists and is accessiable by ELLESEES:\n\"{Directory.GetCurrentDirectory() + "\\_assets\\DefaultTemplate.png"}\".\n\nWould you like to view the exception message for debugging purposes? This is primarily useful when trying to troubleshoot the problem.";

        private void UseDefaultTemplate_Click(object sender, RoutedEventArgs e)
        {
            LoadDefaultImage();
        }

        /// <summary>
        /// Loads default image template.
        /// </summary>
        public void LoadDefaultImage()
        {
            LoadImage(
                DefaultImageTemplatePath,
                (ex) =>
                {
                    if (MessageBox.Show(
                        GetImageNotFoundMessage(),
                        "ELLESEES",
                        MessageBoxButton.YesNo,
                        MessageBoxImage.Error
                    ) == MessageBoxResult.Yes)
                    {
                        try
                        {
                            MessageBox.Show(
                                $"{ex.TargetSite?.DeclaringType?.Name}: {ex.Message}",
                                "ELLESEES",
                                MessageBoxButton.OK,
                                MessageBoxImage.Information
                            );
                        }
                        catch
                        {
                            MessageBox.Show(
                                "The exception message could not be displayed. Oof!",
                                "ELLESEES",
                                MessageBoxButton.OK,
                                MessageBoxImage.Error
                            );
                        }
                    }
                }
            );
        }

        /// <summary>
        /// Loads a custom image.
        /// </summary>
        /// <param name="imagePath">Path to the image.</param>
        /// <param name="OnError">Code to run during an exception.</param>
        public void LoadImage(string imagePath, Action<Exception>? OnError)
        {
            try
            {
                PrivateLoadImage(imagePath);
            }
            catch (Exception ex)
            {
                if (OnError is null)
                {
                    DefaultOnException(ex);
                }
                else
                {
                    OnError(ex);
                }
            }
        }

        private void PrivateLoadImage(string image)
        {
            TemporaryDirectory.EnsureExists();

            image = image.Replace(" ", string.Empty)
                         .Replace("\t", string.Empty);

            if (ImagePath is not null)
            {
                ErrorImageReLoad();
                return;
            }

            string dirName = directoryPath = GenerateDirectoryName();
            Directory.CreateDirectory(dirName);

            string destPath = Path.Combine(dirName, Path.GetFileName(image));

            File.Copy(image, destPath);
            ImagePath = Path.GetFullPath(destPath);

            Preview.Source = new BitmapImage(new Uri(ImagePath, UriKind.Absolute));
            LoadedImage = Image.Load<Rgba32>(ImagePath);

            static void ErrorImageReLoad()
            {
                MessageBox.Show(
                    "You cannot load an image while it's already loaded",
                    "ELLESEES",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error
                );
            }

            static string GenerateDirectoryName()
                => $"./temp/{Random.Shared.Next(1, 999999999)}{Random.Shared.Next(1, 999999999)}{Random.Shared.Next(1, 999999999)}";
        }

        /// <summary>
        /// Checks whether any image was loaded.
        /// </summary>
        public bool IsImageLoaded
        {
            get
            {
                return ImagePath is not null;
            }
        }

        private bool EnsureLoaded()
        {
            if (!IsImageLoaded)
            {
                MessageBox.Show(
                    "You need to load an image first",
                    "ELLESEES",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error
                );
            }

            return IsImageLoaded;
        }

        /// <summary>
        /// Updates image preview to <see cref="ImagePath" />.
        /// </summary>
        public void UpdatePreview()
        {
            Preview.Source = new BitmapImage(new Uri(ImagePath!, UriKind.Absolute));
        }

        /// <summary>
        /// Updates image preview to <see cref="WaitingView" />.
        /// </summary>
        public void SetWait()
        {
            Preview.Source = new BitmapImage(new Uri(WaitingView, UriKind.Absolute));
        }

        private void SetImage(string image)
        {
            Do(new(image, directoryPath));

            Preview.Source = new BitmapImage(new Uri(image, UriKind.Absolute));
        }

        private void UndoButton_Click(object sender, RoutedEventArgs e)
        {
            if (!actionList.IsSuitableForUndo)
            {
                return;
            }

            Undo();
        }

        private void RedoButton_Click(object sender, RoutedEventArgs e)
        {
            if (!actionList.IsSuitableForRedo)
            {
                return;
            }

            Redo();
        }

        private void SelectImage_Click(object sender, RoutedEventArgs e)
        {
            if (EnsureLoaded())
            {
                MessageBoxCommon.ErrorOk($"Cannot load an image because it is already loaded.");

                return;
            }

            var ofd = new OpenFileDialog()
            {
                Title = "Please select an image file",
                Filter = "PNG|*.png|JPG|*.jpg|JPEG|*.jpeg|GIF|*.gif",
                Multiselect = false
            };

            if (ofd.ShowDialog() == true)
            {
                LoadImage(
                    ofd.FileName,
                    (ex) =>
                    {
                        if (MessageBox.Show(
                            GetImageNotFoundMessage(),
                            "ELLESEES",
                            MessageBoxButton.YesNo,
                            MessageBoxImage.Error
                        ) == MessageBoxResult.Yes)
                        {
                            try
                            {
                                MessageBox.Show(
                                    $"{ex.TargetSite?.DeclaringType?.Name}: {ex.Message}",
                                    "ELLESEES",
                                    MessageBoxButton.OK,
                                    MessageBoxImage.Information
                                );
                            }
                            catch
                            {
                                MessageBox.Show(
                                    "The exception message could not be displayed. Oof!",
                                    "ELLESEES",
                                    MessageBoxButton.OK,
                                    MessageBoxImage.Error
                                );
                            }
                        }
                    }
                );
            }
        }
    }
}
