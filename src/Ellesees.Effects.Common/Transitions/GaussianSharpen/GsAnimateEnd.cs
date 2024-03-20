using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;

namespace Ellesees.Effects.Common.Transitions.GaussianSharpen;

public class GsAnimateEnd : Effect, ITransition
{
    public string DisplayName => "Gaussian Sharpen: Maximum to Minimum";
    public TransitionKind Kind => TransitionKind.AnimateEnd;

    public override void Begin(Image<Rgba32>[] frames, string[] args)
    {
        RequireArgumentCount(args, 1);

        var speed = int.Parse(args[0]);

        float gs = 100.0F;
        float gsBy = 100.0F / speed;

        int i = 0;
        foreach (var frame in frames)
        {
            if (i++ % speed == 0)
            {
                gs -= gsBy;
                frame.Mutate(x => x.GaussianSharpen(gs));
            }
        }
    }
}
