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

namespace Ellesees.ProjectParser.ProjectInfo;

/// <summary>
/// Type of an image object model.
/// </summary>
public enum ImageObjectModelKind : byte
{
    /// <summary>
    /// A color covering the whole frame.
    /// </summary>
    Fill,

    /// <summary>
    /// An image embedded into the video.
    /// </summary>
    Image,

    /// <summary>
    /// A rectangular fill.
    /// </summary>
    RectangleFill,

    /// <summary>
    /// A rectangular stroke, e.g. a rectangle, but just its borders.
    /// </summary>
    RectangleStroke,

    /// <summary>
    /// Text.
    /// </summary>
    Text,

    /// <summary>
    /// Any type of effect
    /// </summary>
    Effect,

    /// <summary>
    /// Default placeholder
    /// </summary>
    Nothing = 0xFF
}
