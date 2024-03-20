// MIT License
// 
// Copyright (c) 2024 winscripter
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.
//

namespace ElleseesUI.Initialization;

/// <summary>
/// Helper for restoring the configuration file to its defaults in case
/// of a failure.
/// </summary>
internal static class ConfigurationRecovery
{
    /// <summary>
    /// Checks whether the configuration file can be written and read.
    /// </summary>
    /// <param name="configurationFile">Configuration file</param>
    /// <returns><see langword="true" /> if the file can be both written and read, <see langword="false" /> otherwise.</returns>
    public static bool IsAccessible(string configurationFile)
    {
        try
        {
            File.WriteAllText(configurationFile, File.ReadAllText(configurationFile));

            return true;
        }
        catch
        {
            return false;
        }
    }

    /// <summary>
    /// Default file content of the configuration file.
    /// </summary>
    public static string InitialConfigurationContent
    {
        get => @"[FTU]
IgnoreFtu=false
ForceFtu=false

[UI]
";
  
    }

    /// <summary>
    /// Alias for <see cref="File.Exists(string?)" />.
    /// </summary>
    /// <param name="configurationFile">Configuration file.</param>
    /// <returns><see langword="true" /> if configuration file exists, <see langword="false" /> otherwise.</returns>
    public static bool Exists(string configurationFile)
        => File.Exists(configurationFile);

    /// <summary>
    /// Restores configuration file to its defaults if it does not exist.
    /// </summary>
    /// <param name="configurationFile">Configuration filename.</param>
    public static void Restore(string configurationFile)
    {
        if (!Exists(configurationFile))
        {
            File.WriteAllText(configurationFile, InitialConfigurationContent);
        }
    }

    /// <summary>
    /// Writes default content to the configuration file.
    /// </summary>
    /// <param name="configurationFile">Configuration file.</param>
    public static void OverwriteToDefaults(string configurationFile)
    {
        File.WriteAllText(configurationFile, InitialConfigurationContent);
    }
}
