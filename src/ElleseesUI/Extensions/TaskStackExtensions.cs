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

using ElleseesUI.Core.Common.ImageTasks;
using System.Text;

namespace ElleseesUI.Extensions;

/// <summary>
/// Extensions for <see cref="TaskStack" />.
/// </summary>
internal static class TaskStackExtensions
{
    /// <summary>
    /// Converts an instance of <see cref="TaskStack" /> to an indented part of project timeline.
    /// </summary>
    /// <param name="stack">Input instance of <see cref="TaskStack" />.</param>
    /// <param name="start">Start duration.</param>
    /// <param name="end">End duration.</param>
    public static string ToIndentedXml(this TaskStack stack, TimeSpan start, TimeSpan end)
    {
        StringBuilder sb = new();

        sb.AppendLine($"    <EffectGroupStart StartDuration=\"{start.Stringify()}\" EndDuration=\"{end.Stringify()}\" />");

        foreach (var obj in stack.Items)
        {
            if (obj is Hue hue)
            {
                sb.AppendLine($"    <HueEffect By=\"{hue.By}\" StartDuration=\"{start.Stringify()}\" EndDuration=\"{end.Stringify()}\" />");
            }
            else if (obj is GrayscaleBt709)
            {
                sb.AppendLine($"    <GrayscaleBt709Effect StartDuration=\"{start.Stringify()}\" EndDuration=\"{end.Stringify()}\" />");
            }
            else if (obj is GrayscaleBt601)
            {
                sb.AppendLine($"    <GrayscaleBt601Effect StartDuration=\"{start.Stringify()}\" EndDuration=\"{end.Stringify()}\" />");
            }
            else if (obj is Grayscale gs)
            {
                sb.AppendLine($"    <GrayscaleEffect By=\"{gs.By}\" StartDuration=\"{start.Stringify()}\" EndDuration=\"{end.Stringify()}\" />");
            }
            else if (obj is Saturate saturate)
            {
                sb.AppendLine($"    <SaturationEffect By=\"{saturate.By}\" StartDuration=\"{start.Stringify()}\" EndDuration=\"{end.Stringify()}\" />");
            }
            else if (obj is Lightness lightness)
            {
                sb.AppendLine($"    <LightnessEffect By=\"{lightness.By}\" StartDuration=\"{start.Stringify()}\" EndDuration=\"{end.Stringify()}\" />");
            }
            else if (obj is Brightness brightness)
            {
                sb.AppendLine($"    <BrightnessEffect By=\"{brightness.By}\" StartDuration=\"{start.Stringify()}\" EndDuration=\"{end.Stringify()}\" />");
            }
            else if (obj is Glow)
            {
                sb.AppendLine($"    <GlowEffect StartDuration=\"{start.Stringify()}\" EndDuration=\"{end.Stringify()}\" />");
            }
            else if (obj is GlowBy gby)
            {
                sb.AppendLine($"    <GlowByEffect By=\"{gby.By}\" Color=\"#{gby.Rgba.ToHex()}\" StartDuration=\"{start.Stringify()}\" EndDuration=\"{end.Stringify()}\" />");
            }
            else if (obj is BoxBlur)
            {
                sb.AppendLine($"    <BoxBlurEffect StartDuration=\"{start.Stringify()}\" EndDuration=\"{end.Stringify()}\" />");
            }
            else if (obj is BoxBlurBy bbby)
            {
                sb.AppendLine($"    <BoxBlurByEffect By=\"{bbby.By}\" StartDuration=\"{start.Stringify()}\" EndDuration=\"{end.Stringify()}\" />");
            }
            else if (obj is BokehBlur)
            {
                sb.AppendLine($"    <BokehBlurEffect StartDuration=\"{start.Stringify()}\" EndDuration=\"{end.Stringify()}\" />");
            }
            else if (obj is BokehBlurBy bkhbby)
            {
                sb.AppendLine($"    <BokehBlurByEffect Radius=\"{bkhbby.Radius}\" Components=\"{bkhbby.Components}\" Gamma=\"{bkhbby.Gamma}\" StartDuration=\"{start.Stringify()}\" EndDuration=\"{end.Stringify()}\" />");
            }
            else if (obj is BlackAndWhite)
            {
                sb.AppendLine($"    <BlackAndWhiteEffect StartDuration=\"{start.Stringify()}\" EndDuration=\"{end.Stringify()}\" />");
            }
            else if (obj is Contrast contrast)
            {
                sb.AppendLine($"    <ContrastEffect By=\"{contrast.By}\" StartDuration=\"{start.Stringify()}\" EndDuration=\"{end.Stringify()}\" />");
            }
            else if (obj is Background bg)
            {
                sb.AppendLine($"    <BackgroundEffect By=\"#{bg.Color.ToHex()}\" StartDuration=\"{start.Stringify()}\" EndDuration=\"{end.Stringify()}\" />");
            }
            else if (obj is ColorBlindness cb)
            {
                sb.AppendLine($"    <ColorBlindnessEffect By=\"{(int)cb.Mode}\" StartDuration=\"{start.Stringify()}\" EndDuration=\"{end.Stringify()}\" />");
            }
            else if (obj is Crop crop)
            {
                sb.AppendLine($"    <CropEffect X=\"{crop.X}\" Y=\"{crop.Y}\" StartDuration=\"{start.Stringify()}\" EndDuration=\"{end.Stringify()}\" />");
            }
            else if (obj is Resize resize)
            {
                sb.AppendLine($"    <ResizeEffect X=\"{resize.X}\" Y=\"{resize.Y}\" StartDuration=\"{start.Stringify()}\" EndDuration=\"{end.Stringify()}\" />");
            }
            else if (obj is Rotate rotate)
            {
                sb.AppendLine($"    <RotateEffect Deg=\"{rotate.Deg}\" StartDuration=\"{start.Stringify()}\" EndDuration=\"{end.Stringify()}\" />");
            }
            else if (obj is GaussianBlur gb)
            {
                sb.AppendLine($"    <GaussianBlur Sigma=\"{gb.Sigma}\" StartDuration=\"{start.Stringify()}\" EndDuration=\"{end.Stringify()}\" />");
            }
            else if (obj is Scale scale)
            {
                sb.AppendLine($"    <ScaleEffect X=\"{scale.X}\" Y=\"{scale.Y}\" StartDuration=\"{start.Stringify()}\" EndDuration=\"{end.Stringify()}\" />");
            }
        }

        sb.AppendLine($"    <EffectGroupEnd StartDuration=\"00:00:00.000\" EndDuration=\"00:00:00.000\" />");

        return sb.ToString();
    }
}
