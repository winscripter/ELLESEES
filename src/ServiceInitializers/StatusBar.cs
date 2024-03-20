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

using ElleseesUI.Services.StatusBar;
using ElleseesUI.SharedControllers;
using ElleseesUI.Views;
using System.Windows.Controls;

namespace ElleseesUI.ServiceInitializers;

/// <summary>
/// Status Bar Service initializer
/// </summary>
internal static class StatusBar
{
    /// <summary>
    /// Initializes the service.
    /// </summary>
    /// <param name="output">Output status bar text.</param>
    /// <param name="timeline">The instance of timeline.</param>
    public static void Initialize(Label output, Timeline timeline)
    {
        var statusBarService = new StatusBarService(output, timeline);
        SharedUIController.StatusBarService = statusBarService;

        statusBarService.Idle();
    }
}
