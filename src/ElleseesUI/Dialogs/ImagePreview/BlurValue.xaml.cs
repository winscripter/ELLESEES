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
/// Interaction logic for BlurValue.xaml
/// </summary>
public partial class BlurValue : Window, ICanInitializeThemes
{
    /// <summary>
    /// Blur Sigma returned by the dialog.
    /// </summary>
    public float? Value { get; private set; } = null;

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
    /// Initializes a new instance of <see cref="BlurValue" />.
    /// </summary>
    public BlurValue()
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
        var parseSuccess = float.TryParse(BlurCount.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out float sigma);

        if (!parseSuccess)
        {
            MessageBoxCommon.ErrorOk("Please enter a valid digit (f.e. 1.23, 1,23, 5, etc)");

            return;
        }

        if (sigma < 0F)
        {
            MessageBoxCommon.ErrorOk("Blur cannot be negative");

            return;
        }

        if (sigma > 30000F)
        {
            MessageBoxCommon.ErrorOk("Woah! The sigma value for Gaussian Blur seems a bit too much! Not sure why you would need that much...\n\nUnfortunately, maximum amount of sigma can only be 30,000.");

            return;
        }

        Value = sigma;
        Close();
    }
}
