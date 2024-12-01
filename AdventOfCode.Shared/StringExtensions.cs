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

    public static IEnumerable<int> GetNumbers(this string value, string separator) =>
        value.Split(separator).Where(part => !string.IsNullOrWhiteSpace(part)).Select(part => int.Parse(part));

    public static (string First, string Second) SplitAt(this string value, string separator)
    {
        var parts = value.Split(separator);
        return (First: parts[0], Second: parts[1]);
    }
}
