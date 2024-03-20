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

using Ellesees.Base.Logging;
using ElleseesUI.ProjectInfrastructure;
using System.Collections.ObjectModel;

namespace ElleseesUI.Recent;

/// <summary>
/// Store of recent projects.
/// </summary>
public static class RecentStore
{
    /// <summary>
    /// All recent projects.
    /// </summary>
    public static readonly ObservableCollection<RecentProject> Recent = new();

    /// <summary>
    /// Adds recent project.
    /// </summary>
    /// <param name="project">Project</param>
    public static void AddRecentProject(RecentProject project)
    {
        Recent.Add(project);
    }

    /// <summary>
    /// Removes all recent projects.
    /// </summary>
    public static void RemoveAll()
    {
        Recent.Clear();
    }

    /// <summary>
    /// Removes project by name.
    /// </summary>
    /// <param name="name">Name of the project.</param>
    public static void RemoveByName(string name)
    {
        Recent.RemoveAt(Recent.IndexOf(Recent.Where(r => r.Path == Path.Combine("projects", name)).First()));
    }

    /// <summary>
    /// Initializes all projects.
    /// </summary>
    public static void InstallAll()
    {
        Locations.EnsureProjectsFolderExists();

        try
        {
            var searcher = new RecentSearcher(Locations.ProjectsFolder);
            var filter = new RecentFilter(searcher);

            var sorted = filter.Sort();

            foreach (var item in sorted)
            {
                var dinfo = new DirectoryInfo(item);
                AddRecentProject(new RecentProject { Path = dinfo.Name, LastAccessed = dinfo.LastAccessTime.ToString() });
            }
        }
        catch (Exception ex)
        {
            Logger.Log($"ELLESEES cannot retrieve a list of projects.{Environment.NewLine}{ex}", LoggerFlags.AppendPriority | LoggerFlags.AppendDateTime, LogPriority.Fatal);
        }
    }
}
