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

namespace ElleseesUI.FaultList;

/// <summary>
/// Represents an unhandled exception.
/// </summary>
public class Fault
{
    /// <summary>
    /// A name of a class that triggered the exception.
    /// </summary>
    public string ExceptionClassName { get; init; } = string.Empty;

    /// <summary>
    /// Exception message.
    /// </summary>
    public string ExceptionMessage { get; init; } = string.Empty;

    /// <summary>
    /// Stack trace of the exception.
    /// </summary>
    public string StackTrace { get; init; } = string.Empty;

    /// <summary>
    /// When did the exception happen?
    /// </summary>
    public string HappenedIn { get; init; } = string.Empty;

    /// <summary>
    /// ID of the exception. Zero is reserved for "uninitialized".
    /// </summary>
    public int ID { get; init; } = 0;

    /// <summary>
    /// Creates a new instance of <see cref="Fault" /> using just an exception.
    /// </summary>
    /// <param name="ex">Unhandled exception that occurred.</param>
    /// <returns>A new instance of <see cref="Fault" /> with appropriate values initialized based on the exception.</returns>
    public static Fault Create(Exception ex)
        => new()
        {
            ExceptionClassName = ex.GetType().Name,
            ExceptionMessage = ex.Message,
            StackTrace = ex.StackTrace is null ? "Unknown" : ex.StackTrace,
            HappenedIn = DateTime.Now.ToString(),
        };
}
