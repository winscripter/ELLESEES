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

using Microsoft.Win32;

namespace ElleseesUI.FileSystem;

/// <summary>
/// A file displayed in UIs.
/// </summary>
internal class DisplayFile
{
    /// <summary>
    /// Short name of this file (f.e. file.txt).
    /// </summary>
    public string ShortName { get; init; } = string.Empty;

    /// <summary>
    /// Full name of this file (f.e. C:\Users\User\Desktop\file.txt).
    /// </summary>
    public string FullName { get; init; } = string.Empty;

    public static List<DisplayFile> FromDialog(OpenFileDialog ofd)
    {
        List<string> files = new();
        List<string> filesshort = new();

        foreach (string file in ofd.FileNames)
        {
            files.Add(file);
        }

        foreach (string shortfile in ofd.SafeFileNames)
        {
            filesshort.Add(shortfile);
        }

        List<DisplayFile> displayFiles = new();
        for (int i = 0; i < files.Count; i++)
        {
            displayFiles.Add(new DisplayFile
            {
                FullName = files[i],
                ShortName = filesshort[i]
            });
        }

        return displayFiles;
    }
}
