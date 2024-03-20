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

using System.Windows;

namespace ElleseesUI.ProjectInfrastructure;

/// <summary>
/// Loads a project.
/// </summary>
public class ProjectLoader
{
    /// <summary>
    /// Path to the project
    /// </summary>
    public readonly string Path;

    /// <summary>
    /// Initializes a new instance of <see cref="ProjectLoader" />.
    /// </summary>
    /// <param name="pPath">Path to the project.</param>
    public ProjectLoader(string pPath) => Path = pPath;

    /// <summary>
    /// Loads the project.
    /// </summary>
    /// <param name="home">Home window.</param>
    public void Load(Window home)
    {
        var project = new VideoProject(Path);

        if (project.Project == null)
        {
            home.Hide();

            VideoEditorUILoader.LoadWithError().Show();
        }
    }
}
