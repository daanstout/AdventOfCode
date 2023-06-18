namespace AdventOfCode;

public static class DictionaryExtensions {
    public static TValue GetOrCreate<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key) {
        if (!dictionary.TryGetValue(key, out var value)) {
            value = default;
            dictionary.Add(key, default!);
        }

        return value!;
    }

    public static TValue GetOrCreate<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, Func<TValue> createFunc) {
        if (!dictionary.TryGetValue(key, out var value)) {
            value = createFunc();
            dictionary.Add(key, value);
        }

        return value;
    }
}
