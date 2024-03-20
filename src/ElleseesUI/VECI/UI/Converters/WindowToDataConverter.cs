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

using ElleseesUI.Extensions;
using ElleseesUI.VECI.UI.ActionPicker.Actions;
using System.Windows;

namespace ElleseesUI.VECI.UI.Converters;

/// <summary>
/// Window to Data converter.
/// </summary>
internal static class WindowToDataConverter
{
    /// <summary>
    /// Converts Window to data that's ready to be rendered by the VECI renderer.
    /// </summary>
    public static (VECITaskKind taskKind, string args)? ToData(this Window window)
    {
        if (window is AddAudio addAudio)
        {
            if (addAudio.At != null)
            {
                return (VECITaskKind.AddAudio, $"at={StringifySpan(addAudio.At)}");
            }
        }

        if (window is ChangeAudioVolume changeAudioVolume)
        {
            if (changeAudioVolume.ReturnedVolume != null)
            {
                return (VECITaskKind.ChangeAudioVolume, $"start={StringifySpan(changeAudioVolume.Start)}|end={StringifySpan(changeAudioVolume.End)}|volume={changeAudioVolume.ReturnedVolume.Value}");
            }
        }

        if (window is ChangeGlobalAudioVolume changeGlobalAudioVolume)
        {
            if (changeGlobalAudioVolume.ResultVolume != null)
            {
                return (VECITaskKind.ChangeGlobalAudioVolume, $"volume={changeGlobalAudioVolume.ResultVolume.Value}");
            }
        }

        if (window is CutClipAt cutClipAt)
        {
            if (cutClipAt.Start != null)
            {
                return (VECITaskKind.CutClipAt, $"start={StringifySpan(cutClipAt.Start)}|end={StringifySpan(cutClipAt.End)}");
            }
        }

        if (window is InsertVideo insertVideo)
        {
            if (insertVideo.Start != null)
            {
                return (VECITaskKind.InsertVideo, $"start={StringifySpan(insertVideo.Start)}|end={StringifySpan(insertVideo.End)}");
            }
        }

        if (window is PushFileToStack pushFileToStack)
        {
            if (pushFileToStack.SelectedFile != null)
            {
                return (VECITaskKind.PushFileToStack, $"fileName={pushFileToStack.SelectedFile}");
            }
        }

        if (window is SpeedUpVideo speedUpVideo)
        {
            if (speedUpVideo.ReturnedSpeed != null)
            {
                return (VECITaskKind.SpeedUpVideo, $"speed={speedUpVideo.ReturnedSpeed}");
            }
        }

        throw new InvalidOperationException();

        static TimeSpan SpanOrZero(TimeSpan? span) => span ?? TimeSpan.Zero;
        static string StringifySpan(TimeSpan? span) => SpanOrZero(span).Stringify();
    }
}
