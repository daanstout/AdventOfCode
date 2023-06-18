using System.Drawing;

namespace AdventOfCode;

public static class PointExtensions {
    public static Point ManhattanOffset(this Point source, Point target) => new(target.X - source.X, target.Y - source.Y);

    public static int LengthSquared(this Point source) => source.X * source.X + source.Y * source.Y;

    public static int ManhattenLength(this Point source) => Math.Abs(source.X) + Math.Abs(source.Y);

    public static int ManhattenDistance(this Point source, Point to) => Math.Abs(source.X - to.X) + Math.Abs(source.Y - to.Y);
}
