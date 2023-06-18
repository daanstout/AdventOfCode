﻿using System.Numerics;

namespace AdventOfCode;

/// <summary>
/// A class containing extensions to <see cref="Array"/>s.
/// </summary>
public static class ArrayExtensions {
    /// <summary>
    /// Returns all the elements of the specified row in a 2-dimensional array.
    /// </summary>
    /// <typeparam name="T">The type of the array.</typeparam>
    /// <param name="array">The array to slice through.</param>
    /// <param name="row">The row to take out.</param>
    /// <returns>An <see cref="IEnumerable{T}"/> with the values in the row that can be iterated over.</returns>
    public static IEnumerable<T> SliceRow<T>(this T[,] array, int row) {
        for (int i = 0; i < array.GetLength(0); i++) {
            yield return array[i, row];
        }
    }

    /// <summary>
    /// Returns all the elements of the specified column in a 2-dimensional array.
    /// </summary>
    /// <typeparam name="T">The type of the array.</typeparam>
    /// <param name="array">The array to slice through.</param>
    /// <param name="column">The column to take out.</param>
    /// <returns>An <see cref="IEnumerable{T}"/> with the values in the column that can be iterated over.</returns>
    public static IEnumerable<T> SliceColumn<T>(this T[,] array, int column) {
        for (int i = 0; i < array.GetLength(1); i++) {
            yield return array[column, i];
        }
    }

    /// <summary>
    /// Gets the valid neighbouring coordinates of a 2-dimensional array.
    /// </summary>
    /// <typeparam name="T">The type of the array.</typeparam>
    /// <param name="source">The array to get the valid neighbours from.</param>
    /// <param name="x">The x-position of the element to get the neighbours from.</param>
    /// <param name="y">The y-position of the element to get the neighbours from.</param>
    /// <param name="includeDiagonal">Whether or not to include diagonal neigbours.</param>
    /// <returns>An <see cref="IEnumerable{T}"/> with the valid neighbour coordinates of the requested position.</returns>
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

    /// <summary>
    /// Gets the neighbours of the specified index in a 2-dimensional array.
    /// </summary>
    /// <typeparam name="T">The type of the array.</typeparam>
    /// <param name="source">The array to get the neighbours from.</param>
    /// <param name="x">The x-position of the element to get the neighbours from.</param>
    /// <param name="y">The y-position of the element to get the neighbours from.</param>
    /// <param name="includeDiagonal">Whether or not to include diagonal neighbours.</param>
    /// <returns>An <see cref="IEnumerable{T}"/> with the neighbours of the requested position.</returns>
    public static IEnumerable<T> GetNeighbours<T>(this T[,] source, int x, int y, bool includeDiagonal = true) {
        foreach (var coord in source.GetNeighbourCoords(x, y, includeDiagonal)) {
            yield return source[coord.x, coord.y];
        }
    }

    /// <summary>
    /// Gets the element stored at the specified index of a 2-dimensional array, using a tuple of 2 integers.
    /// </summary>
    /// <typeparam name="T">The type of the array.</typeparam>
    /// <param name="source">The array to get the value from.</param>
    /// <param name="index">The index in both dimensions to get the value from.</param>
    /// <returns>The value stored at the specified index.</returns>
    public static T Get<T>(this T[,] source, (int, int) index) => source[index.Item1, index.Item2];

    /// <summary>
    /// Counts how often a certain value exists using a predicate in a 2-dimensional array.
    /// </summary>
    /// <typeparam name="T">The type of the array.</typeparam>
    /// <param name="source">The array to count in.</param>
    /// <param name="predicate">The predicate to use to check if a value should be counted.</param>
    /// <returns>The total amount of values the <paramref name="predicate"/> returned true on.</returns>
    public static int Count<T>(this T[,] source, Func<T, bool> predicate) {
        int count = 0;
        for (int i = 0; i < source.GetLength(0); i++) {
            for (int j = 0; j < source.GetLength(1); j++) {
                if (predicate(source[i, j]))
                    count++;
            }
        }

        return count;
    }

    /// <summary>
    /// Sums all values in the specified array.
    /// </summary>
    /// <param name="source">The array to sum.</param>
    /// <returns>The sum of all the values in the array.</returns>
    public static T Sum<T>(this T[,] source) where T : INumber<T> {
        T count = default!;
        for (int i = 0; i < source.GetLength(0); i++) {
            for (int j = 0; j < source.GetLength(1); j++) {
                count += source[i, j];
            }
        }

        return count;
    }
}
