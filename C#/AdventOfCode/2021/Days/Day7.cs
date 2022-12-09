namespace _2021.Days;
public class Day7 : AdventDay {
    public Day7() : base(7, 2021, "The Treachery of Whales") { }

    protected override object SolvePart1() {
        var input = Input.Split(',').ToIntArray();
        var min = input.Min();
        var max = input.Max();

        return Enumerable.Range(min, max - min + 1).Select(i => input.Select(val => Math.Abs(val - i)).Sum()).Min();
    }

    protected override object SolvePart2() {
        var input = Input.Split(',').ToIntArray();
        var min = input.Min();
        var max = input.Max();

        return Enumerable.Range(min, max - min + 1).Select(i => input.Select(val =>  Math.Abs(val - i)).Select(x => x * (x + 1) / 2).Sum()).Min();
    }
}
