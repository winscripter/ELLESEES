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
using Ellesees.ProjectParser.ProjectInfo.Effects;
using ElleseesUI.Core.Common.ImageTasks;
using ElleseesUI.Extensions;
using System.Text;

namespace ElleseesUI.ERD;

/// <summary>
/// An extension class with 1 member to convert <see cref="TaskStack" /> to
/// the ERD syntax, ready to be rendered by ELLESEES' renderer process.
/// </summary>
internal static class TaskStackToErdConverter
{
    /// <summary>
    /// Converts <see cref="TaskStack" /> to ERD syntax.
    /// </summary>
    public static string Convert(this TaskStack stack, TimeSpan start, TimeSpan end, TimelineProvider provider)
    {
        StringBuilder sb = new();

        sb.AppendLine($"extractframesr start=\"{start.Stringify()}\" end=\"{end.Stringify()}\" path=\"{provider.PrimaryVideo!.Path}\"");

        foreach (object effect in stack.Items)
        {
            if (effect is Background bg) Emit($"background color=\"#{bg.Color}\"");
            else if (effect is BlackAndWhite) Emit($"blackAndWhite");
            else if (effect is BokehBlurBy bkhbby) Emit($"bokehBlurBy radius=\"{bkhbby.Radius}\" components=\"{bkhbby.Components}\" gamma=\"{bkhbby.Gamma}\"");
            else if (effect is BokehBlur) Emit($"bokehBlur");
            else if (effect is BoxBlurBy bbby) Emit($"boxBlur by=\"{bbby.By}\"");
            else if (effect is BoxBlur) Emit($"boxBlurDefault");
            else if (effect is Brightness brightness) Emit($"brightness by=\"{brightness.By}\"");
            else if (effect is Lightness lightness) Emit($"lightness by=\"{lightness.By}\"");
            else if (effect is Glow) Emit($"glow");
            else if (effect is GlowBy gby) Emit($"glowBy by=\"{gby.By}\" color=\"#{gby.Rgba.ToHex()}\"");
            else if (effect is BlackAndWhite) Emit($"blackAndWhite");
            else if (effect is Contrast contrast) Emit($"contrastBy by=\"{contrast.By}\"");
            else if (effect is ColorBlindness cbe) Emit($"colorBlindness mode=\"{cbe.Mode.Stringify()}\"");
            else if (effect is Crop crop) Emit($"crop x=\"{crop.X}\" y=\"{crop.Y}\"");
            else if (effect is Resize resize) Emit($"resize x=\"{resize.X}\" y=\"{resize.Y}\"");
            else if (effect is Rotate rotate) Emit($"rotate deg=\"{rotate.Deg}\"");
            else if (effect is GaussianBlur gaussianBlur) Emit($"gaussianBlur sigma=\"{gaussianBlur.Sigma}\"");
            else if (effect is Scale scale) Emit($"scale x=\"{scale.X}\" y=\"{scale.Y}\"");
            else if (effect is RectangleFill rect) Emit($"rect x1=\"{rect.X1}\" y1=\"{rect.Y1}\" x2=\"{rect.X2}\" y2=\"{rect.Y2}\" color=\"#{rect.Color.ToHex()}\"");
            else if (effect is Hue hue) Emit($"hue by=\"{hue.By}\"");
            else if (effect is CleanTempEffect)
            {
                sb.AppendLine($"pushfs path=\"{provider.PrimaryVideo?.Path}\"");
                sb.AppendLine($"cleanTemp at=\"{start.Stringify()}\"");
                sb.AppendLine($"popfs");
            }
            else if (effect is ExtractFramesRangeEffect extractFrames) sb.AppendLine($"extractframesr start=\"{extractFrames.StartDuration}\" end=\"{extractFrames.EndDuration}\" output=\"{extractFrames.OutputFormat}\"");
        }

        sb.AppendLine($"pushfs path=\"{provider.PrimaryVideo?.Path}\"");
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
