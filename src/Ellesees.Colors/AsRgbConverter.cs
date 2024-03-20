namespace Ellesees.Colors;

public static class AsRgbConverter
{
    public static RgbColor Convert(this string rgbColor)
    {
        if (rgbColor[0] == '#')
        {
            return Css.FromHexLowercase(rgbColor.ToLowerInvariant());
        }
        else
        {
            return Css.FromCssLowercase(rgbColor);
        }
    }
}
