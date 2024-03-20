namespace Ellesees.Base.Logging;

/// <summary>
/// Exception thrown during logging a string of text to a log file
/// </summary>
public class LoggerException : Exception
{
    /// <summary>
    /// Initializes a new instance of <see cref="LoggerException" />
    /// </summary>
    /// <param name="message">Message</param>
    public LoggerException(string message)
        : base(message)
    {
    }
}
