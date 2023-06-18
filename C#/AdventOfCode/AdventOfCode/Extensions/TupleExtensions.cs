using System.Numerics;

namespace AdventOfCode;

/// <summary>
/// A class containing extensions to<see cref="Tuple"/>s.
/// </summary>
public static class TupleExtensions {
    /// <summary>
    /// Converts an <see cref="int"/> <see cref="Tuple{T1, T2}"/> to a <see cref="Vector2"/>.
    /// </summary>
    /// <param name="source">The tuple to convert.</param>
    /// <returns>The converted <see cref="Vector2"/>.</returns>
    public static Vector2 ToVector2(this (int x, int y) source) => new(source.x, source.y);

    /// <summary>
    /// Inverses the items in a tuple, so the second item becomes the first item, and the first item becomes the second item.
    /// </summary>
    /// <typeparam name="TFirst">The type of the first item.</typeparam>
    /// <typeparam name="TSecond">The type of the second item.</typeparam>
    /// <param name="tuple">The tuple to inverse.</param>
    /// <returns>The inversed tuple.</returns>
    public static (TSecond, TFirst) Inverse<TFirst, TSecond>(this (TFirst, TSecond) tuple) => (tuple.Item2, tuple.Item1);
}
