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
using System.Globalization;
using System.Windows;

namespace ElleseesUI.Dialogs.ImagePreview;

/// <summary>
/// Interaction logic for GlowByValue.xaml
/// </summary>
public partial class GlowByValue : Window
{
    /// <summary>
    /// Color of the glowing.
    /// </summary>
    public Rgba32? Color { get; private set; } = new(0.0F, 0.0F, 0.0F);

    /// <summary>
    /// Amount of glow visibility.
    /// </summary>
    public float? GlowAmount { get; private set; } = null;

    /// <summary>
    /// Initializes a new instance of <see cref="GlowByValue" />.
    /// </summary>
    public GlowByValue()
    {
        InitializeComponent();
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        Close();
    }

    private void SetColorBtn_Click(object sender, RoutedEventArgs e)
    {
        var color = ColorPickerCaller.Call();

        if (color != null)
        {
            CssColor.Text = $"rgba({color.Value.R}, {color.Value.G}, {color.Value.B}, {color.Value.A})";

            Color = color;
        }
    }

    private void SubmitButton_Click(object sender, RoutedEventArgs e)
    {
        var ok = float.TryParse(Amount.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out float amount);

        if (!ok)
        {
            MessageBoxCommon.ErrorOk("Invalid number in Amount field");

            return;
        }

        if (amount is < 0.0F or > 20000.0F)
        {
            MessageBoxCommon.ErrorOk("Amount field must have a number ranging from 0.0 to 20,000.0");

            return;
        }

        GlowAmount = amount;
        Close();
    }
}
