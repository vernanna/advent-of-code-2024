using AdventOfCode.Shared.Extensions;

namespace AdventOfCode.Day13._1;

public class Prize(int x, int y)
{
    public int X { get; } = x;

    public int Y { get; } = y;

    public static Prize Create(string input)
    {
        var numbers = input.GetInts().ToList();
        return new Prize(numbers[0], numbers[1]);
    }
}