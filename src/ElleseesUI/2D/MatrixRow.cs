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

namespace ElleseesUI.TwoDimensional;

/// <summary>
/// Represents a single row used for <see cref="Matrix" />.
/// </summary>
public class MatrixRow
{
    private readonly int[] _columns;
    private readonly int _columnLength;

    /// <summary>
    /// Initializes a new instance of <see cref="MatrixRow" /> and sets all values to 0.
    /// </summary>
    /// <param name="columnLength">Length of columns.</param>
    /// <exception cref="ArgumentException">Thrown when the column length is less than or equal to 0.</exception>
    public MatrixRow(int columnLength)
    {
        if (columnLength <= 0)
        {
            throw new ArgumentException("Value cannot be zero or negative", nameof(columnLength));
        }

        _columns = new int[columnLength];
        _columnLength = columnLength;
    }

    /// <summary>
    /// Gets items in the row.
    /// </summary>
    public int[] Items => _columns;

    /// <summary>
    /// Returns the length of items.
    /// </summary>
    public int Length => _columnLength;

    /// <summary>
    /// Fills all values with <paramref name="value" />.
    /// </summary>
    /// <param name="value">Number to fill all values with.</param>
    public void Fill(int value)
    {
        for (int i = 0; i < _columns.Length; i++)
        {
            _columns[i] = value;
        }
    }

    /// <summary>
    /// Fills all values with 0.
    /// </summary>
    public void Reset()
    {
        Fill(0);
    }

    /// <summary>
    /// Gets or sets element at index.
    /// </summary>
    /// <param name="index">Index.</param>
    /// <returns>Element at index.</returns>
    /// <exception cref="ArgumentException">Thrown during an attempt to set a value greater than or equal the length of the row.</exception>
    public int this[int index]
    {
        get
        {
            return _columns[index];
        }
        set
        {
            if (index >= Length)
            {
                throw new ArgumentException("Cannot set items out of bounds", nameof(index));
            }

            _columns[index] = value;
        }
    }
}
