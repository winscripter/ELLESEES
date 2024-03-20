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

using ElleseesUI.Core;
using ElleseesUI.SharedControllers;

namespace ElleseesUI.Notifications;

/// <summary>
/// Represents a notification
/// </summary>
public class Notification : INotification
{
    private readonly string m_title;
    private readonly string m_description;
    private readonly string m_category;
    private readonly string m_timeSent;
    private readonly string m_source;
    private readonly string m_type;
    private readonly uint m_ID;

    /// <summary>
    /// Initializes a new instance of <see cref="Notification" />
    /// </summary>
    /// <param name="title">Title of the notification, This must be a short string, ranging from 1 to 40 letters.</param>
    /// <param name="description">Notification body. This must be a short string, ranging from 1 to 125 letters.</param>
    /// <param name="category">Category of the notification</param>
    /// <param name="timeSent">Time when the notification was sent</param>
    /// <param name="source">Where the notification comes from. This must be a short string, ranging from 1 to 30 letters.</param>
    /// <param name="type">A type of the notification</param>
    /// <param name="id">An ID of the notification</param>
    public Notification(string title, string description, string category, string timeSent, string source, NotificationType type, uint id)
    {
        NotificationException.ThrowIf(title.Length is < 1 or > 40, $"Notification title length must not have less than 1 or greater than 40 letters; got {title.Length}");
        NotificationException.ThrowIf(description.Length is < 1 or > 125, $"Notification description length must not have less than 1 or greater than 125 letters; got {description.Length}");
        NotificationException.ThrowIf(source.Length is < 1 or > 30, $"Notification source length must not have less than 1 or greater than 30 letters; got {source.Length}");

        m_title = title;
        m_description = description;
        m_category = category;
        m_timeSent = timeSent;
        m_source = source;
        m_type = NotificationFormatter.FormatType(type);
        m_ID = id;
    }

    /// <inheritdoc />
    public string Title => m_title;
    /// <inheritdoc />
    public string Description => m_description;
    /// <inheritdoc />
    public string Category => m_category;
    /// <inheritdoc />
    public string TimeSent => m_timeSent;
    /// <inheritdoc />
    public string From => m_source;
    /// <inheritdoc />
    public string Type => m_type;
    /// <inheritdoc />
    public uint ID => m_ID;

    /// <summary>
    /// Creates a notification based on fewer data.
    /// </summary>
    /// <param name="title">Title of the notification.</param>
    /// <param name="description">Description of the notification.</param>
    /// <param name="category">Category of the notification.</param>
    /// <param name="source">Source of the notification.</param>
    /// <param name="type">Type of the notification.</param>
    /// <returns>A new notification.</returns>
    public static Notification Create(string title, string description, string category, string source, NotificationType type)
        => new(title, description, category, DateTime.Now.ToString(), source, type, NotificationStore.GenerateNotificationID());

    /// <inheritdoc />
    public void Send(bool showOnStatusBar = true)
    {
        if (!SharedUIController.IsStatusBarServiceLoaded())
        {
            MessageBoxCommon.ErrorOk($"A notification from \"{From}\" could not be sent.");

            return;
        }

        if (showOnStatusBar)
        {
            SharedUIController.StatusBarService!.SetText($"New unread notification (ID: {ID}). Click View and then Notifications to check it out!");
        }

        NotificationStore.AddNotification(this);
    }
}
