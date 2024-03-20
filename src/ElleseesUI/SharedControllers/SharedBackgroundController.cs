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

using ElleseesUI.Initialization;
using ElleseesUI.Services.FTU;

namespace ElleseesUI.SharedControllers;

/// <summary>
/// Shared Background Management System
/// </summary>
internal static class SharedBackgroundController
{
    private static FtuService? _ftuService;

    /// <summary>
    /// Gets or sets the FTU service, e.g. a background service that checks
    /// whenever this is the first time user uses ELLESEES.
    /// </summary>
    public static FtuService? FtuService
    {
        get => _ftuService;
        set => _ftuService = value;
    }

    /// <summary>
    /// Checks whether the FTU service was initiated.
    /// </summary>
    /// <returns><see langword="true"/> if the FTU service was initiated, <see langword="false"/> otherwise</returns>
    public static bool IsFtuServiceLoaded() => _ftuService != null;

    /// <summary>
    /// Throws an InvalidOperationException if the FTU service is not initialized.
    /// </summary>
    /// <exception cref="InvalidOperationException">Thrown when the FTU service is unavailable.</exception>
    public static void ThrowIfFtuServiceNotInitialized()
        => _ = _ftuService ?? throw new InvalidOperationException($"The FTU service is currently unavailable");

    private static Configuration? _configuration;

    /// <summary>
    /// Gets or sets the configuration, e.g. ELLESEES settings.
    /// </summary>
    public static Configuration? Configuration
    {
        get => _configuration;
        set => _configuration = value;
    }

    /// <summary>
    /// Checks whether the configuration was initiated.
    /// </summary>
    /// <returns><see langword="true"/> if the configuration was initiated, <see langword="false"/> otherwise</returns>
    public static bool IsConfigurationLoaded() => _configuration != null;

    /// <summary>
    /// Throws an InvalidOperationException if the configuration is not initialized.
    /// </summary>
    /// <exception cref="InvalidOperationException">Thrown when the configuration is unavailable.</exception>
    public static void ThrowIfConfigurationNotLoaded()
        => _ = _configuration ?? throw new InvalidOperationException($"Configuration is currently unavailable");

    private static Versioning.Version? _version;

    /// <summary>
    /// Gets or sets the software version.
    /// </summary>
    public static Versioning.Version? Version
    {
        get => _version;
        set => _version = value;
    }

    /// <summary>
    /// Checks whether <see cref="Version" /> was loaded.
    /// </summary>
    /// <returns><see langword="true" /> if <see cref="Version" /> was loaded, <see langword="false" /> otherwise.</returns>
    public static bool IsVersionLoaded() => _version != null;

    /// <summary>
    /// Throws an InvalidOperationException if version is not initialized.
    /// </summary>
    /// <exception cref="InvalidOperationException">Thrown when version is unavailable.</exception>
    public static void ThrowIfVersionNotLoaded()
        => _ = _version ?? throw new InvalidOperationException($"Version is currently unavailable");
}
