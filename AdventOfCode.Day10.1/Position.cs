namespace AdventOfCode.Day10._1;

public class Position(int height)
{
    public int Height { get; } = height;

    public static Position Create(char height) => new(int.Parse(height.ToString()));
}