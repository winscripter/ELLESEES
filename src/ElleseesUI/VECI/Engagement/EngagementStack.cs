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

namespace ElleseesUI.VECI.Engagement;

internal class EngagementStack
{
    private readonly Stack<StateSnapshot> _items;
    private readonly Stack<StateSnapshot> _undoHistory;

    public EngagementStack()
    {
        _items = new Stack<StateSnapshot>();
        _undoHistory = new Stack<StateSnapshot>();
    }

    public void Do(StateSnapshot stack)
    {
        _items.Push(stack);
    }

    public StateSnapshot Undo()
    {
        var val = _items.Pop();
        _undoHistory.Push(val);
        return val;
    }

    public StateSnapshot Redo()
    {
        var val = _undoHistory.Pop();
        _items.Push(val);
        return val;
    }

    public bool IsSuitableForUndo => _items.Count != 0;
    public bool IsSuitableForRedo => _undoHistory.Count != 0;

    public StateSnapshot[] Items => _items.ToArray();
    public StateSnapshot[] UndoHistory => _undoHistory.ToArray();
}
