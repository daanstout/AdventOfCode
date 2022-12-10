using System.Numerics;

namespace _2015.Days;

public class Day3 : AdventDay {
    public Day3() : base(3, 2015, "Perfectly Spherical Houses in a Vacuum") { }

    protected override object SolvePart1() {
        HashSet<Vector2> visited = new HashSet<Vector2> {
            new Vector2()
        };
        Vector2 current = new();

        foreach (var c in Input) {
            current += c switch {
                '^' => new Vector2(0, 1),
                'v' => new Vector2(0, -1),
                '<' => new Vector2(-1, 0),
                '>' => new Vector2(1, 0),
                _ => new Vector2()
            };
            visited.Add(current);
        }

        return visited.Count;
    }

    protected override object SolvePart2() {
        HashSet<Vector2> visited = new HashSet<Vector2> {
            new Vector2()
        };
        Vector2[] current = new Vector2[2];
        current.FillArray(() => new Vector2());
        int currentIndex = 0;

        foreach(var c in Input) {
            current[currentIndex] += c switch {
                '^' => new Vector2(0, 1),
                'v' => new Vector2(0, -1),
                '<' => new Vector2(-1, 0),
                '>' => new Vector2(1, 0),
                _ => new Vector2()
            };
            visited.Add(current[currentIndex]);

            currentIndex = 1 - currentIndex;
        }

        return visited.Count;
    }
}
