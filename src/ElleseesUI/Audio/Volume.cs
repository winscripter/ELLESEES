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

namespace ElleseesUI.Audio;

/// <summary>
/// Stores information about an audio volume.
/// </summary>
public class Volume
{
    private readonly int m_value;

    /// <summary>
    /// Initializes a new instance of the <see cref="Volume" /> class.
    /// </summary>
    public Volume()
    {
        m_value = 0;
    }

    /// <summary>
    /// Initializes a new instance of <see cref="Volume" /> class.
    /// </summary>
    /// <param name="value">Volume percentage.</param>
    public Volume(int value)
    {
        m_value = value;
    }

    /// <summary>
    /// Implicit conversion from <see cref="int" /> to <see cref="Volume" />.
    /// </summary>
    /// <param name="value">Input <see cref="int" />.</param>
    public static implicit operator Volume(int value) => new(value);

    /// <summary>
    /// Explicit conversion from <see cref="Volume" /> to <see cref="int" />.
    /// </summary>
    /// <param name="vol">Input instance of <see cref="Volume" />.</param>
    public static explicit operator int(Volume vol) => vol.m_value;

    /// <summary>
    /// Attempts to parse given volume string.
    /// </summary>
    /// <param name="s">Given volume string.</param>
    /// <returns>A new instance of <see cref="Volume" />.</returns>
    public static Volume Parse(string s)
    {
        if (s.EndsWith("%"))
        {
            s = s.TrimEnd('%');
        }

        return new Volume(Convert.ToInt32(s));
    }

    /// <summary>
    /// Attempts to parse given volume string.
    /// </summary>
    /// <param name="s">Given volume string.</param>
    /// <param name="value">Output instance of <see cref="Volume" />.</param>
    /// <returns><see langword="TRUE" /> if parsing was successful, <see langword="FALSE" /> if parsing was unsuccessful.</returns>
    public static bool TryParse(string s, out Volume? value)
    {
        try
        {
            value = Parse(s);
            return true;
        }
        catch
        {
            value = default;
            return false;
        }
    }

    /// <summary>
    /// Percentage value of the volume.
    /// </summary>
    public int Value
    {
        get
        {
            return m_value;
        }
    }
}
