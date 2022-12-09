namespace _2022.Days;

public class Day6 : AdventDay {
    public Day6() : base(6, 2022, "Tuning Trouble") { }

    protected override object SolvePart1() => GetStartIndex(4);

    protected override object SolvePart2() => GetStartIndex(14);

    private int GetStartIndex(int numSubsequentCharacters) {
        for (int i = 0; i < Input.Length - numSubsequentCharacters; i++) {
            if (Input.Substring(i, numSubsequentCharacters).Distinct().Count() == numSubsequentCharacters) {
                return i + numSubsequentCharacters;
            }
        }

        return -1;
    }
}
