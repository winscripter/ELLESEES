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

namespace ElleseesUI.Core.Common;

/// <summary>
/// Represents tips of the day
/// </summary>
internal static class TipOfTheDay
{
    /// <summary>
    /// A list of strings that appear as tips of the day
    /// </summary>
    public static readonly string[] Tips =
    {
        "ELLESEES is open-source on GitHub",
        "ELLESEES is not a word in any dictionary, but rather an abbrevation for 8 words: Edit Less - Less Editing; See Everywhere - Everyone Sees, more like \"edit - infer anywhere\". Maybe that sentence will make sense soon, ELLESEES is still in beta-testing stage :)",
        "In case of any issue or question, you can submit an issue or discussion on ELLESEES GitHub repository. We can help without any hesitation!",
        "ELLESEES has its own image editor bundled with it! It is intended to edit clips, so if you really need to work on complex image editing, you may want to use a different software for that. Popular options are Adobe Photoshop or GIMP.",
        "You're permitted to edit the source code and distribute ELLESEES, as long as you do not commit plagiarism (e.g. promoting yourself like you wrote all of it).",
        "ELLESEES operates on frames instead of video itself. This helps reduce memory usage, but the tradeoff is performance.",
        "ELLESEES has little to no system requirements",
        "It's considered bad practice to write ELLESEES without all letters being uppercase (f.e. Ellesees, ellesees) because it's an abbrevation for 8 words and could be mistaken with a word, which doesn't exist",
        "ELLESEES offers a wide variety of effects. However, you should use them wisely and carefully, as they utilize a ton of RAM, and could lead to crashes or data loss if there's not a lot of RAM free!",
        $"ELLESEES can run on any version of Windows, as long as .NET {Context.DotNetRuntimeVersion} supports it"
    };

    /// <summary>
    /// Chooses a random tip of the day from <see cref="Tips" /> array.
    /// </summary>
    /// <returns>A random tip of the day</returns>
    public static string Select()
        => Tips[Random.Shared.Next(1, Tips.Length) - 1];
}
