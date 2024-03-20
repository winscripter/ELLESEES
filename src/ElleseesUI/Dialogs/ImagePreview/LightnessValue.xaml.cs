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
using System.Globalization;
using System.Windows;

namespace ElleseesUI.Dialogs.ImagePreview;

/// <summary>
/// Interaction logic for LightnessValue.xaml
/// </summary>
public partial class LightnessValue : Window
{
    /// <summary>
    /// Lightness Value returned by the dialog.
    /// </summary>
    public float? Value { get; private set; } = null;

    /// <summary>
    /// Initializes a new instance of <see cref="LightnessValue" />.
    /// </summary>
    public LightnessValue()
    {
        InitializeComponent();
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        Close();
    }

    private void Button_Click_1(object sender, RoutedEventArgs e)
    {
        if (!float.TryParse(Lightness.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out float value))
        {
            MessageBoxCommon.ErrorOk("Please enter a valid digit (e.g. 12.34, 12,34, 5, etc)");
        }

        if (value < 0.0F)
        {
            value = 0.0F;
        }

        if (value > 2.0F)
        {
            value = 2.0F;
        }

        if (value == 0.0F)
        {
            if (MessageBoxCommon.WarnYesNo("Are you really sure you want to set lightness for an image to 0.0 or less? The image will be completely dark.") == MessageBoxResult.No)
            {
                return;
            }
        }

        if (value >= 2.0F)
        {
            if (MessageBoxCommon.WarnYesNo("Are you really sure you want to set lightness for an image to 2.0 or more? The image will be completely light.") == MessageBoxResult.No)
            {
                return;
            }
        }

        Value = value;
        Close();
    }
}
