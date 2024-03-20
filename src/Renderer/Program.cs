using Renderer;
using Renderer.ErdSupport;
using CommandLine;
using System.Diagnostics;

Stopwatch sw  = Stopwatch.StartNew();

Configuration.Load();

string? erdcontent = null;
Parser.Default.ParseArguments<AppCommandLine>(args).WithParsed(options =>
{
    if (options.FromErd == null)
    {
        Console.WriteLine($"No passed parameter \"--input\" (case insensitive).");

        return;
    }

    if (!File.Exists(options.FromErd))
    {
        Console.WriteLine($"ERD file not found: \"{options.FromErd}\"");
        
        return;
    }

    erdcontent = File.ReadAllText(options.FromErd);
});

if (erdcontent == null)
{
    Console.WriteLine($"No passed parameter \"--input\" (case insensitive).");

    return;
}

if (!Directory.Exists("./temp"))
{
    Directory.CreateDirectory("./temp");
}

var erd = new ErdContext(erdcontent);
int taskCount = ErdTaskRunner.RunAll(erd);

sw.Stop();
var elapsed = sw.Elapsed;

Console.WriteLine($"\n\nExporting completed successfully. Hooray!\n\n");
Console.WriteLine($"----------=====Summary=====----------");
Console.WriteLine($"Elapsed: {elapsed}");
Console.WriteLine($"Total amount of tasks ran: {taskCount}");
Console.WriteLine($"----------=====Summary=====----------");
