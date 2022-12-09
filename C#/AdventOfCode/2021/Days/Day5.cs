using System.Numerics;

namespace _2021.Days;
public class Day5 : AdventDay {
    public Day5() : base(5, 2021, "Hydrothermal Venture") { }

    protected override object SolvePart1() {
        int[,] map = new int[1000, 1000];

        foreach (var line in Lines) {
            var coords = line.Split(" -> ");
            Vector2[] vecs = new Vector2[2];

            for (int i = 0; i < 2; i++) {
                var coord = coords[i].Split(',');
                vecs[i] = new Vector2(int.Parse(coord[0]), int.Parse(coord[1]));
            }

            if (vecs[0].X == vecs[1].X || vecs[0].Y == vecs[1].Y) {
                int startX = (int)Math.Min(vecs[0].X, vecs[1].X);
                int endX = (int)Math.Max(vecs[0].X, vecs[1].X);
                int startY = (int)Math.Min(vecs[0].Y, vecs[1].Y);
                int endY = (int)Math.Max(vecs[0].Y, vecs[1].Y);

                for (int x = startX; x <= endX; x++) {
                    for (int y = startY; y <= endY; y++) {
                        map[x, y]++;
                    }
                }
            }
        }

        int overlap = 0;
        for (int x = 0; x < 1000; x++) {
            for (int y = 0; y < 1000; y++) {
                if (map[x, y] >= 2)
                    overlap++;
            }
        }

        return overlap;
    }

    protected override object SolvePart2() {
        int[,] map = new int[1000, 1000];

        foreach (var line in Lines) {
            var coords = line.Split(" -> ");
            Vector2[] vecs = new Vector2[2];

            for (int i = 0; i < 2; i++) {
                var coord = coords[i].Split(',');
                vecs[i] = new Vector2(int.Parse(coord[0]), int.Parse(coord[1]));
            }

            if (vecs[0].X == vecs[1].X || vecs[0].Y == vecs[1].Y) {
                int startX = (int)Math.Min(vecs[0].X, vecs[1].X);
                int endX = (int)Math.Max(vecs[0].X, vecs[1].X);
                int startY = (int)Math.Min(vecs[0].Y, vecs[1].Y);
                int endY = (int)Math.Max(vecs[0].Y, vecs[1].Y);

                for (int x = startX; x <= endX; x++) {
                    for (int y = startY; y <= endY; y++) {
                        map[x, y]++;
                    }
                }
            } else {
                int steps = (int)Math.Abs(vecs[0].X - vecs[1].X);

                for (int step = 0; step <= steps; step++) {
                    var x = (int)vecs[0].X + (XBigger() ? -step : step);
                    var y = (int)vecs[0].Y + (YBigger() ? -step : step);
                    map[x, y]++;
                }
                bool XBigger() => vecs[0].X > vecs[1].X;
                bool YBigger() => vecs[0].Y > vecs[1].Y;
            }
        }

        int overlap2 = 0;
        for (int x = 0; x < 1000; x++) {
            for (int y = 0; y < 1000; y++) {
                if (map[x, y] >= 2)
                    overlap2++;
            }
        }

        return overlap2;
    }
}
