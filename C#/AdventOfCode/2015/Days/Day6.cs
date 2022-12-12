using System.Numerics;

namespace _2015.Days;

public class Day6 : AdventDay {
    public Day6() : base(6, 2015, "Probably a Fire Hazard") { }

    protected override object SolvePart1() {
        bool[,] lights = new bool[1000, 1000];

        foreach (var line in Lines) {
            var commands = line.Split(' ');

            if (commands[0] == "turn") {
                bool value = commands[1] == "on";
                Vector2 from = commands[2].ToVec2();
                Vector2 to = commands[4].ToVec2();
                for (int y = (int)from.Y; y <= (int)to.Y; y++) {
                    for (int x = (int)from.X; x <= (int)to.X; x++) {
                        lights[x, y] = value;
                    }
                }
            } else if (commands[0] == "toggle") {
                Vector2 from = commands[1].ToVec2();
                Vector2 to = commands[3].ToVec2();
                for (int y = (int)from.Y; y <= (int)to.Y; y++) {
                    for (int x = (int)from.X; x <= (int)to.X; x++) {
                        lights[x, y] = !lights[x, y];
                    }
                }
            }
        }

        return lights.Count(value => value);
    }

    protected override object SolvePart2() {
        var lights = new int[1000, 1000];

        foreach(var line in Lines) {
            var commands = line.Split(' ');

            if (commands[0] == "turn") {
                int increase = commands[1] == "on" ? 1 : -1;
                Vector2 from = commands[2].ToVec2();
                Vector2 to = commands[4].ToVec2();
                for (int y = (int)from.Y; y <= (int)to.Y; y++) {
                    for (int x = (int)from.X; x <= (int)to.X; x++) {
                        lights[x, y] += increase;
                        if (lights[x, y] < 0)
                            lights[x, y] = 0;
                    }
                }
            } else if (commands[0] == "toggle") {
                Vector2 from = commands[1].ToVec2();
                Vector2 to = commands[3].ToVec2();
                for (int y = (int)from.Y; y <= (int)to.Y; y++) {
                    for (int x = (int)from.X; x <= (int)to.X; x++) {
                        lights[x, y] += 2;
                    }
                }
            }
        }

        return lights.Sum();
    }
}
