using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;

namespace Ellesees.Effects.Common.Transitions.GaussianBlur;

public class GbAnimateStart : Effect, ITransition
{
    public string DisplayName => "Gaussian Blur: Minimum to Maximum";
    public TransitionKind Kind => TransitionKind.AnimateStart;

    public override void Begin(Image<Rgba32>[] frames, string[] args)
    {
        RequireArgumentCount(args, 1);

        var speed = int.Parse(args[0]);

        float gb = 0.00F;
        float gbBy = 100.0F / speed;

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
}
