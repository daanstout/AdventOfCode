namespace _2021.Days;
public class Day8 : AdventDay {
    public Day8() : base(8, 2021, "Seven Segment Search") { }

    protected override object SolvePart1() {
        return Lines.Select(line => line.Split('|')[1].Split(' ', StringSplitOptions.RemoveEmptyEntries).Count(val => new int[] { 2, 3, 4, 7 }.Contains(val.Length))).Sum();
    }

    protected override object SolvePart2() {
        var sum = 0;

        foreach (var line in Lines)
            sum += CalculateValue(line);

        return sum;
    }

    private int CalculateValue(string line) {
        string[] parts = line.Split('|');

        string[] segments = parts[0].Split(' ', StringSplitOptions.RemoveEmptyEntries);
        Array.Sort(segments, (left, right) => left.Length.CompareTo(right.Length));

        char[] correctValues = new char[7];

        var zeroSixNine = segments.Where(text => text.Length == 6).ToList();
        var twoThreeFive = segments.Where(text => text.Length == 5).ToList();

        string[] foundSegments = new string[10];

        foundSegments[1] = segments[0];
        foundSegments[4] = segments[2];
        foundSegments[7] = segments[1];
        foundSegments[8] = segments[^1];
        foundSegments[3] = twoThreeFive.First(text => text.Intersect(foundSegments[1]).Count() == 2);
        twoThreeFive.Remove(foundSegments[3]);
        foundSegments[9] = zeroSixNine.First(text => text.Intersect(foundSegments[3]).Count() == 5);
        zeroSixNine.Remove(foundSegments[9]);
        foundSegments[0] = zeroSixNine.First(text => text.Intersect(foundSegments[1]).Count() == 2);
        zeroSixNine.Remove(foundSegments[0]);
        foundSegments[6] = zeroSixNine.First();
        foundSegments[5] = twoThreeFive.First(text => text.Intersect(foundSegments[4]).Count() == 3);
        twoThreeFive.Remove(foundSegments[5]);
        foundSegments[2] = twoThreeFive.First();

        string[] values = parts[1].Split(' ', StringSplitOptions.RemoveEmptyEntries);

        var result = foundSegments.IndexOf(values[0], Comparer) * 1000
                    + foundSegments.IndexOf(values[1], Comparer) * 100
                    + foundSegments.IndexOf(values[2], Comparer) * 10
                    + foundSegments.IndexOf(values[3], Comparer);

        return result;

        static bool Comparer(string left, string right) => left.Length == right.Length && left.Intersect(right).Count() == left.Length;
    }
}
