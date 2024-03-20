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

using ElleseesUI.Exceptions;
using System.Text.Json.Serialization;

namespace ElleseesUI.ThemeManager;

/// <summary>
/// Theme from JSON.
/// </summary>
[Serializable]
internal class ThemeTemplate
{
    /// <summary>
    /// Name of this theme displayed in ELLESEES.
    /// </summary>
    [JsonPropertyName("name")]
    public string? DisplayName { get; set; } = null;

    /// <summary>
    /// ID of this theme; can range between 0 and <see cref="uint.MaxValue" />.
    /// </summary>
    [JsonPropertyName("id")]
    public uint? ID { get; set; } = null;

    /// <summary>
    /// Part of UI. Value, which is the color, is interpreted as HEX.
    /// </summary>
    [JsonPropertyName("editor.fileManager.background")]
    public string? EditorFileManagerBackground { get; set; } = null;

    /// <summary>
    /// Part of UI. Value, which is the color, is interpreted as HEX.
    /// </summary>
    [JsonPropertyName("editor.tabs.inactiveBackground")]
    public string? EditorTabInactiveBackground { get; set; } = null;

    /// <summary>
    /// Part of UI. Value, which is the color, is interpreted as HEX.
    /// </summary>
    [JsonPropertyName("editor.tabs.activeBackground")]
    public string? EditorTabActiveBackground { get; set; } = null;

    /// <summary>
    /// Part of UI. Value, which is the color, is interpreted as HEX.
    /// </summary>
    [JsonPropertyName("propertyEditor.background")]
    public string? PropertyEditorBackground { get; set; } = null;

    /// <summary>
    /// Part of UI. Value, which is the color, is interpreted as HEX.
    /// </summary>
    [JsonPropertyName("propertyEditor.foreground")]
    public string? PropertyEditorForeground { get; set; } = null;

    /// <summary>
    /// Part of UI. Value, which is the color, is interpreted as HEX.
    /// </summary>
    [JsonPropertyName("menu.background")]
    public string? MenuBackground { get; set; } = null;

    /// <summary>
    /// Part of UI. Value, which is the color, is interpreted as HEX.
    /// </summary>
    [JsonPropertyName("menu.foreground")]
    public string? MenuForeground { get; set; } = null;

    /// <summary>
    /// Part of UI. Value, which is the color, is interpreted as HEX.
    /// </summary>
    [JsonPropertyName("menu.border.color")]
    public string? MenuBorderColor { get; set; } = null;

    /// <summary>
    /// Part of UI. Value, which is the size.
    /// </summary>
    [JsonPropertyName("menu.border.thickness")]
    public int? MenuBorderThickness { get; set; } = null;

    /// <summary>
    /// Part of UI. Value, which is the color, is interpreted as HEX.
    /// </summary>
    [JsonPropertyName("menu.item.background")]
    public string? MenuItemBackground { get; set; } = null;

    /// <summary>
    /// Part of UI. Value, which is the color, is interpreted as HEX.
    /// </summary>
    [JsonPropertyName("menu.item.background")]
    public string? MenuItemForeground { get; set; } = null;

    /// <summary>
    /// Part of UI. Value, which is the color, is interpreted as HEX.
    /// </summary>
    [JsonPropertyName("titleBar.background")]
    public string? TitleBarBackground { get; set; } = null;

    /// <summary>
    /// Part of UI. Value, which is the color, is interpreted as HEX.
    /// </summary>
    [JsonPropertyName("titleBar.foreground")]
    public string? TitleBarForeground { get; set; } = null;

    /// <summary>
    /// Part of UI. Value, which is the color, is interpreted as HEX.
    /// </summary>
    [JsonPropertyName("closeBtn.background")]
    public string? CloseButtonBackground { get; set; } = null;

    /// <summary>
    /// Part of UI. Value, which is the color, is interpreted as HEX.
    /// </summary>
    [JsonPropertyName("closeBtn.foreground")]
    public string? CloseButtonForeground { get; set; } = null;

    /// <summary>
    /// Part of UI. Value, which is the color, is interpreted as HEX.
    /// </summary>
    [JsonPropertyName("editor.objects.background")]
    public string? EditorObjectsBackground { get; set; } = null;

    /// <summary>
    /// Part of UI. Value, which is the color, is interpreted as HEX.
    /// </summary>
    [JsonPropertyName("editor.output.background")]
    public string? EditorOutputBackground { get; set; }

    /// <summary>
    /// Part of UI. Value, which is the color, is interpreted as HEX.
    /// </summary>
    [JsonPropertyName("editor.editElsewhere.background")]
    public string? EditorEditElsewhereBackground { get; set; } = null;

    /// <summary>
    /// Part of UI. Value, which is the color, is interpreted as HEX.
    /// </summary>
    [JsonPropertyName("editor.about.background")]
    public string? EditorAboutBackground { get; set; } = null;

