namespace Ellesees.Base.Logging;

/// <summary>
/// Logging priority
/// </summary>
public enum LogPriority : byte
{
    /// <summary>
    /// Operation succeeded; no attention needed
    /// </summary>
    Success = 0,

    /// <summary>
    /// Something happened; maybe the user wants to change his mind?
    /// </summary>
    Info = 1,

    /// <summary>
    /// An error occurred, but the operation was not aborted
    /// </summary>
    Warn = 2,

    /// <summary>
    /// An error occurred, and the operation was aborted
    /// </summary>
    Error = 3,

    /// <summary>
    /// An error occurred, and the operation was aborted and may not continue to work.
    /// A critical error in the application may also include.
    /// </summary>
    Fatal = 4
}
