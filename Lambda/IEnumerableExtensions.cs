public static class IEnumerableExtensions
{
    public static IEnumerable<TResult> Select<TSource, TResult>(
        this IEnumerable<TSource> source,
        Func<TSource, TResult> selector)
    {
        foreach (var current in source)
        {
            yield return selector(current);
        }
    }
}