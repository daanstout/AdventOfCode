using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2019.Days;

public class Day2 : AdventDay<IntCodeVM> {
    public Day2() : base(2, 2019, "1202 Program Alarm") { }

    protected override object SolvePart1(out IntCodeVM state) {
        var memory = Input.Split(',').ToIntArray();

        state = new IntCodeVM(memory);

        return state.RunCopy(memory => {
            memory[1] = 12;
            memory[2] = 2;
        });
    }

    protected override object SolvePart2(IntCodeVM state) {
        const int TARGET_VALUE = 19690720;

        for (int noun = 0; noun <= 99; noun++) {
            for(int verb = 0; verb <= 99; verb++) {
                if (state.RunCopy(memory => {
                    memory[1] = noun;
                    memory[2] = verb;
                }) == TARGET_VALUE) {
                    return 100 * noun + verb;
                }
            }
        }

        return -1;
    }
}
