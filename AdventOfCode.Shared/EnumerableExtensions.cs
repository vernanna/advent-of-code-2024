namespace AdventOfCode.Shared;

public static class EnumerableExtensions
{
    public static IEnumerable<T> WhereNotNull<T>(this IEnumerable<Nullable<T>> source) where T : struct =>
        source.OfType<T>();

    public static IEnumerable<T> WhereNotNull<T>(this IEnumerable<T?> source) => source.OfType<T>();

    public static TResult[,] Map<TSource, TResult>(
        this TSource[,] source,
        Func<TSource, int, int, TResult> resultSelector)
    {
        int rows = source.GetLength(0);
        int columns = source.GetLength(1);

        var result = new TResult[rows, columns];

        for (int row = 0; row < rows; row++)
        {
            for (int column = 0; column < columns; column++)
            {
                result[row, column] = resultSelector(source[row, column], row, column);
            }
        }

        return result;
    }

    public static bool IsOrdered<T>(this IEnumerable<T?> source)
    {
        source = source.ToList();
        var ascendingSource = source.Order().ToList();
        var descendingSource = source.OrderDescending().ToList();

        return source.SequenceEqual(ascendingSource) || source.SequenceEqual(descendingSource);
    }

    public static bool ContainsDuplicates<T>(this IEnumerable<T> source) =>
        source.GroupBy(item => item).Any(grouping => grouping.Count() > 1);

    public static IEnumerable<T> Duplicates<T>(this IEnumerable<T> source) =>
        source
            .GroupBy(item => item)
            .Where(grouping => grouping.Count() > 1)
            .SelectMany(grouping => grouping);

    public static IEnumerable<(T Previous, T Next)> Pairwise<T>(this IEnumerable<T> source)
    {
        source = source.ToList();
        return source.Zip(source.Skip(1), (first, second) => (first, second));
    }
}