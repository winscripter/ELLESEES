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

namespace ElleseesUI.Services.PropertyEditor;

/// <summary>
/// Type of a property displayed in the property editor dialog
/// </summary>
internal enum PropertyItem : byte
{
    /// <summary>
    /// Property editor displays video properties
    /// </summary>
    Video,

    /// <summary>
    /// Property editor displays audio properties
    /// </summary>
    Audio,

    /// <summary>
    /// Property editor displays image properties
    /// </summary>
    Image,

    /// <summary>
    /// Property editor displays text properties
    /// </summary>
    Text,

    /// <summary>
    /// Property editor displays rectangle properties
    /// </summary>
    Rectangle,

    /// <summary>
    /// Property editor displays fill properties
    /// </summary>
    Fill,

    /// <summary>
    /// Property editor displays object properties
    /// </summary>
    Object,

    /// <summary>
    /// Property editor displays independent effect information
    /// </summary>
    AnyEffect,

    /// <summary>
    /// Property editor displays dependent effect information
    /// </summary>
    Effect
}
