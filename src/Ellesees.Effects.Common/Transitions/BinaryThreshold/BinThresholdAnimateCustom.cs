using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;

namespace Ellesees.Effects.Common.Transitions.BinaryThreshold;

public class BinThresholdAnimateCustom : Effect, ITransition
{
    public string DisplayName => "Binary Threshold: Custom";
    public TransitionKind Kind => TransitionKind.Animate;

    public override void Begin(Image<Rgba32>[] frames, string[] args)
    {
        RequireArgumentCount(args, 1);

        var speed = int.Parse(args[0]);
        var startContrast = float.Parse(args[1]);
        var targetContrast = float.Parse(args[2]);

        float contrastBy = 100.0F / speed;

        if (startContrast < targetContrast)
        {
            var contrast = startContrast;
            contrastBy = contrast / speed;

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
        else
        {
            var contrast = startContrast;
            contrastBy = contrast / speed;

            int i = 0;
            foreach (var frame in frames)
            {
                if (i++ % speed == 0)
                {
                    contrast -= contrastBy;
                    frame.Mutate(x => x.Contrast(contrast / 100));
                }
            }
        }
    }
}
