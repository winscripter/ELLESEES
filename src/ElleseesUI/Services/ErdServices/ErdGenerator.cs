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
using ElleseesUI.Extensions;
using ElleseesUI.Services.ErdServices.Format;

namespace ElleseesUI.Services.ErdServices;

internal class ErdGenerator
{
    private readonly TaskStack _taskStack;

    public ErdGenerator(TaskStack taskStack)
        => _taskStack = taskStack;

    public string Generate()
    {
        var writer = new ErdWriter();

        foreach (object task in _taskStack.Items)
        {
            if (task is GrayscaleBt709)
            {
                writer.AppendColumn(new("grayscalebt709"));
            }
            else if (task is GrayscaleBt601)
            {
                writer.AppendColumn(new("grayscalebt601"));
            }
            else if (task is Grayscale gs)
            {
                writer.AppendColumn(new("grayscale", new(new ErdRow[] { new("by", gs.By.ToString()) })));
            }
            else if (task is Saturate saturate)
            {
                writer.AppendColumn(new("saturate", new(new ErdRow[] { new("by", saturate.By.ToString()) })));
            }
            else if (task is Lightness lightness)
            {
                writer.AppendColumn(new("lightness", new(new ErdRow[] { new("by", lightness.By.ToString()) })));
            }
            else if (task is Brightness brightness)
            {
                writer.AppendColumn(new("brightness", new(new ErdRow[] { new("by", brightness.By.ToString()) })));
            }
            else if (task is Glow)
            {
                writer.AppendColumn(new("glow"));
            }
            else if (task is GlowBy gby)
            {
                writer.AppendColumn(new("glowBy", new(new ErdRow[]
                {
                    new("by", gby.By.ToString()),
                    new("color", gby.Rgba.ToHex())
                })));
            }
            else if (task is BoxBlur)
            {
                writer.AppendColumn(new("boxBlurDefault"));
            }
            else if (task is BoxBlurBy bbby)
            {
                writer.AppendColumn(new("boxBlur", new(new ErdRow[] { new("by", bbby.By.ToString()) })));
            }
            else if (task is BokehBlur)
            {
                writer.AppendColumn(new("bokehBlur"));
            }
            else if (task is BokehBlurBy bkhbby)
            {
                writer.AppendColumn(new("bokehBlurBy", new(new ErdRow[]
                {
                    new("radius", bkhbby.Radius.ToString()),
                    new("components", bkhbby.Components.ToString()),
                    new("gamma", bkhbby.Gamma.ToString())
                })));
            }
            else if (task is BlackAndWhite)
            {
                writer.AppendColumn(new("blackAndWhite"));
            }
            else if (task is Contrast ctr)
            {
                writer.AppendColumn(new("contrastBy", new(new ErdRow[] { new("by", ctr.By.ToString()) })));
            }
            else if (task is Background bg)
            {
                writer.AppendColumn(new("background", new(new ErdRow[] { new("color", bg.Color.ToHex()) })));
            }
            else if (task is ColorBlindness cb)
            {
                writer.AppendColumn(new("colorBlindness", new(new ErdRow[] { new("mode", cb.Mode.Stringify()) })));
            }
            else if (task is Crop crop)
            {
                writer.AppendColumn(new("crop", new(new ErdRow[]
                {
                    new("x", crop.X.ToString()),
                    new("y", crop.Y.ToString())
                })));
            }
            else if (task is Resize resize)
            {
                writer.AppendColumn(new("resize", new(new ErdRow[]
                {
                    new("x", resize.X.ToString()),
                    new("y", resize.Y.ToString())
                })));
            }
            else if (task is Rotate r)
            {
                writer.AppendColumn(new("rotate", new(new ErdRow[] { new("deg", r.Deg.ToString()) })));
            }
            else if (task is GaussianBlur gb)
            {
                writer.AppendColumn(new("gaussianBlur", new(new ErdRow[] { new("sigma", gb.Sigma.ToString()) })));
            }
            else if (task is Scale scale)
            {
                writer.AppendColumn(new("scale", new(new ErdRow[]
                {
                    new("x", scale.X.ToString()),
                    new("y", scale.Y.ToString())
                })));
            }
            else if (task is Text text)
            {
                writer.AppendColumn(new("text", new(new ErdRow[]
                {
                    new("fontPath", text.Context.Path),
                    new("text", text.Context.Text),
                    new("foreground", text.Context.Foreground.ToHex()),
                    new("shadow_fg", text.Context.Shadow == null ? "null" : text.Context.Shadow.ShadowColor.ToString()),
                    new("shadow_sigma", text.Context.Shadow == null ? "null" : text.Context.Shadow.Strength.ToString()),
                    new("allowsShadow", (text.Context.Shadow == null).ToString()),
                    new("fontSize", text.Context.FontSize.ToString()),
                    new("xpos", text.Context.Position.X.ToString()),
                    new("ypos", text.Context.Position.Y.ToString())
                })));
            }

            // TODO: Continue here (IMPORTANT!)
        }

        return writer.ToString()!;
    }
}
