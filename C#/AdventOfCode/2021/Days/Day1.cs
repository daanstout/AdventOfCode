namespace _2021.Days;
public class Day1 : AdventDay{
    public Day1() : base(1, 2021, "Sonar Sweep") { }

    protected override object SolvePart1() {
        int[] input = Lines.ToIntArray();

        bool[] increases = new bool[input.Length - 1];

        int lastIncrease = input[0];
        int lastWindow = CountNextThree(0, input);

        for (int i = 1; i < input.Length; i++) {
            increases[i - 1] = lastIncrease < input[i];
            lastIncrease = input[i];

            int nextThree = CountNextThree(i, input);

            if (nextThree != -1) {
                lastWindow = nextThree;
            }
        }

        return increases.Count(increases => increases);
    }

    protected override object SolvePart2() {
        int[] input = Lines.ToIntArray();

        bool[] measuredWindows = new bool[input.Length - 2];

        int lastIncrease = input[0];
        int lastWindow = CountNextThree(0, input);

        for (int i = 1; i < input.Length; i++) {
            lastIncrease = input[i];

            int nextThree = CountNextThree(i, input);

            if (nextThree != -1) {
                measuredWindows[i - 1] = lastWindow < nextThree;
                lastWindow = nextThree;
            }
        }

        return measuredWindows.Count(increases => increases);
    }

    private static int CountNextThree(int startIndex, int[] array) {
        if (startIndex >= array.Length - 2)
            return -1;
        else
            return array[startIndex] + array[startIndex + 1] + array[startIndex + 2];
    }
}
