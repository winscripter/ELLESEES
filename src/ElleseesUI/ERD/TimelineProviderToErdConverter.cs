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

using Ellesees.ProjectParser;
using Ellesees.ProjectParser.ProjectInfo.Abstractions;
using Ellesees.ProjectParser.ProjectInfo.Effects;
using ElleseesUI.Core.Common.ImageTasks;
using ElleseesUI.Extensions;
using System.Text;
using System.Windows;

namespace ElleseesUI.ERD;

/// <summary>
/// An extension class with 1 member to convert
/// <see cref="TimelineProvider" /> to ERD syntax,
/// ready to be rendered by ELLESEES' renderer process.
/// </summary>
internal static class TimelineProviderToErdConverter
{
    /// <summary>
    /// Converts <see cref="TimelineProvider" /> to ERD syntax.
    /// </summary>
    /// <param name="provider">Input <see cref="TimelineProvider" /> instance.</param>
    /// <param name="start">Start duration for child effects.</param>
    /// <param name="end">End duration for child effects.</param>
    /// <returns>Output ERD syntax.</returns>
    public static string Convert(this TimelineProvider provider, TimeSpan start, TimeSpan end)
    {
        StringBuilder sb = new();

        sb.AppendLine($"pushfs path=\"{provider.PrimaryVideo!.Path}\"");
        sb.AppendLine($"extractframesr start=\"{start.Stringify()}\" end=\"{end.Stringify()}\" output=\"temp/frame%04d.png\"");

        foreach (object effect in provider.Effects)
        {
            if (effect is BackgroundEffect bge) Emit($"background color=\"#{bge.Color}\"");
            else if (effect is BlackAndWhiteEffect) Emit($"blackAndWhite");
            else if (effect is BokehBlurByEffect bkhbby) Emit($"bokehBlurBy radius=\"{bkhbby.Radius}\" components=\"{bkhbby.Components}\" gamma=\"{bkhbby.Gamma}\"");
            else if (effect is BokehBlurEffect) Emit($"bokehBlur");
            else if (effect is BoxBlurByEffect bbby) Emit($"boxBlur by=\"{bbby.By}\"");
            else if (effect is BoxBlurEffect) Emit($"boxBlurDefault");
            else if (effect is BrightnessEffect brightness) Emit($"brightness by=\"{brightness.By}\"");
            else if (effect is LightnessEffect lightness) Emit($"lightness by=\"{lightness.By}\"");
            else if (effect is GlowEffect) Emit($"glow");
            else if (effect is GlowByEffect gby) Emit($"glowBy by=\"{gby.By}\" color=\"#{gby.Color}\"");
            else if (effect is BlackAndWhiteEffect) Emit($"blackAndWhite");
            else if (effect is ContrastEffect contrast) Emit($"contrastBy by=\"{contrast.By}\"");
            else if (effect is ColorBlindnessEffect cbe) Emit($"colorBlindness mode=\"{cbe.By}\"");
            else if (effect is CropEffect crop) Emit($"crop x=\"{crop.X}\" y=\"{crop.Y}\"");
            else if (effect is ResizeEffect resize) Emit($"resize x=\"{resize.X}\" y=\"{resize.Y}\"");
            else if (effect is RotateEffect rotate) Emit($"rotate deg=\"{rotate.Deg}\"");
            else if (effect is GaussianBlurEffect gaussianBlur) Emit($"gaussianBlur sigma=\"{gaussianBlur.Sigma}\"");
            else if (effect is ScaleEffect scale) Emit($"scale x=\"{scale.X}\" y=\"{scale.Y}\"");
            else if (effect is RectangleFill rect) Emit($"rect x1=\"{rect.X1}\" y1=\"{rect.Y1}\" x2=\"{rect.X2}\" y2=\"{rect.Y2}\" color=\"#{rect.Color.ToHex()}\"");
            else if (effect is Hue hue) Emit($"hue by=\"{hue.By}\"");
            else if (effect is ExtractFramesRangeEffect)
            {
                sb.AppendLine($"pushfs path=\"{provider.PrimaryVideo!.Path}\"");
                sb.AppendLine($"extractframesr start=\"{start.Stringify()}\" end=\"{end.Stringify()}\" output=\"temp/frame%04d.png\"");
                sb.AppendLine($"popfs");
            }
            else if (effect is CleanTempEffect)
            {
                sb.AppendLine($"pushfs path=\"{provider.PrimaryVideo!.Path}\"");
                sb.AppendLine($"cleanTemp at=\"{start.Stringify()}\"");
                sb.AppendLine($"popfs");
            }
        }

        foreach (IImageObjectModel model in provider.Models)
        {
            if (model is Ellesees.ProjectParser.ProjectInfo.ImageObjectModels.Text text)
            {
                string shadowForeground = text.ShadowColor ?? "null";
                string shadowSigma = text.ShadowSigma == null
                                     ? "null"
                                     : ((int)text.ShadowSigma).ToString();

                Emit($"text fontPath=\"{text.FontName}\" text=\"{text.Value}\" foreground=\"{text.Color}\" shadow_fg=\"{shadowForeground}\" shadow_sigma=\"{shadowSigma}\" fontSize=\"{text.FontSize}\" x=\"{text.X}\" y=\"{text.Y}\"");
            }
        }

        sb.AppendLine($"pushfs path=\"{provider.PrimaryVideo!.Path}\"");
        sb.AppendLine($"cleanTemp at=\"{start.Stringify()}\"");
        sb.AppendLine($"popfs");

        return sb.ToString();

        void Emit(string line)
        {
            sb.AppendLine($"feactivate path=\"./temp\"");
            sb.AppendLine(line);
        }
    }
}
