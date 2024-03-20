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

namespace ElleseesUI.Services.ErdServices.Format;

/// <summary>
/// Represents one ERD row
/// </summary>
internal class ErdRow : IComparable<ErdRow>
{
    /// <summary>
    /// Name of the row
    /// </summary>
    public string Name { get; private init; }

    /// <summary>
    /// Value of the row
    /// </summary>
    public string Value { get; private init; }

    /// <summary>
    /// Initializes a new instance of <see cref="ErdRow" /> with custom name and value
    /// </summary>
    /// <param name="name">Name of the row</param>
    /// <param name="value">Value of the row</param>
    public ErdRow(string name, string value)
    {
        Name = name;
        Value = value;
    }

    /// <summary>
    /// Initializes a new instance of <see cref="ErdRow" /> with empty name and value
    /// </summary>
    public ErdRow()
        : this("", "")
    {
    }

    /// <inheritdoc />
    public int CompareTo(ErdRow? other)
    {
        if (other == null)
        {
            return 1;
        }

        if (this == other)
        {
            return 0;
        }

        long asciiCombinationThis = 0;
        long asciiCombinationOther = 0;

        foreach (char letter in Name)
        {
            asciiCombinationThis += letter;
        }

        foreach (char letter in other.Name)
        {
            asciiCombinationOther += letter;
        }

        return asciiCombinationThis < asciiCombinationOther
               ? 1
               : 0;
    }
}
