using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;

namespace Ellesees.Base.ImageHandling;

public static class Zoom
{
    public static Color PadColor { get; set; } = Color.Black;

    #region Image method overloads
    private static void ZoomOut(ref Image image, int width, int height)
    {
        int oldWidth = image.Width;
        int oldHeight = image.Height;

        width = image.Width + width;
        height = image.Height + height;

        image.Mutate(x => x.Pad(width, height, PadColor));
        image.Mutate(x => x.Resize(oldWidth, oldHeight));
    }

    private static void ZoomIn(ref Image image, int cropWidth, int cropHeight)
    {
        int oldWidth = image.Width;
        int oldHeight = image.Height;

        int centerX = image.Width / 2;
        int centerY = image.Height / 2;

        cropWidth = image.Width - cropWidth;
        cropHeight = image.Height - cropHeight;

        Rectangle cropRect = new(
            centerX - cropWidth / 2,
            centerY - cropHeight / 2,
            cropWidth, cropHeight
        );

        image.Mutate(x => x.Crop(cropRect));
        image.Mutate(x => x.Resize(oldWidth, oldHeight));
    }

    public static void ZoomX(ref Image image, int newX)
    {
        if (newX < 0)
        {
            ZoomOut(ref image, Math.Abs(newX), 0);
        }
        else
        {
            ZoomIn(ref image, newX, 0);
        }
    }

    public static void ZoomY(ref Image image, int newY)
    {
        if (newY < 0)
        {
            ZoomOut(ref image, 0, Math.Abs(newY));
        }
        else
        {
            ZoomIn(ref image, 0, newY);
        }
    }

    public static void ZoomXY(ref Image image, int x, int y)
    {
        ZoomX(ref image, x);
        ZoomY(ref image, y);
    }

    public static void ZoomImage(ref Image image, int x, int y)
    {
        ZoomXY(ref image, x, y);
    }
    #endregion

    #region Image<Rgba32> method overloads
    private static void ZoomOut(ref Image<Rgba32> image, int width, int height)
    {
        int oldWidth = image.Width;
        int oldHeight = image.Height;

        width = image.Width + width;
        height = image.Height + height;

        image.Mutate(x => x.Pad(width, height, PadColor));
        image.Mutate(x => x.Resize(oldWidth, oldHeight));
    }

    private static void ZoomIn(ref Image<Rgba32> image, int cropWidth, int cropHeight)
    {
        int oldWidth = image.Width;
        int oldHeight = image.Height;

        int centerX = image.Width / 2;
        int centerY = image.Height / 2;

        cropWidth = image.Width - cropWidth;
        cropHeight = image.Height - cropHeight;

        Rectangle cropRect = new(
            centerX - cropWidth / 2,
            centerY - cropHeight / 2,
            cropWidth, cropHeight
        );

        image.Mutate(x => x.Crop(cropRect));
        image.Mutate(x => x.Resize(oldWidth, oldHeight));
    }

    public static void ZoomX(ref Image<Rgba32> image, int newX)
    {
        if (newX < 0)
        {
            ZoomOut(ref image, Math.Abs(newX), 0);
        }
        else
        {
            ZoomIn(ref image, newX, 0);
        }
    }

    public static void ZoomY(ref Image<Rgba32> image, int newY)
    {
        if (newY < 0)
        {
            ZoomOut(ref image, 0, Math.Abs(newY));
        }
        else
        {
            ZoomIn(ref image, 0, newY);
        }
    }

    public static void ZoomXY(ref Image<Rgba32> image, int x, int y)
    {
        ZoomX(ref image, x);
        ZoomY(ref image, y);
    }

    public static void ZoomImage(ref Image<Rgba32> image, int x, int y)
    {
        ZoomXY(ref image, x, y);
    }
    #endregion
}
