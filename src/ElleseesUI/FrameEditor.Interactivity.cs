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

using Ellesees.Base.Context;
using Ellesees.Base.Logging;
using ElleseesUI.Core;
using ElleseesUI.Dialogs.ImagePreview;
using SixLabors.Fonts;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;
using System.Windows;

namespace ElleseesUI;

public partial class FrameEditor
{
    /// <summary>
    /// Event handler for action "Hue".
    /// </summary>
    /// <param name="sender">Base WPF control that raised this event.</param>
    /// <param name="e">Arguments for this event.</param>
    private void HueButton_Click(object sender, RoutedEventArgs e)
    {
        HueValue hv = new();
        hv.ShowDialog();

        if (hv.Value is not null)
        {
            _settings.Hue = hv.Value ?? 0.0F;

            ApplyHue(_settings.Hue);
        }
    }

    /// <summary>
    /// Event handler for action "Grayscale".
    /// </summary>
    /// <param name="sender">Base WPF control that raised this event.</param>
    /// <param name="e">Arguments for this event.</param>
    private void GrayscaleButton_Click(object sender, RoutedEventArgs e)
    {
        if (!EnsureLoaded())
        {
            return;
        }

        var dlg = new GrayscalePicker();
        dlg.ShowDialog();

        if (dlg.ApplyBt601)
        {
            GrayscaleBt601();
        }
        else if (dlg.ApplyBt709)
        {
            GrayscaleBt709();
        }
        else if (dlg.ApplyCustom)
        {
            var value = dlg.Value ?? 0.0F;
            GrayscaleBy(value);
        }
    }

    /// <summary>
    /// Event handler for action "Saturate".
    /// </summary>
    /// <param name="sender">Base WPF control that raised this event.</param>
    /// <param name="e">Arguments for this event.</param>
    private void SaturateButton_Click(object sender, RoutedEventArgs e)
    {
        if (!EnsureLoaded())
        {
            return;
        }

        var dlg = new SaturationValue();
        dlg.ShowDialog();

        if (dlg.Value is not null)
        {
            ApplySaturation(dlg.Value ?? 0.0F);
        }
    }

    /// <summary>
    /// Event handler for action "Lightness".
    /// </summary>
    /// <param name="sender">Base WPF control that raised this event.</param>
    /// <param name="e">Arguments for this event.</param>
    private void LightnessButton_Click(object sender, RoutedEventArgs e)
    {
        if (!EnsureLoaded())
        {
            return;
        }

        var dlg = new LightnessValue();
        dlg.ShowDialog();

        if (dlg.Value is not null)
        {
            ApplyLightness(dlg.Value ?? 0.0F);
        }
    }

    /// <summary>
    /// Event handler for action "Brightness".
    /// </summary>
    /// <param name="sender">Base WPF control that raised this event.</param>
    /// <param name="e">Arguments for this event.</param>
    private void BrightnessButton_Click(object sender, RoutedEventArgs e)
    {
        if (!EnsureLoaded())
        {
            return;
        }

        var dlg = new BrightnessValue();
        dlg.ShowDialog();

        if (dlg.Value is not null)
        {
            ApplyBrightness(dlg.Value ?? 0.0F);
        }
    }

    /// <summary>
    /// Event handler for action "Glow".
    /// </summary>
    /// <param name="sender">Base WPF control that raised this event.</param>
    /// <param name="e">Arguments for this event.</param>
    private void GlowButton_Click(object sender, RoutedEventArgs e)
    {
        if (!EnsureLoaded())
        {
            return;
        }

        if (MessageBoxCommon.InfoYesNo("Are you sure you want to apply radial glowing to an image?") == MessageBoxResult.Yes)
        {
            ApplyGlow();
        }
    }

    /// <summary>
    /// Event handler for action "Glow By".
    /// </summary>
    /// <param name="sender">Base WPF control that raised this event.</param>
    /// <param name="e">Arguments for this event.</param>
    private void GlowByButton_Click(object sender, RoutedEventArgs e)
    {
        if (!EnsureLoaded())
        {
            return;
        }

        var dlg = new GlowByValue();
        dlg.ShowDialog();

        if (dlg.GlowAmount is not null)
        {
            ApplyGlow(dlg.GlowAmount ?? 0.0F, new Rgba32(dlg.Color!.Value.R,
                                                         dlg.Color!.Value.G,
                                                         dlg.Color!.Value.B,
                                                         dlg.Color!.Value.A));
        }
    }

