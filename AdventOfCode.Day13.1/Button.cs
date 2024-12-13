using AdventOfCode.Shared.Extensions;

namespace AdventOfCode.Day13._1;

public class Button(int x, int y, int cost)
{
    public int X { get; } = x;

    public int Y { get; } = y;

    public int Cost { get; } = cost;

    public static Button Create(string input, int cost)
    {
        var numbers = input.GetInts().ToList();
        return new Button(numbers[0], numbers[1], cost);
    }
}