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
using ElleseesUI.ThemeManager.PredefinedThemes;

namespace ElleseesUI.ThemeManager;

/// <summary>
/// Manages themes in ELLESEES.
/// </summary>
internal static class ThemeManager
{
    /// <summary>
    /// A list of all themes currently discovered.
    /// The key represents the theme's ID, pointing to the theme itself.
    /// </summary>
    public static Dictionary<uint, ITheme> Themes = new();

    /// <summary>
    /// Adds the theme.
    /// </summary>
    /// <param name="theme"></param>
    /// <exception cref="DuplicateThemeIDException">Thrown here when a theme being added has the same ID as some other theme</exception>
    public static void AddTheme(ITheme theme)
    {
        if (Themes.ContainsKey(theme.ID))
        {
            throw new DuplicateThemeIDException($"Duplicate theme with ID {theme.ID}.");
        }

        Themes.Add(theme.ID, theme);
    }

    /// <summary>
    /// Returns the theme by its ID.
    /// </summary>
    /// <param name="id">Theme ID to search for.</param>
    /// <returns><see cref="ITheme" /> representing the theme by its matching ID, or <see langword="null" /> if none was found.</returns>
    public static ITheme? GetThemeByID(uint id)
        => Themes.Select(theme => theme.Value).Where(theme => theme.ID == id).FirstOrDefault();

    private static ITheme? _theme;

    /// <summary>
    /// Gets or sets the current theme.
    /// </summary>
    public static ITheme Current
    {
        get => _theme ?? new Default();
        set => _theme = value;
    }
}
