namespace _2022.Days;

public class Day1 : AdventDay {
    public Day1() : base(1, 2022, "Calorie Counting") { }

    protected override object SolvePart1() {
        return GetCountedCalories()[^1];
    }

    protected override object SolvePart2() {
        var caloriesCarried = GetCountedCalories();
        return caloriesCarried[^1] + caloriesCarried[^2] + caloriesCarried[^3];
    }

    private List<int> GetCountedCalories() {
        var input = Lines.ToIntArray();

        int current = 0;
        List<int> caloriesCarried = new();

        foreach (var calories in input) {
            if (calories == 0) {
                caloriesCarried.Add(current);
                current = 0;
            } else {
                current += calories;
            }
        }
        caloriesCarried.Add(current);

        caloriesCarried.Sort();

        return caloriesCarried;
    }
}
