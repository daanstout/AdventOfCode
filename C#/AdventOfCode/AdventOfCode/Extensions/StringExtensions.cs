using System.Numerics;

namespace AdventOfCode;

/// <summary>
/// A class containing extensions to <see cref="string"/>s.
/// </summary>
public static class StringExtensions {
    /// <summary>
    /// Converts a <see cref="string"/> to an <see cref="int"/>.
    /// </summary>
    /// <param name="str">The <see cref="string"/> to convert.</param>
    /// <returns>The <see cref="int"/> value of the string.</returns>
    public static int ToInt32(this string str) => str.Parse(int.Parse);

    /// <summary>
    /// Converts a <see cref="string"/> to a <see cref="short"/>.
    /// </summary>
    /// <param name="str">The <see cref="string"/> to convert.</param>
    /// <returns>The <see cref="short"/> value of the string.</returns>
    public static short ToInt16(this string str) => str.Parse(short.Parse);

    /// <summary>
    /// Converts a <see cref="string"/> to a <see cref="float"/>.
    /// </summary>
    /// <param name="str">The <see cref="string"/> to convert.</param>
    /// <returns>The <see cref="float"/> value of the string.</returns>
    public static float ToFloat(this string str) => str.Parse(float.Parse);

    /// <summary>
    /// Converts a <see cref="string"/> to <typeparamref name="T"/> using the provided <paramref name="parser"/>.
    /// </summary>
    /// <param name="str">The <see cref="string"/> to convert.</param>
    /// <returns>The <typeparamref name="T"/> value of the string.</returns>
    public static T Parse<T>(this string str, Func<string, T> parser) => string.IsNullOrWhiteSpace(str) ? default! : parser(str);

    /// <summary>
    /// Converts a <see cref="string"/> to a <see cref="Vector2"/>.
    /// </summary>
    /// <param name="stringToParse">The <see cref="string"/> to convert.</param>
    /// <param name="split">The character to split by.</param>
    /// <returns>The <see cref="int"/> value of the string.</returns>
    public static Vector2 ToVec2(this string stringToParse, char split = ',') {
        var values = stringToParse.Split(split);
        if(values.Length != 2) {
            throw new ArgumentException("string must contain exactly 2 parts", nameof(stringToParse));
        }
        return new(values[0].ToFloat(), values[1].ToFloat());
    }

    /// <summary>
    /// Converts a <see cref="string"/> <see cref="Array"/> to an <see cref="int"/> heightmap.
    /// </summary>
    /// <param name="source">The <see cref="string"/> to convert.</param>
    /// <param name="width">The width of the heightmap.</param>
    /// <param name="height">The height of the heightmap.</param>
    /// <returns>A heightmap created from the passed string.</returns>
    public static int[,] ToHeightMap(this string[] source, out int width, out int height) {
        return source.ToHeightMap(c => c.ToInt32(), out width, out height);
    }

    /// <summary>
    /// Converts a <see cref="string"/> <see cref="Array"/> to a <typeparamref name="T"/> heightmap.
    /// </summary>
    /// <param name="source">The <see cref="string"/> to convert.</param>
    /// <param name="parser">The parser to use to parse from <see cref="string"/>s to <typeparamref name="T"/></param>
    /// <param name="width">The width of the heightmap.</param>
    /// <param name="height">The height of the heightmap.</param>
    /// <returns>A heightmap created from the passed string.</returns>
    public static T[,] ToHeightMap<T>(this string[] source, Func<char, T> parser, out int width, out int height) {
        if (source.Length == 0) {
            width = 0;
            height = 0;
            return new T[0, 0];
        }

        width = source[0].Length;
        height = source.Length;

        var heightMap = new T[width, height];

        for (int y = 0; y < height; y++) {
            for (int x = 0; x < width; x++) {
                heightMap[x, y] = parser(source[y][x]);
            }
        }

        return heightMap;
    }

    /// <summary>
    /// Gets the index of a certain character in a <see cref="string"/> <see cref="Array"/>.
    /// </summary>
    /// <param name="source">The array to search through.</param>
    /// <param name="c">The character to search for.</param>
    /// <returns>The row and column in the array of the character.</returns>
    public static (int row, int column) IndexOf(this string[] source, char c) {
        for (int i = 0; i < source.Length; i++) {
            var index = source[i].IndexOf(c);

            if (index != -1)
                return (i, index);
        }

        return (-1, -1);
    }
}
