using Ellesees.Base.Context;
using Ellesees.Base.ImageHandling;
using Renderer.ErdSupport;
using Renderer.Extensions;
using SixLabors.Fonts;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Drawing.Processing;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;
using System.Globalization;
using VideoSharp;

namespace Renderer;

/// <summary>
/// A task to mute a clip from a video
/// </summary>
internal class AudioMuteTask : CommonTask
{
    /// <summary>
    /// Initializes this task.
    /// </summary>
    public AudioMuteTask()
        : base(TaskKind.AudioMuteTask)
    {
    }

    /// <inheritdoc />
    public override void Run(ErdItem item)
    {
        var videoAbsolutePath = item.SearchKey("videoPath").Value;
        var startSec = item.SearchKey("startSec").Value.AsSingle();
        var endSec = item.SearchKey("endSec").Value.AsSingle();

        Console.WriteLine($"I want to mute audio...");
        Console.WriteLine($"Absolute path: {videoAbsolutePath}");
        Console.WriteLine($"Start: {startSec}");
        Console.WriteLine($"End: {endSec}");

        //Audio.MuteWait(videoAbsolutePath, startSec, endSec, videoAbsolutePath);
    }
}

/// <summary>
/// A task to change the sound volume from a clip
/// </summary>
internal class AudioSoundTask : CommonTask
{
    /// <summary>
    /// Initializes this task.
    /// </summary>
    public AudioSoundTask()
        : base(TaskKind.AudioSoundTask)
    {
    }

    /// <inheritdoc />
    public override void Run(ErdItem item)
    {
        var videoAbsolutePath = item.SearchKey("videoPath").Value;
        var startSec = item.SearchKey("startSec").Value.AsSingle();
        var endSec = item.SearchKey("endSec").Value.AsSingle();
        var volume = item.SearchKey("value").Value.AsSingle();

        Console.WriteLine($"I want to change audio sound...");
        Console.WriteLine($"Video: {videoAbsolutePath}");
        Console.WriteLine($"Start: {startSec}");
        Console.WriteLine($"End: {endSec}");
        Console.WriteLine($"Volume: {volume}");

        //Audio.ChangeVolumeWait(videoAbsolutePath, volume, startSec, endSec, videoAbsolutePath);
    }
}

/// <summary>
/// A task to extract the MP3 audio out of a clip
/// </summary>
internal class AudioExtractTask : CommonTask
{
    /// <summary>
    /// Initializes this task.
    /// </summary>
    public AudioExtractTask()
        : base(TaskKind.AudioExtractTask)
    {
    }

    /// <inheritdoc />
    public override void Run(ErdItem item)
    {
        var videoAbsolutePath = item.SearchKey("videoPath").Value;
        var outputPath = item.SearchKey("outputPath").Value;

        Audio.ExtractWait(videoAbsolutePath, outputPath);
    }
}

/// <summary>
/// A task to add audio within a given period of time to a clip
/// </summary>
internal class AudioAddTask : CommonTask
{
    /// <summary>
    /// Initializes this task.
    /// </summary>
    public AudioAddTask()
        : base(TaskKind.AudioAddTask)
    {
    }

    /// <inheritdoc />
    public override void Run(ErdItem item)
    {
        var videoAbsolutePath = item.SearchKey("videoPath").Value;
        var outputPath = item.SearchKey("outputPath").Value;

        Audio.ExtractWait(videoAbsolutePath, outputPath);
    }
}

/// <summary>
/// A task to insert a video to a video
/// </summary>
internal class VideoInsertTask : CommonTask
{
    /// <summary>
    /// Initializes this task.
    /// </summary>
    public VideoInsertTask()
        : base(TaskKind.InsertVideo)
    {
    }

    /// <inheritdoc />
    public override void Run(ErdItem item)
    {
        var videoPath = item.ValueOf("videoPath");
        var insertVidPath = item.ValueOf("insertVidPath");
        var start = item.ValueOf("start").AsSingle();
        var end = item.ValueOf("end").AsSingle();

        Video.InsertVideoWait(videoPath, insertVidPath, start, end, videoPath);
    }
}

