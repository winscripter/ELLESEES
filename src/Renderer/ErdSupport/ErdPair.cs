using System.Diagnostics.CodeAnalysis;

namespace Renderer.ErdSupport;

internal readonly struct ErdPair : IEquatable<ErdPair>
{
    private readonly KeyValuePair<string, string> pair;

    public ErdPair(string key, string value)
        => pair = new KeyValuePair<string, string>(key, value);

    public ErdPair(KeyValuePair<string, string> pair)
        => this.pair = pair;

    public readonly string Key => pair.Key;
    public readonly string Value => pair.Value;

    public bool Equals(ErdPair other) => (object)this == (object)other;

    public override bool Equals([NotNullWhen(true)]object? obj) => (object)this == obj;
    public override int GetHashCode() => pair.GetHashCode();
}
