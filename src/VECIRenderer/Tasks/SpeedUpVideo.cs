using ElleseesUI.VECI;
using VECIRenderer.Tasks.Abstractions;
using VideoSharp;

namespace VECIRenderer.Tasks;

internal class SpeedUpVideo : ITask
{
    private readonly string _args;

    public SpeedUpVideo(string args) => _args = args;

    public void Run()
    {
        string fileName = FileStack.Pop();
        int percentage = Convert.ToInt32(VECIArgumentData.GetValueOfArgument(_args, "speed"));

        Video.LaunchAndWaitForFFmpeg($"-y -i \"{fileName}\" -filter:v \"setpts=(1/{percentage / 100})*PTS\" -an output.mp4");

        File.Delete(fileName);
        File.Move("output.mp4", fileName);
    }
}
