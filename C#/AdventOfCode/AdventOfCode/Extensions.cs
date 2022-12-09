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

    public static int ToInt(this string str) => string.IsNullOrWhiteSpace(str) ? 0 : int.Parse(str);

    public static int ToInt(this char c) => c.ToString().ToInt();

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
                heightMap[x, y] = source[y][x].ToInt();
            }
        }

        return heightMap;
    }
}
