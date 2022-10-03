namespace Tools
{
    public static class Operators
    {
        public static IEnumerable<TSource> Get<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            foreach (TSource item in source)
            {
                if (predicate(item))
                    yield return item;
            }
        }

        public static IEnumerable<TResult> Transform<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> transformator)
        {
            foreach (TSource item in source)
            {
                yield return transformator(item);
            }
        }
    }
}