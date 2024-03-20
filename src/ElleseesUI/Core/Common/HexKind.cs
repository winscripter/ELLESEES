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

namespace ElleseesUI.Core.Common;

/// <summary>
/// Type of a HEX color string
/// </summary>
[Flags]
internal enum HexKind : byte
{
    /// <summary>
    /// 3 letter HEX string, f.e. #333
    /// </summary>
    Hex3 = 1,

    /// <summary>
    /// 6 letter HEX string, f.e. #242424
    /// </summary>
    Hex6 = 2,

    /// <summary>
    /// 8 letter HEX string with an additional alpha value, f.e. #24242410
    /// </summary>
    /// <remarks>
    /// This type of HEX string is no longer used (and actually was never used) and may be removed.
    /// </remarks>
    Hex8 = 4,
}
