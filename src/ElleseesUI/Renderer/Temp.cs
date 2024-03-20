namespace Renderer;

/// <summary>
/// Represents ELLESEES Renderer Temp folder.
/// </summary>
internal static class Temp
{
    /// <summary>
    /// Name of the Temp folder where base temporary ELLESEES files are stored.
    /// </summary>
    public const string Name = "ELLESEES";

    /// <summary>
    /// Name of the folder inside ELLESEES inside %TEMP% where Renderer-specific data is stored.
    /// </summary>
    public const string RendererFolder = "RendererProcess";

    /// <summary>
    /// Path to %TEMP%\Name\RendererFolder.
    /// </summary>
    public static string FolderPath => Path.Combine(Path.GetTempPath(), Name, RendererFolder);

    /// <summary>
    /// Checks whether <see cref="FolderPath" /> exists or not.
    /// </summary>
    /// <returns><see langword="true" /> if <see cref="FolderPath" /> exists, <see langword="false" /> otherwise.</returns>
    public static bool Exists() => Directory.Exists(FolderPath);

    /// <summary>
    /// Recreates the ELLESEES Renderer temporary storage folder structure if it doesn't exist.
    /// </summary>
    public static void EnsureExists()
    {
        if (!Directory.Exists(Path.Combine(Path.GetTempPath(), Name)))
        {
            Directory.CreateDirectory(Path.Combine(Path.GetTempPath(), Name));
        }

        if (!Directory.Exists(FolderPath))
        {
            Directory.CreateDirectory(FolderPath);
        }
    }

    /// <summary>
    /// Generates an absolute path to a folder with a completely random name inside Temp.<br /><br />
    /// 
    /// Take this. The probability of a duplicate is nearly impossible. The random characters used
    /// are <c>abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890_</c> (knowing Windows
    /// paths are case-insensitive). The probability of a duplicate is (amount of letters) ^ (folder length).
    /// Folder length is 32, e.g. every generated folder is 32-characters long. Amount of letters is,
    /// 37 to be exact. We ignore casing because, again, Windows paths are case-insensitive. So, the
    /// probability of a duplicate is <b>a staggering</b> (<i>!</i>) 1/(37 ^ 32). 37 ^ 32 equals to: <br />
    /// <i>152214200233450528559804138174517974884637692126081</i>
    /// <br />
    /// So, even if ELLESEES becomes a popular software I wish, it's very unlikely that a duplicate will
    /// ever occur.<br /><br />
    /// 
    /// Either way, if a duplicate occurs, ELLESEES will just generate another folder name using the exact
    /// same algorithm, which will be more impossible to cause a 2nd duplicate.
    /// </summary>
    /// <returns>An absolute path to the generated</returns>
    public static string GenerateSuitableName()
    {
        string s = Path.Combine(FolderPath, GenerateRandomString());
        while (Directory.Exists(s))
        {
            s = Path.Combine(FolderPath, GenerateRandomString());
        }

        return s;

        static string GenerateRandomString()
        {
            const string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890_";
            return new string(Enumerable.Repeat(chars, 32)
                .Select(s => s[Random.Shared.Next(s.Length)]).ToArray());
        }
    }
}
