namespace _2015.Days;

public class Day1 : AdventDay{
    public Day1() : base(1, 2015, "Not Quite Lisp") { }

    protected override object SolvePart1() {
        int floor = 0;

        foreach (var c in Input)
            floor += c == '(' ? 1 : -1;

        return floor;
    }

    protected override object SolvePart2() {
        int floor = 0;

        for (int i = 0; i < Input.Length; i++) {
            floor += Input[i] == '(' ? 1 : -1;

            if(floor < 0) {
                return i + 1;
            }
        }

        return -1;
    }
}
