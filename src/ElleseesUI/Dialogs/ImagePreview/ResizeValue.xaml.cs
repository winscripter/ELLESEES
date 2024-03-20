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
/// Interaction logic for ResizeValue.xaml
/// </summary>
public partial class ResizeValue : Window
{
    /// <summary>
    /// New Width/Height of the image.
    /// </summary>
    public (int x, int y)? Value { get; private set; } = null;

    /// <summary>
    /// Initializes a new instance of <see cref="ResizeValue" />.
    /// </summary>
    public ResizeValue()
    {
        InitializeComponent();
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        Close();
    }

    private void Button_Click_1(object sender, RoutedEventArgs e)
    {
        var xs = int.TryParse(ImageWidth.Text, out int x);
        var ys = int.TryParse(ImageHeight.Text, out int y);

        if (!xs)
        {
            MessageBoxCommon.ErrorOk("The Width field is invalid: Value must be a valid digit (e.g. 1, 2, 5, etc)");

            return;
        }

        if (!ys)
        {
            MessageBoxCommon.ErrorOk("The Height field is invalid: Value must be a valid digit (e.g. 1, 2, 5, etc)");

            return;
        }

        if (x < 0)
        {
            MessageBoxCommon.ErrorOk("The Width field is invalid: Value must not be negative");

            return;
        }

        if (y < 0)
        {
            MessageBoxCommon.ErrorOk("The Height field is invalid: Value must not be negative");

            return;
        }

        if (x > 8192 && y > 8192)
        {
            MessageBoxCommon.ErrorOk("Wow! With the size of the new image being this big, it's not an image anymore, it's quite literally a monstrosity!\n\nUnfortunately, you cannot resize images to values larger than 8192x8192 pixels, because this increases a risk of a system crash or data loss because of insufficient memory.");

            return;
        }

        Value = (x, y);
        Close();
    }
}
