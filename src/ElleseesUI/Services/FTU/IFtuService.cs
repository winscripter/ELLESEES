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

using ElleseesUI.Notifications;

namespace ElleseesUI.Services.FTU;

/// <summary>
/// Represents an interface for ELLESEES First Time Use (FTU) service - <see cref="FtuService" />.
/// </summary>
internal interface IFtuService
{
    /// <summary>
    /// Checks whether the user uses ELLESEES for the first time on a local computer.
    /// </summary>
    /// <returns><see langword="true" /> if this is the first time user uses ELLESEES, <see langword="false" /> otherwise.</returns>
    bool IsFirstTimeUse();

    /// <summary>
    /// Sends First Time Use notification.
    /// </summary>
    void SendFtuNotification();

    /// <summary>
    /// Gets the notification that will be sent during the FTU event.
    /// </summary>
    Notification FtuPrimaryNotification { get; }

    /// <summary>
    /// Sends the FTU primary notification if the user uses ELLESEES for the first time, and then creates a ftulock file.
    /// </summary>
    void ValidateAndSendFtuNotification();
}
