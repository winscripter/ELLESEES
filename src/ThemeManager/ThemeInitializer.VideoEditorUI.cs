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

using Ellesees.Base.Logging;
using ElleseesUI.Core;
using System.Windows;
using System.Windows.Controls;

namespace ElleseesUI.ThemeManager;

public static partial class ThemeInitializer
{
    /// <summary>
    /// Initializes the Video Editor UI based on the theme.
    /// </summary>
    /// <param name="ui">Video Editor UI</param>
    public static void Initialize(VideoEditorUI ui)
    {
        ITheme theme = ThemeManager.Current;

        ui.TitleBarBackground.Background = theme.TitleBarBackground;
        ui.WindowTitle.Foreground = theme.TitleBarForeground;
        ui.UpLeftCorner.Background = theme.UpLeftBackground;
        ui.MenuRoot.Background = theme.MenuBackground;

        foreach (MenuItem item in ui.MenuRootChildItems)
        {
            item.Background = theme.MenuBackground;
            item.Foreground = theme.MenuForeground;

            foreach (MenuItem subItem in item.Items)
            {
                subItem.Background = theme.MenuItemBackground;
                subItem.Foreground = theme.MenuItemForeground;
                subItem.BorderBrush = theme.MenuBorderColor;
                subItem.BorderThickness = new Thickness(theme.MenuBorderThickness);
            }
        }

        ui.ManagementPanel.Background = theme.ManagementPanelBackground;

        try
        {
            foreach (Label lbl in ui.ManagementPanelChildItems)
            {
                Style newStyle = new()
                {
                    BasedOn = lbl.Style,
                    TargetType = typeof(Label)
                };

                Trigger mouseOverTrigger = new()
                {
                    Property = UIElement.IsMouseOverProperty,
                    Value = true
                };

                mouseOverTrigger.Setters.Add(new Setter
                {
                    Property = Control.ForegroundProperty,
                    Value = theme.ManagementPanelHoverForeground
                });

                newStyle.Triggers.Add(mouseOverTrigger);

                lbl.Style = newStyle;
            }
        }
        catch (Exception ex)
        {
            MessageBoxCommon.ErrorOk("Apply part of style failed.");

            Logger.Log($"Cannot change theme for management panel due to the preceding exception:{Environment.NewLine}{ex}",
                         LoggerFlags.AppendPriority | LoggerFlags.AppendDateTime,
                         LogPriority.Error);
        }

        ui.PropertyEditorBackground.Background = theme.PropertyEditorBackground;
        ui.PropertyEditorForeground.Foreground = theme.PropertyEditorForeground;

        ui.CloseButton.Background = theme.CloseButtonBackground;
        ui.CloseButton.Foreground = theme.CloseButtonForeground;
    }
}
