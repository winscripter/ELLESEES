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

using Ellesees.Base.Context;
using ElleseesUI.Core;
using ElleseesUI.Dialogs.ImagePreview;
using ElleseesUI.Extensions;
using ElleseesUI.ReadOnly;
using SixLabors.Fonts;
using System.Windows;

namespace ElleseesUI.ToolClickUIs;

/// <summary>
/// Interaction logic for TextToolClickUI.xaml
/// </summary>
public partial class TextToolClickUI : Window
{
    /// <summary>
    /// Returned text context.
    /// </summary>
    public TextContext Context { get; set; }

    /// <summary>
    /// Start time.
    /// </summary>
    public TimeSpan? Start { get; set; }

    /// <summary>
    /// End time.
    /// </summary>
    public TimeSpan? End { get; set; }

    /// <summary>
    /// Is data successfully returned?
    /// </summary>
    public bool DataReturned = false;

    /// <summary>
    /// Initializes a new instance of <see cref="TextToolClickUI" />.
    /// </summary>
    public TextToolClickUI()
    {
        InitializeComponent();

        Context = TextConstants.DefaultContext;
    }

    /// <summary>
    /// Click event for a button that closes this window.
    /// </summary>
    private void Button_Click(object sender, RoutedEventArgs e)
    {
        Close();
    }

    private void Button_Click_1(object sender, RoutedEventArgs e)
    {
        var dialog = new TextValue();
        dialog.ShowDialog();

        if (dialog.DataReturned)
        {
            Context = new TextContext(
                dialog.Text,
                dialog.FontPath,
                dialog.TextSize,
                GetFontByPath(dialog.FontPath, dialog.TextSize),
                SixLabors.Fonts.FontStyle.Regular,
                dialog.TextForeground,
                new(dialog.X, dialog.Y),
                dialog.AllowTextShadow ? dialog.TextShadow : null
            );
        }

        static Font GetFontByPath(string path, int size)
        {
            FontCollection collection = new();
            FontFamily style = collection.Add(path);
            return style.CreateFont(size);
        }
    }

    private void Button_Click_2(object sender, RoutedEventArgs e)
    {
        var startDuration = StartDuration.Text;
        var endDuration = EndDuration.Text;

        TimeSpan tsStart;
        TimeSpan tsEnd;

        try
        {
            tsStart = startDuration.ToTimeSpan();
        }
        catch
        {
            MessageBoxCommon.ErrorOk($"The Start duration is incorrectly formatted.{Environment.NewLine}{Environment.NewLine}See the tour to learn how time strings are formatted in ELLESEES.");

            return;
        }

        try
        {
            tsEnd = endDuration.ToTimeSpan();
        }
        catch
        {
            MessageBoxCommon.ErrorOk($"The End duration is incorrectly formatted.{Environment.NewLine}{Environment.NewLine}See the tour to learn how time strings are formatted in ELLESEES.");

            return;
        }

        Start = tsStart;
        End = tsEnd;

        DataReturned = true;
        Close();
    }
}
