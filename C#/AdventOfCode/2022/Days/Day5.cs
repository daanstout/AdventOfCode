using System.Text;

namespace _2022.Days;

public class Day5 : AdventDay {
    public Day5() : base(5, 2022, "Supply Stacks") { }

    protected override object SolvePart1() {
        int endInitialTowerState;

        for (endInitialTowerState = 0; endInitialTowerState < Lines.Length; endInitialTowerState++) {
            if (string.IsNullOrWhiteSpace(Lines[endInitialTowerState])) {
                break;
            }
        }

        int numTowers = (Lines[endInitialTowerState - 1].Length + 1) / 4;

        Stack<char>[] stacks1 = new Stack<char>[numTowers];
        stacks1.FillArray(() => new Stack<char>());

        for (int i = endInitialTowerState - 2; i >= 0; i--) {
            for (int j = 0; j < numTowers; j++) {
                char c = Lines[i][(j * 4) + 1];
                if (c >= 'A' && c <= 'Z') {
                    stacks1[j].Push(c);
                }
            }
        }

        for (int i = endInitialTowerState + 1; i < Lines.Length; i++) {
            string[] instructions = Lines[i].Split(' ');
            int count = instructions[1].ToInt();
            int from = instructions[3].ToInt() - 1;
            int to = instructions[5].ToInt() - 1;

            for (int current = 0; current < count; current++) {
                char c = stacks1[from].Pop();
                stacks1[to].Push(c);
            }
        }

        StringBuilder builder = new StringBuilder();

        foreach (var stack in stacks1)
            builder.Append(stack.Peek());

        return builder.ToString();
    }

    protected override object SolvePart2() {
        int endInitialTowerState;

        for (endInitialTowerState = 0; endInitialTowerState < Lines.Length; endInitialTowerState++) {
            if (string.IsNullOrWhiteSpace(Lines[endInitialTowerState])) {
                break;
            }
        }

        int numTowers = (Lines[endInitialTowerState - 1].Length + 1) / 4;

        Stack<char>[] stacks2 = new Stack<char>[numTowers];
        stacks2.FillArray(() => new Stack<char>());

        for (int i = endInitialTowerState - 2; i >= 0; i--) {
            for (int j = 0; j < numTowers; j++) {
                char c = Lines[i][(j * 4) + 1];
                if (c >= 'A' && c <= 'Z') {
                    stacks2[j].Push(c);
                }
            }
        }

        for (int i = endInitialTowerState + 1; i < Lines.Length; i++) {
            string[] instructions = Lines[i].Split(' ');
            int count = instructions[1].ToInt();
            int from = instructions[3].ToInt() - 1;
            int to = instructions[5].ToInt() - 1;

            Stack<char> tempStack = new Stack<char>();

            for (int current = 0; current < count; current++) {
                char c = stacks2[from].Pop();
                tempStack.Push(c);
            }

            foreach (var c in tempStack)
                stacks2[to].Push(c);
        }

        StringBuilder builder = new StringBuilder();

        foreach (var stack in stacks2)
            builder.Append(stack.Peek());

        return builder.ToString();
    }
}
