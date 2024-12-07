namespace AdventOfCode.Shared;

public static class IntExtensions
{
    public static int Concat(this IEnumerable<int> values) => int.Parse(values.Select(value => value.ToString()).Join(""));
}