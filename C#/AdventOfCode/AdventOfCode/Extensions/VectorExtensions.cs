using System.Numerics;

namespace AdventOfCode;

public static class VectorExtensions {
    public static Vector2 ManhattanOffset(this Vector2 source, Vector2 target) => new(target.X - source.X, target.Y - source.Y);
}
