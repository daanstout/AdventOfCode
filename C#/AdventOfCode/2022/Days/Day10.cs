using System.Text;

namespace _2022.Days;

public class Day10 : AdventDay {
    public Day10() : base(10, 2022, "Cahtode-Ray Tube") { }

    protected override object SolvePart1() {
        int x = 1;
        int cycle = 0;

        List<int> signalStrengths = new List<int>();

        foreach (var line in Lines) {
            var command = line.Split(' ');

            if (command[0] == "noop") {
                cycle++;

                if ((cycle - 20) % 40 == 0) {
                    signalStrengths.Add(x * cycle);
                }

            } else if (command[0] == "addx") {
                if ((cycle - 19) % 40 == 0) {
                    signalStrengths.Add(x * (cycle + 1));
                }

                cycle += 2;

                if ((cycle - 20) % 40 == 0) {
                    signalStrengths.Add(x * cycle);
                }

                x += command[1].ToInt();
            }
        }

        return signalStrengths.Sum();
    }

    protected override object SolvePart2() {
        StringBuilder builder = new StringBuilder();

        int x = 1;
        int cycle = 0;

        foreach(var line in Lines) {
            var command = line.Split(' ');

            if (command[0] == "noop") {
                DrawSprite(x, cycle, builder);

                cycle++;
            }else if (command[0] == "addx") {
                DrawSprite(x, cycle, builder);

                cycle++;

                DrawSprite(x, cycle, builder);

                cycle++;

                x += command[1].ToInt();
            }
        }


        return builder.ToString();
    }

    private static void DrawSprite(int x, int cycle, StringBuilder builder) {
        var xPos = cycle % 40;

        if (xPos == 0)
            builder.AppendLine();

        if (Math.Abs(x - xPos) <= 1)
            builder.Append('#');
        else
            builder.Append('.');
    }
}
