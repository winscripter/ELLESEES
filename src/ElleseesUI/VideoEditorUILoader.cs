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

using ElleseesUI.CommonViewFramePages;
using ElleseesUI.ServiceInitializers;
using ElleseesUI.Views;

namespace ElleseesUI;

/// <summary>
/// Loads Video Editor UI
/// </summary>
internal static class VideoEditorUILoader
{
    /// <summary>
    /// Loads Video Editor normally without any projects.
    /// </summary>
    public static VideoEditorUI LoadNormallyWithoutProjects()
    {
        var window = new VideoEditorUI();
        var timeline = new Timeline();
        var fm = new EditingAreaFM();

        timeline.EditAreaView.Content = fm;
        timeline.Activate(0);

        window.CommonViewFrame.Content = timeline;

        FTU.Initialize();
        StatusBar.Initialize(timeline.Status, timeline);
        PropertyEditor.Initialize(window.PropertyEditorVisibility);

        return window;
    }

    /// <summary>
    /// Loads an error visibility into the Video Editor UI.
    /// </summary>
    public static VideoEditorUI LoadWithError()
    {
        var window = new VideoEditorUI();

        window.CommonViewFrame.Content = new Error();
        PropertyEditor.Initialize(window.PropertyEditorVisibility);

        return window;
    }
}
