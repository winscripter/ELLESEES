using Ellesees.Base;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

namespace Ellesees.Effects.Common.Text.Inline;

public class TextDiagonallyMovingDownLeftInline : Effect
{
    public override void Begin(Image<Rgba32>[] frames, string[] args)
    {
        RequireArgumentCount(args, 4);

        string options = args[0];
        int speed = int.Parse(args[1]);
        int startx = int.Parse(args[2]);
        int starty = int.Parse(args[3]);

        var opt = TextOptionsParser.Parse(options);

        int x = startx;
        int y = starty;

        int i = 0;
        foreach (Image<Rgba32> frame in frames)
        {
            if (speed % i++ != 0)
            {
                var obj = new ImageObject(frame);

                obj.AddText((opt with
                {
                    Position = new PointF(x, y)
                })
                .ToContext());

                x--;
                y--;
            }
        }
    }
}
