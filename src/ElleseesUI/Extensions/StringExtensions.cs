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

namespace ElleseesUI.Extensions;

/// <summary>
/// Extensions for strings.
/// </summary>
internal static class StringExtensions
{
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

    /// <summary>
    /// Attempts to convert string to <see cref="TimeSpan" />.
    /// </summary>
    /// <param name="format">Input string.</param>
    /// <param name="value">Output <see cref="TimeSpan" />.</param>
    /// <returns><see langword="TRUE" /> if conversion was successful, <see langword="FALSE" /> if not.</returns>
    public static bool TryFormatToTimeSpan(string format, out TimeSpan value)
    {
        try
        {
            value = ToTimeSpan(format);
            return true;
        }
        catch
        {
            value = default;
            return false;
        }
    }

    /// <summary>
    /// Converts a <see cref="string" /> to <see cref="int" /> where a string is a percentage format.
    /// </summary>
    /// <param name="percentage">Input percentage format string.</param>
    /// <returns>Output integer.</returns>
    public static int FromPercentage(this string percentage)
    {
        if (percentage.EndsWith("%"))
        {
            percentage = percentage.TrimEnd('%');
        }

        return Convert.ToInt32(percentage);
    }

    public static bool TryFromPercentage(this string percentage, out int value)
    {
        try
        {
            value = percentage.FromPercentage();
            return true;
        }
        catch
        {
            value = default;
            return false;
        }
    }
}
