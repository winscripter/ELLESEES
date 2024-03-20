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

using Ellesees.ProjectParser;
using Ellesees.ProjectParser.ProjectInfo.Abstractions;
using ElleseesUI.Core;

namespace ElleseesUI.ProjectInfrastructure;

/// <summary>
/// Represents information about a project
/// </summary>
public class VideoProject
{
    private readonly Project? _project;

    /// <summary>
    /// Absolute path to the project.
    /// </summary>
    public string AbsolutePath { get; private init; }

    /// <summary>
    /// Initializes a new instance of <see cref="VideoProject" />.
    /// </summary>
    /// <param name="projectDirectory">Project directory</param>
    public VideoProject(string projectDirectory)
    {
        try
        {
            _project = new Project(projectDirectory);
        }
        catch (Exception ex)
        {
            File.AppendAllText($"Ellesees.projectfault.log", $"User attempted to run project, and it failed with the following exception:{Environment.NewLine}");
            File.AppendAllText($"Ellesees.projectfault.log", ex.ToString() + $"{Environment.NewLine}{Environment.NewLine}");

            MessageBoxCommon.ErrorOk($"It seems like the project failed to load. We're sorry for the inconvenience. :(\n\nIf this is unintended and keeps happening, feel free to report a bug report to us.\n\nDetails can be found in file Ellesees.projectfault.log.");
        }
        AbsolutePath = projectDirectory;
    }

    /// <summary>
    /// Gets the project context.
    /// </summary>
    public Project? Project
    {
        get => _project;
    }

    /// <summary>
    /// Gets information displayed on the timeline.
    /// </summary>
    public TimelineProvider TimelineProvider
    {
        get => _project!.Provider;
    }

    /// <summary>
    /// Returns object models at the specified <i>time span</i>.
    /// </summary>
    /// <param name="ts"><i>time span</i></param>
    /// <returns>Image object models at <paramref name="ts" />.</returns>
    public IEnumerable<IImageObjectModel> GetModelsAt(TimeSpan ts)
    {
        return TimelineProvider.Models.Where(m => m.StartDuration.TotalSeconds == ts.TotalSeconds);
    }

    /// <summary>
    /// Returns object models that are between two time spans.
    /// </summary>
    /// <param name="tsStart">Start time span.</param>
    /// <param name="tsEnd">End time span.</param>
    /// <returns>Image object models between <paramref name="tsStart"/> and <paramref name="tsEnd" />.</returns>
    public IEnumerable<IImageObjectModel> GetModelsBetween(TimeSpan tsStart, TimeSpan tsEnd)
    {
        return TimelineProvider.Models.Where(m => !(m.StartDuration < tsStart) && !(m.EndDuration > tsEnd));
    }
}
