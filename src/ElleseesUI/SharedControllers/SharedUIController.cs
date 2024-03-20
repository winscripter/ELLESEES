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

using ElleseesUI.Services.PropertyEditor;
using ElleseesUI.Services.StatusBar;

namespace ElleseesUI.SharedControllers;

/// <summary>
/// Shared UI Management system
/// </summary>
internal static class SharedUIController
{
    private static PropertyEditorService? _propertyEditorService;

    /// <summary>
    /// Gets or sets the shared Property Editor service, e.g. UI displayed in the
    /// property editor dialog.
    /// </summary>
    public static PropertyEditorService? PropertyEditorService
    {
        get => _propertyEditorService;
        set => _propertyEditorService = value;
    }

    /// <summary>
    /// Checks whether the property editor service was initiated.
    /// </summary>
    /// <returns><see langword="true"/> if the property editor service was initiated, <see langword="false"/> otherwise</returns>
    public static bool IsPropertyEditorServiceLoaded() => _propertyEditorService != null;

    /// <summary>
    /// Throws an InvalidOperationException if the property editor service is not initialized.
    /// </summary>
    /// <exception cref="InvalidOperationException">Thrown when the property editor service is unavailable.</exception>
    public static void ThrowIfPropertyEditorServiceNotInitialized()
        => _ = _propertyEditorService ?? throw new InvalidOperationException("Property Editor Service is currently unavailable");

    private static StatusBarService? _statusBarService;

    /// <summary>
    /// Gets or sets the shared Status Bar service, e.g. UI displayed on the
    /// status bar.
    /// </summary>
    public static StatusBarService? StatusBarService
    {
        get => _statusBarService;
        set => _statusBarService = value;
    }

    /// <summary>
    /// Checks whether the status bar service was initiated.
    /// </summary>
    /// <returns><see langword="true"/> if the status bar service was initiated, <see langword="false"/> otherwise</returns>
    public static bool IsStatusBarServiceLoaded() => _statusBarService != null;

    /// <summary>
    /// Throws an InvalidOperationException if the status bar service is not initialized.
    /// </summary>
    /// <exception cref="InvalidOperationException">Thrown when the status bar service is unavailable.</exception>
    public static void ThrowIfStatusBarServiceNotInitialized()
        => _ = _statusBarService ?? throw new InvalidOperationException("Status Bar Service is currently unavailable");
}
