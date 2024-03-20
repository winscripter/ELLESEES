using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;

namespace Ellesees.Effects.Common.Transitions.Lightness;

/// <summary>
/// A transition, from max. lightness to min. lightness
/// </summary>
public class LightnessAnimateEnd : Effect, ITransition
{
    string ITransition.DisplayName => "Lightness: Maximum to Minimum";
    TransitionKind ITransition.Kind => TransitionKind.AnimateEnd;

    public override void Begin(Image<Rgba32>[] frames, string[] args)
    {
        RequireArgumentCount(args, 1);

        var speed = int.Parse(args[0]);

        float lightness = 100.0F;
        float lightnessBy = 100.0F / speed;

        int i = 0;
        foreach (var frame in frames)
        {
            if (i++ % speed == 0)
            {
                lightness -= lightnessBy;
                frame.Mutate(x => x.Lightness(lightness / 100));
            }
        }
    }
}
