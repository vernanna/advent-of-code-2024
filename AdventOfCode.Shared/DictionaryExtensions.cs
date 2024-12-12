namespace AdventOfCode.Shared;

public static class DictionaryExtensions
{
    public static TValue GetOrAdd<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, Func<TKey, TValue> valueFactory)
        {
            if (!dictionary.TryGetValue(key, out var value))
            {
                value = valueFactory(key);
                dictionary[key] = value;
            }

            return value;
        }
}