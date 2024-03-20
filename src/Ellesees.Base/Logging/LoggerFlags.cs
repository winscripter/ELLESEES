namespace Ellesees.Base.Logging;

/// <summary>
/// Logging parameters
/// </summary>
[Flags]
public enum LoggerFlags : byte
{
    /// <summary>
    /// Allow appending current date &amp; time
    /// </summary>
    AppendDateTime = 1,

    /// <summary>
    /// Allow appending priority
    /// </summary>
    AppendPriority = 2,
}
