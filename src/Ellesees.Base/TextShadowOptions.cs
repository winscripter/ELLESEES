using SixLabors.ImageSharp;

namespace Ellesees.Base;

public record TextShadowOptions(
    Shadow Shadow,
    PointF Position, // SixLabors.ImageSharp, not System.Drawing!
    Point PositionFromText // SixLabors.ImageSharp, not System.Drawing!
);
