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
using System.Windows.Input;

namespace ElleseesUI.MagicWand;

/// <summary>
/// Interaction logic for MagicWandTimestampSelector.xaml
/// </summary>
public partial class MagicWandTimestampSelector : Window
{
    /// <summary>
    /// The start timestamp where the magic wand starts its effects.
    /// </summary>
    public TimeSpan? Start { get; private set; } = null;

    /// <summary>
    /// The end timestamp where the magic wand stops its effects.
    /// </summary>
    public TimeSpan? End { get; private set; } = null;

    /// <summary>
    /// Checks whether data was successfully submitted by the user or not.
    /// </summary>
    public bool DataReturned { get; private set; } = false;

    /// <summary>
    /// Initializes a new instance of <see cref="MagicWandTimestampSelector" />.
    /// </summary>
    public MagicWandTimestampSelector()
    {
        InitializeComponent();
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        Close();
    }

    private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
    {
        if (e.LeftButton == MouseButtonState.Pressed)
        {
            DragMove();
        }
    }

    private void Button_Click_1(object sender, RoutedEventArgs e)
    {
        TimeSpan start;
        TimeSpan end;

        try
        {
            start = StartTimestamp.Text.ToTimeSpan();
        }
        catch
        {
            MessageBoxCommon.ErrorOk($"The Start field is invalid: Incorrect time stamp string.\n\nSee the Tour to acknowledge how time stamps are formatted in ELLESEES.");

            return;
        }

        try
        {
            end = EndTimestamp.Text.ToTimeSpan();
        }
        catch
        {
            MessageBoxCommon.ErrorOk($"The End field is invalid: Incorrect time stamp string.\n\nSee the Tour to acknowledge how time stamps are formatted in ELLESEES.");

            return;
        }

        Start = start;
        End = end;
        DataReturned = true;

        Close();
    }
}
