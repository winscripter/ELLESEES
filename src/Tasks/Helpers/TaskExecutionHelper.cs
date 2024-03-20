﻿// MIT License
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

using Ellesees.Base.Logging;
using ElleseesUI.Abstractions;
using ElleseesUI.Core;

namespace ElleseesUI.Tasks.Helpers;

/// <summary>
/// An extension class with 1 method that helps run the task
/// and catch an unhandled exception.
/// </summary>
public static class TaskExecutionHelper
{
    /// <summary>
    /// Runs the task to prevent unhandled exceptions.
    /// </summary>
    /// <param name="task">Task to run.</param>
    public static void TryExecute(this ITask task)
    {
        try
        {
            task.Run();
        }
        catch (Exception ex)
        {
            Logger.Log($"Task {task.GetType().Name} failed with the following exception:{Environment.NewLine}{ex}",
                        LoggerFlags.AppendPriority | LoggerFlags.AppendDateTime,
                        LogPriority.Fatal);

            MessageBoxCommon.ErrorOk("Task failed");
        }
    }
}
