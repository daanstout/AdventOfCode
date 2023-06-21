using System.IO.MemoryMappedFiles;
using System.Numerics;
using System.Reflection.Metadata;
using System.Text;

namespace _2022.Days;

public class Day14 : AdventDay {
    public Day14() : base(14, 2022, "Regolith Reservoir") { }

    protected override object SolvePart1() {
        var vecArray = Lines.Select(line => line.Split(" -> ").ToVec2()).ToList();
        var maxX = (int)vecArray.Select(vec => vec.Select(v => v.X).Max()).Max();
        var minX = (int)vecArray.Select(vec => vec.Select(v => v.X).Min()).Min();
        var maxY = (int)vecArray.Select(vec => vec.Select(v => v.Y).Max()).Max();
        var minY = (int)vecArray.Select(vec => vec.Select(v => v.Y).Min()).Min();
        minY = Math.Min(0, minY);
        maxX++;
        minX--;
        maxY++;

        int width = maxX - minX + 1;
        int height = maxY - minY + 1;
        int xOffset = minX;
        int yOffset = minY;

        int x500 = 500 - minX;

        byte[,] map = new byte[width, height];

        foreach (var vecs in vecArray) {
            for (int i = 1; i < vecs.Length; i++) {
                var start = vecs[i - 1];
                var end = vecs[i];
                if (start.X == end.X) {
                    var startY = Math.Min(start.Y, end.Y);
                    var endY = Math.Max(start.Y, end.Y);

                    for (int y = (int)startY; y <= endY; y++) {
                        map[(int)start.X - xOffset, y - yOffset] = 1;
                    }
                } else {
                    var startX = Math.Min(start.X, end.X);
                    var endX = Math.Max(start.X, end.X);

                    for (int x = (int)startX; x <= endX; x++) {
                        map[x - xOffset, (int)start.Y - yOffset] = 1;
                    }
                }
            }
        }

        int loops = 0;
        bool hasFallenOff = false;

        while (!hasFallenOff) {
            bool sandCanMove = true;
            int x = x500;
            int y = -yOffset;
            while (sandCanMove) {
                if (y == maxY - 1) {
                    hasFallenOff = true;
                    break;
                }

                if (map[x, y + 1] == 0) {
                    y++;
                    continue;
                }

                if (map[x - 1, y + 1] == 0) {
                    x--;
                    y++;
                    continue;
                }

                if (map[x + 1, y + 1] == 0) {
                    x++;
                    y++;
                    continue;
                }

                map[x, y] = 2;
                sandCanMove = false;
            }

            loops++;
        }

        return loops - 1;
    }

    protected override object SolvePart2() {
        var vecArray = Lines.Select(line => line.Split(" -> ").ToVec2()).ToList();
        var maxX = (int)vecArray.Select(vec => vec.Select(v => v.X).Max()).Max();
        var minX = (int)vecArray.Select(vec => vec.Select(v => v.X).Min()).Min();
        var maxY = (int)vecArray.Select(vec => vec.Select(v => v.Y).Max()).Max();
        var minY = (int)vecArray.Select(vec => vec.Select(v => v.Y).Min()).Min();
        minY = Math.Min(0, minY);
        // Adding width is hacky but I am too lazy to calculate it. It probably isn't even hard with all the data I have, but meh.
        maxX += 200;
        minX -= 200;
        maxY += 2;
        vecArray.Add(new Vector2[] { new Vector2(minX, maxY), new Vector2(maxX, maxY) });

        int width = maxX - minX + 1;
        int height = maxY - minY + 1;
        int xOffset = minX;
        int yOffset = minY;

        int x500 = 500 - minX;

        byte[,] map = new byte[width, height];

        foreach (var vecs in vecArray) {
            for (int i = 1; i < vecs.Length; i++) {
                var start = vecs[i - 1];
                var end = vecs[i];
                if (start.X == end.X) {
                    var startY = Math.Min(start.Y, end.Y);
                    var endY = Math.Max(start.Y, end.Y);

                    for (int y = (int)startY; y <= endY; y++) {
                        map[(int)start.X - xOffset, y - yOffset] = 1;
                    }
                } else {
                    var startX = Math.Min(start.X, end.X);
                    var endX = Math.Max(start.X, end.X);

                    for (int x = (int)startX; x <= endX; x++) {
                        map[x - xOffset, (int)start.Y - yOffset] = 1;
                    }
                }
            }
        }

        int loops = 0;
        bool blocksSand = false;

        while (!blocksSand) {
            bool sandCanMove = true;
            int x = x500;
            int y = -yOffset;
            while (sandCanMove) {
                if (map[x, y + 1] == 0) {
                    y++;
                    continue;
                }

                if (x > 0 && map[x - 1, y + 1] == 0) {
                    x--;
                    y++;
                    continue;
                }

                if (x < width - 1 && map[x + 1, y + 1] == 0) {
                    x++;
                    y++;
                    continue;
                }

                map[x, y] = 2;
                blocksSand = x == x500 && y == -yOffset;
                sandCanMove = false;
            }

            loops++;
        }

        return loops;
    }
}
