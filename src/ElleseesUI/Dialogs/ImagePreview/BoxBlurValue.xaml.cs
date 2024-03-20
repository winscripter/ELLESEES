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
/// Interaction logic for BoxBlurValue.xaml
/// </summary>
public partial class BoxBlurValue : Window, ICanInitializeThemes
{
    /// <summary>
    /// Checks whether data was successfully submitted.
    /// </summary>
    public bool? HasValue { get; set; } = null;

    /// <summary>
    /// Box Blur value.
    /// </summary>
    public int? Value { get; set; } = null;

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
    /// Initializes a new instance of <see cref="BokehBlurValue" />.
    /// </summary>
    public BoxBlurValue()
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
        if (string.IsNullOrWhiteSpace(BlurAmount.Text) || string.IsNullOrEmpty(BlurAmount.Text))
        {
            HasValue = false;

            Close();
            return;
        }

        var parsesuccess = int.TryParse(
            BlurAmount.Text,
            NumberStyles.Any,
            CultureInfo.InvariantCulture,
            out int value
        );

        if (!parsesuccess)
        {
            MessageBoxCommon.ErrorOk("Expecting a valid integer (e.g. 1, 4, but not 1.23, 1.0, etc)");

            return;
        }

        if (value < 0)
        {
            MessageBoxCommon.ErrorOk("The value cannot be negative");

            return;
        }

        HasValue = true;
        Value = value;

        Close();
    }
}
