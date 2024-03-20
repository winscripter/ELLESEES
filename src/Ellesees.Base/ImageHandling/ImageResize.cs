using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;

namespace Ellesees.Base.ImageHandling;

public class ImageResize
{
    public static void ResizeInHalf(Image image, bool preserveAspectRatio = false)
    {
        int width = image.Width / 2;
        int height = image.Height / 2;

        // If aspect ratio is preserved, just set the height to 0.
        // SixLabors.ImageSharp will calculate the height automatically.
        image.Mutate(x => x.Resize(width, preserveAspectRatio ? 0 : height));
    }

    public static void ResizeImage(Image image, int width, int height, bool preserveAspectRatio = false)
    {
        // If aspect ratio is preserved, just set the height to 0.
        // SixLabors.ImageSharp will calculate the height automatically.
        image.Mutate(x => x.Resize(width, preserveAspectRatio ? 0 : height));
    }
}
