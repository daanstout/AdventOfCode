using System.Numerics;

namespace AdventOfCode;

/// <summary>
/// A class containing extensions to <see cref="IEnumerable{T}"/>s.
/// </summary>
public static class IEnumerableExtensions {
    /// <summary>
    /// Transforms a <see cref="string"/> <see cref="IEnumerable{T}"/> to an <see cref="int"/> <see cref="Array"/>.
    /// </summary>
    /// <param name="enumerable">The <see cref="IEnumerable{T}"/> to parse.</param>
    /// <returns>An <see cref="int"/> <see cref="Array"/> with values parsed from <paramref name="enumerable"/>.</returns>
    public static int[] ToIntArray(this IEnumerable<string> enumerable) => enumerable.ToArray(int.Parse);

    /// <summary>
    /// Transforms a <see cref="char"/> <see cref="IEnumerable{T}"/> to an <see cref="int"/> <see cref="Array"/>.
    /// </summary>
    /// <param name="enumerable">The <see cref="IEnumerable{T}"/> to parse.</param>
    /// <returns>An <see cref="int"/> <see cref="Array"/> with values parsed from <paramref name="enumerable"/>,</returns>
    public static int[] ToIntArray(this IEnumerable<char> enumerable) => enumerable.ToArray(c => c.ToInt32());

    /// <summary>
    /// Transforms a <see cref="string"/> <see cref="IEnumerable{T}"/> to a <see cref="float"/> <see cref="Array"/>.
    /// </summary>
    /// <param name="enumerable">The <see cref="IEnumerable{T}"/> to parse.</param>
    /// <returns>A <see cref="float"/> <see cref="Array"/> with values parsed from <paramref name="enumerable"/>.</returns>
    public static float[] ToFloatArray(this IEnumerable<string> enumerable) => enumerable.ToArray(float.Parse);

    /// <summary>
    /// Transforms a <see cref="string"/> <see cref="IEnumerable{T}"/> to an <see cref="Array"/> of type <typeparamref name="T"/> using the provided <paramref name="parser"/>.
    /// </summary>
    /// <typeparam name="T">The type to conver to.</typeparam>
    /// <param name="enumerable">The <see cref="IEnumerable{T}"/> to parse.</param>
    /// <param name="parser">The parser to use when parsing.</param>
    /// <returns>An <see cref="Array"/> of type <typeparamref name="T"/> with the parsed values.</returns>
    public static T[] ToArray<T>(this IEnumerable<string> enumerable, Func<string, T> parser) => enumerable.Select(line => line.Parse(parser)).ToArray();
    
    /// <summary>
    /// Transforms a <see cref="char"/> <see cref="IEnumerable{T}"/> to an <see cref="Array"/> of type <typeparamref name="T"/> using the provided <paramref name="parser"/>.
    /// </summary>
    /// <typeparam name="T">The type to conver to.</typeparam>
    /// <param name="enumerable">The <see cref="IEnumerable{T}"/> to parse.</param>
    /// <param name="parser">The parser to use when parsing.</param>
    /// <returns>An <see cref="Array"/> of type <typeparamref name="T"/> with the parsed values.</returns>
    public static T[] ToArray<T>(this IEnumerable<char> enumerable, Func<char, T> parser) => enumerable.Select(c => parser(c)).ToArray();

    /// <summary>
    /// Transforms a <see cref="string"/> <see cref="IEnumerable{T}"/> to an <see cref="int"/> <see cref="List{T}"/>.
    /// </summary>
    /// <param name="enumerable">The <see cref="IEnumerable{T}"/> to parse.</param>
    /// <returns>An <see cref="int"/> <see cref="List{T}"/> with values parsed from <paramref name="enumerable"/>.</returns>
    public static List<int> ToIntList(this IEnumerable<string> enumerable) => enumerable.ToList(int.Parse);

    /// <summary>
    /// Transforms a <see cref="string"/> <see cref="IEnumerable{T}"/> to a <see cref="float"/> <see cref="List{T}"/>.
    /// </summary>
    /// <param name="enumerable">The <see cref="IEnumerable{T}"/> to parse.</param>
    /// <returns>A <see cref="float"/> <see cref="List{T}"/> with values parsed from <paramref name="enumerable"/>.</returns>
    public static List<float> ToFloatList(this IEnumerable<string> enumerable) => enumerable.ToList(float.Parse);

