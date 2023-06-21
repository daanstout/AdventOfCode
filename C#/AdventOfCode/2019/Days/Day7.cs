using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2019.Days;

public class Day7 : AdventDay {
    public Day7() : base(7, 2019, "Amplification Circuit") { }

    protected override object SolvePart1() {
        var memory = Input.Split(",").ToIntArray();

        IntCodeVM amplifier = new IntCodeVM(memory);

        int bestOutput = int.MinValue;

        foreach (var phaseSettingsPermutation in GetPermutations(new int[] { 0, 1, 2, 3, 4 }, 5)) {
            int currentInput = 0;

            var phaseSettings = phaseSettingsPermutation.ToArray();

            for (var i = 0; i < phaseSettings.Length; i++) {
                amplifier.LastOutputIsResult = true;
                Queue<int> inputQueue = new Queue<int>();
                inputQueue.Enqueue(phaseSettings[i]);
                inputQueue.Enqueue(currentInput);
                amplifier.UseIEnumerableAsInput(inputQueue);
                currentInput = amplifier.Run();
            }

            if (currentInput > bestOutput)
                bestOutput = currentInput;
        }

        return bestOutput;
    }

    protected override object SolvePart2() => throw new NotImplementedException();

    private static IEnumerable<IEnumerable<int>> GetPermutations(IEnumerable<int> list, int length) {
        if (length == 1)
            return list.Select(i => new int[] { i });

        return GetPermutations(list, length - 1).SelectMany(i => list.Where(e => !i.Contains(e)), (t1, t2) => t1.Concat(new int[] { t2 }));
    }
}
