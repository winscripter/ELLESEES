using Ellesees.Base;
using Ellesees.Base.Context;
using SixLabors.Fonts;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

namespace Ellesees.Effects.Common.Text;

public record TextOptions(
    string Text,
    Rgba32 Foreground,
    Rgba32 ShadowColor,
    float ShadowSigma,
    PointF Position,
    int FontSize,
    Font Font,
    FontStyle Style,
    FontCollection FontCollection
);

internal static class TextOptionsExtensions
{
    public static TextContext ToContext(this TextOptions textOptions)
    {
        return new TextContext(
            textOptions.Text,
            textOptions.FontSize,
            textOptions.Font,
            textOptions.Style,
            textOptions.Foreground,
            textOptions.Position,
            new Shadow(textOptions.ShadowColor, (int)textOptions.ShadowSigma)
        );
    }
}
