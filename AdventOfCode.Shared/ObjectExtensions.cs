namespace AdventOfCode.Shared;

public static class ObjectExtensions
{
    public static TResult Map<TSource, TResult>(this TSource source, Func<TSource, TResult> resultSelector) => resultSelector(source);
}
