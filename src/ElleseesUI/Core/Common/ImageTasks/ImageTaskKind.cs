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

namespace ElleseesUI.Core.Common.ImageTasks;

/// <summary>
/// A type of the task applied on an image
/// </summary>
internal enum ImageTaskKind : byte
{
    /// <summary>
    /// Grayscaling (BT.709)
    /// </summary>
    GrayscaleBt709,

    /// <summary>
    /// Grayscaling (BT.601)
    /// </summary>
    GrayscaleBt601,

    /// <summary>
    /// Grayscaling
    /// </summary>
    Grayscale,

    /// <summary>
    /// Hue
    /// </summary>
    Hue,

    /// <summary>
    /// Saturation
    /// </summary>
    Saturate,

    /// <summary>
    /// Lightness
    /// </summary>
    Lightness,

    /// <summary>
    /// Brightness
    /// </summary>
    Brightness,

    /// <summary>
    /// Glowing
    /// </summary>
    Glow,

    /// <summary>
    /// Glowing by value
    /// </summary>
    GlowBy,

    /// <summary>
    /// Box blur
    /// </summary>
    BoxBlur,

    /// <summary>
    /// Bokeh blur (either default, or by explicit settings - radius, components, gamma)
    /// </summary>
    BokehBlur,

    /// <summary>
    /// Gaussian blur
    /// </summary>
    GaussianBlur,

    /// <summary>
    /// Image black &amp; white
    /// </summary>
    BlackAndWhite,

    /// <summary>
    /// Contrast
    /// </summary>
    Contrast,

    /// <summary>
    /// Background color
    /// </summary>
    BackColor,

    /// <summary>
    /// Color blindness (of any kind)
    /// </summary>
    ColorBlindness,

    /// <summary>
    /// Cropping
    /// </summary>
    Crop,

    /// <summary>
    /// Resizing
    /// </summary>
    Resize,

    /// <summary>
    /// Rotating
    /// </summary>
    Rotate,

    /// <summary>
    /// Scaling
    /// </summary>
    Scale,

    /// <summary>
    /// Text (with any options)
    /// </summary>
    Text,

    /// <summary>
    /// Rectangle filling
    /// </summary>
    Rectangle
}
