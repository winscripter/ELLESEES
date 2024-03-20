if (args.Length == 1)
{
    string dirpath = args[0];

    if (Directory.Exists(dirpath))
    {
        try
        {
            CopyDirectory("project_template", args[0], true);
            LogWithDt("[SUCCESS] Operation completed successfully");
        }
        catch (Exception ex)
        {
            LogWithDt($"[ERROR] An exception occurred whilst copying over the new project template. :( {Environment.NewLine} Stack trace:{Environment.NewLine}{ex.Message}");
        }
    }
    else
    {
        LogWithDt($"[ERROR] Directory {dirpath} does not exist");
    }
}
else if (args.Length == 0)
{
    LogWithDt("[ERROR] No arguments passed");
}
else
{
    LogWithDt("[ERROR] Only 1 argument is expected");
}

static void Log(string message)
{
    File.AppendAllText("CreateNewProject.log", $"[CreateNewProject]: {message}{Environment.NewLine}");
}

static void LogWithDt(string message)
{
    Log($"[{DateTime.Now}]: {message}");
}

static void CopyDirectory(string sourceDir, string destinationDir, bool recursive)
{
    var dir = new DirectoryInfo(sourceDir);

    if (dir.Exists)
    {
        DirectoryInfo[] dirs = dir.GetDirectories();

        Directory.CreateDirectory(destinationDir);

        foreach (FileInfo file in dir.GetFiles())
        {
            string targetFilePath = Path.Combine(destinationDir, file.Name);
            file.CopyTo(targetFilePath);
        }

        if (recursive)
        {
            foreach (DirectoryInfo subDir in dirs)
            {
                string newDestinationDir = Path.Combine(destinationDir, subDir.Name);
                CopyDirectory(subDir.FullName, newDestinationDir, true);
            }
        }
    }
}
