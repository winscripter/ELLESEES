namespace Ellesees.Base.Logging;

/// <summary>
/// Common ELLESEES logger
/// </summary>
public static class Logger
{
    /// <summary>
    /// Log file name (hardcoded to Ellesees.log)
    /// </summary>
    public const string LogFileName = $"Ellesees.log";

    /// <summary>
    /// Formats priority to a string
    /// </summary>
    /// <param name="priority">Input priority</param>
    /// <returns>Formatted priority string</returns>
    private static string FormatPriority(LogPriority priority)
        => priority switch
        {
            LogPriority.Success => "SUCCESS",
            LogPriority.Warn => "WARNING",
            LogPriority.Error => "ERROR",
            LogPriority.Fatal => "FATAL",
            LogPriority.Info or _ => "INFO"
        };

    /// <summary>
    /// Appends line of text to a log file
    /// </summary>
    /// <param name="message">Line of text</param>
    public static void Log(string message)
    {
        File.AppendAllText(LogFileName, message + "\r\n\r\n");
    }

    /// <summary>
    /// Appends line of text with current date &amp; time to a log file
    /// </summary>
    /// <param name="message">Line of text</param>
    private static void LogWithDateTime(string message)
    {
        File.AppendAllText(LogFileName, $"[{DateTime.Now}]: {message}\r\n\r\n");
    }

    /// <summary>
    /// Appends line of text with priority to a log file
    /// </summary>
    /// <param name="message">Line of text</param>
    /// <param name="priority">Priority</param>
    private static void LogWithPriority(string message, LogPriority priority)
    {
        File.AppendAllText(LogFileName, $"[{FormatPriority(priority)}]: {message}\r\n\r\n");
    }

    /// <summary>
    /// Appends line of text with priority and current date &amp; time to a log file
    /// </summary>
    /// <param name="message">Line of text</param>
    /// <param name="priority">Priority</param>
    private static void LogWithPriorityAndDateTime(string message, LogPriority priority)
        => File.AppendAllText(LogFileName, $"[{DateTime.Now}]: [{FormatPriority(priority)}]: {message}\r\n\r\n");

    /// <summary>
    /// Alias for <see cref="LogWithPriority(string, LogPriority)" />
    /// </summary>
    /// <param name="message">Line of text</param>
    /// <param name="priority">Priority</param>
    public static void Log(string message, LogPriority priority)
        => LogWithPriority(message, priority);

    /// <summary>
    /// Logs line of text to a log file based on <i>parameters</i>
    /// </summary>
    /// <param name="message">Line of text</param>
    /// <param name="flags"><i>parameters</i></param>
    /// <exception cref="LoggerException">Thrown when parameters include appending priority, which is not passed to this method</exception>
    public static void Log(string message, LoggerFlags flags)
    {
        if (flags.HasFlag(LoggerFlags.AppendPriority))
        {
            throw new LoggerException("Logger.Log(String, LoggerFlags) can't be used with flags being LoggerFlags.AppendPriority");
        }

        if (flags.HasFlag(LoggerFlags.AppendDateTime))
        {
            LogWithDateTime(message);
        }
        else
        {
            Log(message);
        }
    }

    /// <summary>
    /// Logs line of text to a log file based on <i>parameters</i>
    /// </summary>
    /// <param name="message">Line of text</param>
    /// <param name="flags"><i>parameters</i></param>
    /// <param name="priority">Logging priority</param>
    /// <exception cref="LoggerException">Thrown when parameters include appending priority, which is not passed to this method, or is null</exception>
    public static void Log(string message, LoggerFlags flags, LogPriority? priority)
    {
        if (flags.HasFlag(LoggerFlags.AppendPriority))
        {
            if (priority is null)
            {
                throw new LoggerException("Logger.Log(String, LoggerFlags) can't be used with flags being LoggerFlags.AppendPriority with priority being null");
            }
            else
            {
                if (flags.HasFlag(LoggerFlags.AppendDateTime))
                {
                    LogWithPriorityAndDateTime(message, priority ?? LogPriority.Info);
                }
                else
                {
                    LogWithPriority(message, priority ?? LogPriority.Info);
                }
            }
        }
        else if (flags.HasFlag(LoggerFlags.AppendDateTime))
        {
            LogWithDateTime(message);
        }
        else
        {
            Log(message);
        }
    }
}
