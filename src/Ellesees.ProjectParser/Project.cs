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

using Ellesees.ProjectParser.ProjectInfo.Effects;
using System.Text.Json;

namespace Ellesees.ProjectParser;

/// <summary>
/// Represents a project context.
/// </summary>
public class Project
{
    private readonly ProjectContext _context;
    private readonly TimelineConfig _timelineConfig;
    private readonly TimelineProvider _timelineProvider;

    /// <summary>
    /// File that ELLESEES is looking for in order to retrieve
    /// basic project metadata.
    /// </summary>
    public const string ProjectInfoFileName = "project_info.json";

    /// <summary>
    /// File that ELLESEES is looking for in order to provide configuration
    /// for the timeline.
    /// </summary>
    public const string TimelineConfigFileName = "timeline_config.json";

    /// <summary>
    /// File that ELLESEES is looking for to provide items displayed in the
    /// timeline.
    /// </summary>
    public const string TimelineInfoFileName = "timeline_info.xml";

    /// <summary>
    /// Associations with tag names and effect types.
    /// </summary>
    public static readonly Dictionary<string, Type> TagAndEffectAssociations = new()
    {
        { "BackgroundEffect", typeof(BackgroundEffect) },
        { "BlackAndWhiteEffect", typeof(BlackAndWhiteEffect) },
        { "BokehBlurByEffect", typeof(BokehBlurByEffect) },
        { "BokehBlurEffect", typeof(BokehBlurEffect) },
        { "BoxBlurByEffect", typeof(BoxBlurByEffect) },
        { "BoxBlurEffect", typeof(BoxBlurEffect) },
        { "BrightnessEffect", typeof(BrightnessEffect) },
        { "ColorBlindnessEffect", typeof(ColorBlindnessEffect) },
        { "ContrastEffect", typeof(ContrastEffect) },
        { "CropEffect", typeof(CropEffect) },
        { "GaussianBlurEffect", typeof(GaussianBlurEffect) },
        { "GlowByEffect", typeof(GlowByEffect) },
        { "GlowEffect", typeof(GlowEffect) },
        { "GrayscaleBt601Effect", typeof(GrayscaleBt601Effect) },
        { "GrayscaleBt709Effect", typeof(GrayscaleBt709Effect) },
        { "GrayscaleEffect", typeof(GrayscaleEffect) },
        { "HueEffect", typeof(HueEffect) },
        { "LightnessEffect", typeof(LightnessEffect) },
        { "ResizeEffect", typeof(ResizeEffect) },
        { "RotateEffect", typeof(RotateEffect) },
        { "SaturationEffect", typeof(SaturationEffect) },
        { "ScaleEffect", typeof(ScaleEffect) },
        { "ExtractFramesRangeEffect", typeof(ExtractFramesRangeEffect) },
        { "CleanTempEffect", typeof(CleanTempEffect) },
        { "EffectGroupStart", typeof(EffectGroupStart) },
        { "EffectGroupEnd", typeof(EffectGroupEnd) }
    };

    /// <summary>
    /// Initializes a new instance of <see cref="Project" />.
    /// </summary>
    /// <param name="projectDirPath">Path to the project directory.</param>
    /// <exception cref="ProjectException">Thrown when the project is invalid.</exception>
    public Project(string projectDirPath)
    {
        if (!File.Exists(Path.Combine(projectDirPath, ProjectInfoFileName)))
        {
            throw new ProjectException("Could not find project_info.json in the project directory");
        }

        _context = JsonSerializer.Deserialize<ProjectContext>(File.ReadAllText(Path.Combine(projectDirPath, ProjectInfoFileName))) ?? throw new ProjectException("The project_info.json file in the project directory failed to parse (perhaps it is corrupted or modified with syntax errors)");

        string timelineDir = Path.Combine(projectDirPath, _context.TimelineDirectory!);

        if (!File.Exists(Path.Combine(timelineDir, TimelineConfigFileName)))
        {
            throw new ProjectException("Could not find timeline_config.json in the project timeline directory");
        }

        _timelineConfig = JsonSerializer.Deserialize<TimelineConfig>(File.ReadAllText(Path.Combine(timelineDir, TimelineConfigFileName))) ?? throw new ProjectException("The timeline_config.json file in the project timeline directory failed to parse (perhaps it is corrupted or modified with syntax errors)");

        if (!File.Exists(Path.Combine(timelineDir, TimelineInfoFileName)))
        {
            throw new ProjectException("Could not find timeline_info.xml in the project timeline directory");
        }

        var xparser = new TimelineInfoXmlParser(Path.Combine(timelineDir, TimelineInfoFileName));
        try
        {
            _timelineProvider = xparser.Parse();
        }
        catch (Exception ex) // Just give it a more meaningful exception
        {
            throw new ProjectException($"The timeline_info.xml file in the project timeline directory failed to parse (perhaps it is corrupted or modified with syntax errors).{Environment.NewLine}{Environment.NewLine}Exception details:{Environment.NewLine}{ex}");
        }


    }

    /// <summary>
    /// Gets the common metadata about the project.
    /// </summary>
    public ProjectContext Context
    {
        get
        {
            return _context;
        }
    }

    /// <summary>
    /// Gets the common metadata about the timeline.
    /// </summary>
    public TimelineConfig Configuration
    {
        get
        {
            return _timelineConfig;
        }
    }

    /// <summary>
    /// Gets items displayed in the timeline.
    /// </summary>
    public TimelineProvider Provider
    {
        get
        {
            return _timelineProvider;
        }
    }

    /// <summary>
    /// Primary video filename.
    /// </summary>
    public string PrimaryVideo
    {
        get
        {
            return Provider.PrimaryVideo!.Path;
        }
    }
}
