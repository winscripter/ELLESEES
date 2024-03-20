// Program requires VECI directory

using VECIRenderer.Context;
using VECIRenderer.Tasks;

if (args.Length == 0)
{
    return;
}

string veciFile = args[0];

if (!Directory.Exists(veciFile))
{
    return;
}

Console.WriteLine("----------------------------------------");
Console.WriteLine("VECI Renderer, version 1.0, for ELLESEES");
Console.WriteLine("----------------------------------------");

VECIFile file = VECIFile.Load(veciFile);

foreach (VECIPair task in file.Project!.Value.Tasks)
{
    var type = (VECITaskKind)task.Type;
    string arg = task.Arguments!;

    Console.WriteLine($"Task type is {type}");
    Console.WriteLine($"Args are {task.Arguments}");

    switch (type)
    {
        case VECITaskKind.AddAudio: new AddAudio(arg).Run(); break;
        case VECITaskKind.InsertVideo: new InsertVideo(arg).Run(); break;
        case VECITaskKind.ChangeAudioVolume: new ChangeAudioVolume(arg).Run(); break;
        case VECITaskKind.ChangeGlobalAudioVolume: new ChangeGlobalAudioVolume(arg).Run(); break;
        case VECITaskKind.CutClipAt: new CutVideoAt(arg).Run(); break;
        case VECITaskKind.PushFileToStack: new PushFileToStack(arg).Run(); break;
        case VECITaskKind.SpeedUpVideo: new SpeedUpVideo(arg).Run(); break;
    }
}

Console.WriteLine("\n\nOperation completed successfully.");
