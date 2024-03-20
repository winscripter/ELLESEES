namespace Ellesees.Base.IO;

/// <summary>
/// Manages and locates fonts under <c>./fonts</c> directory
/// </summary>
public static class LocalFontManager
{
    /// <summary>
    /// A directory containing fonts accessiable by ELLESEES. Those do not require installation.<br /><br />
    /// 
    /// By default, ELLESEES is hardcoded to find fonts under <c>./fonts</c>.
    /// </summary>
    public const string FontsFolder = "./fonts";

    /// <summary>
    /// Retrieves all font providers
    /// </summary>
    /// <returns>A list of font providers under <c>./fonts</c></returns>
    public static string[] GetCompanies()
        => Directory.GetDirectories(FontsFolder);

    /// <summary>
    /// Retrieves all font categories from a provider
    /// </summary>
    /// <param name="company">Provider (under <c>./fonts</c>)</param>
    /// <returns>A list of font categories from a provider</returns>
    public static string[] GetFontsFromCompany(string company)
        => Directory.GetDirectories(company); // Has to be relative path to the company dir

    /// <summary>
    /// Returns TTF or WOFF files from a font category
    /// </summary>
    /// <param name="fontDir">Input path to the font category</param>
    /// <returns>TTF or WOFF files under the category</returns>
    public static string[] GetTtfsOrWoffs(string fontDir)
        => Directory.GetFiles(fontDir)
                    .Where(file => file.ToLower().EndsWith(".ttf") || file.ToLower().EndsWith(".woff"))
                    .ToArray();

    /// <summary>
    /// Returns TTF files from a font category
    /// </summary>
    /// <param name="fonts">Input path</param>
    /// <returns>TTF files from a font category</returns>
    public static string[] ByTtf(this string[] fonts)
        => fonts.Where(f => f.ToLower().EndsWith(".ttf")).ToArray();

    /// <summary>
    /// Returns WOFF files from a font category
    /// </summary>
    /// <param name="fonts">Input path</param>
    /// <returns>WOFF files from a font category</returns>
    public static string[] ByWoff(this string[] fonts)
        => fonts.Where(f => f.ToLower().EndsWith(".woff")).ToArray();
}
