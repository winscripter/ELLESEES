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

using ElleseesUI.Views.PropertyEditor;
using System.Windows.Controls;

namespace ElleseesUI.Services.PropertyEditor;

/// <summary>
/// Property Editor lets you edit information about an object
/// in ELLESEES
/// </summary>
internal class PropertyEditorService : IPropertyEditorService
{
    private Frame _ui;

    /// <summary>
    /// Initializes a new instance of <see cref="PropertyEditorService" /> with the
    /// <see cref="Frame" />, which is the child control of <see cref="VideoEditorUI" />
    /// which is the Property Editor frame.
    /// </summary>
    /// <param name="ui">Child control of <see cref="VideoEditorUI" /></param>
    /// <returns>A new instance of <see cref="PropertyEditorService" /></returns>
    public PropertyEditorService(Frame ui)
    {
        _ui = ui;
    }

    /// <summary>
    /// Initializes a new instance of <see cref="PropertyEditorService" /> with the
    /// <see cref="Frame" />, which is the child control of <see cref="VideoEditorUI" />
    /// which is the Property Editor frame.
    /// </summary>
    /// <param name="ui">Child control of <see cref="VideoEditorUI" /></param>
    /// <returns>A new instance of <see cref="PropertyEditorService" /></returns>
    /// <remarks>
    /// An alias for this method is <see cref="PropertyEditorService(Frame)" />
    /// </remarks>
    public static PropertyEditorService Load(Frame ui)
        => new(ui);

    /// <inheritdoc />
    public void ShowPlaceholder()
    {
        _ui.Content = new PlaceholderView();
    }

    /// <inheritdoc />
    public Frame UI
    {
        get => _ui;
        set => _ui = value;
    }

    /// <summary>
    /// A placeholder visibility for the property editor frame
    /// </summary>
    public static Page Placeholder => new PlaceholderView();
}
