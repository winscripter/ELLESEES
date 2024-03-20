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

using ElleseesUI.Dialogs.ImagePreview;

namespace ElleseesUI.ThemeManager;

public static partial class ThemeInitializer
{
    /// <summary>
    /// Theme initializer for <see cref="BokehBlurValue" />.
    /// </summary>
    /// <param name="bokehBlur">Instance of <see cref="BokehBlurValue" /> to apply theme to.</param>
    public static void Initialize(BokehBlurValue bokehBlur)
    {
        var theme = ThemeManager.Current;

        bokehBlur.BackgroundGrid.Background = theme.CommonPickerBackground;
        bokehBlur.TitleBar.Background = theme.CommonPickerTitleBarBackground;
        bokehBlur.CloseButton.Background = theme.CloseButtonBackground;
        bokehBlur.CloseButton.Foreground = theme.CloseButtonForeground;
        bokehBlur.DescriptionHeader.Foreground = theme.CommonPickerForeground;
        bokehBlur.DescriptionText.Foreground = theme.CommonPickerForeground;
        bokehBlur.RadiusField.Foreground = theme.CommonPickerForeground;
        bokehBlur.ComponentsField.Foreground = theme.CommonPickerForeground;
        bokehBlur.GammaField.Foreground = theme.CommonPickerForeground;
    }
}
