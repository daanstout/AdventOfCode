using System.Numerics;

namespace AdventOfCode;

/// <summary>
/// A class containing extensions for <see cref="Vector2"/>s.
/// </summary>
public static class VectorExtensions {
    /// <summary>
    /// Calculates the manhatten distance to the target <see cref="Vector2"/>.
    /// </summary>
    /// <param name="source">The source <see cref="Vector2"/>.</param>
    /// <param name="target">The target <see cref="Vector2"/>.</param>
    /// <returns>The manhatten distance to the target.</returns>
    public static Vector2 ManhattanOffset(this Vector2 source, Vector2 target) => new(target.X - source.X, target.Y - source.Y);
}
