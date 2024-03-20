string[] requiredFiles =
{
    "./app_info/app_dev",
    "./app_info/app_dev_begin",
    "./app_info/app_primary_dev",
    "./app_info/app_publish_year",
    "./app_info/app_version"
};

foreach (string file in requiredFiles)
{
    if (!File.Exists(file))
    {
        Console.WriteLine($"Warning: Required file {file} wasn't found. You may receive a .NET exception if you try to use this file with AppInfoFetcher.");
    }
}

if (args.Length != 1)
{
    Console.WriteLine($"[ERROR]: Expected 1 command-line argument, got {args.Length}");
}
else
{
    switch (args[0].ToLower().Trim())
    {
        case "--dev":
        case "--d":
        case "dev":
            Console.WriteLine(
                File.ReadAllText(
                    "./app_info/app_dev"
                )
            );
            break;
        case "--primary-dev":
        case "--pd":
        case "primary-dev":
            Console.WriteLine(
                File.ReadAllText(
                    "./app_info/app_primary_dev"
                )
            );
            break;
        case "--dev-begin":
        case "--db":
        case "dev-begin":
            Console.WriteLine(
                File.ReadAllText(
                    "./app_info/app_dev_begin"
                )
            );
            break;
        case "--publish-year":
        case "--py":
        case "publish-year":
            Console.WriteLine(
                File.ReadAllText(
                    "./app_info/app_publish_year"
                )
            );
            break;
        case "--version":
        case "--v":
        case "version":
            Console.WriteLine(
                File.ReadAllText(
                    "./app_info/app_version"
                )
            );
            break;
        default:
            Console.WriteLine("USAGE: AppInfoFetcher <argument>");
            Console.WriteLine("Retrieves information about this version of ELLESEES.");
            Console.WriteLine($"This data can be modified by editing the content of different files from the app_info folder from the installation directory{Environment.NewLine}");

            Console.WriteLine("<argument> can be:");
            Console.WriteLine("    --dev, --d, dev: Who developed this version of ELLESEES?");
            Console.WriteLine("    --primary-dev, --pd, primary-dev: Who was the first person developing ELLESEES?");
            Console.WriteLine("    --dev-begin, --db, dev-begin: In which date has ELLESEES development begun?");
            Console.WriteLine("    --publish-year, --py, publish-year: When was this version of ELLESEES published?");
            Console.WriteLine("    --version, --v, version: What version of ELLESEES is this?");
            Console.WriteLine();

            Console.WriteLine("Note: While you may not need most of this information, we do, which is why we still provide them for you.");
            break;
    }
}
