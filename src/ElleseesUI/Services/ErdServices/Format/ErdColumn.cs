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
/// Represents a single ERD column
/// </summary>
internal class ErdColumn
{
    /// <summary>
    /// Name of the column
    /// </summary>
    public string Name { get; private init; }

    /// <summary>
    /// Child rows
    /// </summary>
    public List<ErdRow> Rows { get; private init; }

    /// <summary>
    /// Initializes a new instance of <see cref="ErdColumn" /> with name of the column and child rows
    /// </summary>
    /// <param name="name">Name of the column</param>
    /// <param name="rows">Child rows</param>
    public ErdColumn(string name, List<ErdRow> rows)
    {
        Name = name;
        Rows = rows;
    }

    /// <summary>
    /// Initializes a new instance of <see cref="ErdColumn" /> with name of the column and 0 rows as a starting point
    /// </summary>
    /// <param name="name">Name of the column</param>
    public ErdColumn(string name)
        : this(name, new())
    {
    }
}
