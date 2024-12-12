namespace AdventOfCode.Shared;

public class Character(char Value)
{
    public bool IsDigit => char.IsDigit(Value);

    public int? AsDigit => int.TryParse(Value.ToString(), out var digit) ? digit : null;

    public char Value { get; } = Value;

    public override string ToString() => Value.ToString();

    public static bool operator ==(Character? first, Character? second)
    {
        if (ReferenceEquals(first, second))
        {
            return true;
        }
        if (first is null || second is null)
        {
            return false;
        }

        return first.Value == second.Value;
    }

    public static bool operator !=(Character obj1, Character obj2) => !(obj1 == obj2);

    public override bool Equals(object? obj)
    {
        if (obj is Character other)
        {
            return this == other;
        }

        return false;
    }

    public override int GetHashCode() => HashCode.Combine(Value);
}