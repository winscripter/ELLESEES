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

using SixLabors.ImageSharp.PixelFormats;

namespace ElleseesUI.Extensions;

/// <summary>
/// Extensions to <see cref="Rgba32" />
/// </summary>
internal static class Rgba32Extensions
{
    /// <summary>
    /// Stringifies <see cref="Rgba32" />
    /// </summary>
    /// <param name="rgba32">Input <see cref="Rgba32" /> instance</param>
    /// <returns>Stringified type</returns>
    public static string Stringify(this Rgba32 rgba32)
        => $"{rgba32.R} {rgba32.G} {rgba32.B} {rgba32.GetAlpha()}";

    /// <summary>
    /// Stringies <see cref="Rgba32" /> like CSS RGBA
    /// </summary>
    /// <param name="rgba32">Input <see cref="Rgba32" /> instance</param>
    /// <returns>CSS-like RGBA format</returns>
    public static string ToCss(this Rgba32 rgba32)
        => $"rgba({rgba32.R}, {rgba32.G}, {rgba32.B}, {rgba32.GetAlpha()})";

    /// <summary>
    /// Gets the Alpha component from a <see cref="Rgba32" />
    /// </summary>
    /// <param name="rgba32">Input <see cref="Rgba32" /> instance</param>
    /// <returns>Alpha component from <see cref="Rgba32" /></returns>
    public static float GetAlpha(this Rgba32 rgba32)
        => (rgba32.PackedValue >> 24) / 255F;
}
