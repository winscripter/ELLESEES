using SixLabors.ImageSharp.PixelFormats;

namespace Ellesees.Base;

public record Shadow(
    Rgba32 ShadowColor,
    int Strength
);
