using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;

namespace Ellesees.Effects.Common.Transitions.Lightness;

/// <summary>
/// A transition, from custom min.&max./max.&min. lightness
/// </summary>
public class LightnessAnimateCustom : Effect, ITransition
{
    string ITransition.DisplayName => "Lightness: Custom";
    TransitionKind ITransition.Kind => TransitionKind.Animate;

    public override void Begin(Image<Rgba32>[] frames, string[] args)
    {
        RequireArgumentCount(args, 1);

        var speed = int.Parse(args[0]);
        var startLightness = float.Parse(args[1]);
        var targetLightness = float.Parse(args[2]);

        float lightnessBy = 100.0F / speed;

        if (startLightness < targetLightness)
        {
            var lightness = startLightness;
            lightnessBy = lightness / speed;

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
        else
        {
            var lightness = startLightness;
            lightnessBy = lightness / speed;

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
}
