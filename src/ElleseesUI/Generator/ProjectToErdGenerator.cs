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
using Ellesees.ProjectParser.ProjectInfo.Effects;
using ElleseesUI.ERD;
using ElleseesUI.Extensions;
using ElleseesUI.ProjectInfrastructure;

namespace ElleseesUI.Generator;

/// <summary>
/// Generates ERD files based on the project.
/// </summary>
internal class ProjectToErdGenerator
{
    private readonly VideoProject _project;

    /// <summary>
    /// Initializes a new instance of <see cref="ProjectToErdGenerator" />.
    /// </summary>
    /// <param name="project">Input project instance, which will be converted into ERD.</param>
    public ProjectToErdGenerator(VideoProject project)
        => _project = project;

    /// <summary>
    /// Gets all ERD files.
    /// </summary>
    public Dictionary<string, string> ErdFiles => GenerateErdFiles();

    /// <summary>
    /// Generates ERD files based on the project.
    /// </summary>
    /// <returns>A dictionary, whose key is the filename and value is the content.</returns>
    public Dictionary<string, string> GenerateErdFiles()
    {
        var files = new Dictionary<string, string>();

        TimeSpan? start = null;
        TimeSpan? end = null;

        List<IHasTimeStamps> effects = new();

        int fileIndex = 0;

        foreach (var effect in _project.TimelineProvider.Effects)
        {
            if (effect is not EffectGroupStart && (start == null || end == null))
            {
                continue;
            }

            if (effect is EffectGroupStart groupStart)
            {
                start = groupStart.StartDuration!.ToTimeSpan();
                end = groupStart.EndDuration!.ToTimeSpan();

                continue;
            }

            if (effect is EffectGroupEnd)
            {
                files.Add(
                    $"RenderingData_{++fileIndex}.erd",
                    TimelineProviderToErdConverter.Convert(
                        new TimelineProvider(
                            Array.Empty<ICommonImport>(),
                            Array.Empty<IImageObjectModel>(),
                            effects.ToArray(),
                            _project.TimelineProvider!.PrimaryVideo
                        ),
                        start ?? new(0, 0, 0),
                        end ?? new(0, 0, 0)
                    )
                );

                start = end = null;

                effects.Clear();

                continue;
            }

            effects.Add(effect);
        }

        foreach (IImageObjectModel mod in _project.TimelineProvider.Models)
        {
            if (mod is Ellesees.ProjectParser.ProjectInfo.ImageObjectModels.Text text)
            {
                files.Add(
                    $"RenderingData_{++fileIndex}.erd",
                    TimelineProviderToErdConverter.Convert(
                        new TimelineProvider(
                            Array.Empty<ICommonImport>(),
                            new IImageObjectModel[] { text },
                            Array.Empty<IHasTimeStamps>(),
                            _project.TimelineProvider!.PrimaryVideo
                        ),
                        text.StartDuration!,
                        text.EndDuration!
                    )
                );
            }
        }

        return files;
    }
}
