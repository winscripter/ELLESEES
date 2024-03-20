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

using Microsoft.Win32;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace ElleseesUI.Views
{
    /// <summary>
    /// Interaction logic for EditingAreaFM.xaml
    /// </summary>
    public partial class EditingAreaFM : Page
    {
        /// <summary>
        /// A list of selected images.
        /// </summary>
        public Stack<string> LastSelectedImages = new();

        /// <summary>
        /// A list of selected videos.
        /// </summary>
        public Stack<string> LastSelectedVideos = new();

        /// <summary>
        /// A list of selected audios.
        /// </summary>
        public Stack<string> LastSelectedAudios = new();

        /// <summary>
        /// A list of audio resources displayed in the UI.
        /// </summary>
        public ObservableCollection<string> AudioResources = new();

        /// <summary>
        /// A list of video resources displayed in the UI.
        /// </summary>
        public ObservableCollection<string> VideoResources = new();

        /// <summary>
        /// A list of image resources displayed in the UI.
        /// </summary>
        public ObservableCollection<string> ImageResources = new();

        /// <summary>
        /// Code to run whenever an image is added.
        /// </summary>
        public Action<Stack<string>, Action> OnAddImage = (ls, notifier) =>
        {
            var dialog = new OpenFileDialog
            {
                Filter = "Portable Network Graphics|*.png|Joint Photographic Experts Group (JPG)|*.jpg|Joint Photographic Experts Group (JPEG)|*.jpeg|Graphics Interchange Format (GIF)|*.gif|Google WebP (WEBP)|*.webp|Tag Image File Format (TIFF)|*.tiff|Quite OK Image (QOI)|*.qoi|Truevision Graphics Adapter (TGA)|*.tga|Bitmap|*.bmp",
                Title = "Please select image files",
                Multiselect = true
            };

            bool? success = dialog.ShowDialog();

            if (success == true)
            {
                foreach (string s in dialog.SafeFileNames)
                {
                    ls.Push(s);
                }
            }

            notifier();
        };

        /// <summary>
        /// Code to run whenever an video is added.
        /// </summary>
        public Action<Stack<string>, Action> OnAddVideo = (ls, notifier) =>
        {
            var dialog = new OpenFileDialog
            {
                Filter = "MP4|*.mp4|MKV|*.mkv|WMV|*.wmv|AVI|*.avi",
                Title = "Please select video files",
                Multiselect = true
            };

            bool? success = dialog.ShowDialog();

            if (success == true)
            {
                foreach (string s in dialog.SafeFileNames)
                {
                    ls.Push(s);
                }
            }

            notifier();
        };

        /// <summary>
        /// Code to run whenever an audio is added.
        /// </summary>
        public Action<Stack<string>, Action> OnAddAudio = (ls, notifier) =>
        {
            var dialog = new OpenFileDialog
            {
                Filter = "MP3|*.mp3|AAC|*.aac|OGG|*.ogg|M4A|*.m4a|WAV|*.wav|WMA|*.wma|WEBM|*.webm",
                Title = "Please select audio files",
                Multiselect = true
            };

            bool? success = dialog.ShowDialog();

            if (success == true)
            {
                foreach (string s in dialog.SafeFileNames)
                {
                    ls.Push(s);
                }
            }

            notifier();
        };

        /// <summary>
        /// Binds UI elements to selected files to display them.
        /// </summary>
        public void InitializeBindings()
        {
            AudioResourcesList.ItemsSource = AudioResources;
            VideoResourcesList.ItemsSource = VideoResources;
            ImageResourcesList.ItemsSource = ImageResources;
        }

        /// <summary>
        /// Initializes events whenever an audio, video, or image is added.
        /// </summary>
        public void InitializeEvents()
        {
            SubscribeChangeAudio(() =>
            {
                AudioResources.Clear();

                foreach (string audio in LastSelectedAudios)
                {
                    AudioResources.Add(audio);
                }
            });

            SubscribeChangeVideo(() =>
            {
                VideoResources.Clear();

                foreach (string video in LastSelectedVideos)
                {
                    VideoResources.Add(video);
                }
            });

            SubscribeChangeImage(() =>
            {
                ImageResources.Clear();

                foreach (string image in LastSelectedImages)
                {
                    ImageResources.Add(image);
                }
            });
        }

        /// <summary>
        /// Similar to <see cref="OnAddImage" />.
        /// </summary>

        public Action ChangedImages = () => { };

        /// <summary>
        /// Similar to <see cref="OnAddVideo" />.
        /// </summary>
        public Action ChangedVideos = () => { };

        /// <summary>
        /// Similar to <see cref="OnAddAudio" />.
        /// </summary>
        public Action ChangedAudios = () => { };

        /// <summary>
        /// Initializes a new instance of <see cref="EditingAreaFM" />.
        /// </summary>
        public EditingAreaFM()
        {
            InitializeComponent();

            InitializeBindings();
            InitializeEvents();
        }

        /// <summary>
        /// Subscribes to events that occur during image, video, and audio resources being changed.
        /// </summary>
        /// <param name="imgAdd">Event for image resource changed.</param>
        /// <param name="vidAdd">Event for video resource changed.</param>
        /// <param name="audAdd">Event for audio resource changed.</param>
        public void SetEvents(Action<Stack<string>, Action> imgAdd, Action<Stack<string>, Action> vidAdd, Action<Stack<string>, Action> audAdd)
        {
            OnAddImage = imgAdd;
            OnAddVideo = vidAdd;
            OnAddAudio = audAdd;
        }

        // Image
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OnAddImage(LastSelectedImages, ChangedImages);
        }

        // Video
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            OnAddVideo(LastSelectedVideos, ChangedVideos);
        }

        // Audio
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            OnAddAudio(LastSelectedAudios, ChangedAudios);
        }

        /// <summary>
        /// Performs a subscription to run code whenever an image is added.
        /// </summary>
        /// <param name="action">Code to run when image is added.</param>
        public void SubscribeChangeImage(Action action)
        {
            ChangedImages = action;
        }

        /// <summary>
        /// Performs a subscription to run code whenever a video is added.
        /// </summary>
        /// <param name="action">Code to run when video is added.</param>
        public void SubscribeChangeVideo(Action action)
        {
            ChangedVideos = action;
        }

        /// <summary>
        /// Performs a subscription to run code whenever an audio is added.
        /// </summary>
        /// <param name="action">Code to run when audio is added.</param>
        public void SubscribeChangeAudio(Action action)
        {
            ChangedAudios = action;
        }
    }
}
