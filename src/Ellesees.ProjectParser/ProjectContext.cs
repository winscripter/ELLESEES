namespace Ellesees.ProjectParser;

/// <summary>
/// Represents basic metadata about a project.
/// </summary>
[Serializable]
public class ProjectContext
{
    /// <summary>
    /// Version of the project.
    /// </summary>
    public string? Version { get; set; }

    /// <summary>
    /// Version of the project (of type float).
    /// </summary>
    public float VersionF { get; set; }

    /// <summary>
    /// Directory where output videos are stored.
    /// </summary>
    public string? RenderOutputDirectory { get; set; }

    /// <summary>
    /// Directory where timeline-specific data is stored.
    /// </summary>
    public string? TimelineDirectory { get; set; }

    /// <summary>
    /// Directory where timeline-specific frame splitting is stored.
    /// </summary>
    public int TimelineSplitByFrames { get; set; }
}
