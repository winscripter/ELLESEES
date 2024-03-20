using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

namespace Ellesees.Effects;

public record Rgba(float R, float G, float B, float A);

public abstract class Effect
{
    public abstract void Begin(Image<Rgba32>[] frames, string[] args);

    private object? _effect;

    public void Initialize(object effect)
    {
        _effect = effect;
    }

    public bool IsInitialized
    {
        get
        {
            return _effect is not null;
        }
    }

    public void Execute(Image<Rgba32>[] frames, string[] args)
    {
        Begin(frames, args);
    }

    protected static void RequireArgumentCount(string[] args, int count)
    {
        if (args.Length != count)
        {
            throw new ArgumentException($"Expecting {count} args; passed {args.Length}");
        }
    }
}
