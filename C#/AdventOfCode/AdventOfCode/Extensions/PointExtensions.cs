using System.Drawing;

namespace AdventOfCode;

/// <summary>
/// A class containing extension to <see cref="Point"/>s.
/// </summary>
public static class PointExtensions {
    /// <summary>
    /// Gets the manhattan offset to another <see cref="Point"/>.
    /// </summary>
    /// <param name="source">The source <see cref="Point"/>.</param>
    /// <param name="target">The <see cref="Point"/> to get the offset to.</param>
    /// <returns>A <see cref="Point"/> with the difference between the two <see cref="Point"/>'s <see cref="Point.X"/> and <see cref="Point.Y"/> values.</returns>
    public static Point ManhattanOffset(this Point source, Point target) => new(target.X - source.X, target.Y - source.Y);

    /// <summary>
    /// Gets the squared length of a <see cref="Point"/>.
    /// </summary>
    /// <param name="source">The <see cref="Point"/> to get the squared length of.</param>
    /// <returns>The squared length of the <see cref="Point"/>.</returns>
    public static int LengthSquared(this Point source) => source.X * source.X + source.Y * source.Y;

    /// <summary>
    /// Gets the length of a <see cref="Point"/>.
    /// </summary>
    /// <param name="source">The <see cref="Point"/> to get the length of.</param>
    /// <returns>The length of the <see cref="Point"/>.</returns>
    public static int ManhattenLength(this Point source) => Math.Abs(source.X) + Math.Abs(source.Y);

    /// <summary>
    /// Gets the manhatten distance to another <see cref="Point"/>.
    /// </summary>
    /// <param name="source">The source <see cref="Point"/>.</param>
    /// <param name="target">The <see cref="Point"/> to get the distance to.</param>
    /// <returns>The manhatten distance to the target point.</returns>
    public static int ManhattenDistance(this Point source, Point target) => Math.Abs(source.X - target.X) + Math.Abs(source.Y - target.Y);

    public static Point Add(this Point source, Point add) => new(source.X + add.X, source.Y + add.Y);
}
