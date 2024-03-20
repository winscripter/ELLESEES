using Ellesees.Base;
using SixLabors.Fonts;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

namespace Ellesees.Effects.Common.Text;

internal readonly struct TextOptionsParser
{
    private static readonly Rgba32 DefaultRgba = new(0.0F, 0.0F, 0.0F, 0.0F);

    public static TextOptions Parse(string text)
    {
        string[] dict = text.Split(';');

        var fc = new FontCollection();

        string? txt = null;
        Rgba32? foreground = null;
        Rgba32? shadow = null;
        float? sigma = null;
        PointF? pos = null;
        int? fontSize = null;
        Font? font = null;
        FontStyle? fontStyle = null;

        foreach (string _s in dict)
        {
            string key = _s.Split('=')[0];
            string val = _s.Split('=')[1];

            string s = _s.Replace("\\=", "=")
                .Replace("\\\\", "\\")
                .Replace("\\n", "\n")
                .Replace("\\\"", "\"")
                .Replace("\\;", ";");

            switch (key)
            {
                case "Text":
                    txt = val;
                    break;
                case "Foreground":
                    foreground = ParseRgba(val);
                    break;
                case "Shadow":
                    if (val != "null")
                    {
                        shadow = ParseRgba(val);
                    }
                    break;
                case "ShadowSigma":
                    if (val != "null")
                    {
                        sigma = float.Parse(val);
                    }
                    break;
                case "Position":
                    pos = new PointF(
                        float.Parse(val.Split(',')[0]),
                        float.Parse(val.Split(',')[1])
                    );
                    break;
                case "FontSize":
                    fontSize = int.Parse(val);
                    break;
                case "FontPath":
                    var family = fc.Add(val);
                    font = family.CreateFont(fontSize ?? 16);
                    break;
                case "FontStyle":
                    fontStyle = val switch
                    {
                        "italic" => FontStyle.Italic,
                        "bold" => FontStyle.Bold,
                        "bolditalic" => FontStyle.BoldItalic,
                        _ => FontStyle.Regular,
                    };
                    break;
                default:
                    throw new FormatException($"Unexpected key \"{key}\"");
            }
        }

        return new TextOptions(
            txt ?? string.Empty,
            foreground ?? DefaultRgba,
            shadow ?? DefaultRgba,
            sigma ?? 0.0F,
            pos ?? new PointF(0.0F, 0.0F),
            fontSize ?? 16,
            font ?? FontDefaults.GetDefaultFont(),
            fontStyle ?? FontStyle.Regular,
            fc
        );
    }

    private static Rgba32 ParseRgba(string text)
    {
        return new Rgba32(
            float.Parse(text.Split('-')[0]),
            float.Parse(text.Split('-')[1]),
            float.Parse(text.Split('-')[2]),
            float.Parse(text.Split('-')[3])
        );
    }
}
