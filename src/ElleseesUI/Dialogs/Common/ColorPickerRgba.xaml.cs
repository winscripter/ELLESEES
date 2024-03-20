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
using System.Globalization;
using System.Windows;

// Thank you, Visual Studio 2022. I have set Namespace Declarations
// to File Scoped yet you still use Block Scoped namespace declarations
// for XAML code-behinds... I love Visual Studio.

namespace ElleseesUI.Dialogs.Common
{
    /// <summary>
    /// Interaction logic for ColorPickerRgba.xaml
    /// </summary>
    public partial class ColorPickerRgba : Window, ICanInitializeThemes
    {
        /// <summary>
        /// The amount of Red returned by this dialog.
        /// </summary>
        public float? RValue { get; private set; } = null;

        /// <summary>
        /// The amount of Green returned by this dialog.
        /// </summary>
        public float? GValue { get; private set; } = null;

        /// <summary>
        /// The amount of Blue returned by this dialog.
        /// </summary>
        public float? BValue { get; private set; } = null;

        /// <summary>
        /// The amount of Alpha (opacity) returned by this dialog.
        /// </summary>
        public float? AValue { get; private set; } = null;

        /// <summary>
        /// Checks whether data was submitted by the user or not.
        /// </summary>
        public bool DataSuccessfullyReturned { get; private set; } = false;

        /// <inheritdoc />
        public bool AreThemesInitialized => true;

        /// <inheritdoc />
        public ITheme UITheme => ThemeManager.ThemeManager.Current;

        /// <inheritdoc />
        public void InitializeThemes() => ThemeInitializer.Initialize(this);

        /// <inheritdoc />
        public void RequireThemeInitialization() => ThemeInitializationException.ThrowIf(!AreThemesInitialized);

        /// <summary>
        /// Initializes a new instance of <see cref="ColorPickerRgba" />.
        /// </summary>
        public ColorPickerRgba()
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
            var rs = float.TryParse(R.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out float r);
            var gs = float.TryParse(G.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out float g);
            var bs = float.TryParse(B.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out float b);
            var @as = float.TryParse(A.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out float a);

            if (!rs)
            {
                MessageBoxCommon.ErrorOk("The R field is invalid: Must be a valid digit (12.34, 12,34, 5, etc)");

                return;
            }

            if (!gs)
            {
                MessageBoxCommon.ErrorOk("The G field is invalid: Must be a valid digit (12.34, 12,34, 5, etc)");

                return;
            }

            if (!bs)
            {
                MessageBoxCommon.ErrorOk("The B field is invalid: Must be a valid digit (12.34, 12,34, 5, etc)");

                return;
            }

            if (!@as)
            {
                MessageBoxCommon.ErrorOk("The A field is invalid: Must be a valid digit (12.34, 12,34, 5, etc)");

                return;
            }

            if (r is < 0.0F or > 255.0F)
            {
                MessageBoxCommon.ErrorOk("The R field is invalid: Number must range between 0 and 255");

                return;
            }

            if (g is < 0.0F or > 255.0F)
            {
                MessageBoxCommon.ErrorOk("The G field is invalid: Number must range between 0 and 255");

                return;
            }

            if (b is < 0.0F or > 255.0F)
            {
                MessageBoxCommon.ErrorOk("The B field is invalid: Number must range between 0 and 255");

                return;
            }

            if (a is < 0.0F or > 255.0F)
            {
                MessageBoxCommon.ErrorOk("The A field is invalid: Number must range between 0 and 255");

                return;
            }

            RValue = r;
            GValue = g;
            BValue = b;
            AValue = a;

            DataSuccessfullyReturned = true;
            Close();
        }
    }
}
