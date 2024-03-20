using Ellesees.Base.Logging;

namespace Renderer;

/// <summary>
/// Common ELLESEES Renderer logger.
/// </summary>
internal static class DebugLog
{
    /// <summary>
    /// Signifies whether the renderer is allowed to output messages to stdout.
    /// </summary>
    public const bool IsConsoleStandardOutputWriteEnabled = true;

    /// <summary>
    /// Signifies whether the renderer is allowed to output messages to the log file.
    /// </summary>
    public const bool IsFileWriteEnabled = true;

    /// <summary>
    /// Logs text based on <see cref="IsConsoleStandardOutputWriteEnabled" /> and <see cref="IsFileWriteEnabled" />.
    /// </summary>
    /// <param name="text">Text to output.</param>
    public static void Write(string text)
    {
        if (IsConsoleStandardOutputWriteEnabled)
        {
            Console.WriteLine($"[DEBUG]: {text}");
        }

        if (IsFileWriteEnabled)
        {
            Logger.Log($"[ELLESEES RENDERER PROCESS]: {text}", LoggerFlags.AppendDateTime | LoggerFlags.AppendDateTime, LogPriority.Success);
        }
    }
}
