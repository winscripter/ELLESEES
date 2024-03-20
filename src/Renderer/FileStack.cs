namespace Renderer;

/// <summary>
/// Represents a file stack.
/// </summary>
internal static class FileStack
{
    private static readonly Stack<string> _fileStack = new();

    /// <summary>
    /// Adds a path to the file stack.
    /// </summary>
    /// <param name="path">File path</param>
    public static void Add(string path)
        => _fileStack.Push(path);

    /// <summary>
    /// Pops a file from file stack.
    /// </summary>
    /// <returns>Item popped from stack.</returns>
    public static string Pop()
        => _fileStack.Pop();

    /// <summary>
    /// Returns last item from the stack.
    /// </summary>
    /// <returns>Last item from the stack.</returns>
    public static string Peek()
        => _fileStack.Peek();

    /// <summary>
    /// Pops a file from file stack.
    /// </summary>
    /// <returns>Item popped from the stack, or <see langword="null" /> if stack is empty.</returns>
    public static string? PopOrNull()
        => _fileStack.Count == 0 ? null : Pop();
}
