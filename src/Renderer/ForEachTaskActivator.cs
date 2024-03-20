namespace Renderer;

/// <summary>
/// Signifies whether the <see cref="ForEach" /> task should be activated.
/// </summary>
public static class ForEachTaskActivator
{
    private static bool _isActivated = false;
    private static string _path = ".";

    /// <summary>
    /// Flips ForEach task activation.
    /// </summary>
    /// <returns>After flipping, returns <see langword="true" /> if <see cref="ForEach" /> is now active, <see langword="false" /> if not.</returns>
    public static bool Flip()
    {
        _isActivated = !_isActivated;
        return _isActivated;
    }

    /// <summary>
    /// Path where the files are chucked through.
    /// </summary>
    public static string StorePath
    {
        get => _path;
        set => _path = value;
    }

    /// <summary>
    /// Checks whether the For Each Task is activated.
    /// </summary>
    public static bool IsActivated => _isActivated;
}
