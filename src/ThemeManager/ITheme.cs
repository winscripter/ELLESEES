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

namespace ElleseesUI.ThemeManager;

/// <summary>
/// A common theme that affects only the editor.
/// </summary>
public interface ITheme
{
    /// <summary>
    /// Name of this theme.
    /// </summary>
    string DisplayName { get; }

    /// <summary>
    /// Gets the identifier for this theme.
    /// </summary>
    uint ID { get; }

    /// <summary>
    /// Part of UI.
    /// </summary>
    SolidColorBrush EditorFileManagerBackground { get; }

    /// <summary>
    /// Part of UI.
    /// </summary>
    SolidColorBrush EditorTabInactiveBackground { get; }

    /// <summary>
    /// Part of UI.
    /// </summary>
    SolidColorBrush EditorTabActiveBackground { get; }

    /// <summary>
    /// Part of UI.
    /// </summary>
    SolidColorBrush PropertyEditorBackground { get; }

    /// <summary>
    /// Part of UI.
    /// </summary>
    SolidColorBrush PropertyEditorForeground { get; }

    /// <summary>
    /// Part of UI.
    /// </summary>
    SolidColorBrush MenuBackground { get; }

    /// <summary>
    /// Part of UI.
    /// </summary>
    SolidColorBrush MenuForeground { get; }

    /// <summary>
    /// Part of UI.
    /// </summary>
    SolidColorBrush MenuBorderColor { get; }

    /// <summary>
    /// Part of UI.
    /// </summary>
    int MenuBorderThickness { get; }

    /// <summary>
    /// Part of UI.
    /// </summary>
    SolidColorBrush MenuItemBackground { get; }

    /// <summary>
    /// Part of UI.
    /// </summary>
    SolidColorBrush MenuItemForeground { get; }

    /// <summary>
    /// Part of UI.
    /// </summary>
    SolidColorBrush TitleBarBackground { get; }

    /// <summary>
    /// Part of UI.
    /// </summary>
    SolidColorBrush TitleBarForeground { get; }

    /// <summary>
    /// Part of UI.
    /// </summary>
    SolidColorBrush CloseButtonBackground { get; }

    /// <summary>
    /// Part of UI.
    /// </summary>
    SolidColorBrush CloseButtonForeground { get; }

    /// <summary>
    /// Part of UI.
    /// </summary>
    SolidColorBrush EditorObjectsBackground { get; }

    /// <summary>
    /// Part of UI.
    /// </summary>
    SolidColorBrush EditorOutputBackground { get; }

    /// <summary>
    /// Part of UI.
    /// </summary>
    SolidColorBrush EditorEditElsewhereBackground { get; }

    /// <summary>
    /// Part of UI.
    /// </summary>
    SolidColorBrush EditorAboutBackground { get; }

    /// <summary>
    /// Part of UI.
    /// </summary>
    SolidColorBrush TimelineSecondBackground { get; }

    /// <summary>
    /// Part of UI.
    /// </summary>
    SolidColorBrush TimelineSecondForeground { get; }

    /// <summary>
    /// Part of UI.
    /// </summary>
    SolidColorBrush TimelineLeftButtonBackground { get; }

    /// <summary>
    /// Part of UI.
    /// </summary>
    SolidColorBrush TimelineLeftButtonForeground { get; }

    /// <summary>
    /// Part of UI.
    /// </summary>
    SolidColorBrush TimelineBackground { get; }

    /// <summary>
    /// Part of UI.
    /// </summary>
    SolidColorBrush UpLeftBackground { get; }

    /// <summary>
    /// Part of UI.
    /// </summary>
    SolidColorBrush CommonPickerBackground { get; }

    /// <summary>
    /// Part of UI.
    /// </summary>
    SolidColorBrush CommonPickerForeground { get; }

    /// <summary>
    /// Part of UI.
    /// </summary>
    SolidColorBrush CommonPickerTitleBarBackground { get; }

    /// <summary>
    /// Part of UI.
    /// </summary>
    SolidColorBrush CommonPickerTitleBarForeground { get; }

    /// <summary>
    /// Part of UI.
    /// </summary>
    SolidColorBrush ManagementPanelBackground { get; }

    /// <summary>
    /// Part of UI.
    /// </summary>
    SolidColorBrush ManagementPanelForeground { get; }

    /// <summary>
    /// Part of UI.
    /// </summary>
    SolidColorBrush ManagementPanelHoverForeground { get; }

    /// <summary>
    /// Part of UI.
    /// </summary>
    SolidColorBrush EditorBackground { get; }
}
