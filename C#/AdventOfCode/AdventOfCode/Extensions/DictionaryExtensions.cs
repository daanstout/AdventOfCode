namespace AdventOfCode;

/// <summary>
/// A class containing extensions to <see cref="IDictionary{TKey, TValue}"/>s.
/// </summary>
public static class DictionaryExtensions {
    /// <summary>
    /// Gets a value from a <see cref="IDictionary{TKey, TValue}"/>, or creates a default value if it doesn't exist yet.
    /// </summary>
    /// <typeparam name="TKey">The type of the key to the <see cref="IDictionary{TKey, TValue}"/>.</typeparam>
    /// <typeparam name="TValue">The type of the value stored in the <see cref="IDictionary{TKey, TValue}"/>.</typeparam>
    /// <param name="dictionary">The dictionary to obtain the value from.</param>
    /// <param name="key">The key to the value.</param>
    /// <returns>The value stored at the specified key, or the default value if it doesn't exist yet.</returns>
    /// <exception cref="ArgumentNullException">Thrown if <paramref name="dictionary"/> is <see langword="null"/></exception>
    public static TValue? GetOrCreate<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key) {
        if (dictionary == null)
            throw new ArgumentNullException(nameof(dictionary));

        if (!dictionary.TryGetValue(key, out var value)) {
            value = default;
            dictionary.Add(key, default!);
        }

        return value!;
    }

    /// <summary>
    /// Gets a value from a <see cref="IDictionary{TKey, TValue}"/>, or creates one from the <paramref name="createFunc"/> if it doesn't exist yet.
    /// </summary>
    /// <typeparam name="TKey">The type of the key to the <see cref="IDictionary{TKey, TValue}"/>.</typeparam>
    /// <typeparam name="TValue">The type of the value stored in the <see cref="IDictionary{TKey, TValue}"/>,</typeparam>
    /// <param name="dictionary">The dictionary to obtain the value from.</param>
    /// <param name="key">The key to the value.</param>
    /// <param name="createFunc">The function to call to create a new value if it doesn't exist yet in the <see cref="IDictionary{TKey, TValue}"/>.</param>
    /// <returns>The value stored at the specified key.</returns>
    public static TValue GetOrCreate<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, Func<TValue> createFunc) {
        if (!dictionary.TryGetValue(key, out var value)) {
            value = createFunc();
            dictionary.Add(key, value);
        }

        return value;
    }
}
