using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace _2021.Days;
public class Day9 : AdventDay {
    public Day9() : base(9, 2021, "Title") { }

    protected override object SolvePart1() {
        var width = Lines[0].Length;
        var height = Lines.Length;
        int[,] heightMap = new int[width, height];

        for (int x = 0; x < width; x++) {
            for (int y = 0; y < height; y++) {
                heightMap[x, y] = Lines[y][x].ToInt();
            }
        }

        int sum = 0;

        for (int x = 0; x < width; x++) {
            for (int y = 0; y < height; y++) {
                bool isLowest = true;
                foreach (var neighbour in heightMap.GetNeighbours(x, y, false)) {
                    if (neighbour <= heightMap[x, y]) {
                        isLowest = false;
                        break;
                    }
                }
                if (isLowest) {
                    sum += heightMap[x, y] + 1;
                }
            }
        }

        return sum;
    }

    protected override object SolvePart2() {
        var width = Lines[0].Length;
        var height = Lines.Length;
        int[,] heightMap = new int[width, height];
        List<(int x, int y)> coords = new List<(int x, int y)>();

        for (int x = 0; x < width; x++) {
            for (int y = 0; y < height; y++) {
                heightMap[x, y] = Lines[y][x].ToInt();
                coords.Add((x, y));
            }
        }

        coords = coords.Where(item => heightMap[item.x, item.y] != 9).ToList();

        List<int> sizes = new();

        while (coords.Count > 0) {
            var current = coords[0];
            coords.RemoveAt(0);

            int size = 1;

            Queue<(int x, int y)> queue = new Queue<(int x, int y)>();

            queue.Enqueue(current);

            while (queue.Count > 0) {
                var (x, y) = queue.Dequeue();

                foreach (var neighbour in heightMap.GetNeighbourCoords(x, y, false)) {
                    int neighbourIndex = coords.IndexOf(neighbour);

                    if (neighbourIndex != -1) {
                        size++;
                        coords.RemoveAt(neighbourIndex);
                        queue.Enqueue(neighbour);
                    }
                }
            }

            sizes.Add(size);
        }

        sizes.Sort();

        return sizes.TakeLast(3).Aggregate(1, (seed, current) => seed * current);
    }
}
