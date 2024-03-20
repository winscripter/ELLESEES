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

namespace ElleseesUI.Extensions;

/// <summary>
/// Extensions for <see cref="TimeSpan" />.
/// </summary>
internal static class TimeSpanExtensions
{
    /// <summary>
    /// Stringifes <see cref="TimeSpan" /> in such a way so ELLESEES is able to read it.
    /// </summary>
    /// <param name="value">Input TimeSpan.</param>
    /// <returns>Output string.</returns>
    public static string Stringify(this TimeSpan value)
    {
        var h = value.Hours;
        var m = value.Minutes.ToString().Length == 1 ? "0" + value.Minutes.ToString() : value.Minutes.ToString();
        var s = value.Seconds.ToString().Length == 1 ? "0" + value.Seconds.ToString() : value.Seconds.ToString();
        var ms = value.Milliseconds.ToString().Length > 3
                 ? value.Milliseconds.ToString()[..3]
                 : value.Milliseconds.ToString().Length == 1
                   ? $"00{value.Milliseconds}"
                   : value.Milliseconds.ToString().Length == 2
                     ? $"0{value.Milliseconds}"
                     : /*we know it for a fact it's 3 here*/ value.Milliseconds.ToString();

        return $"{h}:{m}:{s}.{ms}";
    }
}
