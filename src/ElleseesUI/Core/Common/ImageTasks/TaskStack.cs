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

namespace ElleseesUI.Core.Common.ImageTasks;

/// <summary>
/// A list of tasks applied on an image
/// </summary>
internal class TaskStack
{
    /// <summary>
    /// A list of valid image tasks
    /// </summary>
    public static readonly Type[] ValidTaskTypes =
    {
        typeof(GrayscaleBt709), typeof(GrayscaleBt601), typeof(Grayscale),
        typeof(BoxBlur), typeof(BokehBlur), typeof(GaussianBlur),
        typeof(Saturate), typeof(Lightness), typeof(Brightness),
        typeof(Glow), typeof(GlowBy), typeof(BoxBlurBy), typeof(BokehBlurBy),
        typeof(BlackAndWhite), typeof(Contrast), typeof(ColorBlindness),
        typeof(Background), typeof(Crop), typeof(Resize), typeof(Scale),
        typeof(Text), typeof(Rotate), typeof(RectangleFill), typeof(Hue)
    };

    private readonly Stack<object> _stack;

    /// <summary>
    /// Initializes a new instance of <see cref="TaskStack" />
    /// </summary>
    public TaskStack()
    {
        _stack = new();
    }

    /// <summary>
    /// Adds an image task
    /// </summary>
    /// <typeparam name="T">Image task type</typeparam>
    /// <param name="task">Task</param>
    /// <exception cref="ArgumentException">Exception thrown when an invalid task type was requested</exception>
    public void Push<T>(T task)
        where T : class
    {
        if (!ValidTaskTypes.Contains(typeof(T)))
        {
            throw new ArgumentException($"Not a valid task", nameof(task));
        }

        _stack.Push(task);
    }

    /// <summary>
    /// Pops an image task
    /// </summary>
    /// <returns>Image task</returns>
    public object Pop() => _stack.Pop();

    /// <summary>
    /// Returns all image tasks in this instance of <see cref="TaskStack" />
    /// </summary>
    public object[] Items => _stack.ToArray();
}
