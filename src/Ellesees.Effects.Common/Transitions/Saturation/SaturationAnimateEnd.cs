using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;

namespace Ellesees.Effects.Common.Transitions.Saturation;

public class SaturationAnimateEnd : Effect, ITransition
{
    public string DisplayName => "Saturation: Maximum to Minimum";
    public TransitionKind Kind => TransitionKind.AnimateEnd;

    public override void Begin(Image<Rgba32>[] frames, string[] args)
    {
        RequireArgumentCount(args, 1);

        var speed = int.Parse(args[0]);

        float saturation = 100.0F;
        float saturateBy = 100.0F / speed;

        int i = 0;
        foreach (var frame in frames)
        {
            if (i++ % speed == 0)
            {
                saturation -= saturateBy;
                frame.Mutate(x => x.Saturate(saturation / 100));
            }
        }
    }
}
