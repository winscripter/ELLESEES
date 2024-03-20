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

namespace ElleseesUI.Core;

/// <summary>
/// An X/Y cube, typically a resolution or a selection
/// </summary>
public struct Resolution
{
    /// <summary>
    /// Gets or sets the Width of the rectangle
    /// </summary>
    public ushort X { get; set; }

    /// <summary>
    /// Gets or sets the Height of the rectangle
    /// </summary>
    public ushort Y { get; set; }

    /// <summary>
    /// Initializes a new instance of <see cref="Resolution" />, with the Width (<paramref name="x"/>) and Height (<paramref name="y"/>)
    /// </summary>
    /// <param name="x">Width</param>
    /// <param name="y">Height</param>
    public Resolution(ushort x, ushort y)
    {
        X = x;
        Y = y;
    }

    /// <summary>
    /// Multiples <see cref="X" /> and <see cref="Y" /> together and returns the result
    /// </summary>
    public readonly int Cube
    {
        get
        {
            return X * Y;
        }
    }

    /// <summary>
    /// Adds <see cref="X" /> and <see cref="Y" /> together and returns the result
    /// </summary>
    public readonly int Borders
    {
        get
        {
            return X + Y;
        }
    }

    /// <summary>
    /// Constant resolutions typically used in phones
    /// </summary>
    public readonly struct PhoneResolutionConstants
    {
        /// <summary>
        /// A very small resolution, 480x800
        /// </summary>
        public static readonly Resolution VerySmall = new(480, 800);

        /// <summary>
        /// A small resolution, 640x1136
        /// </summary>
        public static readonly Resolution Small = new(640, 1136);

        /// <summary>
        /// An average resolution, 720x1280
        /// </summary>
        public static readonly Resolution Average = new(720, 1280);

        /// <summary>
        /// A medium resolution, 750x1334
        /// </summary>
        public static readonly Resolution Medium = new(750, 1334);

        /// <summary>
        /// A large resolution, 1080x1920
        /// </summary>
        public static readonly Resolution Large = new(1080, 1920);

        /// <summary>
        /// A very large resolution, 1440x2560
        /// </summary>
        public static readonly Resolution VeryLarge = new(1440, 2560);
    }
}
