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

using ElleseesUI.Core;
using SixLabors.ImageSharp.PixelFormats;
using System.Windows;

namespace ElleseesUI.Dialogs.ImagePreview;

/// <summary>
/// Interaction logic for TextShadowOptions.xaml
/// </summary>
public partial class TextShadowOptions : Window
{
    /// <summary>
    /// Color of the text shadow.
    /// </summary>
    public Rgba32? Color { get; private set; } = null;

    /// <summary>
    /// Shadow color of the text.
    /// </summary>
    public int? Sigma { get; private set; } = null;

    private Rgba32 color = new(0F, 0F, 0F, 1F);

    /// <summary>
    /// Actual alpha channel of the text shadow color.
    /// </summary>
    public float? ActualAlpha { get; private set; } = null;

    /// <summary>
    /// Initializes a new instance of <see cref="TextShadowOptions" />.
    /// </summary>
    public TextShadowOptions()
    {
        InitializeComponent();
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        Close();
    }

    private void ChangeShadowColorButton_Click(object sender, RoutedEventArgs e)
    {
        (float? alpha, Rgba32? color) = ColorPickerCaller.CallWithAlpha();
        
        if (color != null)
        {
            ActualAlpha = alpha;

            this.color = color is null
                         ? new Rgba32(0F, 0F, 0F, 1F)
                         : new Rgba32(Convert.ToSingle(color.Value.R),
                                      Convert.ToSingle(color.Value.G),
                                      Convert.ToSingle(color.Value.B),
                                      alpha ?? 1F);

            CssShadowColor.Text = $"rgba({color!.Value.R}, {color.Value.G}, {color.Value.B}, {alpha})";
        }
    }

    private void Button_Click_1(object sender, RoutedEventArgs e)
    {
        if (!int.TryParse(SigmaCount.Text, out int sigma))
        {
            MessageBoxCommon.ErrorOk("The Sigma field is invalid: Value must be valid integer (e.g. 1, 2, 5, etc)");

            return;
        }

        if (sigma <= 0)
        {
            MessageBoxCommon.ErrorOk("Sigma can't be 0 or negative");

            return;
        }

        Color = color;
        Sigma = sigma;

        ActualAlpha ??= 1F;

        Close();
    }
}
