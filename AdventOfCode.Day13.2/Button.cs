using AdventOfCode.Shared.Extensions;

namespace AdventOfCode.Day13._2;

public class Button(decimal x, decimal y, decimal cost)
{
    public decimal X { get; } = x;

    public decimal Y { get; } = y;

    public decimal Cost { get; } = cost;

    public static Button Create(string input, decimal cost)
    {
        var numbers = input.GetDecimals().ToList();
        return new Button(numbers[0], numbers[1], cost);
    }
}