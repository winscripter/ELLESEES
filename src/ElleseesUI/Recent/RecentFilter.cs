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

namespace ElleseesUI.Recent;

/// <summary>
/// Filters projects by recent modification date.
/// </summary>
public class RecentFilter
{
    private readonly RecentSearcher _searcher;

    /// <summary>
    /// Initializes a new instance of <see cref="RecentFilter" />.
    /// </summary>
    /// <param name="searcher">An instance of project searcher.</param>
    public RecentFilter(RecentSearcher searcher)
    {
        _searcher = searcher;
    }

    /// <summary>
    /// Sorts projects by the recent time they were modified.
    /// </summary>
    /// <returns>Directory paths, but sorted.</returns>
    public string[] Sort() => _searcher.Search().Select(path => new DirectoryInfo(path))
                                                .Where(dinfo => dinfo.Exists)
                                                .OrderByDescending(dinfo => dinfo.LastAccessTime)
                                                .Select(dinfo => dinfo.FullName)
                                                .ToArray();
}
