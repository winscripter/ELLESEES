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

namespace ElleseesUI.Dialogs.Common;

/// <summary>
/// Interaction logic for ColorPickerRgb.xaml
/// </summary>
public partial class ColorPickerRgb : Window, ICanInitializeThemes
{
    /// <summary>
    /// Amount of Red returned by the dialog.
    /// </summary>
    public byte? RValue { get; private set; } = null;

    /// <summary>
    /// Amount of Green returned by the dialog.
    /// </summary>
    public byte? GValue { get; private set; } = null;

    /// <summary>
    /// Amount of Blue returned by the dialog.
    /// </summary>
    public byte? BValue { get; private set; } = null;

    /// <summary>
    /// Checks whether the user submitted data from this dialog or not.
    /// </summary>
    public bool DataSuccessfullyReturned { get; private set; } = false;

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
    /// Initializes a new instance of <see cref="ColorPickerRgb" />.
    /// </summary>
    public ColorPickerRgb()
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
        var rs = byte.TryParse(R.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out byte r);
        var gs = byte.TryParse(G.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out byte g);
        var bs = byte.TryParse(B.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out byte b);

        if (!rs)
        {
            MessageBoxCommon.ErrorOk("The R field is invalid: Must be a valid digit (12.34, 12,34, 5, etc) and must range between 0 and 255");

            return;
        }

        if (!gs)
        {
            MessageBoxCommon.ErrorOk("The G field is invalid: Must be a valid digit (12.34, 12,34, 5, etc) and must range between 0 and 255");

            return;
        }

        if (!bs)
        {
            MessageBoxCommon.ErrorOk("The B field is invalid: Must be a valid digit (12.34, 12,34, 5, etc) and must range between 0 and 255");

            return;
        }

        RValue = r;
        GValue = g;
        BValue = b;

        DataSuccessfullyReturned = true;
        Close();
    }
}
