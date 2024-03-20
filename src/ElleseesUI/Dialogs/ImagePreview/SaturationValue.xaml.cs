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

using System.Globalization;
using System.Windows;

namespace ElleseesUI.Dialogs.ImagePreview;

/// <summary>
/// Interaction logic for SaturationValue.xaml
/// </summary>
public partial class SaturationValue : Window
{
    /// <summary>
    /// Amount of saturation applied to the image.
    /// </summary>
    public float? Value { get; private set; } = null;

    /// <summary>
    /// Initializes a new instance of <see cref="SaturationValue" />.
    /// </summary>
    public SaturationValue()
    {
        InitializeComponent();
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        Close();
    }

    private void Submit_Click(object sender, RoutedEventArgs e)
    {
        if (!float.TryParse(Saturation.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out float value))
        {
            Error("Please enter a valid digit (f.e. 12.34, 12,34, 5, etc)");

            return;
        }

        if (value < 0.0F)
        {
            Error("Cannot apply saturation with negative values");

            return;
        }

        if (value >= 5000.0F)
        {
            Error("Saturation with value this high cannot be applied (max. 4999)");

            return;
        }

        if (value is > 50.0F and < 5000.0F)
        {
            if (MessageBox.Show(
                "Woah! That's a high saturation value!\n\nIf you continue, the image may look mostly red and yellow, basically unexplainable.\n\nAre you sure you want to apply saturation with this value?",
                "ELLESEES",
                MessageBoxButton.YesNo,
                MessageBoxImage.Warning
            ) == MessageBoxResult.No)
            {
                return;
            }
        }

        Value = value;
        Close();

        static void Error(string message)
        {
            MessageBox.Show(
                message,
                "ELLESEES",
                MessageBoxButton.OK,
                MessageBoxImage.Error
            );
        }
    }
}
