namespace Renderer.Extensions;

/// <summary>
/// Extensions for string manipulation
/// </summary>
public static class StringExtensions
{
    /// <summary>
    /// Gets the next space from a string
    /// </summary>
    /// <param name="str">Input string</param>
    /// <returns>String without the previous space and before</returns>
    public static string NextSpace(this string str)
        => str.Split(' ')[str.Split(' ').Length == 0 ? 0 : 1];

    /// <summary>
    /// Adds the string to the stack
    /// </summary>
    /// <param name="str">Input string</param>
    /// <param name="stack">Output stack</param>
    /// <returns><paramref name="str"/></returns>
    public static string AddTo(this string str, Stack<string> stack)
    {
        stack.Push(str);

        return str;
    }

    /// <summary>
    /// Converts <paramref name="str"/> to <see cref="float" />
    /// </summary>
    /// <param name="str">Input string</param>
    /// <returns><paramref name="str"/> explicitly converted to <see cref="float"/></returns>
    public static float AsSingle(this string str) => Convert.ToSingle(str);

    /// <summary>
    /// Converts string to <see cref="TimeSpan" />.
    /// </summary>
    /// <param name="duration">Input string</param>
    /// <returns>Output formatted <see cref="TimeSpan" />.</returns>
    public static TimeSpan ToTimeSpan(this string duration)
    {
        string[] splitted = duration.Split(':');

        string hours = splitted[0];
        string minutes = splitted[1];

        string[] s = splitted[2].Split('.');

        string seconds = s[0];
        string milliseconds = s[1];

        int i_hours = int.Parse(hours);
        int i_minutes = int.Parse(minutes);
        int i_seconds = int.Parse(seconds);
        int i_milliseconds = int.Parse(milliseconds);

        return new TimeSpan(i_hours / 24, i_hours, i_minutes, i_seconds, i_milliseconds);
    }
}
