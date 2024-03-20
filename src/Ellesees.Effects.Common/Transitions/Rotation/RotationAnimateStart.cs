using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;

namespace Ellesees.Effects.Common.Transitions.Rotation;

public class LightnessAnimateStart : Effect, ITransition
{
    string ITransition.DisplayName => "Rotation: Minimum to Maximum";
    TransitionKind ITransition.Kind => TransitionKind.AnimateStart;

    public override void Begin(Image<Rgba32>[] frames, string[] args)
    {
        RequireArgumentCount(args, 1);

        var speed = int.Parse(args[0]);

        float rotation = 0.00F;
        float rotationBy = 100.0F / speed;

        int i = 0;
        foreach (var frame in frames)
        {
            if (i++ % speed == 0)
            {
                rotation += rotationBy;
                frame.Mutate(x => x.Rotate(rotation / 100));
            }
        }
    }
}
