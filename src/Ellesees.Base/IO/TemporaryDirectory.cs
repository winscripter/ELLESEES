namespace Ellesees.Base.IO;

/// <summary>
/// Manipulates the temporary directory
/// </summary>
public static class TemporaryDirectory
{
    /// <summary>
    /// A path to the temporary directory
    /// </summary>
    public const string Path = "./temp";

    /// <summary>
    /// Creates the temporary directory if it doesn't exist
    /// </summary>
    public static void EnsureExists()
    {
        if (!Directory.Exists(Path))
        {
            Directory.CreateDirectory(Path);
        }
    }

    /// <summary>
    /// Checks whether the temporary directory exists or not
    /// </summary>
    public static bool Exists
    {
        get
        {
            return Directory.Exists(Path);
        }
    }

    /// <summary>
    /// Empties the contents of the temporary directory
    /// </summary>
    public static void CleanUp()
    {
        if (!Exists)
        {
            return;
        }

        Directory.Delete(Path, true);

        EnsureExists();
    }
}
