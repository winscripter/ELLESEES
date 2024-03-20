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
using ElleseesUI.SharedControllers;

namespace ElleseesUI.Services.FTU;

/// <summary>
/// Implementation for the First Time Use (FTU) service, which provides straightforward information whenever the user uses ELLESEES for the first time.
/// This system may not be perfect, because the user can delete the <c>ftulock</c> file, which makes ELLESEES think the user just started using ELLESEES again.
/// However, most people that edit videos just focus on the application and don't go into the file structure, so it's probably OK. Either way, it's not a big deal.
/// </summary>
internal class FtuService : IFtuService
{
    /// <summary>
    /// Initializes a new instance of <see cref="FtuService" />
    /// </summary>
    public FtuService()
    {
    }

    /// <inheritdoc />
    public bool IsFirstTimeUse() => !File.Exists(FtuConstants.FtuLockFile);

    /// <inheritdoc />
    public Notification FtuPrimaryNotification => Notification.Create(
        "Welcome to ELLESEES",
        "Thank you for choosing ELLESEES! We hope you like it! Select Help and then Tour to get started.",
        "Greeting",
        "ELLESEES",
        NotificationType.Information
    );

    /// <inheritdoc />
    public void SendFtuNotification() => FtuPrimaryNotification.Send(false);

    /// <inheritdoc />
    public void ValidateAndSendFtuNotification()
    {
        if (IsFirstTimeUse())
        {
            SendFtuNotification();
            SharedUIController.StatusBarService!.SetText("Welcome to ELLESEES! Click View and Notifications to get started!");

            File.Create(FtuConstants.FtuLockFile);
        }
    }
}
