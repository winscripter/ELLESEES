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

using ElleseesUI.Controls.TimelineObjects;
using System.Windows;

namespace ElleseesUI.Services.Timeline;

/// <summary>
/// A service for displaying objects on the timeline.
/// </summary>
public class TimelineObjectUIService
{
    /// <summary>
    /// Text objects.
    /// </summary>
    public TextVisibility[] Text { get; private init; }

    /// <summary>
    /// Audio objects.
    /// </summary>
    public AudioVisibility[] Audio { get; private init; }

    /// <summary>
    /// Video objects.
    /// </summary>
    public VideoVisibility[] Video { get; private init; }

    /// <summary>
    /// Image objects.
    /// </summary>
    public ImageVisibility[] Image { get; private init; }

    /// <summary>
    /// Effect objects.
    /// </summary>
    public EffectVisibility[] Effect { get; private init; }

    /// <summary>
    /// Initializes a new instance of <see cref="TimelineObjectUIService" />.
    /// </summary>
    /// <param name="text">Initial value for <see cref="Text" />.</param>
    /// <param name="audio">Initial value for <see cref="Audio" />.</param>
    /// <param name="video">Initial value for <see cref="Video" />.</param>
    /// <param name="image">Initial value for <see cref="Image" />.</param>
    /// <param name="effect">Initial value for <see cref="Effect" />.</param>
    public TimelineObjectUIService(TextVisibility[] text, AudioVisibility[] audio, VideoVisibility[] video, ImageVisibility[] image, EffectVisibility[] effect)
    {
        Text = text;
        Audio = audio;
        Video = video;
        Image = image;
        Effect = effect;
    }

    /// <summary>
    /// Hides all text objects displayed on the timeline.
    /// </summary>
    public void HideAllTextObjects()
    {
        foreach (var obj in Text)
        {
            obj.Visibility = Visibility.Hidden;
        }
    }

    /// <summary>
    /// Hides all audio objects displayed on the timeline.
    /// </summary>
    public void HideAllAudioObjects()
    {
        foreach (var aud in Audio)
        {
            aud.Visibility = Visibility.Hidden;
        }
    }

    /// <summary>
    /// Hides all video objects displayed on the timeline.
    /// </summary>
    public void HideAllVideoObjects()
    {
        foreach (var vid in Video)
        {
            vid.Visibility = Visibility.Hidden;
        }
    }

    /// <summary>
    /// Hides all image objects displayed on the timeline.
    /// </summary>
    public void HideAllImageObjects()
    {
        foreach (var img in Image)
        {
            img.Visibility = Visibility.Hidden;
        }
    }

    /// <summary>
    /// Hides all effect objects displayed on the timeline.
    /// </summary>
    public void HideAllEffectObjects()
    {
        foreach (var eff in Effect)
        {
            eff.Visibility = Visibility.Hidden;
        }
    }

    /// <summary>
    /// Hides all objects based on types.
    /// </summary>
    /// <param name="kind">Types of objects.</param>
    public void HideAll(TimelineObjectKind kind)
    {
        if (kind.HasFlag(TimelineObjectKind.Audio))
        {
            HideAllAudioObjects();
        }

        if (kind.HasFlag(TimelineObjectKind.Video))
        {
            HideAllVideoObjects();
        }

        if (kind.HasFlag(TimelineObjectKind.Image))
        {
            HideAllImageObjects();
        }

        if (kind.HasFlag(TimelineObjectKind.Effect))
        {
            HideAllEffectObjects();
        }

        if (kind.HasFlag(TimelineObjectKind.Text))
        {
            HideAllTextObjects();
        }
    }
}
