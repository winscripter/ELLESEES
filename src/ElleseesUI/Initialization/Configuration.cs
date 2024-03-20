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

using Microsoft.Extensions.Configuration;
using System.Text;

namespace ElleseesUI.Initialization;

/// <summary>
/// Represents data from Ellesees.cfg.
/// </summary>
internal class Configuration
{
    /// <summary>
    /// Value of the easter egg "IEnjoyUsingELLESEES".
    /// </summary>
    public const string EasterEggValue
        = "oksowithoutlookingintothesourcecodenobodywilleverfindthisstringandsetitintotheconfigurationfilelikeitssolongwhoisevengoingtotrythis";

    private readonly string _configFileName;

    /// <summary>
    /// Default hardcoded configuration filename.
    /// </summary>
    public const string ConfigurationFileName = "Ellesees.cfg";

    /// <summary>
    /// Should ELLESEES ignore the First Time Use (FTU) service?
    /// </summary>
    public bool? IgnoreFtu { get; set; }

    /// <summary>
    /// Should ELLESEES force the First Time Use (FTU) service?
    /// </summary>
    public bool? ForceFtu { get; set; }

    /// <summary>
    /// Easter egg.
    /// </summary>
    public bool? IEnjoyUsingEllesees { get; set; }

    /// <summary>
    /// Path to the JSON file containing the UI Theme. If this is null or empty,
    /// it defaults to ELLESEES' predefined dark theme.
    /// </summary>
    public string? UIThemePath { get; set; }

    /// <summary>
    /// Initializes a new instance of <see cref="Configuration" />
    /// </summary>
    /// <param name="configFileName">Path to ELLESEES configuration file</param>
    /// <exception cref="InitializationException"></exception>
    public Configuration(string? configFileName)
    {
        if (configFileName == null)
        {
            _configFileName = string.Empty;

            return;
        }

        _configFileName = configFileName;

        if (!File.Exists(_configFileName))
        {
            throw new InitializationException($"Configuration file \"{_configFileName}\" wasn't found");
        }

        Parse();
    }

    /// <summary>
    /// Parses the configuration file.
    /// </summary>
    /// <exception cref="InitializationException">An error parsing the configuration file.</exception>
    /// <exception cref="FormatException">Invalid ini content</exception>
    /// <exception cref="FileNotFoundException">Configuration file not found</exception>
    private void Parse()
    {
        var builder = new ConfigurationBuilder()
                          .SetBasePath(Directory.GetCurrentDirectory())
                          .AddIniFile(_configFileName);

        var configuration = builder.Build();

        string? ignoreFtu = configuration["FTU:IgnoreFtu"];
        string? forceFtu = configuration["FTU:ForceFtu"];
        string? ienjoyusingellesees = configuration["lol:IEnjoyUsingELLESEES"];
        string? uiThemePath = configuration["UI:UIThemePath"];

        if (ignoreFtu != null)
        {
            IgnoreFtu = ignoreFtu.ToLower() == "true";
        }

        if (forceFtu != null)
        {
            ForceFtu = forceFtu.ToLower() == "true";
        }

        if (ienjoyusingellesees == EasterEggValue)
        {
            IEnjoyUsingEllesees = true;
        }

        if (uiThemePath != null)
        {
            UIThemePath = uiThemePath;
        }

        if ((IgnoreFtu ?? false) && (ForceFtu ?? false))
        {
            throw new InitializationException($"IgnoreFtu and ForceFtu cannot be both true.");
        }
    }

    /// <summary>
    /// Uses default settings.
    /// </summary>
    public void UseDefaultSettings()
    {
        IgnoreFtu = ForceFtu = IEnjoyUsingEllesees = false;
        UIThemePath = string.Empty; // Empty string defaults to ELLESEES' predefined dark theme
    }

    /// <summary>
    /// Saves settings from this instance of <see cref="Configuration" /> to the configuration file named <paramref name="config" />.
    /// </summary>
    /// <exception cref="InitializationException">Thrown when the saving progress failed.</exception>
    public void SaveAs(string config)
    {
        try
        {
            StringBuilder sb = new();

            sb.AppendLine($"[FTU]");
            
            if (IgnoreFtu != null)
            {
                sb.AppendLine($"IgnoreFtu={IgnoreFtu.ToString()!.ToLower()}");
            }

            if (ForceFtu != null)
            {
                sb.AppendLine($"ForceFtu={ForceFtu.ToString()!.ToLower()}");
            }

            sb.AppendLine();
            if (IEnjoyUsingEllesees is not false and not null)
            {
                sb.AppendLine($"[lol]");
                sb.AppendLine($"IEnjoyUsingELLESEES={EasterEggValue}");
                sb.AppendLine();
            }

            if (UIThemePath != null)
            {
                sb.AppendLine("[UI]");
                sb.AppendLine($"UIThemePath={UIThemePath}");
                sb.AppendLine();
            }

            File.WriteAllText(config, sb.ToString());
        }
        catch
        {
            throw new InitializationException($"Cannot save configuration file.");
        }
    }
}
