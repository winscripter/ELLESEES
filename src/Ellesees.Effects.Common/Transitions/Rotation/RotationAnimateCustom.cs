using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;

namespace Ellesees.Effects.Common.Transitions.Rotation;

public class RotationAnimateCustom : Effect, ITransition
{
    string ITransition.DisplayName => "Rotation: Custom";
    TransitionKind ITransition.Kind => TransitionKind.Animate;

    public override void Begin(Image<Rgba32>[] frames, string[] args)
    {
        RequireArgumentCount(args, 1);

        var speed = int.Parse(args[0]);
        var startRotationDeg = float.Parse(args[1]);
        var targetRotationDeg = float.Parse(args[2]);

        float degBy = 100.0F / speed;

        if (startRotationDeg < targetRotationDeg)
        {
            var r = startRotationDeg;
            degBy = r / speed;

            int i = 0;
            foreach (var frame in frames)
            {
                if (i++ % speed == 0)
                {
                    r += degBy;
                    frame.Mutate(x => x.Rotate(r));
                }
            }
        }
        else
        {
            var r = startRotationDeg;
            degBy = r / speed;

            int i = 0;
            foreach (var frame in frames)
            {
                if (i++ % speed == 0)
                {
                    r -= degBy;
                    frame.Mutate(x => x.Rotate(r));
                }
            }
        }
    }
}
