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

using Ellesees.ProjectParser.ProjectInfo;
using Ellesees.ProjectParser.ProjectInfo.Abstractions;
using Ellesees.ProjectParser.ProjectInfo.ImageObjectModels;
using ElleseesUI.Abstractions;
using ElleseesUI.Extensions;
using ElleseesUI.ProjectInfrastructure;
using ElleseesUI.Views;
using System.Windows;

namespace ElleseesUI.Tasks;

/// <summary>
/// A task to scroll the timeline left.
/// </summary>
public class ScrollLeft : ITask
{
    private readonly Timeline editor;
    private readonly VideoProject project;

    /// <summary>
    /// Initializes a new instance of <see cref="ScrollLeft" />
    /// </summary>
    /// <param name="editor">Base editor.</param>
    /// <param name="project">Project.</param>
    public ScrollLeft(Timeline editor, VideoProject project)
    {
        this.editor = editor;
        this.project = project;
    }

    /// <inheritdoc />
    public void Run()
    {
        editor.TimelineShiftSpansBack();
        editor.HideTimelineChildObjects();

        // Text objects
        if (FilterBy(editor.TimeService.Span, typeof(Text)).Length != 0)
        {
            editor.Text1.DisplayedText.Text = $"{FilterBy(editor.TimeService.Span, typeof(Text)).Length} items";
            editor.Text1.Visibility = Visibility.Visible;
        }

        if (FilterBy(editor.TimeService.Span.Add(new(0, 0, 1)), typeof(Text)).Length != 0)
        {
            editor.Text2.DisplayedText.Text = $"{FilterBy(editor.TimeService.Span.Add(new(0, 0, 1)), typeof(Text)).Length} items";
            editor.Text2.Visibility = Visibility.Visible;
        }

        if (FilterBy(editor.TimeService.Span.Add(new(0, 0, 2)), typeof(Text)).Length != 0)
        {
            editor.Text3.DisplayedText.Text = $"{FilterBy(editor.TimeService.Span.Add(new(0, 0, 2)), typeof(Text)).Length} items";
            editor.Text3.Visibility = Visibility.Visible;
        }

        if (FilterBy(editor.TimeService.Span.Add(new(0, 0, 3)), typeof(Text)).Length != 0)
        {
            editor.Text4.DisplayedText.Text = $"{FilterBy(editor.TimeService.Span.Add(new(0, 0, 3)), typeof(Text)).Length} items";
            editor.Text4.Visibility = Visibility.Visible;
        }

        // Image objects
        if (FilterBy(editor.TimeService.Span, typeof(Image)).Length != 0)
        {
            editor.Image1.DisplayedText.Text = $"{FilterBy(editor.TimeService.Span, typeof(Image)).Length} items";
            editor.Image1.Visibility = Visibility.Visible;
        }

        if (FilterBy(editor.TimeService.Span.Add(new(0, 0, 1)), typeof(Image)).Length != 0)
        {
            editor.Image2.DisplayedText.Text = $"{FilterBy(editor.TimeService.Span.Add(new(0, 0, 1)), typeof(Image)).Length} items";
            editor.Image2.Visibility = Visibility.Visible;
        }

        if (FilterBy(editor.TimeService.Span.Add(new(0, 0, 2)), typeof(Image)).Length != 0)
        {
            editor.Image3.DisplayedText.Text = $"{FilterBy(editor.TimeService.Span.Add(new(0, 0, 2)), typeof(Image)).Length} items";
            editor.Image3.Visibility = Visibility.Visible;
        }

        if (FilterBy(editor.TimeService.Span.Add(new(0, 0, 3)), typeof(Image)).Length != 0)
        {
            editor.Image4.DisplayedText.Text = $"{FilterBy(editor.TimeService.Span.Add(new(0, 0, 3)), typeof(Image)).Length} items";
            editor.Image4.Visibility = Visibility.Visible;
        }

        // Effect objects
        if (FilterBy(editor.TimeService.Span, typeof(Effect)).Length != 0)
        {
            editor.Effect1.DisplayedText.Text = $"{FilterBy(editor.TimeService.Span, typeof(Effect)).Length} items";
            editor.Effect1.Visibility = Visibility.Visible;
        }

        if (FilterBy(editor.TimeService.Span.Add(new(0, 0, 1)), typeof(Effect)).Length != 0)
        {
            editor.Effect2.DisplayedText.Text = $"{FilterBy(editor.TimeService.Span.Add(new(0, 0, 1)), typeof(Effect)).Length} items";
            editor.Effect2.Visibility = Visibility.Visible;
        }

        if (FilterBy(editor.TimeService.Span.Add(new(0, 0, 2)), typeof(Effect)).Length != 0)
        {
            editor.Effect3.DisplayedText.Text = $"{FilterBy(editor.TimeService.Span.Add(new(0, 0, 2)), typeof(Effect)).Length} items";
            editor.Effect3.Visibility = Visibility.Visible;
        }

        if (FilterBy(editor.TimeService.Span.Add(new(0, 0, 3)), typeof(Effect)).Length != 0)
        {
            editor.Effect4.DisplayedText.Text = $"{FilterBy(editor.TimeService.Span.Add(new(0, 0, 3)), typeof(Effect)).Length} items";
            editor.Effect4.Visibility = Visibility.Visible;
        }
        // Other effect objects

        if (ModelsAtE(editor.TimeService.Span).Length != 0)
        {
            editor.Effect1.DisplayedText.Text = $"{ModelsAtE(editor.TimeService.Span).Length} items";
            editor.Effect1.Visibility = Visibility.Visible;
        }

        if (ModelsAtE(editor.TimeService.Span.Add(new(0, 0, 1))).Length != 0)
        {
            editor.Effect2.DisplayedText.Text = $"{ModelsAtE(editor.TimeService.Span.Add(new(0, 0, 1))).Length} items";
            editor.Effect2.Visibility = Visibility.Visible;
        }

        if (ModelsAtE(editor.TimeService.Span.Add(new(0, 0, 2))).Length != 0)
        {
            editor.Effect3.DisplayedText.Text = $"{ModelsAtE(editor.TimeService.Span.Add(new(0, 0, 2))).Length} items";
            editor.Effect3.Visibility = Visibility.Visible;
        }

        if (ModelsAtE(editor.TimeService.Span.Add(new(0, 0, 3))).Length != 0)
        {
            editor.Effect4.DisplayedText.Text = $"{ModelsAtE(editor.TimeService.Span.Add(new(0, 0, 3))).Length} items";
            editor.Effect4.Visibility = Visibility.Visible;
        }

        // Video objects
        if (FilterByI(editor.TimeService.Span, typeof(VideoImport)).Length != 0)
        {
            editor.Video1.DisplayedText.Text = $"{FilterByI(editor.TimeService.Span, typeof(VideoImport)).Length} items";
            editor.Video1.Visibility = Visibility.Visible;
        }

        if (FilterByI(editor.TimeService.Span.Add(new(0, 0, 1)), typeof(VideoImport)).Length != 0)
        {
            editor.Video2.DisplayedText.Text = $"{FilterByI(editor.TimeService.Span.Add(new(0, 0, 1)), typeof(VideoImport)).Length} items";
            editor.Video2.Visibility = Visibility.Visible;
        }

        if (FilterByI(editor.TimeService.Span.Add(new(0, 0, 2)), typeof(VideoImport)).Length != 0)
        {
            editor.Video3.DisplayedText.Text = $"{FilterByI(editor.TimeService.Span.Add(new(0, 0, 2)), typeof(VideoImport)).Length} items";
            editor.Video3.Visibility = Visibility.Visible;
        }

        if (FilterByI(editor.TimeService.Span.Add(new(0, 0, 3)), typeof(VideoImport)).Length != 0)
        {
            editor.Video4.DisplayedText.Text = $"{FilterByI(editor.TimeService.Span.Add(new(0, 0, 3)), typeof(VideoImport)).Length} items";
            editor.Video4.Visibility = Visibility.Visible;
        }

        // Audio imports
        if (FilterByI(editor.TimeService.Span, typeof(AudioImport)).Length != 0)
        {
            editor.Audio1.DisplayedText.Text = $"{FilterByI(editor.TimeService.Span, typeof(AudioImport)).Length} items";
            editor.Audio1.Visibility = Visibility.Visible;
        }

        if (FilterByI(editor.TimeService.Span.Add(new(0, 0, 1)), typeof(AudioImport)).Length != 0)
        {
            editor.Audio2.DisplayedText.Text = $"{FilterByI(editor.TimeService.Span.Add(new(0, 0, 1)), typeof(AudioImport)).Length} items";
            editor.Audio2.Visibility = Visibility.Visible;
        }

        if (FilterByI(editor.TimeService.Span.Add(new(0, 0, 2)), typeof(AudioImport)).Length != 0)
        {
            editor.Audio3.DisplayedText.Text = $"{FilterByI(editor.TimeService.Span.Add(new(0, 0, 2)), typeof(AudioImport)).Length} items";
            editor.Audio3.Visibility = Visibility.Visible;
        }

        if (FilterByI(editor.TimeService.Span.Add(new(0, 0, 3)), typeof(AudioImport)).Length != 0)
        {
            editor.Audio4.DisplayedText.Text = $"{FilterByI(editor.TimeService.Span.Add(new(0, 0, 3)), typeof(AudioImport)).Length} items";
            editor.Audio4.Visibility = Visibility.Visible;
        }

        IImageObjectModel[] ModelsAt(TimeSpan ts) => project.GetModelsAt(ts).ToArray();
        IImageObjectModel[] FilterBy(TimeSpan appearTime, Type type) => ModelsAt(appearTime).Where(m => m.GetType() == type).ToArray();
        ICommonImport[] ModelsAtI(TimeSpan ts) => project.TimelineProvider.Imports.Where(m => m.StartDuration.TotalSeconds == ts.TotalSeconds).ToArray();
        ICommonImport[] FilterByI(TimeSpan appearTime, Type type) => ModelsAtI(appearTime).Where(m => m.GetType() == type).ToArray();
        IHasTimeStamps[] ModelsAtE(TimeSpan ts) => project.TimelineProvider.Effects.Where(m => m.StartDuration!.ToTimeSpan().TotalSeconds == ts.TotalSeconds).ToArray();
    }
}
