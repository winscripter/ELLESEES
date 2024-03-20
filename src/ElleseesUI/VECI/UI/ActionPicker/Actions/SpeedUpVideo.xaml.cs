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
using ElleseesUI.Extensions;
using System.Windows;

namespace ElleseesUI.VECI.UI.ActionPicker.Actions;

/// <summary>
/// Interaction logic for SpeedUpVideo.xaml
/// </summary>
public partial class SpeedUpVideo : Window
{
    /// <summary>
    /// Speed returned by this dialog.
    /// </summary>
    public int? ReturnedSpeed { get; private set; } = null;

    /// <summary>
    /// Initializes a new instance of <see cref="SpeedUpVideo" />.
    /// </summary>
    public SpeedUpVideo()
    {
        InitializeComponent();
    }

    /// <summary>
    /// Event handler for the Close button.
    /// </summary>
    protected void OnCloseButtonClick(object sender, RoutedEventArgs e)
    {
        Close();
    }

    /// <summary>
    /// Event handler for the OK button.
    /// </summary>
    protected void OnOKButtonClick(object sender, RoutedEventArgs e)
    {
        var parseSuccess = StringExtensions.TryFromPercentage(SpeedTextBox.Text, out int speed);

        if (!parseSuccess)
        {
            MessageBoxCommon.ErrorOk("The Speed Percentage field contains an invalid value: Expecting valid integer (f.e. 1, 2, 5, etc).");

            return;
        }

        this.ReturnedSpeed = speed;
    }
}
