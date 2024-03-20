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

using System.Collections.ObjectModel;

namespace ElleseesUI.Notifications;

/// <summary>
/// Contains a list of notifications.
/// </summary>
public static class NotificationStore
{
    /// <summary>
    /// All unread notifications.
    /// </summary>
    public static readonly ObservableCollection<Notification> UnreadNotifications = new();

    /// <summary>
    /// Adds a notification.
    /// </summary>
    /// <param name="notification">Notification to add</param>
    public static void AddNotification(Notification notification) => UnreadNotifications.Add(notification);

    /// <summary>
    /// Clears unread notifications.
    /// </summary>
    public static void ReadAll() => UnreadNotifications.Clear();

    /// <summary>
    /// Returns an unread <see cref="Notification" /> based on its ID, or <see langword="null" /> if there's no notification by its ID.
    /// </summary>
    /// <param name="id">The ID to search a notification for</param>
    /// <returns><see cref="Notification" /> by its <paramref name="id"/>, or <see langword="null" /> if there's no unread notification with a specified ID</returns>
    public static Notification? GetNotificationByID(uint id) => UnreadNotifications.Where(x => x.ID == id).FirstOrDefault();

    /// <summary>
    /// Generates an unoccupied notification by its ID to ensure no duplicates exist.
    /// </summary>
    /// <returns>Available notification ID</returns>
    public static uint GenerateNotificationID()
    {
        uint i = (uint)Random.Shared.Next(1, int.MaxValue);

        while (GetNotificationByID(i) != null)
        {
            i = (uint)Random.Shared.Next(1, int.MaxValue);
        }

        return i;
    }
}
