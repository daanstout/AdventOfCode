namespace _2015.Days;

public class Day5 : AdventDay {
    public Day5() : base(5, 2015, "Doesn't He Have Intern-Elves For This?") { }

    protected override object SolvePart1() {
        int niceStrings = 0;

        string[] invalidSequences = new string[] {
            "ab",
            "cd",
            "pq",
            "xy"
        };

        var vowelString = "aeiou";

        foreach (var line in Lines) {
            if (!(line.Count(vowelString.Contains) >= 3))
                continue;

            if (!line.Aggregate(false, (accumulate, currentChar, nextChar) => accumulate |= currentChar == nextChar, true)) {
                continue;
            }

            if (line.Aggregate(false, (accumulate, currentChar, nextChar) => accumulate |= invalidSequences.Contains($"{currentChar}{nextChar}"), true)) {
                continue;
            }

            niceStrings++;
        }

        return niceStrings;
    }

    protected override object SolvePart2() {
        int niceStrings = 0;

        foreach (var line in Lines) {
            bool hasFirst = false;
            bool hasSecond = false;
            for (int i = 0; i < line.Length - 2; i++) {
                if (!hasFirst && line[i] == line[i + 2]) {
                    hasFirst = true;
                }

                if (!hasSecond && i < line.Length - 3) {
                    if (line.Length - line.Replace(line.Substring(i, 2), string.Empty).Length >= 4)
                        hasSecond = true;
                }

                if (hasFirst && hasSecond) {
                    niceStrings++;
                    break;
                }
            }
        }

        return niceStrings;
    }
}
