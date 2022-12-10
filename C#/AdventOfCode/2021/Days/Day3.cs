namespace _2021.Days;

public class Day3 : AdventDay {
    private int Bits => UseTest ? 5 : 12;

    public Day3() : base(3, 2021, "Binary Diagnostic") { }

    protected override object SolvePart1() {
        int[] bitHighCount = new int[Bits];

        foreach (var line in Lines) {
            for (int i = 0; i < Bits; i++) {
                bitHighCount[i] += int.Parse(line[i].ToString());
            }
        }

        int gamma = 0, epsilon = 0;

        for (int i = 0; i < Bits; i++) {
            int bit = bitHighCount[i] > Lines.Length / 2 ? 1 : 0;

            gamma += bit;
            epsilon += 1 - bit;

            gamma <<= 1;
            epsilon <<= 1;
        }

        gamma >>= 1;
        epsilon >>= 1;

        return gamma * epsilon;
    }

    protected override object SolvePart2() {
        var oxygenGeneratorRating = GetNumber(Lines, (bitCount, numberCount) => bitCount * 2 >= numberCount);
        var co2ScrubberRating = GetNumber(Lines, (bitCount, numberCount) => bitCount * 2 < numberCount);

        return oxygenGeneratorRating * co2ScrubberRating;
    }

    private int GetNumber(IEnumerable<string> input, Func<int, int, bool> bitPredicate) {
        List<string> numbers = new List<string>(input);

        for (int i = 0; i < Bits; i++) {
            int bitCount = 0;

            for (int j = 0; j < numbers.Count; j++) {
                bitCount += int.Parse(numbers[j][i].ToString());
            }

            List<string> temp = new List<string>();
            char bit = bitPredicate(bitCount, numbers.Count) ? '1' : '0';

            foreach (var number in numbers) {
                if (number[i] == bit) {
                    temp.Add(number);
                }
            }

            if (temp.Count == 1) {
                return BitsToInt(temp[0]);
            }

            numbers = temp;
        }

        return 0;
    }

    private static int BitsToInt(string bits) {
        int result = 0;
        foreach (char bit in bits) {
            result += int.Parse(bit.ToString());
            result <<= 1;
        }
        result >>= 1;
        return result;
    }
}
