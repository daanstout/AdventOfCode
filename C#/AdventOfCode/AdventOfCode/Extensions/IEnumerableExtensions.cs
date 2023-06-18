using System.Numerics;

namespace AdventOfCode;
public static class IEnumerableExtensions {
    public static int[] ToIntArray(this IEnumerable<string> enumerable) => enumerable.ToArray(int.Parse);

    public static float[] ToFloatArray(this IEnumerable<string> enumerable) => enumerable.ToArray(float.Parse);

    public static T[] ToArray<T>(this IEnumerable<string> enumerable, Func<string, T> parser) => enumerable.Select(line => string.IsNullOrWhiteSpace(line) ? default : parser(line)).ToArray()!;

    public static List<int> ToIntList(this IEnumerable<string> enumerable) => enumerable.ToList(int.Parse);

    public static List<float> ToFloatList(this IEnumerable<string> enumerable) => enumerable.ToList(float.Parse);

    public static List<T> ToList<T>(this IEnumerable<string> enumerable, Func<string, T> parser) => enumerable.Select(line => string.IsNullOrWhiteSpace(line) ? default : parser(line)).ToList()!;

    public static void FillArray<T>(this T[] array, Func<T> factory) {
        for (int i = 0; i < array.Length; i++)
            array[i] = factory();
    }

    public static Vector2[] ToVec2(this IEnumerable<string> str, char split = ',') {
        return str.Select(s => s.ToVec2(split)).ToArray();
    }

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

    public static IEnumerable<int> Lowest(this IEnumerable<int> source, int count) {
        List<int> copy = new List<int>(source);

        copy.Sort();

        for (int i = 0; i < count && i < copy.Count; i++) {
            yield return copy[i];
        }
    }

    public static IEnumerable<int> Highest(this IEnumerable<int> source, int count) {
        List<int> copy = new List<int>(source);

        copy.Sort();

        for (int i = 0; i < count && i < copy.Count; i++) {
            yield return copy[^(i + 1)];
        }
    }

    public static IEnumerable<long> Highest(this IEnumerable<long> source, int count) {
        List<long> copy = new List<long>(source);

        copy.Sort();

        for (int i = 0; i < count && i < copy.Count; i++) {
            yield return copy[^(i + 1)];
        }
    }

    public static int Multiply(this IEnumerable<int> source) {
        int multiple = 1;

        foreach (var i in source)
            multiple *= i;

        return multiple;
    }

    public static long Multiply(this IEnumerable<long> source) {
        long multiple = 1;

        foreach (var i in source)
            multiple *= i;

        return multiple;
    }

    public static TAccumulate Aggregate<TSource, TAccumulate>(this IEnumerable<TSource> source, TAccumulate seed, Func<TAccumulate, TSource, TSource, TAccumulate> func) {
        var asArray = source.ToArray();
        TAccumulate accumulate = seed;
        for (int i = 0; i < asArray.Length - 1; i++) {
            accumulate = func(accumulate, asArray[i], asArray[i + 1]);
        }
        return accumulate;
    }

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
