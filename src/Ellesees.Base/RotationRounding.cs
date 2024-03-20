using SixLabors.ImageSharp.Processing;

namespace Ellesees.Base;

public static class RotationRounding
{
    private static readonly Dictionary<float, RotateMode> IgnoreList = new()
    {
        {
            90.0F,
            RotateMode.Rotate90
        },
        {
            180.0F,
            RotateMode.Rotate180
        },
        {
            270.0F,
            RotateMode.Rotate270
        },
        {
            360.0F,
            RotateMode.None
        }
    };

    private static RotateMode Round(float angle)
    {
        return angle switch
        {
            0.0F or <= 45.0F or > 315.0F => RotateMode.None,
            > 225.0F and < 315.0F => RotateMode.Rotate270,
            > 135.0F and < 225.0F => RotateMode.Rotate180,
            > 45.0F and < 135.0F => RotateMode.Rotate90,
            _ => RotateMode.None
        };
    }

    public static RotateMode RoundRotation(float angle)
    {
        if (!IgnoreList.ContainsKey(angle))
        {
            return Round(angle);
        }
        else
        {
            return IgnoreList[angle];
        }
    }
}
