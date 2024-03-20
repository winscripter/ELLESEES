using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;

namespace Ellesees.Effects.Common.Transitions.Lightness;

/// <summary>
/// A transition, from min. lightness to max. lightness
/// </summary>
public class LightnessAnimateStart : Effect, ITransition
{
    string ITransition.DisplayName => "Lightness: Minimum to Maximum";
    TransitionKind ITransition.Kind => TransitionKind.AnimateStart;

    public override void Begin(Image<Rgba32>[] frames, string[] args)
    {
        RequireArgumentCount(args, 1);

        var speed = int.Parse(args[0]);

        float lightness = 0.00F;
        float lightnessBy = 100.0F / speed;

        int i = 0;
        foreach (var frame in frames)
        {
            if (i++ % speed == 0)
            {
                lightness += lightnessBy;
                frame.Mutate(x => x.Lightness(lightness / 100));
            }
        }
    }
}
