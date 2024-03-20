using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;

namespace Ellesees.Effects.Common.Transitions.BinaryThreshold;

public class BinThresholdAnimateStart : Effect, ITransition
{
    public string DisplayName => "Binary Threshold: Minimum to Maximum";
    public TransitionKind Kind => TransitionKind.AnimateStart;

    public override void Begin(Image<Rgba32>[] frames, string[] args)
    {
        RequireArgumentCount(args, 1);

        var speed = int.Parse(args[0]);

        float bt = 0.00F;
        float btBy = 100.0F / speed;

        int i = 0;
        foreach (var frame in frames)
        {
            if (i++ % speed == 0)
            {
                bt += btBy;
                frame.Mutate(x => x.BinaryThreshold(bt));
            }
        }
    }
}
