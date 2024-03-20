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

namespace ElleseesUI.Core.FrameEditor;

internal class ActionList
{
    private readonly Stack<CommonAction> _fileModifications;
    private readonly Stack<CommonAction> _undoHistory;

    public ActionList()
    {
        _fileModifications = new();
        _undoHistory = new();
    }

    public void Do(CommonAction file)
    {
        _fileModifications.Push(file);
    }

    public CommonAction Undo()
    {
        var action = _fileModifications.Pop();

        _undoHistory.Push(action);

        return action;
    }

    public CommonAction Redo()
    {
        var value = _undoHistory.Pop();

        _fileModifications.Push(value);
        return value;
    }

    public CommonAction[] Modifications { get {  return _fileModifications.ToArray(); } }
    public CommonAction[] UndoHistory { get { return _undoHistory.ToArray(); } }
    public bool IsEmpty { get { return Modifications.Length == 0 || UndoHistory.Length == 0; } }
    public bool IsSuitableForUndo { get { return Modifications.Length != 0; } }
    public bool IsSuitableForRedo { get { return UndoHistory.Length != 0; } }
    public CommonAction Current { get { return _fileModifications.Peek(); } }
}
