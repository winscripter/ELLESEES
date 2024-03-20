using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;

namespace Ellesees.Effects.Common.Transitions.Saturation;

public class SaturationAnimateCustom : Effect, ITransition
{
    public string DisplayName => "Saturation: Custom";
    public TransitionKind Kind => TransitionKind.Animate;

    public override void Begin(Image<Rgba32>[] frames, string[] args)
    {
        RequireArgumentCount(args, 1);

        var speed = int.Parse(args[0]);
        var startSaturation = float.Parse(args[1]);
        var targetSaturation = float.Parse(args[2]);

        float saturationBy = 100.0F / speed;

        if (startSaturation < targetSaturation)
        {
            var saturation = startSaturation;
            saturationBy = saturation / speed;

            int i = 0;
            foreach (var frame in frames)
            {
                if (i++ % speed == 0)
                {
                    saturation += saturationBy;
                    frame.Mutate(x => x.Saturate(saturation / 100));
                }
            }
        }
        else
        {
            var saturation = startSaturation;
            saturationBy = saturation / speed;

            int i = 0;
            foreach (var frame in frames)
            {
                if (i++ % speed == 0)
                {
                    saturation -= saturationBy;
                    frame.Mutate(x => x.Saturate(saturation / 100));
                }
            }
        }
    }
}
