using Renderer.ErdSupport;

namespace Renderer;

/// <summary>
/// Base class for all tasks
/// </summary>
internal abstract class CommonTask
{
    public TaskKind Kind { get; set; }

    public CommonTask(TaskKind kind) => Kind = kind;

    /// <summary>
    /// Runs the task
    /// </summary>
    /// <param name="item">Options</param>
    public abstract void Run(ErdItem item);
}
