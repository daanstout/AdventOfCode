using System.Numerics;

namespace _2021.Days;

public class Day2 : AdventDay {
    public Day2() : base(2, 2021, "Dive!") { }

    protected override object SolvePart1() {
        Vector2 location = new Vector2(0, 0);

        foreach (var line in Lines) {
            var command = line.Split(' ');
            int value = int.Parse(command[1]);

            location += command[0] switch {
                "forward" => new Vector2(value, 0),
                "up" => new Vector2(0, -value),
                "down" => new Vector2(0, value),
                _ => new Vector2(0, 0)
            };
        }

        return (int)location.X * (int)location.Y;
    }

    protected override object SolvePart2() {
        Vector3 location = new Vector3(0, 0, 0);

        foreach (var line in Lines) {
            var command = line.Split(' ');
            int value = int.Parse(command[1]);

            location += command[0] switch {
                "forward" => new Vector3(value, value * location.Z, 0),
                "up" => new Vector3(0, 0, -value),
                "down" => new Vector3(0, 0, value),
                _ => new Vector3(0, 0, 0)
            };
        }

        return (int)location.X * (int)location.Y;
    }
}
