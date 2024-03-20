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

using Ellesees.Base;
using Ellesees.Base.Context;
using SixLabors.ImageSharp.PixelFormats;

namespace ElleseesUI.ReadOnly;

/// <summary>
/// Constants related to text representation in an image.
/// </summary>
internal static class TextConstants
{
    /// <summary>
    /// Default text template.
    /// </summary>
    public const string Template = "A quick brown fox jumps over the lazy dog.";

    /// <summary>
    /// Default (relative) path to the default TTF font file.
    /// </summary>
    public const string SpaceGroteskTtfPath = "./fonts/Google/Space Grotesk/SpaceGrotesk-Medium.ttf";

    /// <summary>
    /// Default setting to allow text shadow or not (no).
    /// </summary>
    public const bool AllowsShadow = false;

    /// <summary>
    /// Default font shadow sigma.
    /// </summary>
    public const int Sigma = 4;

    /// <summary>
    /// Default font size.
    /// </summary>
    public const int FontSize = 24;

    /// <summary>
    /// Default X start coordinate (by pixel units).
    /// </summary>
    public const int X = 64;

    /// <summary>
    /// Default Y start coordinate (by pixel units).
    /// </summary>
    public const int Y = 64;

    /// <summary>
    /// Default text foreground.
    /// </summary>
    public static Rgba32 TextDefaultForeground => new(0F, 0F, 0F, 1F);

    /// <summary>
    /// Default shadow foreground.
    /// </summary>
    public static Rgba32 ShadowDefaultColor => new(0F, 0F, 0F, 1F);

    /// <summary>
    /// Default text context.
    /// </summary>
    public static TextContext DefaultContext => new(
        Template,
        SpaceGroteskTtfPath,
        FontSize,
        FontDefaults.GetDefaultFont(),
        SixLabors.Fonts.FontStyle.Regular,
        TextDefaultForeground,
        new(X, Y),
        null
    );
}
