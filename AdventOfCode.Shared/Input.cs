namespace AdventOfCode.Shared;

public static class Input
{
    private const string InputPath = "Input.txt";

    public static IEnumerable<string> ReadLines() => File.ReadAllLines(InputPath);

    public static Table<Character> ReadTable()
    {
        var lines = ReadLines().ToList();

        var array = new Character[lines.Count, lines[0].Length];

        for (int i = 0; i < lines.Count; i++)
        {
            for (int j = 0; j < lines[i].Length; j++)
            {
                array[i, j] = new Character(lines[i][j]);
            }
        }

        return new Table<Character>(array);
    }

    public static Table<TResult> ReadTable<TResult>(Func<char, TResult> resultSelector)
    {
        var lines = ReadLines().ToList();

        var array = new TResult[lines.Count, lines[0].Length];

        for (int i = 0; i < lines.Count; i++)
        {
            for (int j = 0; j < lines[i].Length; j++)
            {
                array[i, j] = resultSelector(lines[i][j]);
            }
        }

        return new Table<TResult>(array);
    }

    public static IEnumerable<Entry<TId, TValue>> ReadEntries<TId, TValue>(string idSeparator, Func<string, TId> idSelector, Func<string, TValue> valueSelector) =>
        ReadLines()
            .Select(
                line =>
                {
                    var parts = line.Split(idSeparator);
                    return new Entry<TId, TValue>(idSelector(parts[0]), valueSelector(parts[1]));
                });
}