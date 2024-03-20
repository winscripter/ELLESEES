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

using ElleseesUI.Abstractions;
using ElleseesUI.Exceptions;

namespace ElleseesUI.Versioning;

/// <summary>
/// Represents the version of the application.
/// </summary>
public class ApplicationVersion : IValidatable
{
    /// <summary>
    /// Name of the file where data is read from.
    /// </summary>
    public const string Name = "app_version";

    /// <summary>
    /// Version string.
    /// </summary>
    public string Version { get; set; }

    /// <summary>
    /// Initializes a new instance of <see cref="ApplicationVersion" />.
    /// </summary>
    public ApplicationVersion()
    {
        Validate();
        Version = File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), "app_info", Name));
    }

    /// <inheritdoc />
    public bool IsValid()
        => File.Exists(Path.Combine(Directory.GetCurrentDirectory(), "app_info", Name));

    /// <inheritdoc />
    public void Validate()
        => ValidationException.ThrowFrom(this);

    /// <summary>
    /// Compares two <see cref="ApplicationVersion" /> instances.
    /// </summary>
    public static bool operator ==(ApplicationVersion left, ApplicationVersion right)
        => left.Version == right.Version;

    /// <summary>
    /// Compares two <see cref="ApplicationVersion" /> instances.
    /// </summary>
    public static bool operator !=(ApplicationVersion left, ApplicationVersion right)
        => !(left == right);

    /// <inheritdoc />
    public override int GetHashCode()
        => Version.GetHashCode();

    /// <inheritdoc />
    public override bool Equals(object? obj)
    {
        if (obj == null)
        {
            return false;
        }

        if (obj is not ApplicationVersion)
        {
            return false;
        }

        return this == (ApplicationVersion)obj;
    }
}
