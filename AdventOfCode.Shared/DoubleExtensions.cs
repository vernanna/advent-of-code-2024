namespace AdventOfCode.Shared;

public static class DoubleExtensions
{
    public static double Concat(this IEnumerable<double> values) => double.Parse(values.Select(value => value.ToString("F0")).Join(""));
}