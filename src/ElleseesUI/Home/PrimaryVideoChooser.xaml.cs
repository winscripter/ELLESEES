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
using Microsoft.Win32;
using System.Windows;

namespace ElleseesUI.Home;

/// <summary>
/// Interaction logic for PrimaryVideoChooser.xaml
/// </summary>
public partial class PrimaryVideoChooser : Window
{
    /// <summary>
    /// Path to the primary video selected.
    /// </summary>
    public string? PathToPrimaryVideo { get; set; } = null;

    /// <summary>
    /// Initializes a new instance of <see cref="PrimaryVideoChooser" />.
    /// </summary>
    public PrimaryVideoChooser()
    {
        InitializeComponent();
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        Close();
    }

    private void Button_Click_1(object sender, RoutedEventArgs e)
    {
        var dialog = new OpenFileDialog()
        {
            Title = "Please select video file",
            Filter = "MP4|*.mp4|MKV|*.mkv|AVI|*.avi|WMV|*.wmv",
            Multiselect = false
        };

        if (dialog.ShowDialog() == true)
        {
            PathToPrimaryVideo = dialog.FileName;
        }

        Close();
    }

    private void Button_Click_2(object sender, RoutedEventArgs e)
    {
        if (!File.Exists(Path.Text))
        {
            MessageBoxCommon.ErrorOk($"The specified file does not exist.");

            return;
        }

        PathToPrimaryVideo = Path.Text;

        Close();
    }
}
