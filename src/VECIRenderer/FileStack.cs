namespace VECIRenderer;

internal static class FileStack
{
    private static Stack<string> _fileNames = new();

    public static void Push(string name) => _fileNames.Push(name);
    public static string Pop() => _fileNames.Pop();
    public static string Peek() => _fileNames.Peek();
}
