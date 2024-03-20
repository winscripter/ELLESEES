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

using ElleseesUI.Abstractions;
using ElleseesUI.Core;
using ElleseesUI.Exceptions;
using ElleseesUI.ThemeManager;
using System.Collections.ObjectModel;
using System.Windows;

namespace ElleseesUI.Dialogs.Common
{
    /// <summary>
    /// Interaction logic for FontCategoryList.xaml
    /// </summary>
    public partial class FontCategoryList : Window, ICanInitializeThemes
    {
        /// <summary>
        /// Font file selected by the user.
        /// </summary>
        public string? FontFile { get; private set; } = null;

        /// <inheritdoc />
        public bool AreThemesInitialized => true;

        /// <inheritdoc />
        public ITheme UITheme => ThemeManager.ThemeManager.Current;

        /// <inheritdoc />
        public void InitializeThemes()
            => ThemeInitializer.Initialize(this);

        /// <inheritdoc />
        public void RequireThemeInitialization()
            => ThemeInitializationException.ThrowIf(!AreThemesInitialized);

        /// <summary>
        /// A list of fonts displayed in the font list view.
        /// </summary>
        public ObservableCollection<string> Fonts;

        /// <summary>
        /// Initializes a new instance of <see cref="FontCategoryList" />.
        /// </summary>
        public FontCategoryList()
        {
            Fonts = new();

            InitializeComponent();
            InitializeThemes();
        }

        /// <summary>
        /// Initializes UI element bindings to show font files.
        /// </summary>
        public void InitializeBinding() => FontFiles.ItemsSource = Fonts;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (FontFiles.SelectedItems.Count == 0)
            {
                MessageBoxCommon.ErrorOk("Please select a font file");

                return;
            }
            else
            {
                FontFile = FontFiles.SelectedItems[0] as string;

                Close();
            }
        }
    }
}
