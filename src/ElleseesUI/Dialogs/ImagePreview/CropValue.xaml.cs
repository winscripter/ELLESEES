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

namespace ElleseesUI.Dialogs.ImagePreview;

/// <summary>
/// Interaction logic for CropValue.xaml
/// </summary>
public partial class CropValue : Window, ICanInitializeThemes
{
    /// <summary>
    /// Original width of the image.
    /// </summary>
    public int OriginalX { get; init; } = 0;

    /// <summary>
    /// Original height of the image.
    /// </summary>
    public int OriginalY { get; init; } = 0;

    /// <summary>
    /// New width/height of the image submitted by the user.
    /// </summary>
    public (int x, int y)? Value { get; private set; } = null;

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
    /// Initializes a new instance of <see cref="CropValue" />.
    /// </summary>
    public CropValue()
    {
        InitializeComponent();
        InitializeThemes();
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        Close();
    }

    private void Button_Click_1(object sender, RoutedEventArgs e)
    {
        if (OriginalX + OriginalY == 0)
        {
            MessageBoxCommon.ErrorOk("Unable to continue: Bad initialization was requested.");

            return;
        }

        var xs = int.TryParse(ImageWidth.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out int x);
        var ys = int.TryParse(ImageHeight.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out int y);

        if (!xs)
        {
            MessageBoxCommon.ErrorOk("The Width field is invalid: Must be a valid digit (e.g. 1, 2, 5, etc)");

            return;
        }

        if (!ys)
        {
            MessageBoxCommon.ErrorOk("The Height field is invalid: Must be a valid digit (e.g. 1, 2, 5, etc)");

            return;
        }

        if (x < 0)
        {
            MessageBoxCommon.ErrorOk("The Width field is invalid: Value cannot be negative");

            return;
        }

        if (y < 0)
        {
            MessageBoxCommon.ErrorOk("The Height field is invalid: Value cannot be negative");

            return;
        }

        if (x >= OriginalX)
        {
            MessageBoxCommon.ErrorOk($"The Width field is invalid: Width can't be greater than or equal to the original image width (max. {OriginalX}, got {x})");

            return;
        }

        if (y >= OriginalY)
        {
            MessageBoxCommon.ErrorOk($"The Height field is invalid: Height can't be greater than or equal to the original image height (max. {OriginalY}, got {y})");

            return;
        }

        Value = (x, y);
        Close();
    }
}
