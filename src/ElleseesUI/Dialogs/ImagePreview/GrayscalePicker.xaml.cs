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

using System.Windows;

namespace ElleseesUI.Dialogs.ImagePreview;

/// <summary>
/// Interaction logic for GrayscalePicker.xaml
/// </summary>
public partial class GrayscalePicker : Window
{
    /// <summary>
    /// Checks whether BT.709 grayscale toning should be applied.
    /// </summary>
    public bool ApplyBt709 { get; private set; } = false;

    /// <summary>
    /// Checks whether BT.601 grayscale toning should be applied.
    /// </summary>
    public bool ApplyBt601 { get; private set; } = false;

    /// <summary>
    /// Checks whether grayscaling should be applied by the user (e.g. the
    /// user enters the amount of grayscaling to apply).
    /// </summary>
    public bool ApplyCustom { get; private set; } = false;

    /// <summary>
    /// Value of grayscaling (which is <see langword="null" /> if the user didn't choose <see cref="ApplyCustom" /> grayscaling).
    /// </summary>
    public float? Value { get; private set; } = null;

    /// <summary>
    /// Initializes a new instance of <see cref="GrayscalePicker" />.
    /// </summary>
    public GrayscalePicker()
    {
        InitializeComponent();
    }

    // Exit
    private void Button_Click(object sender, RoutedEventArgs e)
    {
        Close();
    }

    private void Bt709Kind_Click(object sender, RoutedEventArgs e)
    {
        ApplyBt709 = true;
        Close();
    }

    private void Bt601Kind_Click(object sender, RoutedEventArgs e)
    {
        ApplyBt601 = true;
        Close();
    }

    private void Custom_Click(object sender, RoutedEventArgs e)
    {
        var window = new GrayscaleCustom();
        window.ShowDialog();

        if (window.Value is not null)
        {
            ApplyCustom = true;
            Value = window.Value ?? 0.0F;

            Close();
        }
    }

    private void Quit_Click(object sender, RoutedEventArgs e)
    {
        Close();
    }
}
