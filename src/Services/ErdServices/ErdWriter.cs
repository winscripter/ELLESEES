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

using ElleseesUI.Services.ErdServices.Format;

namespace ElleseesUI.Services.ErdServices;

/// <summary>
/// Writes data to an ERD
/// </summary>
internal class ErdWriter
{
    private readonly List<ErdColumn> columns;

    /// <summary>
    /// ERD Columns
    /// </summary>
    public List<ErdColumn> Columns => columns;

    /// <summary>
    /// Initializes a new instance of <see cref="ErdWriter" />
    /// </summary>
    /// <param name="columns">Initial columns as a starting point</param>
    public ErdWriter(List<ErdColumn> columns)
    {
        this.columns = columns;
    }

    /// <summary>
    /// Initializes a new instance of <see cref="ErdWriter" /> with 0 columns as a starting point
    /// </summary>
    public ErdWriter()
    {
        columns = new();
    }

    /// <summary>
    /// Appends a column
    /// </summary>
    /// <param name="column">Column</param>
    public void AppendColumn(ErdColumn column)
    {
        columns.Add(column);
    }

    /// <summary>
    /// Appends a row to a column by its name
    /// </summary>
    /// <param name="columnName">Column name</param>
    /// <param name="row">Row that will be appended to a column with a name specified by <paramref name="columnName" /></param>
    /// <exception cref="ErdException"></exception>
    public void AddRowToColumn(string columnName, ErdRow row)
    {
        var column = columns.Where(c => c.Name == columnName).FirstOrDefault()
                     ?? throw new ErdException($"No ERD column with name \"{columnName}\" was found");

        var cidx = columns.IndexOf(column);

        // We already verified if the column is in the list or not.
        // No need to check if index is -1 or not.

        columns[cidx].Rows.Add(row);
    }
}
