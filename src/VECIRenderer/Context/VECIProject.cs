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

namespace VECIRenderer.Context;

/// <summary>
/// Represents data about a VECI project.
/// </summary>
internal struct VECIProject
{
    /// <summary>
    /// Header of the project.
    /// </summary>
    public string Header { get; set; }

    /// <summary>
    /// Minimum ELLESEES version that is able to read it.
    /// </summary>
    public float MinimumElleseesVersion { get; set; }

    /// <summary>
    /// Directory where files reside.
    /// </summary>
    public string DataDirectory { get; set; }

    /// <summary>
    /// A list of tasks.
    /// </summary>
    public VECIPair[] Tasks { get; set; }

    /// <summary>
    /// Creates a new VECI project template.
    /// </summary>
    /// <returns>New VECI project template.</returns>
    public static VECIProject CreateNew()
        => new()
        {
            DataDirectory = "data",
            Header = "ELLESEES VECI",
            MinimumElleseesVersion = 1.0F,
            Tasks = Array.Empty<VECIPair>(),
        };
}
