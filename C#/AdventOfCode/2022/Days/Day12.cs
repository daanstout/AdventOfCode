namespace _2022.Days;

public class Day12 : AdventDay {
    public Day12() : base(12, 2022, "Hill Climbing Algorithm") { }

    protected override object SolvePart1() {
        var heightMap = Lines.ToHeightMap(c => {
            if (c == 'S')
                return 1;
            else if (c == 'E')
                return 26;
            else
                return c - 'a' + 1;
        }, out var width, out var height);

        var start = Lines.IndexOf('S').Inverse();
        var end = Lines.IndexOf('E').Inverse();

        Dictionary<(int, int), List<(int, int)>> movement = new();

        for (int y = 0; y < height; y++) {
            for (int x = 0; x < width; x++) {
                var currentValue = heightMap[x, y];

                foreach (var neighbour in heightMap.GetNeighbourCoords(x, y, false)) {
                    var destinationValue = heightMap.Get(neighbour);

                    if (destinationValue - currentValue >= 2) {
                        continue;
                    }

                    movement.GetOrCreate((x, y), () => new()).Add(neighbour);
                }
            }
        }

        var queue = new Queue<(int, int)>();
        queue.Enqueue(start);
        HashSet<(int, int)> passed = new HashSet<(int, int)> {
            start
        };
        Dictionary<(int, int), int> steps = new Dictionary<(int, int), int>() {
            { start, 0 }
        };

        while (queue.Count > 0) {
            var current = queue.Dequeue();

            foreach (var movements in movement[current]) {
                if (!passed.Add(movements))
                    continue;

                queue.Enqueue(movements);
                steps[movements] = steps[current] + 1;
            }
        }

        return steps[end];
    }

    protected override object SolvePart2() {
        var heightMap = Lines.ToHeightMap(c => {
            if (c == 'S')
                return 1;
            else if (c == 'E')
                return 26;
            else
                return c - 'a' + 1;
        }, out var width, out var height);

        var start = Lines.IndexOf('S').Inverse();
        var end = Lines.IndexOf('E').Inverse();

        Dictionary<(int, int), List<(int, int)>> movement = new();

        for (int y = 0; y < height; y++) {
            for (int x = 0; x < width; x++) {
                var currentValue = heightMap[x, y];

                foreach (var neighbour in heightMap.GetNeighbourCoords(x, y, false)) {
                    var destinationValue = heightMap.Get(neighbour);

                    if (currentValue - destinationValue >= 2) {
                        continue;
                    }

                    movement.GetOrCreate((x, y), () => new()).Add(neighbour);
                }
            }
        }

        var queue = new Queue<(int, int)>();
        queue.Enqueue(end);
        HashSet<(int, int)> passed = new HashSet<(int, int)> {
            end
        };
        Dictionary<(int, int), int> steps = new Dictionary<(int, int), int>() {
            { end, 0 }
        };

        while (queue.Count > 0) {
            var current = queue.Dequeue();

            if(heightMap.Get(current) == 1) {
                return steps[current];
            }

            foreach (var movements in movement[current]) {
                if (!passed.Add(movements))
                    continue;

                queue.Enqueue(movements);
                steps[movements] = steps[current] + 1;
            }
        }

        return -1;
    }
}
