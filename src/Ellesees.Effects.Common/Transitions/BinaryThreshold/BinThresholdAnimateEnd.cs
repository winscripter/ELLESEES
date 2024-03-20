using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;

namespace Ellesees.Effects.Common.Transitions.BinaryThreshold;

public class BinThresholdAnimateEnd : Effect, ITransition
{
    public string DisplayName => "Binary Threshold: Maximum to Minimum";
    public TransitionKind Kind => TransitionKind.AnimateEnd;

    public override void Begin(Image<Rgba32>[] frames, string[] args)
    {
        RequireArgumentCount(args, 1);

        var speed = int.Parse(args[0]);

        float bt = 100.0F;
        float btBy = 100.0F / speed;

        int i = 0;
        foreach (var frame in frames)
        {
            if (i++ % speed == 0)
            {
                bt -= btBy;
                frame.Mutate(x => x.BinaryThreshold(bt));
            }
        }
    }
}
