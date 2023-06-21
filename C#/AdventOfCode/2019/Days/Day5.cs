using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2019.Days;

public class Day5 : AdventDay<IntCodeVM> {
    public Day5() : base(5, 2019, "Sunny with a Chance of Asteroids") { }

    protected override object SolvePart1(out IntCodeVM state) {
        var memory = Input.Split(',').ToIntArray();

        state = new IntCodeVM(memory) {
            LastOutputIsResult = true
        };
        Queue<int> inputs = new Queue<int>();
        inputs.Enqueue(1);
        state.UseIEnumerableAsInput(inputs);

        return state.Run();
    }

    protected override object SolvePart2(IntCodeVM state) {
        Queue<int> inputs = new Queue<int>();
        inputs.Enqueue(5);
        state.UseIEnumerableAsInput(inputs);
        return state.Run();
    }
}