/// <summary>
/// A task to add file to file stack.
/// </summary>
internal class PushToFileStackTask : CommonTask
{
    /// <summary>
    /// Initializes this task.
    /// </summary>
    public PushToFileStackTask()
        : base(TaskKind.PushToFileStack)
    {
    }

    /// <inheritdoc />
    public override void Run(ErdItem item)
    {
        var path = item.ValueOf("path");

        FileStack.Add(path);
    }
}

/// <summary>
/// A task to pop file from file task.
/// </summary>
internal class PopFromFileStackTask : CommonTask
{
    /// <summary>
    /// Initializes this task.
    /// </summary>
    public PopFromFileStackTask()
        : base(TaskKind.PopFromFileStack)
    {
    }

    /// <inheritdoc />
    public override void Run(ErdItem item)
    {
        _ = FileStack.Pop();
    }
}

/// <summary>
/// A task to apply BT.709 grayscaling to an image
/// </summary>
internal class GrayscaleBt709 : CommonTask
{
    /// <summary>
    /// Initializes this task.
    /// </summary>
    public GrayscaleBt709()
        : base(TaskKind.GrayscaleBt709)
    {
    }

    /// <inheritdoc />
    public override void Run(ErdItem item)
    {
        var image = Image.Load(FileStack.Peek());
        image.Mutate(x => x.Grayscale(GrayscaleMode.Bt709));
        image.Save(FileStack.Peek());
    }
}

/// <summary>
/// A task to apply BT.601 grayscaling to an image
/// </summary>
internal class GrayscaleBt601 : CommonTask
{
    /// <summary>
    /// Initializes this task.
    /// </summary>
    public GrayscaleBt601()
        : base(TaskKind.GrayscaleBt601)
    {
    }

    /// <inheritdoc />
    public override void Run(ErdItem item)
    {
        var image = Image.Load(FileStack.Peek());
        image.Mutate(x => x.Grayscale(GrayscaleMode.Bt601));
        image.Save(FileStack.Peek());
    }
}

/// <summary>
/// A task to apply custom grayscaling to an image.
/// </summary>
internal class Grayscale : CommonTask
{
    /// <summary>
    /// Initializes this task.
    /// </summary>
    public Grayscale()
        : base(TaskKind.Grayscale)
    {
    }

    /// <inheritdoc />
    public override void Run(ErdItem item)
    {
        float by = Convert.ToSingle(item.ValueOf("by"), CultureInfo.InvariantCulture);

        var image = Image.Load(FileStack.Peek());
        image.Mutate(x => x.Grayscale(by));
        image.Save(FileStack.Peek());
    }
}

/// <summary>
/// A task to apply saturation to an image.
/// </summary>
internal class Saturate : CommonTask
{
    /// <summary>
    /// Initializes this task.
    /// </summary>
    public Saturate()
        : base(TaskKind.Saturate)
    {
    }

    /// <inheritdoc />
    public override void Run(ErdItem item)
    {
        float by = Convert.ToSingle(item.ValueOf("by"), CultureInfo.InvariantCulture);

        var image = Image.Load(FileStack.Peek());
        image.Mutate(x => x.Saturate(by));
        image.Save(FileStack.Peek());
    }
}

/// <summary>
/// A task to apply lightness to an image.
/// </summary>
internal class Lightness : CommonTask
{
    /// <summary>
    /// Initializes this task.
    /// </summary>
    public Lightness()
        : base(TaskKind.Lightness)
    {
    }

    /// <inheritdoc />
    public override void Run(ErdItem item)
    {
        float by = Convert.ToSingle(item.ValueOf("by").Replace(",", "."), CultureInfo.InvariantCulture);
        DebugLog.Write($"Brightness is {by}");

        var image = Image.Load(FileStack.Peek());
        image.Mutate(x => x.Lightness(by));
        image.Save(FileStack.Peek());
    }
}

