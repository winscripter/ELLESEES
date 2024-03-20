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

namespace ElleseesUI.Notifications;

/// <summary>
/// Represents a type of a notification.
/// </summary>
[Flags]
public enum NotificationType : byte
{
    /// <summary>
    /// No notification type; it's just a notification...
    /// </summary>
    None = 1,

    /// <summary>
    /// A notification is something informative.
    /// </summary>
    Information = 2,

    /// <summary>
    /// A notification informs something the user may need to be aware of.
    /// </summary>
    Warning = 4,

    /// <summary>
    /// A notification informs a failure.
    /// </summary>
    Error = 8,

    /// <summary>
    /// A notification informs a fatal failure that may need to be recovered.
    /// </summary>
    Fatal = 16,

    /// <summary>
    /// A notification represents a suggestion, e.g. something the user may want to give a try.
    /// </summary>
    Suggestion = 32,

    /// <summary>
    /// A notification represents a tip, likely a tip of the day.
    /// </summary>
    Tip = 64,
}
