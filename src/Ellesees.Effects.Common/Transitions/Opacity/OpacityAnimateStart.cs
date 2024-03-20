using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;

namespace Ellesees.Effects.Common.Transitions.Opacity;

public class OpacityAnimateStart : Effect, ITransition
{
    public string DisplayName => "Opacity: Minimum to Maximum";
    public TransitionKind Kind => TransitionKind.AnimateStart;

    public override void Begin(Image<Rgba32>[] frames, string[] args)
    {
        RequireArgumentCount(args, 1);

        var speed = int.Parse(args[0]);

        float opacity = 0.00F;
        float opacityBy = 100.0F / speed;

        int i = 0;
        foreach (var frame in frames)
        {
            if (i++ % speed == 0)
            {
                opacity += opacityBy;
                frame.Mutate(x => x.Opacity(opacity));
            }
        }
    }
}
