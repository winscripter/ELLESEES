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

using System.Numerics;

namespace ElleseesUI.TwoDimensional;

/// <summary>
/// Represents a custom-size matrix.
/// </summary>
public class Matrix
{
    private readonly List<MatrixRow> _rows;
    private readonly int _width;
    private readonly int _height;

    /// <summary>
    /// Initializes a new instance of <see cref="Matrix" />.
    /// </summary>
    /// <param name="x">Width of this matrix per row.</param>
    /// <param name="y">Height of this matrix, e.g. row count.</param>
    /// <exception cref="ArgumentException">Thrown when Width or Height is zero or negative.</exception>
    public Matrix(int x, int y)
    {
        // Gotta use K&R style here instead of Allman, otherwise the code looks
        // really really really ugly.
        if (x <= 0) throw new ArgumentException("Value cannot be zero or negative", nameof(x));
        if (y <= 0) throw new ArgumentException("Value cannot be zero or negative", nameof(y));

        _rows = new();

        for (int i = 0; i < y; i++)
        {
            _rows.Add(new MatrixRow(x));
        }

        _width = x;
        _height = y;
    }

    /// <summary>
    /// Gets the width of this matrix.
    /// </summary>
    public int Width { get { return _width; } }

    /// <summary>
    /// Gets the height of this matrix.
    /// </summary>
    public int Height { get { return _height ;} }

    /// <summary>
    /// Gets items in this matrix.
    /// </summary>
    public MatrixRow[] Items { get { return _rows.ToArray(); } }

    /// <summary>
    /// Gets the length of this matrix.
    /// </summary>
    public int Length { get { return Items.Length; } }

    /// <summary>
    /// Gets or sets an item at an index of this matrix.
    /// </summary>
    /// <param name="index">Index.</param>
    /// <returns>Item at an index.</returns>
    /// <exception cref="ArgumentException">Thrown when attempting to set an item at an index that is out of bounds.</exception>
    public MatrixRow this[int index]
    {
        get
        {
            return _rows[index];
        }
        set
        {
            if (index >= Length)
            {
                throw new ArgumentException("Cannot set items out of bounds", nameof(index));
            }

            Items[index] = value;
        }
    }

    /// <summary>
    /// Exports this Matrix as a Big Integer.
    /// <b>WARNING: This could be memory inefficient, slow, and result in potentially large numbers!</b>
    /// </summary>
    /// <returns>An instance of <see cref="BigInteger" /> exported from this instance of <see cref="Matrix" />.</returns>
    public BigInteger ToBigInteger()
    {
        var integer = new BigInteger();

        foreach (MatrixRow row in Items)
        {
            foreach (int item in row.Items)
            {
                integer += item;
            }
        }

        return integer;
    }
}
