namespace Ellesees.Effects.Common.Transitions;

public interface ITransition
{
    TransitionKind Kind { get; }
    string DisplayName { get; }
}
