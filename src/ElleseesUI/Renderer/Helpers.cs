using VideoSharp;

namespace Renderer;

internal static class Helpers
{
    /// <summary>
    /// Exports all frames between the selected range of time.
    /// </summary>
    /// <param name="start">Start</param>
    /// <param name="end">End</param>
    /// <param name="videoFile">Video file</param>
    /// <param name="outputFormat">Output image files (frames) format</param>
    public static void ExportFramesBetween(float start, float end, string videoFile, string outputFormat)
    {
        Video.EnsureFFmpegExists();
        
        Video.LaunchAndWaitForFFmpeg($"-i \"{videoFile}\" -vf \"select='between(t\\,{start}\\,{end})'\" -vsync vfr \"{outputFormat}\" -start_number 0");
    }
}
