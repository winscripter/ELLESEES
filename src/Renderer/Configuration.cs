using Microsoft.Extensions.Configuration;

namespace Renderer;

/// <summary>
/// Represents configuration data.
/// </summary>
public static class Configuration
{
    /// <summary>
    /// Checks whether the configuration was initiated.
    /// </summary>
    public static bool IsInitialized { get; private set; } = false;

    private static string _baseFontsPath = string.Empty;

    /// <summary>
    /// Path where fonts are stored.
    /// </summary>
    public static string BaseFontsPath
    {
        get
        {
            RequireInitialization();
            return _baseFontsPath;
        }
        private set
        {
            _baseFontsPath = value;
        }
    }

    /// <summary>
    /// Throws an exception if configuration isn't yet initialized.
    /// </summary>
    /// <exception cref="Exception">Configuration isn't initialized.</exception>
    public static void RequireInitialization()
    {
        if (!IsInitialized)
        {
            throw new Exception("Cannot access this property because it is not initialized");
        }
    }

    /// <summary>
    /// Loads statistics from the configuration file.
    /// </summary>
    /// <exception cref="FileNotFoundException">Configuration file isn't found.</exception>
    /// <exception cref="InvalidOperationException">Configuration file has invalid settings.</exception>
    public static void Load()
    {
        if (!File.Exists("renderersettings.ini"))
        {
            throw new FileNotFoundException($"Configuration file can't be found.");
        }

        var builder = new ConfigurationBuilder()
                          .SetBasePath(Directory.GetCurrentDirectory())
                          .AddIniFile("renderersettings.ini");

        var configuration = builder.Build();

        BaseFontsPath = configuration["Paths:BaseFontsPath"] ?? throw new InvalidOperationException("Missing property BaseFontsPath under section Paths.");
        IsInitialized = true;
    }
}
