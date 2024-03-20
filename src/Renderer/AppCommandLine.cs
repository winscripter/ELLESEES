using CommandLine;

namespace Renderer;

/// <summary>
/// Command line options for the renderer.
/// </summary>
internal class AppCommandLine
{
    /// <summary>
    /// Required <c>--input</c> case-sensitive parameter being the input ERD file.
    /// </summary>
    [Option('i', "input", Required = true, HelpText = "File where ERD content is read from to produce a rendering logic")]
    public string? FromErd { get; set; }
}
