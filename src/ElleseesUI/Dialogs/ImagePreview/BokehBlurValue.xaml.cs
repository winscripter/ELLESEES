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
/// Interaction logic for BokehBlurValue.xaml
/// </summary>
public partial class BokehBlurValue : Window, ICanInitializeThemes
{
    /// <summary>
    /// Checks whether data was successfully submitted.
    /// </summary>
    public bool DataReturned { get; private set; } = false;

    /// <summary>
    /// Radius field of Bokeh Blur.
    /// </summary>
    public int? Radius { get; private set; } = null;

    /// <summary>
    /// Components field of Bokeh Blur.
    /// </summary>
    public int? Components { get; private set; } = null;

    /// <summary>
    /// Gamma field of Bokeh Blur.
    /// </summary>
    public float? Gamma { get; private set; } = null;

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
    public BokehBlurValue()
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
        if (Empty(RadiusText.Text) && Empty(ComponentsText.Text) && Empty(GammaText.Text))
        {
            DataReturned = true;

            Close();
            return;
        }

        if (Empty(RadiusText.Text))
        {
            MessageBoxCommon.ErrorOk("The Radius field is invalid: Value is empty.\n\nHint: To use default Bokeh Blur values, all fields must be empty");

            return;
        }

        if (Empty(ComponentsText.Text))
        {
            MessageBoxCommon.ErrorOk("The Components field is invalid: Value is empty.\n\nHint: To use default Bokeh Blur values, all fields must be empty");

            return;
        }

        if (Empty(GammaText.Text))
        {
            MessageBoxCommon.ErrorOk("The Gamma field is invalid: Value is empty.\n\nHint: To use default Bokeh Blur values, all fields must be empty");

            return;
        }

        var r = int.TryParse(RadiusText.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out int radius);
        var c = int.TryParse(ComponentsText.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out int components);
        var g = float.TryParse(GammaText.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out float gamma);

        if (!r)
        {
            MessageBoxCommon.ErrorOk("The Radius field is invalid: Value must be an integer (e.g. 1, 5, but not 1.23, 1.0, etc)");

            return;
        }

        if (!c)
        {
            MessageBoxCommon.ErrorOk("The Components field is invalid: Value must be an integer (e.g. 1, 5, but not 1.23, 1.0, etc)");

            return;
        }

        if (!g)
        {
            MessageBoxCommon.ErrorOk("The Gamma field is invalid: Value must be a floating-point integer (e.g. 1, 5, 1.23, 1.0, etc)");

            return;
        }

        if (radius < 0)
        {
            MessageBoxCommon.ErrorOk("The Radius field is invalid: Value must not be negative");

            return;
        }

        if (components < 0)
        {
            MessageBoxCommon.ErrorOk("The Components field is invalid: Value must not be negative");

            return;
        }

        if (gamma < 0.0F)
        {
            MessageBoxCommon.ErrorOk("The Gamma field is invalid: Value must not be negative");

            return;
        }

        if (components is < 1 or > 6)
        {
            MessageBoxCommon.ErrorOk($"The Components field is invalid: Value must range between 1 and 6, got {components}");

            return;
        }

        Radius = radius;
        Components = components;
        Gamma = gamma;
        DataReturned = true;

        Close();

        static bool Empty(string text) => string.IsNullOrWhiteSpace(text) || string.IsNullOrEmpty(text);
    }
}
