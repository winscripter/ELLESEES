using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;

namespace Ellesees.Effects.Common.Lightness;

public class BrightToDark : Effect
{
    public override void Begin(Image<Rgba32>[] frames, string[] args)
    {
        RequireArgumentCount(args, 1);

        var speed = int.Parse(args[0]);
        float brightness = 100.0F;
        float perIteration = 100.0F / speed;

        int i = 0;
        foreach (Image<Rgba32> frame in frames)
        {
            if (i++ % speed != 0)
            {
                brightness -= perIteration;
                frame.Mutate(x => x.Brightness(brightness / 100));
            }
        }
    }
}