    /// <summary>
    /// Transforms a <see cref="string"/> <see cref="IEnumerable{T}"/> to a <see cref="List{T}"/> of type <typeparamref name="T"/> using the provided <paramref name="parser"/>.
    /// </summary>
    /// <typeparam name="T">The type to conver to.</typeparam>
    /// <param name="enumerable">The <see cref="IEnumerable{T}"/> to parse.</param>
    /// <param name="parser">The parser to use when parsing.</param>
    /// <returns>A <see cref="List{T}"/> of type <typeparamref name="T"/> with the parsed values.</returns>
    public static List<T> ToList<T>(this IEnumerable<string> enumerable, Func<string, T> parser) => enumerable.Select(line => string.IsNullOrWhiteSpace(line) ? default : parser(line)).ToList()!;

    /// <summary>
    /// Fills an <see cref="Array"/> with values using the provided <paramref name="factory"/>.
    /// </summary>
    /// <typeparam name="T">The type of the array to fill.</typeparam>
    /// <param name="array">The array to fill.</param>
    /// <param name="factory">The factory to use to fill the array.</param>
    public static void FillArray<T>(this T[] array, Func<T> factory) {
        for (int i = 0; i < array.Length; i++)
            array[i] = factory();
    }

    /// <summary>
    /// Transforms a <see cref="string"/> <see cref="IEnumerable{T}"/> to a <see cref="Vector2"/> <see cref="Array"/>.
    /// </summary>
    /// <param name="enumerable">The <see cref="IEnumerable{T}"/> to parse.</param>
    /// <param name="split">The character to use when splitting a <see cref="string"/> value to a <see cref="Vector2"/>.</param>
    /// <returns>A <see cref="Vector2"/> <see cref="Array"/> with values parsed from <paramref name="enumerable"/>.</returns>
    public static Vector2[] ToVec2(this IEnumerable<string> enumerable, char split = ',') {
        return enumerable.Select(s => s.ToVec2(split)).ToArray();
    }

    /// <summary>
    /// Finds the index of the requested item in an <see cref="IEnumerable{T}"/> using the provided <paramref name="comparer"/> to check equality.
    /// </summary>
    /// <typeparam name="T">The type of the <see cref="IEnumerable{T}"/>.</typeparam>
    /// <param name="source">The <see cref="IEnumerable{T}"/> to look through.</param>
    /// <param name="item">The item to find the index of.</param>
    /// <param name="comparer">The comparer to check for equality.</param>
    /// <returns>The index of the item, or -1 if the item doesn't exist within the <see cref="IEnumerable{T}"/>.</returns>
    public static int IndexOf<T>(this IEnumerable<T> source, T item, Func<T, T, bool> comparer) {
        int count = 0;

        foreach (var obj in source) {
            if (comparer(obj, item))
                return count;
            else
                count++;
        }

        return -1;
    }

    /// <summary>
    /// Obtains the lowest <paramref name="count"/> items in an <see cref="IEnumerable{T}"/>.
    /// </summary>
    /// <typeparam name="T">The type of the <see cref="IEnumerable{T}"/>.</typeparam>
    /// <param name="source">The <see cref="IEnumerable{T}"/> to obtain the lowest values in.</param>
    /// <param name="count">The amount of items to return.</param>
    /// <returns>An <see cref="IEnumerable{T}"/> with the lowest values that can be iterated over.</returns>
    public static IEnumerable<T> Lowest<T>(this IEnumerable<T> source, int count) {
        List<T> copy = new List<T>(source);

        copy.Sort();

        for (int i = 0; i < count && i < copy.Count; i++) {
            yield return copy[i];
        }
    }

    /// <summary>
    /// Obtains the highest <paramref name="count"/> items in an <see cref="IEnumerable{T}"/>.
    /// </summary>
    /// <typeparam name="T">The type of the <see cref="IEnumerable{T}"/>.</typeparam>
    /// <param name="source">The <see cref="IEnumerable{T}"/> to obtain the lowest values in.</param>
    /// <param name="count">The amount of items to return.</param>
    /// <returns>An <see cref="IEnumerable{T}"/> with the highest values that can be iterated over.</returns>
    public static IEnumerable<T> Highest<T>(this IEnumerable<T> source, int count) {
        List<T> copy = new List<T>(source);

        copy.Sort();

        for (int i = 0; i < count && i < copy.Count; i++) {
            yield return copy[^(i + 1)];
        }
    }

