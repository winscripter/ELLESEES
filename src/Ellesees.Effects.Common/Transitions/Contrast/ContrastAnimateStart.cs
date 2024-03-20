using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;

namespace Ellesees.Effects.Common.Transitions.Contrast;

/// <summary>
/// A transition, from min. contrast to max. contrast
/// </summary>
public class ContrastAnimateStart : Effect, ITransition
{
    string ITransition.DisplayName => "Contrast: Minimum to Maximum";
    TransitionKind ITransition.Kind => TransitionKind.AnimateStart;

    public override void Begin(Image<Rgba32>[] frames, string[] args)
    {
        RequireArgumentCount(args, 1);

        var speed = int.Parse(args[0]);

        float contrast = 0.00F;
        float contrastBy = 100.0F / speed;

        int i = 0;
        foreach (var frame in frames)
        {
            if (i++ % speed == 0)
            {
                contrast += contrastBy;
                frame.Mutate(x => x.Contrast(contrast / 100));
            }
        }
    }
}
