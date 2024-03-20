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
/// Interaction logic for GrayscaleCustom.xaml
/// </summary>
public partial class GrayscaleCustom : Window
{
    /// <summary>
    /// Grayscaling value returned by the dialog.
    /// </summary>
    public float? Value { get; private set; } = null;

    /// <summary>
    /// Initializes a new instance of <see cref="GrayscaleCustom" />.
    /// </summary>
    public GrayscaleCustom()
    {
        InitializeComponent();
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        Close();
    }

    private void SubmitButton_Click(object sender, RoutedEventArgs e)
    {
        var value = Grayscale.Text;

        try
        {
            Value = float.Parse(value, CultureInfo.InvariantCulture);

            if (Value is >= 1.0F or <= 0.0F)
            {
                MessageBox.Show(
                    "Please enter a digit ranging from 0.01 to 0.99",
                    "ELLESEES",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error
                );

                return;
            }

            Close();
        }
        catch
        {
            MessageBox.Show(
                "Please enter a valid digit (examples: 12.34, 12,34, 5)",
                "ELLESEES",
                MessageBoxButton.OK,
                MessageBoxImage.Error
            );
        }
    }
}