    /// <summary>
    /// Event handler for action "Box Blur".
    /// </summary>
    /// <param name="sender">Base WPF control that raised this event.</param>
    /// <param name="e">Arguments for this event.</param>
    private void BoxBlurButton_Click(object sender, RoutedEventArgs e)
    {
        if (!EnsureLoaded())
        {
            return;
        }

        var dlg = new BoxBlurValue();
        dlg.ShowDialog();

        if (dlg.HasValue != null)
        {
            if (dlg.HasValue ?? true)
            {
                ApplyBoxBlur();
            }
            else
            {
                ApplyBoxBlur(dlg.Value ?? 1);
            }
        }
    }

    /// <summary>
    /// Event handler for action "Bokeh Blur".
    /// </summary>
    /// <param name="sender">Base WPF control that raised this event.</param>
    /// <param name="e">Arguments for this event.</param>
    private void BokehBlurButton_Click(object sender, RoutedEventArgs e)
    {
        if (!EnsureLoaded())
        {
            return;
        }

        var dlg = new BokehBlurValue();
        dlg.ShowDialog();

        try
        {
            if (dlg.DataReturned)
            {
                if (dlg.Radius == null || dlg.Components == null || dlg.Gamma == null)
                {
                    ApplyBokehBlur();
                }
                else
                {
                    ApplyBokehBlur(
                        dlg.Radius ?? 1,
                        dlg.Components ?? 1,
                        dlg.Gamma ?? 1.0F
                    );
                }
            }
        }
        catch (Exception ex)
        {
            Logger.Log(
                ex.ToString(),
                LoggerFlags.AppendDateTime | LoggerFlags.AppendPriority,
                LogPriority.Error
            );

            MessageBoxCommon.ErrorOk("Could not apply bokeh blur to an image. We're very sorry. :(\n\nDetails can be found in the log file Ellesees.log.");
        }
    }

    /// <summary>
    /// Event handler for action "Black and White".
    /// </summary>
    /// <param name="sender">Base WPF control that raised this event.</param>
    /// <param name="e">Arguments for this event.</param>
    private void BlackAndWhiteButton_Click(object sender, RoutedEventArgs e)
    {
        if (!EnsureLoaded())
        {
            return;
        }

        if (MessageBoxCommon.InfoYesNo("Are you sure you want to make the image black and white?") == MessageBoxResult.Yes)
        {
            ApplyBlackAndWhite();
        }
    }

    /// <summary>
    /// Event handler for action "Contrast".
    /// </summary>
    /// <param name="sender">Base WPF control that raised this event.</param>
    /// <param name="e">Arguments for this event.</param>
    private void ContrastButton_Click(object sender, RoutedEventArgs e)
    {
        if (!EnsureLoaded())
        {
            return;
        }

        var dlg = new ContrastValue();
        dlg.ShowDialog();

        if (dlg.Value is not null)
        {
            ApplyContrast(dlg.Value ?? 0.0F);
        }
    }

    /// <summary>
    /// Event handler for action "Background Color".
    /// </summary>
    /// <param name="sender">Base WPF control that raised this event.</param>
    /// <param name="e">Arguments for this event.</param>
    private void BackgroundColorButton_Click(object sender, RoutedEventArgs e)
    {
        if (!EnsureLoaded())
        {
            return;
        }

        var color = ColorPickerCaller.Call();

        if (color is not null)
        {
            ApplyBackColor(new Rgba32(color.Value.R, color.Value.G, color.Value.B, color.Value.A));
        }
    }

    /// <summary>
    /// Event handler for action "Color Blindness".
    /// </summary>
    /// <param name="sender">Base WPF control that raised this event.</param>
    /// <param name="e">Arguments for this event.</param>
    private void ColorBlindnessButton_Click(object sender, RoutedEventArgs e)
    {
        if (!EnsureLoaded())
        {
            return;
        }

        var dlg = new ColorBlindnessValue();
        dlg.ShowDialog();

        if (dlg.Value is not null)
        {
            ApplyColorBlindness(dlg.Value ?? ColorBlindnessMode.Achromatomaly);
        }
    }

