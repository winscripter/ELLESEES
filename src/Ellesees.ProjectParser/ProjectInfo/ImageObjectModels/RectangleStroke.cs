﻿// MIT License
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

namespace Ellesees.ProjectParser.ProjectInfo.ImageObjectModels;

/// <summary>
/// Stroke of the rectangle, e.g. no rectangle, just its borders.
/// </summary>
[Serializable]
public class RectangleStroke : IImageObjectModel
{
    /// <summary>
    /// Color of the borders.
    /// </summary>
    public string? Color { get; set; }

    /// <summary>
    /// X1
    /// </summary>
    public float X { get; set; }

    /// <summary>
    /// Y1
    /// </summary>
    public float Y { get; set; }

    /// <summary>
    /// X2
    /// </summary>
    public int Width { get; set; }

    /// <summary>
    /// Y2
    /// </summary>
    public int Height { get; set; }

    /// <inheritdoc />
    public TimeSpan StartDuration { get; set; }

    /// <inheritdoc />
    public TimeSpan EndDuration { get; set; }

    /// <inheritdoc />
    public ImageObjectModelKind Kind
    {
        get => ImageObjectModelKind.RectangleStroke;
    }
}
