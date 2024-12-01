namespace AdventOfCode.Shared;

public class Character(char Value)
{
    public bool IsDigit => char.IsDigit(Value);

    public int? AsDigit => int.TryParse(Value.ToString(), out var digit) ? digit : null;

    public char Value { get; } = Value;
}