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

namespace ElleseesUI.Tools;

/// <summary>
/// Contains options for locating CreateNewProject.exe ELLESEES component.
/// </summary>
/// <remarks>
/// The source code of CreateNewProject.exe is located in a separate project.
/// </remarks>
public static class CreateNewProject
{
    /// <summary>
    /// Checks whether CreateNewProject.exe exists.
    /// </summary>
    /// <returns><see langword="true"/> if CreateNewProject.exe was found, <see langword="false"/> otherwise.</returns>
    public static bool Exists()
        => File.Exists("CreateNewProject.exe");

    /// <summary>
    /// Checks whether all required components for CreateNewProject.exe and CreateNewProject.exe itself exist.
    /// </summary>
    /// <returns><see langword="true"/> if CreateNewProject.exe and its components were found, <see langword="false"/> otherwise.</returns>
    public static bool ComponentsExist()
        => !(new[]
        {
            "CreateNewProject.exe",
            "CreateNewProject.pdb",
            "CreateNewProject.dll",
            "CreateNewProject.runtimeconfig.json",
            "CreateNewProject.deps.json"
        }).Where(file => !File.Exists(file)).Any();
}
