namespace AdventOfCode.Shared.Extensions;

public static class DoubleExtensions
{
    public static double Concat(this IEnumerable<double> values) =>
        double.Parse(values.Select(value => value.ToString("F0")).Join(""));

    public static int? ToIntOrNull(this double value)
    {
        if (Math.Abs(value - Math.Round(value)) > 0)
        {
            return null;
        }

        return (int)Math.Round(value);
    }

    public static long? ToLongOrNull(this double value)
    {
        if (Math.Abs(value - Math.Round(value)) > 0)
        {
            return null;
        }

        return (long)Math.Round(value);
    }
}