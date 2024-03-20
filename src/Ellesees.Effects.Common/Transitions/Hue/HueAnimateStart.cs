using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;

namespace Ellesees.Effects.Common.Transitions.Hue;

public class HueAnimateStart : Effect, ITransition
{
    public string DisplayName => "Hue: Minimum to Maximum";
    public TransitionKind Kind => TransitionKind.AnimateStart;

    public override void Begin(Image<Rgba32>[] frames, string[] args)
    {
        RequireArgumentCount(args, 1);

        var speed = int.Parse(args[0]);

        float hue = 100.0F;
        float hueBy = 100.0F / speed;

        int i = 0;
        foreach (var frame in frames)
        {
            if (i++ % speed == 0)
            {
                hue += hueBy;
                frame.Mutate(x => x.Hue(hue / 100));
            }
        }
    }
}
