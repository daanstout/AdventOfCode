namespace _2021.Days;
public class Day6 : AdventDay {
    public Day6() : base(6, 2021, "Lanternfish") { }

    protected override object SolvePart1() {
        var initial = Input.Split(',').ToIntList();

        long[] dayCount = new long[9];

        foreach (var value in initial) {
            dayCount[value]++;
        }

        for (int day = 0; day < 80; day++) {
            var temp = new long[9];
            for (int i = 0; i < 8; i++) {
                temp[i] = dayCount[i + 1];
            }
            temp[6] += dayCount[0];
            temp[8] = dayCount[0];
            dayCount = temp;
        }

        return dayCount.Sum();
    }

    protected override object SolvePart2() {
        var initial = Input.Split(',').ToIntList();

        long[] dayCount = new long[9];

        foreach (var value in initial) {
            dayCount[value]++;
        }

        for (int day = 0; day < 256; day++) {
            var temp = new long[9];
            for (int i = 0; i < 8; i++) {
                temp[i] = dayCount[i + 1];
            }
            temp[6] += dayCount[0];
            temp[8] = dayCount[0];
            dayCount = temp;
        }

        return dayCount.Sum();
    }
}
