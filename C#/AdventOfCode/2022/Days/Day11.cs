namespace _2022.Days;

public class Day11 : AdventDay {
    private class Monkey {
        public int InspectCount { get; private set; }

        public int DivisibleBy { get; }

        private readonly List<Item> items;
        private readonly Func<long, long> worryOperation;
        private readonly int ifTrue;
        private readonly int ifFalse;

        private Monkey(List<Item> items, Func<long, long> worryOperation, int divisibleBy, int ifTrue, int ifFalse) {
            this.items = items;
            this.worryOperation = worryOperation;
            this.DivisibleBy = divisibleBy;
            this.ifTrue = ifTrue;
            this.ifFalse = ifFalse;
        }

        public static Monkey Construct(string[] lines) {
            var itemsString = lines[1].Split(" ", StringSplitOptions.RemoveEmptyEntries);
            List<Item> items = new();
            for (int i = 2; i < itemsString.Length; i++) {
                items.Add(new Item(itemsString[i].Replace(",", "").ToInt32()));
            }
            var operationString = lines[2].Split(' ', StringSplitOptions.RemoveEmptyEntries);
            bool square = operationString[^1] == "old";
            Func<long, long> worryOperation = (operationString[^2], square) switch {
                ("*", true) => input => input * input,
                ("*", false) => input => input * operationString[^1].ToInt32(),
                ("+", true) => input => input + input,
                ("+", false) => input => input + operationString[^1].ToInt32(),
                _ => input => input
            };
            var testString = lines[3].Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var divisibleBy = testString[^1].ToInt32();

            var ifTrueString = lines[4].Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var ifTrue = ifTrueString[^1].ToInt32();

            var ifFalseString = lines[5].Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var ifFalse = ifFalseString[^1].ToInt32();

            return new Monkey(items, worryOperation, divisibleBy, ifTrue, ifFalse);
        }

        public IEnumerable<(Item, int)> DoRound(int diviser = -1) {
            foreach (var item in items) {
                InspectCount++;
                if (item.ApplyWorry(worryOperation, diviser == -1, diviser == -1 ? 3 : diviser, DivisibleBy)) {
                    yield return (item, ifTrue);
                } else {
                    yield return (item, ifFalse);
                }
            }
            items.Clear();
        }

        public void AddItem(Item item) => items.Add(item);

        public override string ToString() => InspectCount.ToString();
    }

    private class Item {
        public long Worry { get; private set; }

        public Item(long worry) => Worry = worry;

        public bool ApplyWorry(Func<long, long> operation, bool reduceWorry, int diviser, int divisibleBy) {
            var worry = operation(Worry);
            if (reduceWorry) {
                worry = worry / 3;
            } else {
                worry %= diviser;
            }
            var isDivisible = worry % divisibleBy == 0;
            Worry = worry;
            return isDivisible;
        }

        public override string ToString() => Worry.ToString();
    }
    public Day11() : base(11, 2022, "Monkey in the Middle") { }

    protected override object SolvePart1() {
        List<Monkey> monkeys = new List<Monkey>();

        for (int i = 0; i < Lines.Length; i += 7) {
            monkeys.Add(Monkey.Construct(Lines.Skip(i).Take(7).ToArray()));
        }

        for (int i = 0; i < 20; i++) {
            foreach (var monkey in monkeys) {
                foreach (var item in monkey.DoRound()) {
                    monkeys[item.Item2].AddItem(item.Item1);
                }
            }
        }

        var highestTwo = monkeys.Select(monkey => monkey.InspectCount).Highest(2).ToArray();

        return highestTwo.Multiply();
    }

    protected override object SolvePart2() {
        List<Monkey> monkeys = new List<Monkey>();

        for (int i = 0; i < Lines.Length; i += 7) {
            monkeys.Add(Monkey.Construct(Lines.Skip(i).Take(7).ToArray()));
        }

        var commonDiviser = monkeys.Aggregate(1, (accumulate, monkey) => accumulate * monkey.DivisibleBy);

        for (int i = 0; i < 10000; i++) {
            foreach (var monkey in monkeys) {
                foreach (var item in monkey.DoRound(commonDiviser)) {
                    monkeys[item.Item2].AddItem(item.Item1);
                }
            }

            //if (i == 0 || i == 19 || i == 999 || i == 1999 || i == 2999 || i == 3999 || i == 4999) {
            //    System.Diagnostics.Debugger.Break();
            //}
        }

        //System.Diagnostics.Debugger.Break();

        var highestTwo = monkeys.Select(monkey => (long)monkey.InspectCount).Highest(2).ToArray();

        return highestTwo.Multiply();
    }
}