    /// <summary>
    /// Part of UI. Value, which is the color, is interpreted as HEX.
    /// </summary>
    [JsonPropertyName("timelineSecond.background")]
    public string? TimelineSecondBackground { get; set; } = null;

    /// <summary>
    /// Part of UI. Value, which is the color, is interpreted as HEX.
    /// </summary>
    [JsonPropertyName("timelineSecond.foreground")]
    public string? TimelineSecondForeground { get; set; } = null;

    /// <summary>
    /// Part of UI. Value, which is the color, is interpreted as HEX.
    /// </summary>
    [JsonPropertyName("timeline.shiftLeftBtn.background")]
    public string? TimelineLeftButtonBackground { get; set; } = null;

    /// <summary>
    /// Part of UI. Value, which is the color, is interpreted as HEX.
    /// </summary>
    [JsonPropertyName("timeline.shiftLeftBtn.foreground")]
    public string? TimelineLeftButtonForeground { get; set; } = null;

    /// <summary>
    /// Part of UI. Value, which is the color, is interpreted as HEX.
    /// </summary>
    [JsonPropertyName("timeline.background")]
    public string? TimelineBackground { get; set; } = null;

    /// <summary>
    /// Part of UI. Value, which is the color, is interpreted as HEX.
    /// </summary>
    [JsonPropertyName("upLeft.background")]
    public string? UpLeftBackground { get; set; } = null;

    /// <summary>
    /// Part of UI. Value, which is the color, is interpreted as HEX.
    /// </summary>
    [JsonPropertyName("commonPicker.background")]
    public string? CommonPickerBackground { get; set; } = null;

    /// <summary>
    /// Part of UI. Value, which is the color, is interpreted as HEX.
    /// </summary>
    [JsonPropertyName("commonPicker.foreground")]
    public string? CommonPickerForeground { get; set; } = null;

    /// <summary>
    /// Part of UI. Value, which is the color, is interpreted as HEX.
    /// </summary>
    [JsonPropertyName("commonPicker.titleBar.Background")]
    public string? CommonPickerTitleBarBackground { get; set; } = null;

    /// <summary>
    /// Part of UI. Value, which is the color, is interpreted as HEX.
    /// </summary>
    [JsonPropertyName("commonPicker.titleBar.foreground")]
    public string? CommonPickerTitleBarForeground { get; set; } = null;

    /// <summary>
    /// Part of UI. Value, which is the color, is interpreted as HEX.
    /// </summary>
    [JsonPropertyName("managementPanel.background")]
    public string? ManagementPanelBackground { get; init; } = null;

    /// <summary>
    /// Part of UI. Value, which is the color, is interpreted as HEX.
    /// </summary>
    [JsonPropertyName("managementPanel.foreground")]
    public string? ManagementPanelForeground { get; init; } = null;

    /// <summary>
    /// Part of UI. Value, which is the color, is interpreted as HEX.
    /// </summary>
    [JsonPropertyName("managementPanel.hoverForeground")]
    public string? ManagementPanelHoverForeground { get; init; } = null;

    /// <summary>
    /// Part of UI. Value, which is the color, is interpreted as HEX.
    /// </summary>
    [JsonPropertyName("editor.background")]
    public string? EditorBackground { get; init; } = null;

    /// <summary>
    /// Makes sure all properties of this theme from JSON were initialized.
    /// </summary>
    /// <exception cref="ThemeException">Thrown when not all properties from JSON were initialized.</exception>
    public void Validate()
    {
        bool invalid = ID == null || MenuBorderThickness == null ||
                       HasNull(
                           DisplayName,
                           EditorFileManagerBackground,
                           EditorTabInactiveBackground,
                           EditorTabActiveBackground,
                           PropertyEditorBackground,
                           PropertyEditorForeground,
                           MenuBackground,
                           MenuForeground,
                           MenuBorderColor,
                           MenuItemBackground,
                           MenuItemForeground,
                           TitleBarBackground,
                           TitleBarForeground,
                           CloseButtonBackground,
                           CloseButtonForeground,
                           EditorObjectsBackground,
                           EditorOutputBackground,
                           EditorEditElsewhereBackground,
                           EditorAboutBackground,
                           TimelineSecondBackground,
                           TimelineSecondForeground,
                           TimelineLeftButtonBackground,
                           TimelineLeftButtonForeground,
                           TimelineBackground,
                           UpLeftBackground,
                           CommonPickerBackground,
                           CommonPickerTitleBarBackground,
                           CommonPickerTitleBarForeground,
                           ManagementPanelBackground,
                           ManagementPanelForeground,
                           ManagementPanelHoverForeground,
                           EditorBackground
                       );

        if (invalid)
        {
            throw new ThemeException($"This theme contains uninitialized properties.");
        }

        static bool HasNull<T>(params T?[] values)
            => values.Where(item => item == null).Any();
    }
}
