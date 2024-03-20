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

using ElleseesUI.Core;

namespace ElleseesUI.Export;

/// <summary>
/// A class with 1 member to verify integrity before exporting (e.g. check if
/// all necessary files are intact).
/// </summary>
internal static class ExportIntegrity
{
    /// <summary>
    /// Checks if all files vital to the exporting functionality exist.
    /// </summary>
    /// <returns><see langword="TRUE" /> if all files required for exporting exist, <see langword="FALSE" /> if at least one doesn't.</returns>
    public static bool VerifyExportComponentIntegrity()
    {
        string[] files =
        {
            "Renderer.exe",
            "Renderer.dll",
            "Renderer.deps.json",
            "Renderer.runtimeconfig.json",
            "renderersettings.ini",
            "ffmpeg.exe"
        };

        foreach (string file in files)
        {
            if (!File.Exists(file))
            {
                MessageBoxCommon.ErrorOk($"Exporting cannot complete because the file \"{file}\" cannot be found.");

                return false;
            }
        }

        return true;
    }
}
