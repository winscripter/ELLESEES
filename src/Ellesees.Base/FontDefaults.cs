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

using SixLabors.Fonts;

namespace Ellesees.Base;

public static class FontDefaults
{
    public const string SpaceGroteskPath = "fonts/Google/Space Grotesk/SpaceGrotesk-Medium.ttf";

    /// <summary>
    /// Returns the Space Grotesk font, which
    /// is the default.
    /// The font size is 16.
    /// </summary>
    public static Font GetDefaultFont()
    {
        var fonts = new FontCollection();
        
        if (!File.Exists(SpaceGroteskPath))
        {
            throw new FileNotFoundException("Cannot find the default font file \"Space Grotesk\". If this error occurrs from the ELLESEES video editor app, please reinstall the app.");
        }

        var family = fonts.Add(SpaceGroteskPath);
        return family.CreateFont(16);
    }

    /// <summary>
    /// Returns the default font family, which is Space Grotesk.
    /// </summary>
    public static FontFamily GetDefaultFontFamily()
    {
        var fonts = new FontCollection();

        if (!File.Exists(SpaceGroteskPath))
        {
            throw new FileNotFoundException("Cannot find the default font file \"Space Grotesk\". If this error occurrs from the ELLESEES video editor app, please reinstall the app.");
        }

        return fonts.Add(SpaceGroteskPath);
    }

    public static FontCollection CreateFontCollection()
    {
        return new FontCollection();
    }
}
