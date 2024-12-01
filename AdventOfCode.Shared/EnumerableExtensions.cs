namespace AdventOfCode.Shared;

public static class EnumerableExtensions
{
    public static IEnumerable<T> WhereNotNull<T>(this IEnumerable<Nullable<T>> source) where T : struct => source.OfType<T>();
    
    public static IEnumerable<T> WhereNotNull<T>(this IEnumerable<T?> source) => source.OfType<T>();

    public static TResult[,] Map<TSource, TResult>(this TSource[,] source, Func<TSource, int, int, TResult> resultSelector)
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
}
