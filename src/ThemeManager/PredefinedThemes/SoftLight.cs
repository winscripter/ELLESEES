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
/// The predefined Light theme for ELLESEES.
/// </summary>
public class SoftLight : ITheme
{
    /// <inheritdoc />
    public string DisplayName => $"Soft Light";
    /// <inheritdoc />
    public uint ID => 1;

    /// <inheritdoc />
    public SolidColorBrush EditorFileManagerBackground
        => (SolidColorBrush)new BrushConverter().ConvertFrom("#171717")!;

    /// <inheritdoc />
    public SolidColorBrush EditorTabInactiveBackground
        => (SolidColorBrush)new BrushConverter().ConvertFrom("#F5F5F5")!;

    /// <inheritdoc />
    public SolidColorBrush EditorTabActiveBackground
        => Brushes.LightBlue;

    /// <inheritdoc />
    public SolidColorBrush PropertyEditorBackground
        => (SolidColorBrush)new BrushConverter().ConvertFrom("#F5F5F5")!;

    /// <inheritdoc />
    public SolidColorBrush PropertyEditorForeground
        => Brushes.Black;

    /// <inheritdoc />
    public SolidColorBrush MenuBackground
        => (SolidColorBrush)new BrushConverter().ConvertFrom("#F5F5F5")!;

    /// <inheritdoc />
    public SolidColorBrush MenuForeground
        => Brushes.Black;

    /// <inheritdoc />
    public SolidColorBrush MenuBorderColor
        => Brushes.Black;

    /// <inheritdoc />
    public int MenuBorderThickness
        => 0;

    /// <inheritdoc />
    public SolidColorBrush MenuItemBackground
        => (SolidColorBrush)new BrushConverter().ConvertFrom("#F5F5F5")!;

    /// <inheritdoc />
    public SolidColorBrush MenuItemForeground
        => Brushes.Black;

    /// <inheritdoc />
    public SolidColorBrush TitleBarBackground
        => (SolidColorBrush)new BrushConverter().ConvertFrom("#F5F5F5")!;

    /// <inheritdoc />
    public SolidColorBrush TitleBarForeground
        => Brushes.Black;

    /// <inheritdoc />
    public SolidColorBrush CloseButtonBackground
        => Brushes.Transparent;

    /// <inheritdoc />
    public SolidColorBrush CloseButtonForeground
        => Brushes.Black;

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
        => (SolidColorBrush)new BrushConverter().ConvertFrom("#F5F5F5")!;

    /// <inheritdoc />
    public SolidColorBrush CommonPickerBackground
        => (SolidColorBrush)new BrushConverter().ConvertFrom("#F5F5F5")!;

    /// <inheritdoc />
    public SolidColorBrush CommonPickerForeground
        => Brushes.Black;

    /// <inheritdoc />
    public SolidColorBrush CommonPickerTitleBarBackground
        => (SolidColorBrush)new BrushConverter().ConvertFrom("#e3e3e3")!;

    /// <inheritdoc />
    public SolidColorBrush CommonPickerTitleBarForeground
        => Brushes.White;

    /// <inheritdoc />
    public SolidColorBrush ManagementPanelBackground
        => (SolidColorBrush)new BrushConverter().ConvertFrom("#F5F5F5")!;

    /// <inheritdoc />
    public SolidColorBrush ManagementPanelForeground
        => Brushes.LightGray;

    /// <inheritdoc />
    public SolidColorBrush ManagementPanelHoverForeground
        => Brushes.Black;

    /// <inheritdoc />
    public SolidColorBrush EditorBackground
        => (SolidColorBrush)new BrushConverter().ConvertFrom("#F5F5F5")!;
}
