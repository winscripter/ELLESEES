// MIT License
// 
// Copyright (c) 2024 winscripter
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.
//

using VideoSharp;

namespace ElleseesUI.Helpers;

internal static class FFprobeHelpers
{
    public static (int width, int height) GetVideoDimensions(string video)
    {
        Video.EnsureFFprobeExists();

        var output = Video.LaunchAndRedirectFFprobeOutput($"-v error -show_entries stream=width,height -of default=noprint_wrappers=1 \"{video}\"").Replace("\r\n", "\n");

        return (
            Convert.ToInt32(output.Split('\n')[0].Split('=')[1]),
            Convert.ToInt32(output.Split('\n')[1].Split('=')[1])
        );
    }

    public static float GetFps(string video)
    {
        float fps = Video.GetFpsCount(video);

        return (float)Math.Round(fps);
    }

    public static int GetFrameCount(string video)
    {
        Video.EnsureFFmpegExists();

        string parameters = $"-v error -select_streams v:0 -count_packets -show_entries stream=nb_read_packets -of csv=p=0 \"{video}\"";

        var output = Video.LaunchAndRedirectFFprobeOutput(parameters);

        try
        {
            return int.Parse(output);
        }
        catch
        {
            throw new InvalidOperationException("The video file is invalid");
        }
    }
}