    /// <summary>
    /// Event handler for action "Crop".
    /// </summary>
    /// <param name="sender">Base WPF control that raised this event.</param>
    /// <param name="e">Arguments for this event.</param>
    private void CropButton_Click(object sender, RoutedEventArgs e)
    {
        if (!EnsureLoaded())
        {
            return;
        }

        var dlg = new CropValue
        {
            OriginalX = LoadedImage!.Width,
            OriginalY = LoadedImage!.Height
        };
        dlg.ShowDialog();

        if (dlg.Value is not null)
        {
            (int x, int y) = dlg.Value ?? (0, 0);
            ApplyCrop(x, y);
        }
    }

    /// <summary>
    /// Event handler for action "Resize".
    /// </summary>
    /// <param name="sender">Base WPF control that raised this event.</param>
    /// <param name="e">Arguments for this event.</param>
    private void ResizeButton_Click(object sender, RoutedEventArgs e)
    {
        if (!EnsureLoaded())
        {
            return;
        }

        var dlg = new ResizeValue();
        dlg.ShowDialog();

        if (dlg.Value is not null)
        {
            (int x, int y) = dlg.Value ?? (0, 0);
            ApplyResize(x, y);
        }
    }

    /// <summary>
    /// Event handler for action "Rotate".
    /// </summary>
    /// <param name="sender">Base WPF control that raised this event.</param>
    /// <param name="e">Arguments for this event.</param>
    private void RotateButton_Click(object sender, RoutedEventArgs e)
    {
        if (!EnsureLoaded())
        {
            return;
        }

        var dlg = new RotateValue();
        dlg.ShowDialog();

        if (dlg.Value is not null)
        {
            ApplyRotate(dlg.Value ?? 0F);
        }
    }

    /// <summary>
    /// Event handler for action "Blur".
    /// </summary>
    /// <param name="sender">Base WPF control that raised this event.</param>
    /// <param name="e">Arguments for this event.</param>
    private void BlurButton_Click(object sender, RoutedEventArgs e)
    {
        if (!EnsureLoaded())
        {
            return;
        }

        var dlg = new BlurValue();
        dlg.ShowDialog();

        if (dlg.Value is not null)
        {
            ApplyGaussianBlur(dlg.Value ?? 0.0F);
        }
    }

    /// <summary>
    /// Event handler for action "Scale".
    /// </summary>
    /// <param name="sender">Base WPF control that raised this event.</param>
    /// <param name="e">Arguments for this event.</param>
    private void ZoomButton_Click(object sender, RoutedEventArgs e)
    {
        if (!EnsureLoaded())
        {
            return;
        }

        var dlg = new ScaleValue();
        dlg.ShowDialog();

        if (dlg.ValueX is not null && dlg.ValueY is not null)
        {
            ApplyScale(dlg.ValueX ?? 0, dlg.ValueY ?? 0);
        }
    }

    /// <summary>
    /// Event handler for action "Text".
    /// </summary>
    /// <param name="sender">Base WPF control that raised this event.</param>
    /// <param name="e">Arguments for this event.</param>
    private void TextButton_Click(object sender, RoutedEventArgs e)
    {
        if (!EnsureLoaded())
        {
            return;
        }

        var dlg = new TextValue();
        dlg.ShowDialog();

        if (dlg.DataReturned)
        {
            try
            {
                var collection = new FontCollection();
                var family = collection.Add(dlg.FontPath);

                ApplyText(new TextContext(
                    dlg.Text,
                    dlg.FontPath,
                    dlg.TextSize,
                    family.CreateFont(dlg.TextSize),
                    dlg.TextFontStyle,
                    new Rgba32(dlg.TextForeground.R, dlg.TextForeground.G, dlg.TextForeground.B, dlg.TextForeground.A),
                    new PointF(Convert.ToSingle(dlg.X), Convert.ToSingle(dlg.Y)),
                    dlg.AllowTextShadow ? dlg.TextShadow : null
                ));
            }
            catch (Exception ex)
            {
                Logger.Log(ex.ToString(), LoggerFlags.AppendPriority | LoggerFlags.AppendDateTime, LogPriority.Error);

                MessageBoxCommon.ErrorOk("Could not apply text. We're sorry. :(\n\nDetails can be found in the log file Ellesees.log.");
            }
        }
    }

    /// <summary>
    /// Event handler for action "Rectangle Fill".
    /// </summary>
    /// <param name="sender">Base WPF control that raised this event.</param>
    /// <param name="e">Arguments for this event.</param>
    private void RectangleFillButton_Click(object sender, RoutedEventArgs e)
    {
        // TODO: Work on rectangle fill
    }
}
