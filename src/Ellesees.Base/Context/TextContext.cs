using SixLabors.Fonts;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Drawing.Processing;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;

namespace Ellesees.Base.Context;

public class TextContext
{
    #region Read-only fields
    private readonly string _text;
    private readonly Color? _foregroundColor;
    private readonly int _fontSize;
    private readonly Font _font;
    private readonly FontStyle _fontStyle;
    private readonly int _letterSpacing;
    private readonly Shadow? _shadow;
    private readonly string _path;
    #endregion

    private PointF _position;

    public TextContext(string text, string path, Color foregroundColor, PointF? position = null, Shadow? shadow = null)
    {
        _text = text;
        _fontStyle = FontStyle.Regular;
        _fontSize = 16;

        _font = FontDefaults.GetDefaultFont();

        _letterSpacing = 4;
        _foregroundColor = foregroundColor;
        _shadow = shadow;

        _position = position ?? new PointF(0, 0); // defaults to 0x0y
        _path = path;
    }

    public TextContext(string text, string path, int fontSize, Font font, FontStyle fontStyle, Color foregroundColor, PointF? position = null, Shadow? shadow = null) : this(text, path, foregroundColor, position, shadow)
    {
        _fontSize = fontSize;
        _font = font;
        _fontStyle = fontStyle;
        _letterSpacing = 4;
    }

    public string Text
    {
        get
        {
            return _text;
        }
    }

    public Color ForegroundShadow
    {
        get
        {
            return _shadow?.ShadowColor ?? Color.Transparent;
        }
    }

    public int FontSize
    {
        get
        {
            return _fontSize;
        }
    }

    public Font Font
    {
        get
        {
            return _font;
        }
    }

    public FontFamily FontFamily
    {
        get
        {
            return Font.Family;
        }
    }

    public FontStyle FontStyle
    {
        get
        {
            return _fontStyle;
        }
    }

    public bool IsItalic
    {
        get
        {
            return _fontStyle == FontStyle.Italic;
        }
    }

    public bool IsBold
    {
        get
        {
            return _fontStyle == FontStyle.Bold;
        }
    }

    public bool IsBoldItalic
    {
        get
        {
            return _fontStyle == FontStyle.BoldItalic;
        }
    }

    public int LetterSpacing
    {
        get
        {
            return _letterSpacing;
        }
    }

    public Color Foreground
    {
        get
        {
            return _foregroundColor ?? Color.Black;
        }
    }

    public int ShadowStrength
    {
        get
        {
            return _shadow?.Strength ?? 0;
        }
    }

    public PointF Position
    {
        get
        {
            return _position; // defaults to 0x0y
        }
        set
        {
            _position = value;
        }
    }

    public Shadow? Shadow
    {
        get
        {
            return _shadow;
        }
    }

    public string Path
    {
        get
        {
            return _path;
        }
    }

    public void DrawOn(Image<Rgba32> image, TextShadowOptions? shadowOptions = null)
    {
        // TODO: Text not drawing !!!
        if (shadowOptions is not null)
        {
            DrawTextWithShadow(
                image,
                Text,
                Foreground,
                Font,
                shadowOptions.Shadow.ShadowColor,
                shadowOptions.Shadow.Strength,
                shadowOptions.Position,
                shadowOptions.PositionFromText
            );
        }
        else
        {
            DrawText(
                image,
                Text,
                Foreground,
                Font,
                Position
            );
        }
    }

    public static void DrawText(Image<Rgba32> image, string text, Color foreground, Font font, PointF position)
    {
        image.Mutate(x => x
            .DrawText(text, font, foreground, position)
        );
    }

    public static void DrawTextWithShadow(Image<Rgba32> image, string text, Color foreground, Font font, Color shadowColor, int strength, PointF position, Point positionFromText)
    {
        using (Image<Rgba32> shadowImage = new(image.Width, image.Height))
        {
            shadowImage.Mutate(x => x
                .DrawText(text, font, shadowColor, position)
            );

            shadowImage.Mutate(x => x
                .GaussianBlur(strength)
            );

            image.Mutate(x => x
                .DrawImage(shadowImage, positionFromText, 1F)
            );
        }

        image.Mutate(x => x
            .DrawText(text, font, foreground, position)
        );
    }
}
