namespace AdventOfCode.Shared;

public class Entry<TId, TValue>(TId id, TValue value)
{
    public TId Id { get; } = id;

    public TValue Value { get; } = value;
}
