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

using ElleseesUI.Tasks;

namespace ElleseesUI.SharedControllers;

/// <summary>
/// Shared controller for tasks that reside in the <c>ElleseesUI.Tasks</c> namespace.
/// </summary>
internal static class SharedTaskController
{
    private static SetCorruptProjectMode? _setCorruptProjectMode;

    /// <summary>
    /// Gets or sets the Set Corrupt Project Mode task, which
    /// notifies the user about project corruption or unexpected
    /// error.
    /// </summary>
    public static SetCorruptProjectMode? SetCorruptProjectMode
    {
        get => _setCorruptProjectMode;
        set => _setCorruptProjectMode = value;
    }

    /// <summary>
    /// Checks whether Set Corrupt Project Mode task was initialized.
    /// </summary>
    /// <returns><see langword="true" /> if Set Corrupt Project Mode task was initialized, <see langword="false" /> otherwise.</returns>
    public static bool IsSetCorruptProjectModeTaskInitialized()
        => _setCorruptProjectMode != null;
    
    /// <summary>
    /// Throws <see cref="InvalidOperationException" /> if <see cref="SetCorruptProjectMode" /> wasn't initialized.
    /// </summary>
    /// <exception cref="InvalidOperationException">Thrown when <see cref="SetCorruptProjectMode" /> is unavailable.</exception>
    public static void ThrowIfSetCorruptProjectModeTaskNotInitialized()
        => _ = _setCorruptProjectMode ?? throw new InvalidOperationException("Set Corrupt Project Mode task is currently unavailable.");
}
