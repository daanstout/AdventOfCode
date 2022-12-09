namespace _2022.Days;

public class Day3 : AdventDay {
    public Day3() : base(3, 2022, "Rucksack Reorganization") { }

    protected override object SolvePart1() {
        int sum = 0;
        foreach (var line in Lines) {
            var chunked = line.Chunk(line.Length / 2).ToList();

            var same = chunked[0].Intersect(chunked[1]).First();

            if (same >= 'a' && same <= 'z')
                sum += same - 'a' + 1;
            else
                sum += same - 'A' + 27;
        }

        return sum;
    }

    protected override object SolvePart2() {
        int sum = 0;

        for (int i = 0; i < Lines.Length; i += 3) {
            var items = Lines[i].Intersect(Lines[i + 1].Intersect(Lines[i + 2])).ToList();

            var same = items[0];

            if (same >= 'a' && same <= 'z')
                sum += same - 'a' + 1;
            else
                sum += same - 'A' + 27;
        }

        return sum;
    }
}
