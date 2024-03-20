namespace Ellesees.ProjectParser.ProjectInfo.Abstractions;

/// <summary>
/// Represents a member that has start and end time stamps.
/// </summary>
public interface IHasTimeStamps
{
    /// <summary>
    /// Start duration of this effect.
    /// </summary>
    string? StartDuration { get; set; }

    /// <summary>
    /// End duration of this effect.
    /// </summary>
    string? EndDuration { get; set; }
}
