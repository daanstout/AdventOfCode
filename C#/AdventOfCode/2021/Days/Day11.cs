namespace _2021.Days;
public class Day11 : AdventDay {
    public Day11() : base(11, 2021, "Dumbo Octopus") { }

    protected override object SolvePart1() {
        var heightMap = Lines.ToHeightMap(out int width, out int height);

        int numFlashes = 0;

        for (int i = 0; i < 100; i++) {
            Queue<(int x, int y)> flashQueue = new Queue<(int x, int y)>();
            HashSet<(int x, int y)> flashedPositions = new HashSet<(int x, int y)>();

            for (int y = 0; y < height; y++) {
                for (int x = 0; x < width; x++) {
                    heightMap[x, y]++;

                    if (heightMap[x, y] > 9) {
                        flashQueue.Enqueue((x, y));
                    }
                }
            }

            while (flashQueue.Count > 0) {
                var current = flashQueue.Dequeue();

                if (!flashedPositions.Add(current))
                    continue;

                numFlashes++;

                foreach (var neighbour in heightMap.GetNeighbourCoords(current.x, current.y, true)) {
                    heightMap[neighbour.x, neighbour.y]++;
                    if (heightMap[neighbour.x, neighbour.y] > 9) {
                        flashQueue.Enqueue(neighbour);
                    }
                }
            }

            foreach(var (x, y) in flashedPositions) {
                heightMap[x, y] = 0;
            }
        }

        return numFlashes;
    }

    protected override object SolvePart2() {
        var heightMap = Lines.ToHeightMap(out int width, out int height);

        int numFlashes = 0;
        int numGenerations = 0;

        while(numFlashes != width * height) {
            numFlashes = 0;

            Queue<(int x, int y)> flashQueue = new Queue<(int x, int y)>();
            HashSet<(int x, int y)> flashedPositions = new HashSet<(int x, int y)>();

            for (int y = 0; y < height; y++) {
                for (int x = 0; x < width; x++) {
                    heightMap[x, y]++;

                    if (heightMap[x, y] > 9) {
                        flashQueue.Enqueue((x, y));
                    }
                }
            }

            while (flashQueue.Count > 0) {
                var current = flashQueue.Dequeue();

                if (!flashedPositions.Add(current))
                    continue;

                numFlashes++;

                foreach (var neighbour in heightMap.GetNeighbourCoords(current.x, current.y, true)) {
                    heightMap[neighbour.x, neighbour.y]++;
                    if (heightMap[neighbour.x, neighbour.y] > 9) {
                        flashQueue.Enqueue(neighbour);
                    }
                }
            }

            foreach (var (x, y) in flashedPositions) {
                heightMap[x, y] = 0;
            }
            numGenerations++;
        }

        return numGenerations;
    }
}
