namespace _2015.Days;

public class Day2 : AdventDay {
    public Day2() : base(2, 2015, "I Was Told There Would Be No Math") { }

    protected override object SolvePart1() {
        int total = 0;
        foreach(var line in Lines) {
            var dimensions = line.Split('x').ToIntArray();
            var smallestTwo = dimensions.Lowest(2).ToArray();
            total += 2 * (dimensions[0] * dimensions[1] + dimensions[1] * dimensions[2] + dimensions[0] * dimensions[2]) + smallestTwo[0] * smallestTwo[1];
        }

        return total;
    }

    protected override object SolvePart2() {
        int total = 0;

        foreach(var line in Lines) {
            var dimensions = line.Split('x').ToIntArray();
            var smallestTwo = dimensions.Lowest(2).ToArray();
            total += 2 * smallestTwo[0] + 2 * smallestTwo[1] + dimensions.Multiply();
        }

        return total;
    }
}