/// <summary>
/// A task to apply brightness to an image.
/// </summary>
internal class Brightness : CommonTask
{
    /// <summary>
    /// Initializes this task.
    /// </summary>
    public Brightness()
        : base(TaskKind.Brightness)
    {
    }

    /// <inheritdoc />
    public override void Run(ErdItem item)
    {
        float by = Convert.ToSingle(item.ValueOf("by"), CultureInfo.InvariantCulture);

        var image = Image.Load(FileStack.Peek());
        image.Mutate(x => x.Brightness(by));
        image.Save(FileStack.Peek());
    }
}

/// <summary>
/// A task to apply glowing to an image.
/// </summary>
internal class Glow : CommonTask
{
    /// <summary>
    /// Initializes this task.
    /// </summary>
    public Glow()
        : base(TaskKind.Glow)
    {
    }

    /// <inheritdoc />
    public override void Run(ErdItem item)
    {
        var image = Image.Load(FileStack.Peek());
        image.Mutate(x => x.Glow());
        image.Save(FileStack.Peek());
    }
}

/// <summary>
/// A task to apply custom glowing to an image.
/// </summary>
internal class GlowBy : CommonTask
{
    /// <summary>
    /// Initializes this task.
    /// </summary>
    public GlowBy()
        : base(TaskKind.GlowBy)
    {
    }

    /// <inheritdoc />
    public override void Run(ErdItem item)
    {
        float by = Convert.ToSingle(item.ValueOf("by"), CultureInfo.InvariantCulture);
        string color = item.ValueOf("color");

        var image = Image.Load(FileStack.Peek());
        image.Mutate(x => x.Glow(Rgba32.ParseHex(color), by, new SixLabors.ImageSharp.Rectangle(
                                                0,
                                                0,
                                                image.Width,
                                                image.Height
                                            )));
        image.Save(FileStack.Peek());
    }
}

/// <summary>
/// A task to apply box blur to an image using default settings.
/// </summary>
internal class BoxBlurDefault : CommonTask
{
    /// <summary>
    /// Initializes this task.
    /// </summary>
    public BoxBlurDefault()
        : base(TaskKind.BoxBlurDefault)
    {
    }

    /// <inheritdoc />
    public override void Run(ErdItem item)
    {
        var image = Image.Load(FileStack.Peek());
        image.Mutate(x => x.BoxBlur());
        image.Save(FileStack.Peek());
    }
}

/// <summary>
/// A task to apply box blur to an image using default settings.
/// </summary>
internal class BoxBlur : CommonTask
{
    /// <summary>
    /// Initializes this task.
    /// </summary>
    public BoxBlur()
        : base(TaskKind.BoxBlur)
    {
    }

    /// <inheritdoc />
    public override void Run(ErdItem item)
    {
        int by = Convert.ToInt32(item.ValueOf("by"));

        var image = Image.Load(FileStack.Peek());
        image.Mutate(x => x.BoxBlur(by));
        image.Save(FileStack.Peek());
    }
}

/// <summary>
/// A task to apply bokeh blur to an image.
/// </summary>
internal class BokehBlurBy : CommonTask
{
    /// <summary>
    /// Initializes this task.
    /// </summary>
    public BokehBlurBy()
        : base(TaskKind.BokehBlurBy)
    {
    }

    /// <inheritdoc />
    public override void Run(ErdItem item)
    {
        int radius = Convert.ToInt32(item.ValueOf("radius"));
        int components = Convert.ToInt32(item.ValueOf("components"));
        float gamma = Convert.ToSingle(item.ValueOf("gamma"), CultureInfo.InvariantCulture);

        var image = Image.Load(FileStack.Peek());
        image.Mutate(x => x.BokehBlur(radius, components, gamma));
        image.Save(FileStack.Peek());
    }
}

/// <summary>
/// A task to apply bokeh blur to an image using default settings.
/// </summary>
internal class BokehBlur : CommonTask
{
    /// <summary>
    /// Initializes this task.
    /// </summary>
    public BokehBlur()
        : base(TaskKind.BokehBlur)
    {
    }

