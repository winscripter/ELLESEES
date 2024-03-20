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

using Ellesees.Base.Common.Strings;
using System.Windows.Controls;

namespace ElleseesUI.Services.StatusBar;

/// <summary>
/// An implementation for the status bar service.
/// </summary>
internal class StatusBarService : IStatusBarService
{
    private readonly Label m_outputStatusBarText;
    private readonly Views.Timeline _timeline;

    /// <summary>
    /// Initializes a new instance of <see cref="StatusBarService" />
    /// </summary>
    /// <param name="outputStatusBarText">Text displayed on the status bar</param>
    /// <param name="timeline">Timeline instance where the actual status bar resides.</param>
    public StatusBarService(Label outputStatusBarText, Views.Timeline timeline)
    {
        m_outputStatusBarText = outputStatusBarText;
        _timeline = timeline;
    }

    /// <inheritdoc />
    public Label StatusBarText => m_outputStatusBarText;

    /// <inheritdoc />
    public void HideText() => SetText(string.Empty);

    /// <inheritdoc />
    public string IdleText => StringConstants.UI.IdleText;

    /// <inheritdoc />
    public void SetText(string text)
    {
        if (!_timeline.DoNotDisturb)
        {
            StatusBarText.Content = text;
        }
    }

    /// <inheritdoc />
    public void Idle() => SetText(IdleText);
}
