namespace _2022.Days;
public class Day4 : AdventDay {
    public Day4() : base(4, 2022, "Camp Cleanup") { }

    protected override object SolvePart1() {
        int contained = 0;
        foreach (var line in Lines) {
            var sections = line.Split(',');
            int[] sectionNumbers = new int[4];
            for (int i = 0; i < sections.Length; i++) {
                var parts = sections[i].Split('-');
                sectionNumbers[i * 2] = int.Parse(parts[0]);
                sectionNumbers[i * 2 + 1] = int.Parse(parts[1]);
            }

            if (sectionNumbers[0] >= sectionNumbers[2] && sectionNumbers[1] <= sectionNumbers[3]
                || sectionNumbers[0] <= sectionNumbers[2] && sectionNumbers[1] >= sectionNumbers[3])
                contained++;
        }

        return contained;
    }

    protected override object SolvePart2() {
        int overlap = 0;
        foreach (var line in Lines) {
            var sections = line.Split(',');
            int[] sectionNumbers = new int[4];
            for (int i = 0; i < sections.Length; i++) {
                var parts = sections[i].Split('-');
                sectionNumbers[i * 2] = int.Parse(parts[0]);
                sectionNumbers[i * 2 + 1] = int.Parse(parts[1]);
            }

            var sectionOne = Enumerable.Range(sectionNumbers[0], sectionNumbers[1] - sectionNumbers[0] + 1);
            var sectionTwo = Enumerable.Range(sectionNumbers[2], sectionNumbers[3] - sectionNumbers[2] + 1);

            if (sectionOne.Intersect(sectionTwo).Any())
                overlap++;
        }

        return overlap;
    }
}
