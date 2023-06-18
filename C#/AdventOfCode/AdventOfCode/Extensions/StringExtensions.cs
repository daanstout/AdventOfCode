using System.Numerics;

namespace AdventOfCode;

public static class StringExtensions {
    public static int ToInt32(this string str) => string.IsNullOrWhiteSpace(str) ? 0 : int.Parse(str);

    public static short ToInt16(this string str) => string.IsNullOrWhiteSpace(str) ? (short)0 : short.Parse(str);

    public static float ToFloat(this string str) => string.IsNullOrWhiteSpace(str) ? 0.0f : float.Parse(str);

    public static Vector2 ToVec2(this string str, char split = ',') {
        var values = str.Split(split);
        return new(values[0].ToFloat(), values[1].ToFloat());
    }

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
        for (int i = 0; i < source.Length; i++) {
            var index = source[i].IndexOf(c);

            if (index != -1)
                return (i, index);
        }

        return (-1, -1);
    }
}
