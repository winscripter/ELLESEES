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

using Ellesees.ProjectParser.ProjectInfo.Abstractions;
using ElleseesUI.Abstractions;
using ElleseesUI.Core;
using ElleseesUI.ToolClickUIs;
using Ellesees.ProjectParser.ProjectInfo.ImageObjectModels;
using ElleseesUI.ProjectInfrastructure;
using ElleseesUI.SharedControllers;
using ElleseesUI.Extensions;

namespace ElleseesUI.Tasks;

/// <summary>
/// A task to add text to an image.
/// </summary>
public class AddText : ITask
{
    /// <summary>
    /// Video project where necessary information is extracted.
    /// </summary>
    public VideoProject Project { get; private init; }

    /// <summary>
    /// Initializes a new instance of <see cref="AddText" />.
    /// </summary>
    /// <param name="project">Initial value for <see cref="Project" />.</param>
    public AddText(VideoProject project)
    {
        Project = project;
    }

    /// <inheritdoc />
    public void Run()
    {
        var wnd = new TextToolClickUI();
        wnd.ShowDialog();

        if (wnd.DataReturned)
        {
            var item = Project!.TimelineProvider.Models;
            var list = new List<IImageObjectModel>(item)
                {
                    new Text
                    {
                        // The preceding two values are unused anyway.
                        Width = 0,
                        Height = 0,
                        Color = "#" + wnd.Context.Foreground.ToHex(),
                        StartDuration = wnd.Start ?? new(0, 0, 0),
                        EndDuration = wnd.End ?? new(0, 0, 0),
                        FontName = wnd.Context.Path,
                        FontSize = wnd.Context.FontSize,
                        ShadowColor = "#" + wnd.Context.ForegroundShadow.ToHex(),
                        ShadowSigma = wnd.Context.ShadowStrength,
                        Value = wnd.Context.Text,
                        X = wnd.Context.Position.X,
                        Y = wnd.Context.Position.Y
                    }
                };

            Project!.TimelineProvider.Models = list.ToArray();

            string path = Path.Combine(Project!.AbsolutePath, Project!.Project!.Context!.TimelineDirectory!, Ellesees.ProjectParser.Project.TimelineInfoFileName);

            if (!File.Exists(path))
            {
                MessageBoxCommon.ErrorOk("Project is corrupt. We're sorry for the inconvenience. :(");

                SharedTaskController.SetCorruptProjectMode!.Run();

                return;
            }

            Project!.TimelineProvider.Save(path, Project!.Project!.PrimaryVideo);
        }
    }
}
