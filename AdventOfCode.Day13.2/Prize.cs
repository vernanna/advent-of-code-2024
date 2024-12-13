using AdventOfCode.Shared.Extensions;

namespace AdventOfCode.Day13._2;

public class Prize(decimal x, decimal y)
{
    public decimal X { get; } = x;

    public decimal Y { get; } = y;

    public static Prize Create(string input)
    {
        var numbers = input.GetDecimals().Select(number => number + 10000000000000).ToList();
        var x = numbers[0];
        var y = numbers[1];

        return new Prize(x, y);
    }
}