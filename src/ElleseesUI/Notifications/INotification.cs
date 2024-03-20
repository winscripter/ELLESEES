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
/// Represents a notification.
/// </summary>
public interface INotification
{
    /// <summary>
    /// Notification title, a short text containing the topic.
    /// </summary>
    string Title { get; }

    /// <summary>
    /// Notification description, e.g. text displayed in the notification (notification body).
    /// </summary>
    string Description { get; }

    /// <summary>
    /// Notification category, e.g. what the notification is about.
    /// </summary>
    string Category { get; }

    /// <summary>
    /// Time when the notification was sent.
    /// </summary>
    string TimeSent { get; }

    /// <summary>
    /// Source where the notification comes from.
    /// </summary>
    /// <remarks>
    /// This property would've been named <c>Source</c>, but that would conflict with XAML bindings, so it is
    /// named <c>From</c> to prevent conflicts.
    /// </remarks>
    string From { get; }

    /// <summary>
    /// Type of the notification (suggestion, error, information, etc).
    /// </summary>
    string Type { get; }

    /// <summary>
    /// Notification ID.
    /// </summary>
    uint ID { get; }

    /// <summary>
    /// Sends the notification.
    /// </summary>
    /// <param name="showOnStatusBar">
    /// Show the text on the status bar about the new unread notification or not?
    /// </param>
    void Send(bool showOnStatusBar = true);
}
