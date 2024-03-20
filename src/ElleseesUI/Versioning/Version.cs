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

namespace ElleseesUI.Versioning;

/// <summary>
/// Versioning information about ELLESEES.
/// </summary>
public class Version
{
    /// <summary>
    /// Represents the copyright information about this application.
    /// </summary>
    public ApplicationCopyright? Copyright { get; private init; }

    /// <summary>
    /// Represents the developer of this application.
    /// </summary>
    public ApplicationDeveloper? Developer { get; private init; }

    /// <summary>
    /// Represents the display name of this application.
    /// </summary>
    public ApplicationDisplayName? DisplayName { get; private init; }

    /// <summary>
    /// Represents the primary developer of this application.
    /// </summary>
    public ApplicationPrimaryDeveloper? PrimaryDeveloper { get; private init; }

    /// <summary>
    /// Represents the version of this application.
    /// </summary>
    public ApplicationVersion? AppVersion { get; private init; }

    /// <summary>
    /// Initializes a new instance of <see cref="Version" />.
    /// </summary>
    public Version()
    {
        Copyright = new();
        Developer = new();
        DisplayName = new();
        PrimaryDeveloper = new();
        AppVersion = new();
    }

    /// <summary>
    /// Checks whether both <see cref="ApplicationVersion" /> are compatible.
    /// </summary>
    public bool AreCompatible(ApplicationVersion version)
    {
        return AppVersion! == version;
    }
}
