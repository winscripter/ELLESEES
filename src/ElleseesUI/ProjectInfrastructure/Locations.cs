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

namespace ElleseesUI.ProjectInfrastructure;

/// <summary>
/// Represents different paths related to video management.
/// </summary>
public static class Locations
{
    /// <summary>
    /// Directory where projects are stored.
    /// </summary>
    public const string ProjectsFolder = "projects";

    /// <summary>
    /// Directory where VECI projects are stored.
    /// </summary>
    public const string VECIProjectsFolder = "veci_projects";

    /// <summary>
    /// Creates <see cref="ProjectsFolder" /> if it doesn't exist.
    /// </summary>
    /// <returns><see cref="ProjectsFolder" /></returns>
    public static string EnsureProjectsFolderExists()
    {
        if (!Directory.Exists(ProjectsFolder))
        {
            Directory.CreateDirectory(ProjectsFolder);
        }

        return ProjectsFolder;
    }

    /// <summary>
    /// Creates <see cref="VECIProjectsFolder" /> if it doesn't exist.
    /// </summary>
    /// <returns><see cref="VECIProjectsFolder" />.</returns>
    public static string EnsureVECIProjectsFolderExists()
    {
        if (!Directory.Exists(VECIProjectsFolder))
        {
            Directory.CreateDirectory(VECIProjectsFolder);
        }

        return VECIProjectsFolder;
    }
}
