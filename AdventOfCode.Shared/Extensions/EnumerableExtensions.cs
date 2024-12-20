namespace AdventOfCode.Shared.Extensions;

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

    public static int IndexOf<T>(this IEnumerable<T> source, T element) where T : IEquatable<T>
    {
        foreach (var (index, item) in source.Index())
        {
            if (EqualityComparer<T>.Default.Equals(item, element))
            {
                return index;
            }
        }

        return -1;
    }

    public static IEnumerable<IEnumerable<T>> GetPermutations<T>(this IEnumerable<T> source, int length)
    {
        source = source.ToList();
        return length == 1
            ? source.Select(item => new[] { item })
            : GetPermutations(source, length - 1).SelectMany(permutation => source.Select(permutation.Append));
    }

    public static IEnumerable<(T First, T Second)> UniquePairs<T>(this IEnumerable<T> source)
    {
        source = source.ToList();
        return source.SelectMany(
            (_, index) => source.Skip(index + 1),
            (first, second) => (item1: first, item2: second));
    }

    public static int FindIndex<T>(this IEnumerable<T> source, Func<T, bool> predicate)
    {
        foreach (var itemAndIndex in source.Index())
        {
            if (predicate(itemAndIndex.Item))
            {
                return itemAndIndex.Index;
            }
        }

        return -1;
    }

    public static ulong Sum(this IEnumerable<ulong> source)
    {
        ulong sum = 0;
        foreach (var value in source)
        {
            checked
            {
                sum += value;
            }
        }

        return sum;
    }

    public static ulong Sum<TSource>(this IEnumerable<TSource> source, Func<TSource, ulong> selector) =>
        source.Select(selector).Sum();
}