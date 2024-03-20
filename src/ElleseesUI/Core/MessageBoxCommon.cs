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

using System.Windows;

namespace ElleseesUI.Core;

/// <summary>
/// A variety of shortcuts to display message boxes in one line
/// </summary>
internal static class MessageBoxCommon
{
    /// <summary>
    /// The title displayed on every message box, which is hardcoded to ELLESEES by default.
    /// </summary>
    public const string Title = "ELLESEES";

    #region Errors

    /// <summary>
    /// Displays an error message box with one button: OK
    /// </summary>
    /// <param name="message">A message to display</param>
    /// <returns>The message box result, e.g. what button did the user click on</returns>
    public static MessageBoxResult ErrorOk(string message)
        => MessageBox.Show(message, Title, MessageBoxButton.OK, MessageBoxImage.Error);

    /// <summary>
    /// Displays an error message box with 2 buttons: Yes, No
    /// </summary>
    /// <param name="message">A message to display</param>
    /// <returns>The message box result, e.g. what button did the user click on</returns>
    public static MessageBoxResult ErrorYesNo(string message)
        => MessageBox.Show(message, Title, MessageBoxButton.YesNo, MessageBoxImage.Error);

    /// <summary>
    /// Displays an error message box with 3 buttons: Yes, No, Cancel
    /// </summary>
    /// <param name="message">A message to display</param>
    /// <returns>The message box result, e.g. what button did the user click on</returns>
    public static MessageBoxResult ErrorYesNoCancel(string message)
        => MessageBox.Show(message, Title, MessageBoxButton.YesNoCancel, MessageBoxImage.Error);

    /// <summary>
    /// Displays an error message box with 2 buttons: OK, Cancel
    /// </summary>
    /// <param name="message">A message to display</param>
    /// <returns>The message box result, e.g. what button did the user click on</returns>
    public static MessageBoxResult ErrorOkCancel(string message)
        => MessageBox.Show(message, Title, MessageBoxButton.OKCancel, MessageBoxImage.Error);
    #endregion

    #region Warnings

    /// <summary>
    /// Displays a warning message box with one button: OK
    /// </summary>
    /// <param name="message">A message to display</param>
    /// <returns>The message box result, e.g. what button did the user click on</returns>
    public static MessageBoxResult WarnOk(string message)
        => MessageBox.Show(message, Title, MessageBoxButton.OK, MessageBoxImage.Warning);

    /// <summary>
    /// Displays a warning message box with 2 buttons: Yes, No
    /// </summary>
    /// <param name="message">A message to display</param>
    /// <returns>The message box result, e.g. what button did the user click on</returns>
    public static MessageBoxResult WarnYesNo(string message)
        => MessageBox.Show(message, Title, MessageBoxButton.YesNo, MessageBoxImage.Warning);

    /// <summary>
    /// Displays a warning message box with 3 buttons: Yes, No, Cancel
    /// </summary>
    /// <param name="message">A message to display</param>
    /// <returns>The message box result, e.g. what button did the user click on</returns>
    public static MessageBoxResult WarnYesNoCancel(string message)
        => MessageBox.Show(message, Title, MessageBoxButton.YesNoCancel, MessageBoxImage.Warning);

    /// <summary>
    /// Displays a warning message box with 2 buttons: OK, Cancel
    /// </summary>
    /// <param name="message">A message to display</param>
    /// <returns>The message box result, e.g. what button did the user click on</returns>
    public static MessageBoxResult WarnOkCancel(string message)
        => MessageBox.Show(message, Title, MessageBoxButton.OKCancel, MessageBoxImage.Warning);
    #endregion

    #region Information

    /// <summary>
    /// Displays an info message box with one button: OK
    /// </summary>
    /// <param name="message">A message to display</param>
    /// <returns>The message box result, e.g. what button did the user click on</returns>
    public static MessageBoxResult InfoOk(string message)
        => MessageBox.Show(message, Title, MessageBoxButton.OK, MessageBoxImage.Information);

    /// <summary>
    /// Displays an info message box with 2 buttons: Yes, No
    /// </summary>
    /// <param name="message">A message to display</param>
    /// <returns>The message box result, e.g. what button did the user click on</returns>
    public static MessageBoxResult InfoYesNo(string message)
        => MessageBox.Show(message, Title, MessageBoxButton.YesNo, MessageBoxImage.Information);

    /// <summary>
    /// Displays an info message box with 3 buttons: Yes, No, Cancel
    /// </summary>
    /// <param name="message">A message to display</param>
    /// <returns>The message box result, e.g. what button did the user click on</returns>
    public static MessageBoxResult InfoYesNoCancel(string message)
        => MessageBox.Show(message, Title, MessageBoxButton.YesNoCancel, MessageBoxImage.Information);

    /// <summary>
    /// Displays an info message box with 2 buttons: OK, Cancel
    /// </summary>
    /// <param name="message">A message to display</param>
    /// <returns>The message box result, e.g. what button did the user click on</returns>
    public static MessageBoxResult InfoOkCancel(string message)
        => MessageBox.Show(message, Title, MessageBoxButton.OKCancel, MessageBoxImage.Information);
    #endregion
}
