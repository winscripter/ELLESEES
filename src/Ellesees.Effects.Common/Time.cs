namespace Ellesees.Effects.Common;

public readonly struct Time
{
    private readonly double _hrs;
    private readonly byte _mins;
    private readonly byte _secs;
    private readonly double _ms;

    public Time(double hours, byte mins, byte secs, double ms)
    {
        _hrs = hours;
        _mins = mins;
        _secs = secs;
        _ms = ms;
    }

    public Time(byte mins, byte secs, double ms)
    {
        _hrs = 0;
        _mins = mins;
        _secs = secs;
        _ms = ms;
    }

    public Time(byte secs, double ms)
    {
        _hrs = 0;
        _mins = 0;
        _secs = secs;
        _ms = ms;
    }

    public readonly double Hours
    {
        get
        {
            return _hrs;
        }
    }

    public readonly byte Minutes
    {
        get
        {
            return _mins;
        }
    }

    public readonly byte Seconds
    {
        get
        {
            return _secs;
        }
    }

    public readonly double Milliseconds
    {
        get
        {
            return _ms;
        }
    }

    public readonly double Days
    {
        get
        {
            return _hrs / 24;
        }
    }

    public readonly double Months
    {
        get
        {
            return Days / 30;
        }
    }

    public readonly double Years
    {
        get
        {
            return Days / 365;
        }
    }

    public static Time Parse(string s)
    {
        string[] splitted = s.Split(":");

        string hrs = splitted[0];
        string mins = splitted[1];

        string[] sp = splitted[2].Split(".");

        string secs = sp[0];
        string ms = sp[1];

        return new Time(
            double.Parse(hrs),
            byte.Parse(mins),
            byte.Parse(secs),
            double.Parse(ms)
        );
    }

    public static bool TryParse(string s, out Time result)
    {
        try
        {
            result = Parse(s);
            return true;
        }
        catch
        {
            result = default;
            return false;
        }
    }

    public double TotalSeconds
    {
        get
        {
            return (Hours * 60) + (Minutes * 60) + Seconds;
        }
    }
}
