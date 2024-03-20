using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;

namespace Ellesees.Effects.Common.Transitions.Opacity;

public class OpacityAnimateCustom : Effect, ITransition
{
    public string DisplayName => "Opacity: Custom";
    public TransitionKind Kind => TransitionKind.Animate;

    public override void Begin(Image<Rgba32>[] frames, string[] args)
    {
        RequireArgumentCount(args, 1);

        var speed = int.Parse(args[0]);
        var startOpacity = float.Parse(args[1]);
        var targetOpacity = float.Parse(args[2]);

        float opacityBy = 100.0F / speed;

        if (startOpacity < targetOpacity)
        {
            var opacity = startOpacity;
            opacityBy = opacity / speed;

            int i = 0;
            foreach (var frame in frames)
            {
                if (i++ % speed == 0)
                {
                    opacity += opacityBy;
                    frame.Mutate(x => x.Opacity(opacity / 100));
                }
            }
        }
        else
        {
            var opacity = startOpacity;
            opacityBy = opacity / speed;

            int i = 0;
            foreach (var frame in frames)
            {
                if (i++ % speed == 0)
                {
                    opacity -= opacityBy;
                    frame.Mutate(x => x.Opacity(opacity / 100));
                }
            }
        }
    }
}
