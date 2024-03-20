namespace Renderer;

/// <summary>
/// Represents types of tasks
/// </summary>
internal enum TaskKind : byte
{
    /// <summary>
    /// A task to mute audio. Used by <see cref="Renderer.AudioMuteTask" />
    /// </summary>
    AudioMuteTask,

    /// <summary>
    /// A task to change volume. Used by <see cref="Renderer.AudioSoundTask" />
    /// </summary>
    AudioSoundTask,

    /// <summary>
    /// A task to extract audio from a video. Used by <see cref="Renderer.AudioExtractTask" />
    /// </summary>
    AudioExtractTask,

    /// <summary>
    /// A task to add audio to a video. Used by <see cref="Renderer.AudioAddTask" />
    /// </summary>
    AudioAddTask,

    /// <summary>
    /// A task to insert a video at a specific time to a video. Used by <see cref="Renderer.VideoInsertTask" />
    /// </summary>
    InsertVideo,

    /// <summary>
    /// Pushes a file to file stack.
    /// </summary>
    PushToFileStack,

    /// <summary>
    /// Pops a file from file stack.
    /// </summary>
    PopFromFileStack,

    /// <summary>
    /// Applies BT.709 grayscaling to an image.
    /// </summary>
    GrayscaleBt709,

    /// <summary>
    /// Applies BT.601 grayscaling to an image.
    /// </summary>
    GrayscaleBt601,

    /// <summary>
    /// Applies custom grayscaling to an image.
    /// </summary>
    Grayscale,

    /// <summary>
    /// Applies custom saturation to an image.
    /// </summary>
    Saturate,

    /// <summary>
    /// Applies custom lightness to an image.
    /// </summary>
    Lightness,

    /// <summary>
    /// Applies custom brightness to an image.
    /// </summary>
    Brightness,

    /// <summary>
    /// Applies default glowing to the center of the image.
    /// </summary>
    Glow,

    /// <summary>
    /// Applies custom glowing to an image.
    /// </summary>
    GlowBy,

    /// <summary>
    /// Applies Box Blur to an image using default settings.
    /// </summary>
    BoxBlurDefault,

    /// <summary>
    /// Applies Box Blur to an image with custom preferences.
    /// </summary>
    BoxBlur,

    /// <summary>
    /// Applies default Bokeh Blur to an image.
    /// </summary>
    BokehBlur,

    /// <summary>
    /// Applies custom Bokeh Blur to an image.
    /// </summary>
    BokehBlurBy,

    /// <summary>
    /// Applies Black &amp; White effect to an image.
    /// </summary>
    BlackAndWhite,

    /// <summary>
    /// Applies Contrast effect to an image.
    /// </summary>
    ContrastBy,

    /// <summary>
    /// Applies Background to an image.
    /// </summary>
    Background,

    /// <summary>
    /// Applies Color Blindness to an image.
    /// </summary>
    ColorBlindness,

    /// <summary>
    /// Crops the image to smaller resolution.
    /// </summary>
    Crop,

    /// <summary>
    /// Resizes the image to a new resolution.
    /// </summary>
    Resize,

    /// <summary>
    /// Rotates the image by degrees.
    /// </summary>
    Rotate,

    /// <summary>
    /// Applies Gaussian Blur to an image.
    /// </summary>
    GaussianBlur,

    /// <summary>
    /// Applies Hue to an image.
    /// </summary>
    Hue,

    /// <summary>
    /// Applies scaling (aka zoom in &amp; out) to an image.
    /// </summary>
    Scale,

    /// <summary>
    /// Applies text to an image.
    /// </summary>
    Text,

    /// <summary>
    /// Draws a rectangle on an image.
    /// </summary>
    Rectangle,

    /// <summary>
    /// A task to extract frames from a video within the specified duration of time.
    /// </summary>
    ExtractFrameRange,

    /// <summary>
    /// A task to loop the next task <i>n</i> amount of times, where <i>n</i> is the amount of files
    /// in the specified directory. This can be useful to manage all frames which could be unpredictable
    /// count.
    /// </summary>
    ForEach,

    /// <summary>
    /// Cleans the Temp folder.
    /// </summary>
    CleanTemp
}
