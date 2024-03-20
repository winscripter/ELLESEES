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

using System.Windows.Media;

namespace ElleseesUI.ThemeManager.PredefinedThemes;

/// <summary>
/// The default Extra Dark theme for ELLESEES.
/// </summary>
public class Default : ITheme
{
    /// <inheritdoc />
    public string DisplayName => $"Extra Dark (Default)";
    /// <inheritdoc />
    public uint ID => 0; // reserved for Default theme

    /// <inheritdoc />
    public SolidColorBrush EditorFileManagerBackground
        => (SolidColorBrush)new BrushConverter().ConvertFrom("#171717")!;

    /// <inheritdoc />
    public SolidColorBrush EditorTabInactiveBackground
        => Brushes.Transparent;

    /// <inheritdoc />
    public SolidColorBrush EditorTabActiveBackground
        => (SolidColorBrush)new BrushConverter().ConvertFrom("#747474")!;

    /// <inheritdoc />
    public SolidColorBrush PropertyEditorBackground
        => (SolidColorBrush)new BrushConverter().ConvertFrom("#171717")!;

    /// <inheritdoc />
    public SolidColorBrush PropertyEditorForeground
        => Brushes.White;

    /// <inheritdoc />
    public SolidColorBrush MenuBackground
        => (SolidColorBrush)new BrushConverter().ConvertFrom("#171717")!;

    /// <inheritdoc />
    public SolidColorBrush MenuForeground
        => Brushes.White;

    /// <inheritdoc />
    public SolidColorBrush MenuBorderColor
        => (SolidColorBrush)new BrushConverter().ConvertFrom("#454545")!;

    /// <inheritdoc />
    public int MenuBorderThickness
        => 2;

    /// <inheritdoc />
    public SolidColorBrush MenuItemBackground
        => (SolidColorBrush)new BrushConverter().ConvertFrom("#454545")!;

    /// <inheritdoc />
    public SolidColorBrush MenuItemForeground
        => Brushes.White;

    /// <inheritdoc />
    public SolidColorBrush TitleBarBackground
        => (SolidColorBrush)new BrushConverter().ConvertFrom("#171717")!;

    /// <inheritdoc />
    public SolidColorBrush TitleBarForeground
        => Brushes.White;

    /// <inheritdoc />
    public SolidColorBrush CloseButtonBackground
        => Brushes.Transparent;

    /// <inheritdoc />
    public SolidColorBrush CloseButtonForeground
        => Brushes.White;

    /// <inheritdoc />
    public SolidColorBrush EditorObjectsBackground
        => (SolidColorBrush)new BrushConverter().ConvertFrom("#171717")!;

    /// <inheritdoc />
    public SolidColorBrush EditorOutputBackground
        => (SolidColorBrush)new BrushConverter().ConvertFrom("#171717")!;

    /// <inheritdoc />
    public SolidColorBrush EditorEditElsewhereBackground
        => (SolidColorBrush)new BrushConverter().ConvertFrom("#171717")!;

    /// <inheritdoc />
    public SolidColorBrush EditorAboutBackground
        => (SolidColorBrush)new BrushConverter().ConvertFrom("#171717")!;

    /// <inheritdoc />
    public SolidColorBrush TimelineSecondBackground
        => (SolidColorBrush)new BrushConverter().ConvertFrom("#242424")!;

    /// <inheritdoc />
    public SolidColorBrush TimelineSecondForeground
        => Brushes.White;

    /// <inheritdoc />
    public SolidColorBrush TimelineLeftButtonBackground
        => (SolidColorBrush)new BrushConverter().ConvertFrom("#171717")!;

    /// <inheritdoc />
    public SolidColorBrush TimelineLeftButtonForeground
        => Brushes.White;

    /// <inheritdoc />
    public SolidColorBrush TimelineBackground
        => (SolidColorBrush)new BrushConverter().ConvertFrom("#171717")!;

    /// <inheritdoc />
    public SolidColorBrush UpLeftBackground
        => (SolidColorBrush)new BrushConverter().ConvertFrom("#171717")!;

    /// <inheritdoc />
    public SolidColorBrush CommonPickerBackground
        => (SolidColorBrush)new BrushConverter().ConvertFrom("#313131")!;

    /// <inheritdoc />
    public SolidColorBrush CommonPickerForeground
        => Brushes.White;

    /// <inheritdoc />
    public SolidColorBrush CommonPickerTitleBarBackground
        => (SolidColorBrush)new BrushConverter().ConvertFrom("#171717")!;

    /// <inheritdoc />
    public SolidColorBrush CommonPickerTitleBarForeground
        => Brushes.White;

    /// <inheritdoc />
    public SolidColorBrush ManagementPanelBackground
        => (SolidColorBrush)new BrushConverter().ConvertFrom("#171717")!;

    /// <inheritdoc />
    public SolidColorBrush ManagementPanelForeground
        => Brushes.LightGray;

    /// <inheritdoc />
    public SolidColorBrush ManagementPanelHoverForeground
        => Brushes.White;

    /// <inheritdoc />
    public SolidColorBrush EditorBackground
        => (SolidColorBrush)new BrushConverter().ConvertFrom("#363636")!;
}
