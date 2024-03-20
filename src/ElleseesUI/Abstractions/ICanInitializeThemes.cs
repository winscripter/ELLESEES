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

using ElleseesUI.ThemeManager;

namespace ElleseesUI.Abstractions;

/// <summary>
/// An interface to implement members for theme initialization.
/// </summary>
internal interface ICanInitializeThemes
{
    /// <summary>
    /// Initializes themes if none are yet initialized.
    /// </summary>
    void InitializeThemes();

    /// <summary>
    /// Checks whether the themes are already initialized.
    /// </summary>
    bool AreThemesInitialized { get; }

    /// <summary>
    /// Throws an exception if themes weren't yet initialized.
    /// </summary>
    void RequireThemeInitialization();

    /// <summary>
    /// Returns a theme currently used by the component.
    /// </summary>
    ITheme UITheme { get; }
}
