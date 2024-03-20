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
using ElleseesUI.ReadOnly;
using System.Text.Json;
using System.Windows.Media;

namespace ElleseesUI.ThemeManager;

/// <summary>
/// Represents a theme.
/// </summary>
internal class Theme : ITheme
{
    /// <inheritdoc />
    public string DisplayName { get; init; } = ThemeStringConstants.UnknownThemePlaceholder;

    /// <inheritdoc />
    public uint ID { get; init; } = 0;

    /// <inheritdoc />
    public SolidColorBrush EditorFileManagerBackground { get; init; } = Brushes.Transparent;

    /// <inheritdoc />
    public SolidColorBrush EditorTabInactiveBackground { get; init; } = Brushes.Transparent;

    /// <inheritdoc />
    public SolidColorBrush EditorTabActiveBackground { get; init; } = Brushes.Transparent;

    /// <inheritdoc />
    public SolidColorBrush PropertyEditorBackground { get; init; } = Brushes.Transparent;

    /// <inheritdoc />
    public SolidColorBrush PropertyEditorForeground { get; init; } = Brushes.Transparent;

    /// <inheritdoc />
    public SolidColorBrush MenuBackground { get; init; } = Brushes.Transparent;

    /// <inheritdoc />
    public SolidColorBrush MenuForeground { get; init; } = Brushes.Transparent;

    /// <inheritdoc />
    public SolidColorBrush MenuBorderColor { get; init; } = Brushes.Transparent;

    /// <inheritdoc />
    public int MenuBorderThickness { get; init; } = 0;

    /// <inheritdoc />
    public SolidColorBrush MenuItemBackground { get; init; } = Brushes.Transparent;

    /// <inheritdoc />
    public SolidColorBrush MenuItemForeground { get; init; } = Brushes.Transparent;

    /// <inheritdoc />
    public SolidColorBrush TitleBarBackground { get; init; } = Brushes.Transparent;

    /// <inheritdoc />
    public SolidColorBrush TitleBarForeground { get; init; } = Brushes.Transparent;

    /// <inheritdoc />
    public SolidColorBrush CloseButtonBackground { get; init; } = Brushes.Transparent;

    /// <inheritdoc />
    public SolidColorBrush CloseButtonForeground { get; init; } = Brushes.Transparent;

    /// <inheritdoc />
    public SolidColorBrush EditorObjectsBackground { get; init; } = Brushes.Transparent;

    /// <inheritdoc />
    public SolidColorBrush EditorOutputBackground { get; init; } = Brushes.Transparent;

    /// <inheritdoc />
    public SolidColorBrush EditorEditElsewhereBackground { get; init; } = Brushes.Transparent;

    /// <inheritdoc />
    public SolidColorBrush EditorAboutBackground { get; init; } = Brushes.Transparent;

    /// <inheritdoc />
    public SolidColorBrush TimelineSecondBackground { get; init; } = Brushes.Transparent;

    /// <inheritdoc />
    public SolidColorBrush TimelineSecondForeground { get; init; } = Brushes.Transparent;

    /// <inheritdoc />
    public SolidColorBrush TimelineLeftButtonBackground { get; init; } = Brushes.Transparent;

    /// <inheritdoc />
    public SolidColorBrush TimelineLeftButtonForeground { get; init; } = Brushes.Transparent;

    /// <inheritdoc />
    public SolidColorBrush TimelineBackground { get; init; } = Brushes.Transparent;

    /// <inheritdoc />
    public SolidColorBrush UpLeftBackground { get; init; } = Brushes.Transparent;

    /// <inheritdoc />
    public SolidColorBrush CommonPickerBackground { get; init; } = Brushes.Transparent;

    /// <inheritdoc />
    public SolidColorBrush CommonPickerForeground { get; init; } = Brushes.Transparent;

    /// <inheritdoc />
    public SolidColorBrush CommonPickerTitleBarBackground { get; init; } = Brushes.Transparent;

    /// <inheritdoc />
    public SolidColorBrush CommonPickerTitleBarForeground { get; init; } = Brushes.Transparent;

    /// <inheritdoc />
    public SolidColorBrush ManagementPanelBackground { get; init; } = Brushes.Transparent;

    /// <inheritdoc />
    public SolidColorBrush ManagementPanelForeground { get; init; } = Brushes.Transparent;

    /// <inheritdoc />
    public SolidColorBrush ManagementPanelHoverForeground { get; init; } = Brushes.Transparent;

    /// <inheritdoc />
    public SolidColorBrush EditorBackground { get; init; } = Brushes.Transparent;

    /// <summary>
    /// Makes sure the ID is correct.
    /// </summary>
    /// <exception cref="ThemeException">Thrown if ID was uninitialized or zero.</exception>
    public void Validate()
    {
        if (ID == 0)
        {
            throw new ThemeException($"Theme with ID equivalent to 0 is reserved for the default theme and cannot be used.");
        }
    }

