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
/// A 3-letter HEX string
/// </summary>
/// <param name="First">First character</param>
/// <param name="Second">Second character</param>
/// <param name="Third">Last character</param>
public record Hex3(
    char First,
    char Second,
    char Third
);

/// <summary>
/// A 6-letter HEX string
/// </summary>
/// <param name="First">Red</param>
/// <param name="Second">Green</param>
/// <param name="Third">Blue</param>
public record Hex6(
    byte First,
    byte Second,
    byte Third
);

/// <summary>
/// RGB representation
/// </summary>
/// <param name="R">Red</param>
/// <param name="G">Green</param>
/// <param name="B">Blue</param>
public record Rgb3(
    byte R,
    byte G,
    byte B
);

/// <summary>
/// An exception that occurs when a hex string could not be parsed.
/// </summary>
internal class HexParseException : Exception
{
    /// <summary>
    /// Initializes a new instance of <see cref="HexParseException" />
    /// </summary>
    public HexParseException()
    {
    }

    /// <summary>
    /// Initializes a new instance of <see cref="HexParseException" />
    /// </summary>
    /// <param name="message">An exception message</param>
    public HexParseException(string message)
        : base(message)
    {
    }
}

/// <summary>
/// Parses a HEX color string
/// </summary>
internal class HexParser
{
    private const int H3_MUL = 17;

    /// <summary>
    /// Type of a HEX color
    /// </summary>
    public HexKind? HexKind { get; private set; } = null;
    private readonly string value;

    /// <summary>
    /// 3 letter HEX representation
    /// </summary>
    public Hex3? Hex3 { get; private set; }

    /// <summary>
    /// 6 letter HEX representation
    /// </summary>
    public Hex6? Hex6 { get; private set; }

    /// <summary>
    /// RGB representation
    /// </summary>
    public Rgb3? Rgb3 { get; private set; }

    /// <summary>
    /// Initializes a new instance of <see cref="HexParser" />
    /// </summary>
    /// <param name="value">Input HEX color string (including a hashtag character at the beginning)</param>
    public HexParser(string value)
    {
        this.value = value;
    }

    /// <summary>
    /// Parses the HEX color string and sets <see cref="Hex3" />, <see cref="Hex6" /> and <see cref="Rgb3" /> to their appropriate values.
    /// </summary>
    /// <exception cref="HexParseException">The HEX string is not valid</exception>
    public void Parse()
    {
        if (value.Length is not 4 and not 7)
        {
            throw new HexParseException($"Length of hexadecimal string must be 4 or 7 letters; got {value.Length}");
        }

        if (value[0] != '#')
        {
            throw new HexParseException("Every hexadecimal string must start with a hashtag (#) character");
        }

        try
        {
            switch (value.Length)
            {
                case 4:
                    HexKind = Common.HexKind.Hex3;
                    Hex3 = new(value[1], value[2], value[3]);

                    Rgb3 = new Rgb3((byte)(Hex3.First * H3_MUL),
                                    (byte)(Hex3.Second * H3_MUL),
                                    (byte)(Hex3.Third * H3_MUL));
                    break;
                case 7:
                    HexKind = Common.HexKind.Hex6;
                    Hex6 = new(Convert.ToByte($"0x{value[1]}{value[2]}", 16),
                               Convert.ToByte($"0x{value[3]}{value[4]}", 16),
                               Convert.ToByte($"0x{value[5]}{value[6]}", 16));

                    Rgb3 = new Rgb3(Hex6.First, Hex6.Second, Hex6.Third);
                    break;
                default:
                    throw new HexParseException();
            }
        }
        catch (FormatException)
        {
            Null();

            throw new HexParseException("Every letter must be one of following:\n\n0 1 2 3 4 5 6 7 8 9 AaBbCcDdEeFf");
        }
        catch (NullReferenceException)
        {
            Null();

            throw new HexParseException("Oof");
        }
        catch (Exception ex) when (ex is OutOfMemoryException or InsufficientMemoryException)
        {
            Null();

            throw new HexParseException("Out of memory");
        }

        void Null()
        {
            HexKind = null;
            Hex3 = null;
            Hex6 = null;
            Rgb3 = null;
        }
    }
}
