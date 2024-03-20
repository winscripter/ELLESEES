using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

namespace Ellesees.Effects.Common;

public class GlitchEffect : Effect
{
    public override void Begin(Image<Rgba32>[] frames, string[] args)
    {
        if (args.Length != 4)
        {
            throw new ArgumentException("args must be 4 long");
        }

        var start = Time.Parse(args[0]);
        var end = Time.Parse(args[1]);
        int colorCount = int.Parse(args[2]);
        int fps = int.Parse(args[3]);

        Rgba32[] glitchColors = new Rgba32[colorCount];
        bool[] keepColors = new bool[colorCount];

        for (int j = 0; j < colorCount; j++)
        {
            glitchColors[j] = new Rgba32(
                Random.Shared.NextSingle(),
                Random.Shared.NextSingle(),
                Random.Shared.NextSingle(),
                Random.Shared.NextSingle()
            );

            keepColors[j] = true;
        }

        int i = 0;
        foreach (Image<Rgba32> image in frames)
        {
            i++;

            if (start.TotalSeconds < i * fps)
            {
                continue;
            }

            if (end.TotalSeconds > i * fps)
            {
                break;
            }

            var color = GetColor();

            int height = Random.Shared.Next(0, image.Height);
            int width = Random.Shared.Next(0, image.Width);
            int x = Random.Shared.Next(0, image.Height);
            int y = Random.Shared.Next(0, image.Width);

            try
            {
                RectangleFill(image, x, y, width, height, color);
            }
            catch
            {
                // just skip that one
            }
        }

        Rgba32 GetColor()
        {
            int i;
            do
            {
                i = Random.Shared.Next(0, glitchColors.Length);
            }
            while (!keepColors[i]);

            keepColors[i] = false;
            return glitchColors[i];
        }
    }

    private static void RectangleFill(Image<Rgba32> image, int startx, int starty, int endx, int endy, Color color)
    {
        for (int x = startx; x < endx; x++)
        {
            for (int y = starty; y < endy; y++)
            {
                image[x, y] = color;
            }
        }
    }
}
