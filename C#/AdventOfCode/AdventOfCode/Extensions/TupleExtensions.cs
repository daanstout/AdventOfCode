using System.Numerics;

namespace AdventOfCode;

public static class TupleExtensions {
    public static Vector2 ToVector2(this (int x, int y) source) => new(source.x, source.y);

    public static (TSecond, TFirst) Inverse<TFirst, TSecond>(this (TFirst, TSecond) tuple) => (tuple.Item2, tuple.Item1);
}
