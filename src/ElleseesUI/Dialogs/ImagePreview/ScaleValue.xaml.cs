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
using System.Windows;

namespace ElleseesUI.Dialogs.ImagePreview;

/// <summary>
/// Interaction logic for ScaleValue.xaml
/// </summary>
public partial class ScaleValue : Window
{
    /// <summary>
    /// Scaling by X.
    /// </summary>
    public int? ValueX { get; private set; } = null;

    /// <summary>
    /// Scaling by Y.
    /// </summary>
    public int? ValueY { get; private set; } = null;

    /// <summary>
    /// Initializes a new instance of <see cref="ScaleValue" />.
    /// </summary>
    public ScaleValue()
    {
        InitializeComponent();
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        Close();
    }

    private void Button_Click_2(object sender, RoutedEventArgs e)
    {
        var isWidthParseSuccess = int.TryParse(WidthText.Text, out int width);
        var isHeightParseSuccess = int.TryParse(HeightText.Text, out int height);

        if (!isWidthParseSuccess)
        {
            MessageBoxCommon.ErrorOk("The Width field is invalid: Please enter a valid integer (f.e. 1, 2, 5, etc)");

            return;
        }

        if (!isHeightParseSuccess)
        {
            MessageBoxCommon.ErrorOk("The Height field is invalid: Please enter a valid integer (f.e. 1, 2, 5, etc)");

            return;
        }

        if (width is < -32767 or > 32767)
        {
            MessageBoxCommon.ErrorOk("The Width field is invalid: Integer must range between -32767 and 32767");

            return;
        }

        if (height is < -32767 or > 32767)
        {
            MessageBoxCommon.ErrorOk("The Width field is invalid: Integer must range between -32767 and 32767");

            return;
        }

        ValueX = width;
        ValueY = height;

        Close();
    }
}
