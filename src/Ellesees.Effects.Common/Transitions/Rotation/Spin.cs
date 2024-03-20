using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

namespace Ellesees.Effects.Common.Transitions.Rotation;

public class Spin : Effect, ITransition
{
    public string DisplayName => "Rotation: Spin by 360 degrees";
    public TransitionKind Kind => TransitionKind.Animate;

    public override void Begin(Image<Rgba32>[] frames, string[] args)
    {
        RequireArgumentCount(args, 1);

        var rac = new RotationAnimateCustom();
        rac.Begin(frames, new[] { args[0], "0", "180" });
        rac.Begin(frames, new[] { args[0], "180", "0" });
    }
}
