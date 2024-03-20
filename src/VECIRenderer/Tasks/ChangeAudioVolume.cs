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

using ElleseesUI.Extensions;
using ElleseesUI.VECI;
using VECIRenderer.Tasks.Abstractions;
using VideoSharp;

namespace VECIRenderer.Tasks;

internal class ChangeAudioVolume : ITask
{
    private readonly string _args;

    public ChangeAudioVolume(string args) => _args = args;

    public void Run()
    {
        var fileName = FileStack.Pop();

        TimeSpan start = VECIArgumentData.GetValueOfArgument(_args, "start").ToTimeSpan();
        TimeSpan end = VECIArgumentData.GetValueOfArgument(_args, "end").ToTimeSpan();
        int volume = Convert.ToInt32(VECIArgumentData.GetValueOfArgument(_args, "volume"));

        Video.LaunchAndWaitForFFmpeg($"-y -i \"{fileName}\" -af \"volume={volume / 100}:enable='between(t,{start.TotalSeconds},{end.TotalSeconds})'\" output.mp4");

        File.Delete(fileName);
        File.Move("output.mp4", fileName);
    }
}
