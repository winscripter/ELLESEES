using Renderer.ErdSupport;
using System.Runtime.Serialization;

namespace Renderer;

/// <summary>
/// Helper for executing ERD tasks
/// </summary>
internal static class ErdTaskRunner
{
    /// <summary>
    /// Runs ERD.
    /// </summary>
    /// <param name="cxt">Input ERD.</param>
    /// <returns>Amount of tasks ran.</returns>
    public static int RunAll(this ErdContext cxt)
    {
        int taskCount = 0;
        List<CommonTask> instances = new();

        foreach (var item in cxt.Items)
        {
            CommonTask instance = item.Name switch
            {
                "audioMute" => new AudioMuteTask(),
                "audioSound" => new AudioSoundTask(),
                "audioExtract" => new AudioExtractTask(),
                "audioAdd" => new AudioAddTask(),
                "insertVideo" => new VideoInsertTask(),
                "pushfs" => new PushToFileStackTask(),
                "popfs" => new PopFromFileStackTask(),
                "grayscalebt709" => new GrayscaleBt709(),
                "grayscalebt601" => new GrayscaleBt601(),
                "grayscale" => new Grayscale(),
                "saturate" => new Saturate(),
                "lightness" => new Lightness(),
                "brightness" => new Brightness(),
                "glow" => new Glow(),
                "glowBy" => new GlowBy(),
                "boxBlurDefault" => new BoxBlurDefault(),
                "boxBlur" => new BoxBlur(),
                "bokehBlur" => new BokehBlur(),
                "bokehBlurBy" => new BokehBlurBy(),
                "blackAndWhite" => new BlackAndWhite(),
                "contrastBy" => new ContrastBy(),
                "background" => new Background(),
                "colorBlindness" => new ColorBlindness(),
                "crop" => new Crop(),
                "resize" => new Resize(),
                "rotate" => new Rotate(),
                "gaussianBlur" => new GaussianBlur(),
                "scale" => new Scale(),
                "text" => new Text(),
                "rect" => new Rectangle(),
                "extractframesr" => new ExtractFrameRange(),
                "feactivate" => new ForEach(),
                "hue" => new Hue(),
                "cleanTemp" => new CleanTempTask(),
                _ => throw new InvalidOperationException($"Invalid ERD row: \"{item.Name}\""),
            };

            instances.Add(instance);
        }

        for (int i = 0; i < instances.Count; i++)
        {
            DebugLog.Write($"Got object \"{instances[i].GetType().Name}\". Attempting to run task...");
            DebugLog.Write($"ForEachTaskActivator.IsActivated returns {ForEachTaskActivator.IsActivated}.");

            if (ForEachTaskActivator.IsActivated)
            {
                DebugLog.Write($"ForEach task is enabled.");

                foreach (string file in Directory.GetFiles(ForEachTaskActivator.StorePath))
                {
                    DebugLog.Write($"ForEach task is enabled, current file is {file}");

                    _ = FileStack.PopOrNull();
                    FileStack.Add(file);

                    DebugLog.Write($"Running task {instances[i].GetType().Name}...");
                    instances[i].Run(cxt.Items[i]);
                    taskCount++;
                }

                DebugLog.Write($"ForEach task is now disabled.");

                _ = ForEachTaskActivator.Flip();
            }
            else
            {
                DebugLog.Write($"ForEach task is disabled.");

                instances[i].Run(cxt.Items[i]);
                taskCount++;
            }
        }

        return taskCount;
    }
}
