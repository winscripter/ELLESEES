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

namespace ElleseesUI.Recent;

/// <summary>
/// Searcher for Recent projects
/// </summary>
public class RecentSearcher
{
    private readonly string _projectsFolder;

    /// <summary>
    /// Initializes a new instance of <see cref="RecentSearcher" />
    /// </summary>
    /// <param name="projectsFolder">A directory where projects reside.</param>
    public RecentSearcher(string projectsFolder) => _projectsFolder = projectsFolder;
    
    /// <summary>
    /// Gets all projects.
    /// </summary>
    /// <returns>List of projects.</returns>
    public string[] Search() => Directory.GetDirectories(_projectsFolder);
}