    /// <summary>
    /// Multiplies all values in an <see cref="IEnumerable{T}"/> together and returns the result.
    /// </summary>
    /// <param name="source">The <see cref="IEnumerable{T}"/> to multiply with itself.</param>
    /// <returns>The mutliple of all the values in the <see cref="IEnumerable{T}"/>.</returns>
    public static T Multiply<T>(this IEnumerable<T> source) where T : INumber<T>{
        T multiple = T.One;

        foreach (var i in source)
            multiple *= i;

        return multiple;
    }

    /// <summary>
    /// Aggregates over an <see cref="IEnumerable{T}"/>, allowing for comparison between the current value and the next value until the end.
    /// </summary>
    /// <typeparam name="TSource">The type of the <see cref="IEnumerable{T}"/>.</typeparam>
    /// <typeparam name="TAccumulate">The type to accumulate with.</typeparam>
    /// <param name="source">The <see cref="IEnumerable{T}"/> to aggregate over.</param>
    /// <param name="seed">The seed for the aggregation.</param>
    /// <param name="func">The aggregation function to use.</param>
    /// <returns>The result of the aggregation.</returns>
    public static TAccumulate Aggregate<TSource, TAccumulate>(this IEnumerable<TSource> source, TAccumulate seed, Func<TAccumulate, TSource, TSource, TAccumulate> func) {
        var asArray = source.ToArray();
        TAccumulate accumulate = seed;
        for (int i = 0; i < asArray.Length - 1; i++) {
            accumulate = func(accumulate, asArray[i], asArray[i + 1]);
        }
        return accumulate;
    }

    /// <summary>
    /// Aggregates over an <see cref="IEnumerable{T}"/>, allowing for comparison between the current value and the next value until the end, or until the accumulate has become equal to the <paramref name="earlyExitValue"/>.
    /// </summary>
    /// <typeparam name="TSource">The type of the <see cref="IEnumerable{T}"/>.</typeparam>
    /// <typeparam name="TAccumulate">The type to accumulate with.</typeparam>
    /// <param name="source">The <see cref="IEnumerable{T}"/> to aggregate over.</param>
    /// <param name="seed">The seed for the aggregation.</param>
    /// <param name="func">The aggregation function to use.</param>
    /// <param name="earlyExitValue">The value to check against and stop aggregation when reached.</param>
    /// <returns>The result of the aggregation.</returns>
    public static TAccumulate Aggregate<TSource, TAccumulate>(this IEnumerable<TSource> source, TAccumulate seed, Func<TAccumulate, TSource, TSource, TAccumulate> func, TAccumulate? earlyExitValue = default) {
        var asArray = source.ToArray();
        TAccumulate accumulate = seed;
        for (int i = 0; i < asArray.Length - 1; i++) {
            accumulate = func(accumulate, asArray[i], asArray[i + 1]);

            if (earlyExitValue != null && earlyExitValue.Equals(accumulate)) {
                return accumulate;
            }
        }
        return accumulate;
    }

    /// <summary>
    /// Groups an <see cref="IEnumerable{T}"/> into smaller groups.
    /// <para>If the length of <paramref name="input"/> is not a whole multiple of <paramref name="groupSize"/>, the last item will be partially filled.</para>
    /// </summary>
    /// <typeparam name="T">The type of the <see cref="IEnumerable{T}"/> to group up.</typeparam>
    /// <param name="input">The <see cref="IEnumerable{T}"/> to group up.</param>
    /// <param name="groupSize">how many items should exist in each group.</param>
    /// <returns>An <see cref="IEnumerable{T}"/> with the groups that can be iterated over.</returns>
    public static IEnumerable<IEnumerable<T>> GroupsOf<T>(this IEnumerable<T> input, int groupSize) {
        var current = new T[groupSize];
        var index = 0;

        foreach (var item in input) {
            current[index++] = item;
            if (index != groupSize) {
                continue;
            }

            yield return current;

            current = new T[groupSize];
            index = 0;
        }

        if (index > 0) {
            yield return current.Take(index).ToArray();
        }
    }
}
