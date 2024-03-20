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

namespace ElleseesUI.Core;

/// <summary>
/// Represents fonts and their paths
/// </summary>
internal static class FontRegistrar
{
    /// <summary>
    /// All fonts
    /// </summary>
    public static readonly Dictionary<string, string> Fonts = new();

    /// <summary>
    /// Adds a font and path
    /// </summary>
    /// <param name="name">Font name</param>
    /// <param name="path">Font path</param>
    public static void Add(string name, string path) => Fonts.Add(name, path);

    /// <summary>
    /// Adds a font and path to the font into the dictionary if it's not already present
    /// </summary>
    /// <param name="name">Font name</param>
    /// <param name="path">Font path</param>
    public static void AddWithoutDuplicates(string name, string path)
    {
        if (!Fonts.ContainsKey(name))
        {
            Fonts.Add(name, path);
        }
    }

    /// <summary>
    /// Returns the font path by its name, or <see langword="null" /> if it's not present.
    /// </summary>
    /// <param name="name">Font name</param>
    /// <returns>Path to the font, or <see langword="null" /> if it's not present</returns>
    public static string? Find(string name)
    {
        try
        {
            return Fonts[name];
        }
        catch
        {
            return null;
        }
    }
}
