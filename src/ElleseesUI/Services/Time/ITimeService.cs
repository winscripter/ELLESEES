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

namespace ElleseesUI.Services.Time;

/// <summary>
/// An interface for the Time service.
/// </summary>
public interface ITimeService : ICloneable
{
    /// <summary>
    /// Returns a <see cref="TimeSpan" /> from a time service.
    /// </summary>
    TimeSpan Span { get; set; }

    /// <summary>
    /// Exports the time.
    /// </summary>
    /// <returns>Time.</returns>
    (int d, int h, int m, int s) Export();

    /// <summary>
    /// Adds 1 second.
    /// </summary>
    void AddSecond();

    /// <summary>
    /// Adds <paramref name="seconds"/> seconds.
    /// </summary>
    /// <param name="seconds">Amount of seconds</param>
    void AddSeconds(int seconds);

    /// <summary>
    /// Adds 1 minute.
    /// </summary>
    void AddMinute();

    /// <summary>
    /// Adds <paramref name="minutes"/> minutes.
    /// </summary>
    /// <param name="minutes">Amount of minutes</param>
    void AddMinutes(int minutes);

    /// <summary>
    /// Adds 1 hour.
    /// </summary>
    void AddHour();

    /// <summary>
    /// Adds <paramref name="hours"/> hours.
    /// </summary>
    /// <param name="hours">Amount of hours</param>
    void AddHours(int hours);

    /// <summary>
    /// Adds 1 day.
    /// </summary>
    void AddDay();

    /// <summary>
    /// Adds <paramref name="days"/> days.
    /// </summary>
    /// <param name="days">Amount of days</param>
    void AddDays(int days);

    /// <summary>
    /// Adds 1 week.
    /// </summary>
    void AddWeek();

    /// <summary>
    /// Adds <paramref name="weeks"/> weeks.
    /// </summary>
    /// <param name="weeks">Amount of weeks</param>
    void AddWeeks(int weeks);

    /// <summary>
    /// Adds 1 month.
    /// </summary>
    void AddMonth();

    /// <summary>
    /// Adds <paramref name="months" /> months.
    /// </summary>
    /// <param name="months">Amount of months</param>
    void AddMonths(int months);

    /// <summary>
    /// Gets the amount of hours from this time service.
    /// </summary>
    int Hours { get; }

    /// <summary>
    /// Gets the amount of minutes from this time service.
    /// </summary>
    int Minutes { get; }

    /// <summary>
    /// Gets the amount of seconds from this time service.
    /// </summary>
    int Seconds { get; }

    /// <summary>
    /// Changes <see cref="Hours" />, <see cref="Minutes" />, and <see cref="Seconds" />,
    /// to <paramref name="hours" />, <paramref name="minutes" />, and <paramref name="seconds" /> respectively.
    /// </summary>
    /// <param name="hours">New amount of hours</param>
    /// <param name="minutes">New amount of minutes</param>
    /// <param name="seconds">New amount of seconds</param>
    void Change(int hours, int minutes, int seconds);
}