    /// <summary>
    /// Converts <see cref="ThemeTemplate" /> to <see cref="Theme" />.
    /// </summary>
    /// <param name="template">Input <see cref="ThemeTemplate" />.</param>
    /// <returns>Output <see cref="Theme" />.</returns>
    /// <exception cref="ThemeException">Thrown when a theme has invalid property values.</exception>
    public static Theme FromTemplate(ThemeTemplate template)
    {
        template.Validate();

        var converter = new BrushConverter();

        var theme = new Theme
        {
            CloseButtonBackground = HexToBrush(template.CloseButtonBackground),
            CloseButtonForeground = HexToBrush(template.CloseButtonForeground),
            CommonPickerBackground = HexToBrush(template.CommonPickerBackground),
            CommonPickerForeground = HexToBrush(template.CommonPickerForeground),
            CommonPickerTitleBarBackground = HexToBrush(template.CommonPickerTitleBarBackground),
            CommonPickerTitleBarForeground = HexToBrush(template.CommonPickerTitleBarForeground),
            DisplayName = template.DisplayName ?? ThemeStringConstants.UnknownThemePlaceholder,
            EditorAboutBackground = HexToBrush(template.EditorAboutBackground),
            EditorEditElsewhereBackground = HexToBrush(template.EditorEditElsewhereBackground),
            EditorFileManagerBackground = HexToBrush(template.EditorFileManagerBackground),
            EditorObjectsBackground = HexToBrush(template.EditorObjectsBackground),
            EditorOutputBackground = HexToBrush(template.EditorOutputBackground),
            EditorTabActiveBackground = HexToBrush(template.EditorTabActiveBackground),
            EditorTabInactiveBackground = HexToBrush(template.EditorTabInactiveBackground),
            ID = template.ID ?? 1,
            MenuBackground = HexToBrush(template.MenuBackground),
            MenuForeground = HexToBrush(template.MenuForeground),
            MenuBorderColor = HexToBrush(template.MenuBorderColor),
            MenuBorderThickness = Convert.ToInt32(template.MenuBorderThickness ?? 0),
            MenuItemBackground = HexToBrush(template.MenuItemBackground),
            MenuItemForeground = HexToBrush(template.MenuItemForeground),
            PropertyEditorBackground = HexToBrush(template.PropertyEditorBackground),
            PropertyEditorForeground = HexToBrush(template.PropertyEditorForeground),
            TimelineBackground = HexToBrush(template.TimelineBackground),
            TimelineLeftButtonBackground = HexToBrush(template.TimelineLeftButtonBackground),
            TimelineLeftButtonForeground = HexToBrush(template.TimelineLeftButtonForeground),
            TimelineSecondBackground = HexToBrush(template.TimelineSecondBackground),
            TimelineSecondForeground = HexToBrush(template.TimelineSecondForeground),
            TitleBarBackground = HexToBrush(template.TitleBarBackground),
            TitleBarForeground = HexToBrush(template.TitleBarForeground),
            UpLeftBackground = HexToBrush(template.UpLeftBackground),
            ManagementPanelBackground = HexToBrush(template.ManagementPanelBackground),
            ManagementPanelForeground = HexToBrush(template.ManagementPanelForeground),
            ManagementPanelHoverForeground = HexToBrush(template.ManagementPanelHoverForeground),
            EditorBackground = HexToBrush(template.EditorBackground)
        };

        if (theme.MenuBorderThickness is < 1 or > 255)
        {
            throw new ThemeException(ThemeStringConstants.InvalidBorderThickness);
        }

        return theme;

        bool CanConvert(string value)
        {
            try
            {
                _ = converter.ConvertFrom(value);

                return true;
            }
            catch
            {
                return false;
            }
        }

        SolidColorBrush HexToBrush(string? hex)
            => CanConvert(hex ?? ThemeStringConstants.BlackColor)
               ? (SolidColorBrush)converter.ConvertFrom(hex ?? ThemeStringConstants.BlackColor)!
               : throw new ThemeException(ThemeStringConstants.InvalidPropertyMessage);
    }

    /// <summary>
    /// Reads the JSON file and converts its content to <see cref="Theme" />.
    /// </summary>
    /// <param name="jsonFile">JSON filename.</param>
    /// <returns><see cref="Theme" /> deserialized from a JSON file.</returns>
    /// <exception cref="ThemeException">The JSON file is invalid.</exception>
    public static Theme FromJsonFile(string jsonFile)
    {
        ThemeTemplate template = JsonSerializer.Deserialize<ThemeTemplate>(File.ReadAllText(jsonFile))
                                 ?? throw new ThemeException(ThemeStringConstants.ThemeJsonInvalid);


        return FromTemplate(template);
    }
}
