namespace Ellesees.Colors;

public static class Hex4
{
    public static RgbaColor ToRgba(this string hex)
    {
        if (hex[0] != '#')
        {
            throw new FormatException("Hex colors must start with a hashtag character");
        }

        return new RgbaColor(
            Convert.ToByte(hex[1] + hex[2]),
            Convert.ToByte(hex[3] + hex[4]),
            Convert.ToByte(hex[5] + hex[6]),
            Convert.ToByte(hex[7] + hex[8])
        );
    }
}
