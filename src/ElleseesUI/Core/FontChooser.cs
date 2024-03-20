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

using Ellesees.Base.IO;
using ElleseesUI.Dialogs.Common;

namespace ElleseesUI.Core;

/// <summary>
/// Font picker dialog caller
/// </summary>
internal static class FontChooser
{
    /// <summary>
    /// Calls the font picker and asks the user to choose the font. After
    /// that, it returns the relative or absolute path to the font file if the
    /// user chose one.
    /// </summary>
    /// <returns>Relative or absolute path to the font file, or <see langword="null" /> if font wasn't chosen</returns>
    public static string? GetFont()
    {
        var window = new FontProviderChooser();
        window.InitializeBinding();
        
        foreach (string provider in LocalFontManager.GetCompanies())
        {
            string prv = provider;
            if (prv.Contains('/'))
            {
                prv = prv.Split('/')[1];
            }
            else if (prv.Contains('\\'))
            {
                prv = prv.Split('\\')[1];
            }

            window.Providers.Add(prv);
        }

        window.ShowDialog();
        return window.Provider;
    }
}
