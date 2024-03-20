using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;

namespace Ellesees.Effects.Common.Transitions.Hue;

public class HueAnimateCustom : Effect, ITransition
{
    public string DisplayName => "Hue: Custom";
    public TransitionKind Kind => TransitionKind.Animate;

    public override void Begin(Image<Rgba32>[] frames, string[] args)
    {
        RequireArgumentCount(args, 1);

        var speed = int.Parse(args[0]);
        var startHue = float.Parse(args[1]);
        var targetHue = float.Parse(args[2]);

        float hueBy = 100.0F / speed;

        if (startHue < targetHue)
        {
            var hue = startHue;
            hueBy = hue / speed;

            int i = 0;
            foreach (var frame in frames)
            {
                if (i++ % speed == 0)
                {
                    hue += hueBy;
                    frame.Mutate(x => x.Hue(hue));
                }
            }
        }
        else
        {
            var hue = startHue;
            hueBy = hue / speed;

            int i = 0;
            foreach (var frame in frames)
            {
                if (i++ % speed == 0)
                {
                    hue -= hueBy;
                    frame.Mutate(x => x.Hue(hue));
                }
            }
        }
    }
}
