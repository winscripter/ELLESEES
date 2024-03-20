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
/// Implements the Time service.
/// </summary>
public class TimeService : ITimeService
{
    private int h;
    private int m;
    private int s;

    /// <summary>
    /// Initializes a new instance of <see cref="TimeService" /> with explicit initial time as a starting point.
    /// </summary>
    /// <param name="h">Hours</param>
    /// <param name="m">Months</param>
    /// <param name="s">Seconds</param>
    public TimeService(int h, int m, int s)
    {
        this.h = h;
        this.m = m;
        this.s = s;
    }

    /// <summary>
    /// Initializes a new instance of <see cref="TimeService" /> with 0 hours, 0 minutes, and 0 seconds as a starting point.
    /// </summary>
    public TimeService()
        : this(0, 0, 0)
    {
    }

    /// <inheritdoc />
    public TimeSpan Span
    {
        get
        {
            return TimeSpan.FromSeconds((h * 60 * 60) + (m * 60) + s);
        }
        set
        {
            h = value.Hours;
            m = value.Minutes;
            s = value.Seconds;
        }
    }

    /// <inheritdoc />
    public (int d, int h, int m, int s) Export() => (h / 24, h % 24, m, s);

    /// <inheritdoc />
    public void AddSecond()
    {
        s++;

        if (s >= 60)
        {
            s = 0;
            AddMinute();
        }
    }

    /// <inheritdoc />
    public void AddSeconds(int seconds)
    {
        for (int i = 0; i < seconds; i++)
        {
            AddSecond();
        }
    }

    /// <inheritdoc />
    public void AddMinute()
    {
        m++;

        if (m >= 60)
        {
            m = 0;
            AddHour();
        }
    }

    /// <inheritdoc />
    public void AddMinutes(int m)
    {
        while (m >= 60)
        {
            m -= 60;
            AddHour();
        }

        this.m = m;
    }

    /// <inheritdoc />
    public int Hours => h;
    /// <inheritdoc />
    public int Minutes => m;
    /// <inheritdoc />
    public int Seconds => s;

    /// <inheritdoc />
    public void AddHour() => h++;

    /// <inheritdoc />
    public void AddHours(int hours) => h += hours;

    /// <inheritdoc />
    public void AddDay() => h += 24; // 1 day equals 24 hours (technically 23 hours 56 minutes but nobody cares)

    /// <inheritdoc />
    public void AddDays(int days) => h += days * 24;

    /// <inheritdoc />
    public void AddWeek() => AddDays(7);

    /// <inheritdoc />
    public void AddWeeks(int weeks) => AddDays(weeks * 7);

    /// <inheritdoc />
    public void AddMonth() => AddDays(30); // computers and programmers usually interpret a "month" by 30 days.

    /// <inheritdoc />
    public void AddMonths(int months) => AddDays(30 * months);

    /// <inheritdoc />
    public void Change(int hours, int minutes, int seconds)
    {
        h = hours;
        m = minutes;
        s = seconds;
    }

    /// <inheritdoc />
    public object Clone() => new TimeService(h, m, s);
}
