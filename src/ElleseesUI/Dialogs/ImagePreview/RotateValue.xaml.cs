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
/// Interaction logic for RotateValue.xaml
/// </summary>
public partial class RotateValue : Window
{
    /// <summary>
    /// Amount of degrees for image rotation.
    /// </summary>
    public float? Value { get; private set; } = null;

    /// <summary>
    /// Initializes a new instance of <see cref="RotateValue" />.
    /// </summary>
    public RotateValue()
    {
        InitializeComponent();
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        Close();
    }

    private void Button_Click_1(object sender, RoutedEventArgs e)
    {
        var rs = float.TryParse(Deg.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out float r);

        if (!rs)
        {
            MessageBoxCommon.ErrorOk("Please enter a valid floating-point integer (e.g. 1.23, 1,23, 1, 2, 5, etc)");

            return;
        }

        while (r < 0F)
        {
            r += 360F;
        }

        Value = r;
        Close();
    }
}