    /// <inheritdoc />
    public override void Run(ErdItem item)
    {
        var image = Image.Load(FileStack.Peek());
        image.Mutate(x => x.BokehBlur());
        image.Save(FileStack.Peek());
    }
}

/// <summary>
/// A task to apply Black &amp; White to an image.
/// </summary>
internal class BlackAndWhite : CommonTask
{
    /// <summary>
    /// Initializes this task.
    /// </summary>
    public BlackAndWhite()
        : base(TaskKind.BlackAndWhite)
    {
    }

    /// <inheritdoc />
    public override void Run(ErdItem item)
    {
        var image = Image.Load(FileStack.Peek());
        image.Mutate(x => x.BlackWhite());
        image.Save(FileStack.Peek());
    }
}

/// <summary>
/// A task for applying contrast to an image.
/// </summary>
internal class ContrastBy : CommonTask
{
    /// <summary>
    /// Initializes this task.
    /// </summary>
    public ContrastBy()
        : base(TaskKind.ContrastBy)
    {
    }

    /// <inheritdoc />
    public override void Run(ErdItem item)
    {
        float ctr = Convert.ToSingle(item.ValueOf("by"), CultureInfo.InvariantCulture);

        var image = Image.Load(FileStack.Peek());
        image.Mutate(x => x.Contrast(ctr));
        image.Save(FileStack.Peek());
    }
}

/// <summary>
/// A task for applying contrast to an image.
/// </summary>
internal class Background : CommonTask
{
    /// <summary>
    /// Initializes this task.
    /// </summary>
    public Background()
        : base(TaskKind.Background)
    {
    }

    /// <inheritdoc />
    public override void Run(ErdItem item)
    {
        Rgba32 color = Rgba32.ParseHex(item.ValueOf("color"));

        var image = Image.Load(FileStack.Peek());
        image.Mutate(x => x.BackgroundColor(color));
        image.Save(FileStack.Peek());
    }
}

/// <summary>
/// A task for applying color blindness to an image.
/// </summary>
internal class ColorBlindness : CommonTask
{
    /// <summary>
    /// Initializes this task.
    /// </summary>
    public ColorBlindness()
        : base(TaskKind.ColorBlindness)
    {
    }

    /// <inheritdoc />
    public override void Run(ErdItem item)
    {
        ColorBlindnessMode cbm = (ColorBlindnessMode)Convert.ToInt32(item.ValueOf("mode"));

        var image = Image.Load(FileStack.Peek());
        image.Mutate(x => x.ColorBlindness(cbm));
        image.Save(FileStack.Peek());
    }
}

/// <summary>
/// A task to resize an image to something smaller.
/// </summary>
internal class Crop : CommonTask
{
    /// <summary>
    /// Initializes this task.
    /// </summary>
    public Crop()
        : base(TaskKind.Crop)
    {
    }

    /// <inheritdoc />
    public override void Run(ErdItem item)
    {
        int xc = Convert.ToInt32(item.ValueOf("x"));
        int yc = Convert.ToInt32(item.ValueOf("y"));

        var image = Image.Load(FileStack.Peek());
        image.Mutate(x => x.Crop(xc, yc));
        image.Save(FileStack.Peek());
    }
}

/// <summary>
/// A task to resize an image.
/// </summary>
internal class Resize : CommonTask
{
    /// <summary>
    /// Initializes this task.
    /// </summary>
    public Resize()
        : base(TaskKind.Resize)
    {
    }

    /// <inheritdoc />
    public override void Run(ErdItem item)
    {
        int xc = Convert.ToInt32(item.ValueOf("x"));
        int yc = Convert.ToInt32(item.ValueOf("y"));

        var image = Image.Load(FileStack.Peek());
        image.Mutate(x => x.Resize(xc, yc));
        image.Save(FileStack.Peek());
    }
}

/// <summary>
/// A task to rotates an image by a specified amout of degrees.
/// </summary>
internal class Rotate : CommonTask
{
    /// <summary>
    /// Initializes this task.
    /// </summary>
    public Rotate()
        : base(TaskKind.Rotate)
    {
    }

