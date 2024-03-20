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
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;

namespace ElleseesUI.Core.Common.ImageTasks;

/// <summary>
/// Hue Task
/// </summary>
/// <param name="By">Amount of hue</param>
public record Hue(int By);

/// <summary>
/// BT.709 Grayscaling Task
/// </summary>
public record GrayscaleBt709();

/// <summary>
/// BT.601 Grayscaling Task
/// </summary>
public record GrayscaleBt601();

/// <summary>
/// Custom Grayscaling Task
/// </summary>
public record Grayscale(float By);

/// <summary>
/// Saturation Task
/// </summary>
/// <param name="By">Amount of saturation</param>
public record Saturate(float By);

/// <summary>
/// Lightness Task
/// </summary>
/// <param name="By">Amount of lightness</param>
public record Lightness(float By);

/// <summary>
/// Brightness Task
/// </summary>
/// <param name="By">Amount of brightness</param>
public record Brightness(float By);

/// <summary>
/// Default Glowing Task
/// </summary>
public record Glow();

/// <summary>
/// Glow By Task
/// </summary>
/// <param name="By">Amount of glow</param>
/// <param name="Rgba">Glowing color</param>
public record GlowBy(float By, Rgba32 Rgba);

/// <summary>
/// Default Box Blur Task
/// </summary>
public record BoxBlur();

/// <summary>
/// Box Blur By Task
/// </summary>
/// <param name="By">Amount of blurring</param>
public record BoxBlurBy(int By);

/// <summary>
/// Default Bokeh Blur Task
/// </summary>
public record BokehBlur();

/// <summary>
/// Bokeh Blur Task
/// </summary>
/// <param name="Radius">Radius</param>
/// <param name="Components">Components (1-6)</param>
/// <param name="Gamma">Gamma</param>
public record BokehBlurBy(int Radius, int Components, float Gamma);

/// <summary>
/// Black &amp; White Task
/// </summary>
public record BlackAndWhite();

/// <summary>
/// Contrast Task
/// </summary>
/// <param name="By">Amount of contrast</param>
public record Contrast(float By);

/// <summary>
/// Background Color Task
/// </summary>
/// <param name="Color">Background Color</param>
public record Background(Color Color);

/// <summary>
/// Color Blindness Task
/// </summary>
/// <param name="Mode">Color Blindness Mode</param>
public record ColorBlindness(ColorBlindnessMode Mode);

/// <summary>
/// Crop Task
/// </summary>
/// <param name="X">Width</param>
/// <param name="Y">Height</param>
public record Crop(int X, int Y);

/// <summary>
/// Image Resize Task
/// </summary>
/// <param name="X">Width</param>
/// <param name="Y">Height</param>
public record Resize(int X, int Y);

/// <summary>
/// Image Rotation Task
/// </summary>
/// <param name="Deg">Degrees</param>
public record Rotate(float Deg);

/// <summary>
/// Gaussian Blur Task
/// </summary>
/// <param name="Sigma">Gaussian Blur Sigma</param>
public record GaussianBlur(float Sigma);

/// <summary>
/// Image Scaling Task
/// </summary>
/// <param name="X">Width</param>
/// <param name="Y">Height</param>
public record Scale(int X, int Y);

/// <summary>
/// Image Text Task
/// </summary>
/// <param name="Context">Text rendering information</param>
public record Text(TextContext Context);

/// <summary>
/// Rectangle Fill Task
/// </summary>
/// <param name="X1">Start X</param>
/// <param name="Y1">Start Y</param>
/// <param name="X2">End X</param>
/// <param name="Y2">End Y</param>
/// <param name="Color">Rectangle Fill Color</param>
public record RectangleFill(int X1, int Y1, int X2, int Y2, Color Color);
