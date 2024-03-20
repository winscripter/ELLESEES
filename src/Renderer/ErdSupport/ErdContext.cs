﻿using System.Text.RegularExpressions;

namespace Renderer.ErdSupport;

/// <summary>
/// Provides support for ERD (ELLESEES Rendering Data)
/// </summary>
internal class ErdContext
{
    private readonly List<ErdItem> _items;

    private readonly Dictionary<string, int> BasedOnKindReplicationCounts = new()
    {
        { "text", 9 }, // text fontRelativePath="string" fontForegroundRGBA="rgba" textShadowColorRGBA="rgba" textShadowSigma="4" allowsShadow="False" fontStyle="regular" startX="64" startY="64" fontSize="20"
        { "gaussianBlur", 1 }, // gaussianBlur sigma="4.0"
        { "bokehBlur", 3 }, // bokehBlur radius="4" components="4" gamma="4.0"
        { "boxBlur", 1 }, // boxBlur value="4 (or null)"
        { "brightness", 1 }, // brightness value="0.7"
        { "colorBlindness", 1 }, // colorBlindness value="achromatomaly | achromatopsia | deuteranomaly | deuteranopia | protanomaly | protanopia | tritanomaly | tritanopia"
        { "contrast", 1 }, // contrast value="0.78"
        { "crop", 2 }, // crop x="320" y="320"
        { "glowBy", 2 }, // glowBy color="rgba" by="100"
        { "grayscale", 1 }, // grayscale value="1.25 | bt709 | bt601"
        { "hue", 1 }, // hue value="180"
        { "lightness", 1 }, // lightness value="1.25"
        { "rectangleFill", 5 }, // rectangleFill x1="20" y1="20" x2="70" y2="70" color="rgba"
        { "resize", 2 }, // resize x="256" y="256"
        { "rotate", 1 }, // rotate deg="-90"
        { "saturation", 1 }, // saturation by="1.5"
        { "scale", 2 }, // scale x="-60" y="260"
    };

    /// <summary>
    /// Initializes a new instance of <see cref="ErdContext" />
    /// </summary>
    /// <param name="erdContent">A content of the ERD file</param>
    public ErdContext(string erdContent)
    {
        _items = new();

        erdContent = erdContent.Replace("\r\n", "\n");

        _items = ParseErd(erdContent).ToList();
    }

    // This method below was generated using Artificial Intelligence.
    // Generated by Microsoft Edge Copilot (it's underrated, trust me).

    /// <summary>
    /// Generated by AI; Parses the ERD file syntax
    /// </summary>
    /// <param name="input">Input ERD file content</param>
    /// <returns>A parsed ERD</returns>
    private static ErdItem[] ParseErd(string input)
    {
        string[] lines = input.Split('\n').Where(line => !string.IsNullOrEmpty(line) && !string.IsNullOrWhiteSpace(line))
                                          .ToArray();

        var items = new List<ErdItem>();

        int fileln = 0;
        foreach (string line in lines)
        {
            DebugLog.Write($"From ERD file, line is {++fileln}.");

            string name = line.Split(' ')[0];

            var pairs = new List<ErdPair>();

            MatchCollection matches = Regex.Matches(line, @"(\w+)=""(.*?)""");

            foreach (Match match in matches.Cast<Match>())
            {
                string key = match.Groups[1].Value;
                string value = match.Groups[2].Value;

                var pair = new ErdPair(key, value);

                pairs.Add(pair);
            }

            var item = new ErdItem(name, pairs.ToArray());

            items.Add(item);
        }

        return items.ToArray();
    }

    /// <summary>
    /// Gets parsed ERD items
    /// </summary>
    public List<ErdItem> Items { get { return _items; } }
}
