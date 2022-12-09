namespace _2022.Days;
public class Day2 : AdventDay {
    public Day2() : base(2, 2022, "Rock Paper Scissors") { }

    protected override object SolvePart1() {
        int totalPoints = 0;

        foreach (var line in Lines) {
            var hands = line.Split(' ');

            totalPoints += GetPointsOne(hands[0], hands[1]);
        }

        return totalPoints;
    }

    protected override object SolvePart2() {
        int totalPoints = 0;

        foreach (var line in Lines) {
            var hands = line.Split(' ');

            totalPoints += GetPointsTwo(hands[0], hands[1]);
        }

        return totalPoints;
    }

    private static int GetPointsOne(string first, string second) {
        return (first, second) switch {
            ("A", "X") => 1 + 3,
            ("A", "Y") => 2 + 6,
            ("A", "Z") => 3 + 0,
            ("B", "X") => 1 + 0,
            ("B", "Y") => 2 + 3,
            ("B", "Z") => 3 + 6,
            ("C", "X") => 1 + 6,
            ("C", "Y") => 2 + 0,
            ("C", "Z") => 3 + 3,
            _ => 0
        };
    }

    private static int GetPointsTwo(string first, string second) {
        return (first, second) switch {
            ("A", "X") => 3 + 0,
            ("A", "Y") => 1 + 3,
            ("A", "Z") => 2 + 6,
            ("B", "X") => 1 + 0,
            ("B", "Y") => 2 + 3,
            ("B", "Z") => 3 + 6,
            ("C", "X") => 2 + 0,
            ("C", "Y") => 3 + 3,
            ("C", "Z") => 1 + 6,
            _ => 0
        };
    }
}
