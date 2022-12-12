using System.Numerics;

namespace AdventOfCode;

public static class Extensions {
    public static IEnumerable<T> SliceRow<T>(this T[,] array, int row) {
        for (int i = 0; i < array.GetLength(0); i++) {
            yield return array[i, row];
        }
    }

    public static IEnumerable<T> SliceColumn<T>(this T[,] array, int column) {
        for (int i = 0; i < array.GetLength(1); i++) {
            yield return array[column, i];
        }
    }

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

    public static int ToInt32(this string str) => string.IsNullOrWhiteSpace(str) ? 0 : int.Parse(str);

    public static short ToInt16(this string str) => string.IsNullOrWhiteSpace(str) ? (short)0 : short.Parse(str);

    public static int ToInt32(this char c) => c.ToString().ToInt32();

    public static float ToFloat(this string str) => string.IsNullOrWhiteSpace(str) ? 0.0f : float.Parse(str);

    public static Vector2 ToVec2(this string str, char split = ',') {
        var values = str.Split(split);
        return new(values[0].ToFloat(), values[1].ToFloat());
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

    public static IEnumerable<(int x, int y)> GetNeighbourCoords<T>(this T[,] source, int x, int y, bool includeDiagonal = true) {
        int width = source.GetLength(0);
        int height = source.GetLength(1);

        if (x > 0) {
            yield return (x - 1, y);

            if (includeDiagonal) {
                if (y > 0)
                    yield return (x - 1, y - 1);
                if (y < height - 1)
                    yield return (x - 1, y + 1);
            }
        }

        if (x < width - 1) {
            yield return (x + 1, y);

            if (includeDiagonal) {
                if (y > 0)
                    yield return (x + 1, y - 1);
                if (y < height - 1)
                    yield return (x + 1, y + 1);
            }
        }

        if (y > 0)
            yield return (x, y - 1);
        if (y < height - 1)
            yield return (x, y + 1);
    }

    public static IEnumerable<T> GetNeighbours<T>(this T[,] source, int x, int y, bool includeDiagonal = true) {
        foreach (var coord in source.GetNeighbourCoords(x, y, includeDiagonal)) {
            yield return source[coord.x, coord.y];
        }
    }

    public static Vector2 ToVector2(this (int x, int y) source) => new(source.x, source.y);

    public static int[,] ToHeightMap(this string[] source, out int width, out int height) {
        return source.ToHeightMap(c => c.ToInt32(), out width, out height);
    }

    public static int[,] ToHeightMap(this string[] source, Func<char, int> conversation, out int width, out int height) {
        if (source.Length == 0) {
            width = 0;
            height = 0;
            return new int[0, 0];
        }

        width = source[0].Length;
        height = source.Length;

        var heightMap = new int[width, height];

        for (int y = 0; y < height; y++) {
            for (int x = 0; x < width; x++) {
                heightMap[x, y] = conversation(source[y][x]);
            }
        }

        return heightMap;
    }

    public static (int row, int column) IndexOf(this string[] source, char c) {
        for(int i = 0; i < source.Length; i++) {
            var index = source[i].IndexOf(c);

            if (index != -1)
                return (i, index);
        }

        return (-1, -1);
    }

    public static (TSecond, TFirst) Inverse<TFirst, TSecond>(this (TFirst, TSecond) tuple) => (tuple.Item2, tuple.Item1);

    public static T Get<T>(this T[,] source, (int, int) index) => source[index.Item1, index.Item2];

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

    public static int Count<T>(this T[,] source, Func<T, bool> predicate) {
        int count = 0;
        for(int i = 0; i < source.GetLength(0); i++) {
            for(int j = 0; j < source.GetLength(1); j++) {
                if (predicate(source[i, j]))
                    count++;
            }
        }

        return count;
    }

    public static int Sum(this int[,] source) {
        int count = 0;
        for (int i = 0; i < source.GetLength(0); i++) {
            for (int j = 0; j < source.GetLength(1); j++) {
                count += source[i, j];
            }
        }

        return count;
    }

    public static TValue GetOrCreate<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key) {
        if(!dictionary.TryGetValue(key, out var value)) {
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
