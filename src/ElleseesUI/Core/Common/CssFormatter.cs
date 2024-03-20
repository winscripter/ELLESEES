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

namespace ElleseesUI.Core.Common;

/// <summary>
/// Formats RGB or HEX as a CSS string
/// </summary>
internal static class CssFormatter
{
    /// <summary>
    /// Converts a HEX color string into a CSS RGB representation
    /// </summary>
    /// <param name="hex">HEX color string</param>
    /// <returns>CSS RGB representation</returns>
    public static string FormatHex(string hex)
        => $"rgb({Convert.ToByte($"0x{hex[1]}{hex[2]}", 16)}, {Convert.ToByte($"0x{hex[3]}{hex[4]}", 16)}, {Convert.ToByte($"0x{hex[5]}{hex[6]}", 16)})";

    /// <summary>
    /// Formats RGB like CSS RGB
    /// </summary>
    /// <param name="rgb">Input RGB color</param>
    /// <returns>Output RGB color represented like in CSS</returns>
    public static string FormatRgb(Rgb3 rgb)
        => $"rgb({rgb.R}, {rgb.G}, {rgb.B})";

    /// <summary>
    /// Formats RGBA like CSS RGBA
    /// </summary>
    /// <param name="rgba">Input RGBA color</param>
    /// <returns>Output RGBA color represented like in CSS</returns>
    public static string FormatRgba(Rgba32 rgba)
        => $"rgba({rgba.R}, {rgba.G}, {rgba.B}, {rgba.A})";
}
