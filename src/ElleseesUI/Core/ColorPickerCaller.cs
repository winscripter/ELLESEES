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

using ElleseesUI.Dialogs.Common;
using SixLabors.ImageSharp.PixelFormats;

namespace ElleseesUI.Core;

/// <summary>
/// Calls the ELLESEES' default color picker in order to ask
/// the user to choose the color.
/// </summary>
internal static class ColorPickerCaller
{
    /// <summary>
    /// Displays the color picker dialog and returns
    /// <see langword="null"/> if the user didn't choose a color,
    /// otherwise returns an instance of <see cref="Rgba32" /> representing
    /// the color that the user chose.
    /// </summary>
    /// <returns>A new instance of <see cref="Rgba32" /> representing the color that the user chose</returns>
    public static Rgba32? Call()
    {
        var dlg = new ColorPicker();
        dlg.ShowDialog();

        return dlg.Rgba;
    }

    /// <summary>
    /// Displays the color picker dialog and returns
    /// <see langword="null"/> if the user didn't choose a color,
    /// otherwise returns an instance of <see cref="Rgba32" /> representing
    /// the color that the user chose, and also an alpha value that the user entered.
    /// </summary>
    /// <returns>A new instance of <see cref="Rgba32" /> representing the color that the user chose and the alpha value</returns>
    public static (float? alpha, Rgba32? r32) CallWithAlpha()
    {
        var dlg = new ColorPicker();
        dlg.ShowDialog();

        return (dlg.ActualAlpha, dlg.Rgba);
    }
}
