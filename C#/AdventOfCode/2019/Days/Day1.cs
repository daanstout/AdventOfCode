using System.Linq;

namespace _2019.Days;

public class Day1 : AdventDay<int[]> {
    public Day1() : base(1, 2019, "The Tyranny of the Rocket Equation") { }

    protected override object SolvePart1(out int[] state) {
        state = Lines.ToIntArray();

        int[] result = new int[Lines.Length];

        for (int i = 0; i < Lines.Length; i++) {
            result[i] = CalculateFuelCost(state[i]);
        }

        return result.Sum();
    }

    protected override object SolvePart2(int[] state) {
        int[] result = new int[state.Length];

        for(int i = 0; i < state.Length; i++) {
            int currentAddition = CalculateFuelCost(state[i]);

            while (currentAddition > 0) {
                result[i] += currentAddition;
                currentAddition = CalculateFuelCost(currentAddition);
            }
        }
        

        return result.Sum();
    }

    private int CalculateFuelCost(int mass) => mass / 3 - 2;
}
