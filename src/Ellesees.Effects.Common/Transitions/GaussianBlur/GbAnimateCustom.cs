using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;

namespace Ellesees.Effects.Common.Transitions.GaussianBlur;

public class GbAnimateCustom : Effect, ITransition
{
    public string DisplayName => "Gaussian Blur: Custom";
    public TransitionKind Kind => TransitionKind.Animate;

    public override void Begin(Image<Rgba32>[] frames, string[] args)
    {
        RequireArgumentCount(args, 1);

        var speed = int.Parse(args[0]);
        var startGb = float.Parse(args[1]);
        var targetGb = float.Parse(args[2]);

        float gbBy = 100.0F / speed;

        if (startGb < targetGb)
        {
            var gb = startGb;
            gbBy = gb / speed;

            int i = 0;
            foreach (var frame in frames)
            {
                if (i++ % speed == 0)
                {
                    gb += gbBy;
                    frame.Mutate(x => x.GaussianBlur(gb));
                }
            }
        }
        else
        {
            var gb = startGb;
            gbBy = gb / speed;

            int i = 0;
            foreach (var frame in frames)
            {
                if (i++ % speed == 0)
                {
                    gb -= gbBy;
                    frame.Mutate(x => x.GaussianBlur(gb));
                }
            }
        }
    }
}