    /// <inheritdoc />
    public override void Run(ErdItem item)
    {
        int deg = Convert.ToInt32(item.ValueOf("deg"));

        var image = Image.Load(FileStack.Peek());
        image.Mutate(x => x.Rotate(deg));
        image.Save(FileStack.Peek());
    }
}

/// <summary>
/// A task to apply gaussian blur to an image.
/// </summary>
internal class GaussianBlur : CommonTask
{
    /// <summary>
    /// Initializes this task.
    /// </summary>
    public GaussianBlur()
        : base(TaskKind.GaussianBlur)
    {
    }

    /// <inheritdoc />
    public override void Run(ErdItem item)
    {
        float sigma = Convert.ToSingle(item.ValueOf("sigma"), CultureInfo.InvariantCulture);

        var image = Image.Load(FileStack.Peek());
        image.Mutate(x => x.GaussianBlur(sigma));
        image.Save(FileStack.Peek());
    }
}

/// <summary>
/// Applies Hue to an image.
/// </summary>
internal class Hue : CommonTask
{
    /// <summary>
    /// Initializes this task.
    /// </summary>
    public Hue()
        : base(TaskKind.Hue)
    {
    }

    public override void Run(ErdItem item)
    {
        int by = Convert.ToInt32(item.ValueOf("by"));

        var image = Image.Load(FileStack.Peek());
        image.Mutate(x => x.Hue(by));
        image.Save(FileStack.Peek());
    }
}

/// <summary>
/// A task to apply scaling (a.k.a. zoom in &amp; out) to an image.
/// </summary>
internal class Scale : CommonTask
{
    /// <summary>
    /// Initializes this task.
    /// </summary>
    public Scale()
        : base(TaskKind.Scale)
    {
    }

    /// <inheritdoc />
    public override void Run(ErdItem item)
    {
        int x = Convert.ToInt32(item.ValueOf("x"));
        int y = Convert.ToInt32(item.ValueOf("y"));

        var image = Image.Load(FileStack.Peek());
        Zoom.ZoomImage(ref image, x, y);
        image.Save(FileStack.Peek());
    }
}

/// <summary>
/// A task to draw text on an image.
/// </summary>
internal class Text : CommonTask
{
    /// <summary>
    /// Initializes this task.
    /// </summary>
    public Text()
        : base(TaskKind.Text)
    {
    }

    /// <inheritdoc />
    public override void Run(ErdItem item)
    {
        string fontPath = Path.Combine(Configuration.BaseFontsPath, item.ValueOf("fontPath"));
        string text = item.ValueOf("text");
        Rgba32 foreground = Rgba32.ParseHex(item.ValueOf("foreground"));
        Rgba32? shadowForeground = item.ValueOf("shadow_fg") == "null"
                                   ? null
                                   : Rgba32.ParseHex(item.ValueOf("shadow_fg"));
        int? shadowSigma = item.ValueOf("shadow_sigma") == "null"
                           ? null
                           : Convert.ToInt32(item.ValueOf("shadow_sigma"));
        int fontSize = Convert.ToInt32(item.ValueOf("fontSize"));
        PointF pos = new(Convert.ToInt32(item.ValueOf("x")), Convert.ToInt32(item.ValueOf("y")));

        FontCollection collection = new();
        var family = collection.Add(fontPath);
        var font = family.CreateFont(fontSize);

        TextContext cxt = new(text, fontPath, fontSize, font, FontStyle.Regular /*doesn't matter here*/, foreground, pos, shadowForeground == null ? null : new Ellesees.Base.Shadow(shadowForeground ?? new(0F, 0F, 0F, 0F), shadowSigma ?? 0));

        var image = Image.Load<Rgba32>(FileStack.Peek());

        cxt.DrawOn(image, shadowForeground == null ? null : new Ellesees.Base.TextShadowOptions(new Ellesees.Base.Shadow(shadowForeground ?? new(0F, 0F, 0F, 1F), shadowSigma ?? 0), pos, new Point(3, 3)));

        image.Save(FileStack.Peek());
    }
}

