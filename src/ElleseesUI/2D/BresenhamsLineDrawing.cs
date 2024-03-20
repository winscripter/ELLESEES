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
/// Represents Bresenhams Line Drawing algorithms (2D).
/// </summary>
internal static class BresenhamsLineDrawing
{
    /// <summary>
    /// Performs Bresenhams Line Drawing.
    /// </summary>
    /// <param name="x1">Start X.</param>
    /// <param name="y1">Start Y.</param>
    /// <param name="x2">End X.</param>
    /// <param name="y2">End Y.</param>
    /// <returns>2D Coordinates.</returns>
    public static List<(int, int)> GetLineCoordinates(int x1, int y1, int x2, int y2)
    {
        List<(int, int)> coordinates = new();

        int dx = Math.Abs(x2 - x1);
        int dy = Math.Abs(y2 - y1);
        int sx = x1 < x2 ? 1 : -1;
        int sy = y1 < y2 ? 1 : -1;
        int error = dx - dy;
        int x = x1;
        int y = y1;

        while (true)
        {
            coordinates.Add((x, y));

            if (x == x2 && y == y2)
            {
                break;
            }

            int e = 2 * error;

            if (e > -dy)
            {
                error -= dy;
                x += sx;
            }

            if (e < dx)
            {
                error += dx;
                y += sy;
            }
        }

        return coordinates;
    }
}
