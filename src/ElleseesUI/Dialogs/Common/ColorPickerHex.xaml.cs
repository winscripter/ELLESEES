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
using ElleseesUI.Core.Common;
using ElleseesUI.Exceptions;
using ElleseesUI.ThemeManager;
using System.Windows;

namespace ElleseesUI.Dialogs.Common
{
    /// <summary>
    /// Interaction logic for ColorPickerHex.xaml
    /// </summary>
    public partial class ColorPickerHex : Window, ICanInitializeThemes
    {
        /// <summary>
        /// RGB color returned by the dialog.
        /// </summary>
        public Rgb3? Rgb { get; private set; } = null;

        /// <inheritdoc />
        public bool AreThemesInitialized
            => true;

        /// <inheritdoc />
        public ITheme UITheme
            => ThemeManager.ThemeManager.Current;

        /// <inheritdoc />
        public void InitializeThemes()
            => ThemeInitializer.Initialize(this);

        /// <inheritdoc />
        public void RequireThemeInitialization()
            => ThemeInitializationException.ThrowIf(!AreThemesInitialized);

        /// <summary>
        /// Initializes a new instance of <see cref="ColorPickerHex" />.
        /// </summary>
        public ColorPickerHex()
        {
            InitializeComponent();
            InitializeThemes();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            var val = Hex.Text;

            if (val.Length == 0)
            {
                MessageBoxCommon.ErrorOk("Please enter a valid hexadecimal value");

                return;
            }

            var parser = new HexParser(val);

            try
            {
                parser.Parse();

                Rgb = parser.Rgb3!;
                Close();
            }
            catch (HexParseException ex)
            {
                MessageBoxCommon.ErrorOk(ex.Message);

                return;
            }
            catch (NullReferenceException)
            {
                // this will never be reached
                MessageBoxCommon.ErrorOk("Oof");

                return;
            }
        }
    }
}