/// <summary>
/// A task to draw a rectangle on an image.
/// </summary>
internal class Rectangle : CommonTask
{
    /// <summary>
    /// Initializes this task.
    /// </summary>
    public Rectangle()
        : base(TaskKind.Rectangle)
    {
    }

    /// <inheritdoc />
    public override void Run(ErdItem item)
    {
        int x1 = Convert.ToInt32(item.ValueOf("x1"));
        int y1 = Convert.ToInt32(item.ValueOf("y1"));
        int x2 = Convert.ToInt32(item.ValueOf("x2"));
        int y2 = Convert.ToInt32(item.ValueOf("y2"));
        Rgba32 color = Rgba32.ParseHex(item.ValueOf("color"));

        var image = Image.Load(FileStack.Peek());

        var rectangle = new SixLabors.ImageSharp.Rectangle(x1, y1, x2 - x1, y2 - y1);
        var brush = new SolidBrush(color);

        image.Mutate(ctx => ctx.Fill(brush, rectangle));

        image.Save(FileStack.Peek());
    }
}

/// <summary>
/// A task to extract frames from a video between two time spans into the output directory.
/// </summary>
internal class ExtractFrameRange : CommonTask
{
    /// <summary>
    /// Initializes this task.
    /// </summary>
    public ExtractFrameRange()
        : base(TaskKind.ExtractFrameRange)
    {
    }

    /// <inheritdoc />
    public override void Run(ErdItem item)
    {
        TimeSpan start = item.ValueOf("start").ToTimeSpan();
        float ss = Convert.ToSingle($"{start.TotalSeconds}.{start.Milliseconds}", CultureInfo.InvariantCulture);

        TimeSpan end = item.ValueOf("end").ToTimeSpan();
        float es = Convert.ToSingle($"{end.TotalSeconds}.{end.Milliseconds}", CultureInfo.InvariantCulture);

        string outputFormat = item.ValueOf("output");
        
        Helpers.ExportFramesBetween(ss, es, FileStack.Peek(), outputFormat);
    }
}

internal class ForEach : CommonTask
{
    /// <summary>
    /// Initializes this task.
    /// </summary>
    public ForEach()
        : base(TaskKind.ForEach)
    {
    }

    /// <inheritdoc />
    public override void Run(ErdItem item)
    {
        string path = item.ValueOf("path");

        _ = ForEachTaskActivator.Flip();
        ForEachTaskActivator.StorePath = path;

        string enabledOrDisabled = ForEachTaskActivator.IsActivated ? "enabled" : "disabled";
        Console.WriteLine($"[DEBUG] The ForEach task is now {enabledOrDisabled}.");
    }
}

/// <summary>
/// A task to clean the temp folder.
/// </summary>
internal class CleanTempTask : CommonTask
{
    /// <summary>
    /// Initializes this task.
    /// </summary>
    public CleanTempTask()
        : base(TaskKind.CleanTemp)
    {
    }

    /// <inheritdoc />
    public override void Run(ErdItem item)
    {
        TimeSpan at = item.ValueOf("at").ToTimeSpan();
        string fileName = FileStack.Peek();

        DebugLog.Write($"Launching FFmpeg with the preceding args:");
        DebugLog.Write($"-i \"{fileName}\" -itsoffset {at.TotalSeconds}.{at.Milliseconds} -i temp/frame%04d.png -lavfi \"overlay=eof_action=pass\" out.mp4");

        _ = Video.LaunchAndRedirectFFmpegOutput($"-i \"{fileName}\" -itsoffset {at.TotalSeconds}.{at.Milliseconds} -i temp/frame%04d.png -lavfi \"overlay=eof_action=pass\" out.mp4");

        File.Delete(fileName);
        File.Move("out.mp4", fileName);

        if (Directory.Exists("./temp"))
        {
            Directory.Delete("./temp", true);
        }

        Directory.CreateDirectory("./temp");
    }
}
