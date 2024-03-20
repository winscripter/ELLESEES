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
using System.Windows;

namespace ElleseesUI.Services.Integrity;

/// <summary>
/// A service for ELLESEES integrity. It is not yet used,
/// but will be in the later versions.
/// </summary>
internal class IntegrityService
{
    /// <summary>
    /// These are 7 files that are vital to ELLESEES functionality. There are
    /// many more files that are needed by ELLESEES to work, but without them ELLESEES
    /// wouldn't be able to launch at all, so these are files that ELLESEES can launch
    /// without those, but are still needed.
    /// </summary>
    public static readonly string[] VitalFiles =
    {
        "ffmpeg.exe", "ffprobe.exe", "Renderer.exe", "Renderer.deps.json", "Renderer.runtimeconfig.json",
        "./_assets/DefaultTemplate.png", "./_assets/TaskPending.png"
    };

    /// <summary>
    /// Initializes a new instance of <see cref="IntegrityService" />
    /// </summary>
    public IntegrityService()
    {
    }

    /// <summary>
    /// Runs the integrity check
    /// </summary>
#pragma warning disable CA1822 // Mark member as static
    public void RunIntegrityCheck()
    {
        foreach (string file in VitalFiles)
        {
            if (!File.Exists(file))
            {
                if (MessageBoxCommon.WarnOk($"A file vital to ELLESEES functionality: \"{file}\", was not found. You can still continue, but ELLESEES may not work well (here be dragons!). Would you like to continue the execution of ELLESEES?") == MessageBoxResult.No)
                {
                    Environment.Exit(1);
                }
            }
        }
    }
#pragma warning restore CA1822
}
