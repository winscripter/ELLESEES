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

using ElleseesUI.VECI.UI.DisplayActions.Actions;
using System.Collections.ObjectModel;

namespace ElleseesUI.VECI.UI.DisplayActions;

/// <summary>
/// An extension class that helps bind actions to <see cref="ObservableCollection{T}" />.
/// </summary>
internal static class UIActionDisplayTask
{
    /// <summary>
    /// Binds all actions to <paramref name="actions" />.
    /// </summary>
    /// <param name="actions">Collection where actions will bind to.</param>
    public static void BindToActions(this ObservableCollection<IDisplayAction> actions)
    {
        actions.Clear();

        actions.Add(new AddAudio());
        actions.Add(new ChangeAudioVolume());
        actions.Add(new ChangeGlobalAudioVolume());
        actions.Add(new CutClipAt());
        actions.Add(new InsertVideo());
        actions.Add(new SpeedUpVideo());
        actions.Add(new PushToFileStack());
    }
}
