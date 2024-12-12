using System.Text.RegularExpressions;

namespace AdventOfCode.Shared;

public static class StringExtensions
{
    private static readonly Dictionary<string, int> nameAndDigits = new(StringComparer.OrdinalIgnoreCase)
    {
        { "zero", 0 },
        { "one", 1 },
        { "two", 2 },
        { "three", 3 },
        { "four", 4 },
        { "five", 5 },
        { "six", 6 },
        { "seven", 7 },
        { "eight", 8 },
        { "nine", 9 }
    };

    public static IEnumerable<int> FindDigits(this string value, bool includeWrittenOutDigits = false)
    {
        var indexAndDigits = new List<(int, int)>();
        for (var i = 0; i < value.Length; i++)
        {
            if (char.IsDigit(value[i]))
            {
                indexAndDigits.Add((i, int.Parse(value[i].ToString())));
            }
        }

        if (includeWrittenOutDigits)
        {
            foreach (var (name, digit) in nameAndDigits)
            {
                var matches = Regex.Matches(value, name, RegexOptions.IgnoreCase);
                foreach (Match match in matches)
                {
                    indexAndDigits.Add((match.Index, digit));
                }
            }
        }

        return indexAndDigits.OrderBy(x => x.Item1).Select(x => x.Item2);
    }

    public static int? GetDigit(this string value)
    {
        if (value.Length == 1 && char.IsDigit(value[0]))
        {
            return int.Parse(value[0].ToString());
        }

        if (nameAndDigits.TryGetValue(value, out var digit))
        {
            return digit;
        }

        return null;
    }

    public static int GetInt(this string value) => int.Parse(value);
    public static double GetDouble(this string value) => double.Parse(value);

    public static IEnumerable<int> GetInts(this string value, string separator) =>
        value.Split(separator).Where(part => !string.IsNullOrWhiteSpace(part)).Select(int.Parse);

    public static IEnumerable<uint> GetUnsignedInts(this string value, string separator) =>
        value.Split(separator).Where(part => !string.IsNullOrWhiteSpace(part)).Select(uint.Parse);

    public static IEnumerable<long> GetLongs(this string value, string separator) =>
        value.Split(separator).Where(part => !string.IsNullOrWhiteSpace(part)).Select(long.Parse);

    public static IEnumerable<double> GetDoubles(this string value, string separator) =>
        value.Split(separator).Where(part => !string.IsNullOrWhiteSpace(part)).Select(double.Parse);

    public static (string First, string Second) SplitAt(this string value, string separator)
    {
        var parts = value.Split(separator);
        return (First: parts[0], Second: parts[1]);
    }

    public static string Join(this IEnumerable<string> values, string separator) => string.Join(separator, values);
}