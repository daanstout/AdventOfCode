using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2019;

public class IntCodeVM {
    private readonly int[] memory;
    private int ip;

    public IntCodeVM(int[] memory) {
        this.memory = memory;
    }

    public int Run() {
        ip = 0;
        while (memory[ip] != 99) {
            switch (memory[ip]) {
                case 1:
                    memory[memory[ip + 3]] = memory[memory[ip + 1]] + memory[memory[ip + 2]];
                    ip += 4;
                    break;
                case 2:
                    memory[memory[ip + 3]] = memory[memory[ip + 1]] * memory[memory[ip + 2]];
                    ip += 4;
                    break;
                default:
                    throw new ArgumentException();
            }
        }

        return memory[0];
    }

    public int RunCopy(Action<int[]> PreRunMemoryTransformer) {
        var memory = this.memory.ToArray();
        var ip = 0;

        PreRunMemoryTransformer(memory);

        while (memory[ip] != 99) {
            switch (memory[ip]) {
                case 1:
                    memory[memory[ip + 3]] = memory[memory[ip + 1]] + memory[memory[ip + 2]];
                    ip += 4;
                    break;
                case 2:
                    memory[memory[ip + 3]] = memory[memory[ip + 1]] * memory[memory[ip + 2]];
                    ip += 4;
                    break;
                default:
                    throw new ArgumentException();
            }
        }

        return memory[0];
    }
}
