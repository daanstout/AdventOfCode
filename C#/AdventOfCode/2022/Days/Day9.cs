using System.Numerics;

namespace _2022.Days;

public class Day9 : AdventDay {
    public Day9() : base(9, 2022, "Rope Bridge") { }

    protected override object SolvePart1() {
        Vector2 head = new Vector2();
        Vector2 tail = new Vector2();

        HashSet<Vector2> tailPositions = new() {
            tail
        };

        foreach (var line in Lines) {
            var command = line.Split(' ');
            for (int i = 0; i < command[1].ToInt32(); i++) {
                head += command[0] switch {
                    "R" => new Vector2(1, 0),
                    "U" => new Vector2(0, 1),
                    "L" => new Vector2(-1, 0),
                    "D" => new Vector2(0, -1),
                    _ => new Vector2()
                };

                tail = MoveTail(head, tail);
                tailPositions.Add(tail);
            }
        }

        return tailPositions.Count;
    }

    protected override object SolvePart2() {
        Vector2[] rope = new Vector2[10];

        HashSet<Vector2> tailPositions = new() {
            rope[^1]
        };

        foreach (var line in Lines) {
            var command = line.Split(' ');

            for(int i = 0; i < command[1].ToInt32(); i++) {
                rope[0] += command[0] switch {
                    "R" => new Vector2(1, 0),
                    "U" => new Vector2(0, 1),
                    "L" => new Vector2(-1, 0),
                    "D" => new Vector2(0, -1),
                    _ => new Vector2()
                };

                for (int knot = 0; knot < 9; knot++) {
                    rope[knot + 1] = MoveTail(rope[knot], rope[knot + 1]);
                }

                tailPositions.Add(rope[^1]);
            }
        }

        return tailPositions.Count;
    }

    private static Vector2 MoveTail(Vector2 head, Vector2 tail) {
        if (Vector2.Distance(head, tail) > MathF.Sqrt(2)) {
            var deltaX = head.X - tail.X;
            var deltaY = head.Y - tail.Y;

            var x = tail.X + (int)((deltaX / 2) + (deltaX < 0 ? -0.5f : 0.5f));
            var y = tail.Y + (int)((deltaY / 2) + (deltaY < 0 ? -0.5f : 0.5f));

            return new Vector2(x, y);
        }

        return tail;
    }
}
