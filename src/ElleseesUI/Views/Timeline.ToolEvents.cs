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

using ElleseesUI.Core;
using ElleseesUI.Extensions;
using ElleseesUI.MagicWand;
using ElleseesUI.Tasks;
using System.Windows;

namespace ElleseesUI.Views;

public partial class Timeline
{
    /// <summary>
    /// An event handler for the Text tool button inside the Tool Group.
    /// </summary>
    public void OnTextToolClick(object sender, RoutedEventArgs e)
    {
        if (!EnsureProjectLoaded())
        {
            return;
        }

        new AddText(Project!).Run();
    }

    /// <summary>
    /// An event handler for the Magic Wand tool button inside the Tool Group.
    /// </summary>
    public void OnMagicWandToolClick(object sender, RoutedEventArgs e)
    {
        var result = MagicWandTool.Run();

        if (result != null)
        {
            if (MessageBoxCommon.InfoYesNo("Magic Wand Tool requires to make changes to the project immediately. Would you like to continue?\n\nIf you press No, the Magic Wand Tool will not apply any changes.") == MessageBoxResult.Yes)
            {
                Project!.TimelineProvider.SaveWithEffects(Path.Combine(Project!.AbsolutePath, Project!.Project!.Context!.TimelineDirectory!, Ellesees.ProjectParser.Project.TimelineInfoFileName), result.EngagementStack.ToIndentedXml(result.StartTimestamp, result.EndTimestamp), Project!.Project.PrimaryVideo);
            }
        }

        // Update timeline
        TimelineScrollRight();
        TimelineScrollLeft();
    }
}
