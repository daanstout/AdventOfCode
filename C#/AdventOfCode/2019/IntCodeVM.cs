using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2019;

public class IntCodeVM {
    private const int OP_ADD = 1;
    private const int OP_MUL = 2;
    private const int OP_IN = 3;
    private const int OP_OUT = 4;
    private const int OP_JE = 5;
    private const int OP_JNE = 6;
    private const int OP_LT = 7;
    private const int OP_EQ = 8;

    private const int PARA_POSITION = 0;
    private const int PARA_IMMEDIATE = 1;

    public static Func<int> DefaultReadFunction { get; set; } = () => Console.ReadLine()?.ToInt32() ?? 0;

    public static Action<string> DefaultLogFunction { get; set; } = Console.WriteLine;

    public bool LastOutputIsResult { get; set; }

    public Action<string> LogFunction { get; set; } = DefaultLogFunction;

    public Func<int> ReadFunction { get; set; } = DefaultReadFunction;

    private readonly IReadOnlyCollection<int> memory;

    private int lastOutput;

    private IEnumerator<int>? inputEnumerator;

    public IntCodeVM(IReadOnlyCollection<int> memory) {
        this.memory = memory;
    }

    public void UseIEnumerableAsInput(IEnumerable<int> input) {
        inputEnumerator = input.GetEnumerator();
        ReadFunction = GetNextInput;
    }

    public int Run() {
        var memory = this.memory.ToArray();

        return Run(memory);
    }

    public int Run(Action<int[]> PreRunMemoryTransformer) {
        var memory = this.memory.ToArray();

        PreRunMemoryTransformer(memory);

        return Run(memory);
    }

    private int GetNextInput() {
        if (inputEnumerator == null) {
            ReadFunction = DefaultReadFunction;
            return ReadFunction();
        }

        if (!inputEnumerator.MoveNext()) {
            ReadFunction = DefaultReadFunction;
            inputEnumerator = null;
            return ReadFunction();
        }

        var value = inputEnumerator.Current;

        return value;
    }

    private int Run(int[] memory) {
        var ip = 0;

        while (memory[ip] != 99) {
            int op = GetOpCode(memory[ip], out var parameterModes);
            switch (op) {
                case OP_ADD:
                    memory[GetMemoryAddress(memory, ip + 3, parameterModes[2])] = GetValue(memory, ip + 1, parameterModes[0]) + GetValue(memory, ip + 2, parameterModes[1]);
                    ip += 4;
                    break;
                case OP_MUL:
                    memory[GetMemoryAddress(memory, ip + 3, parameterModes[2])] = GetValue(memory, ip + 1, parameterModes[0]) * GetValue(memory, ip + 2, parameterModes[1]);
                    ip += 4;
                    break;
                case OP_IN:
                    memory[GetMemoryAddress(memory, ip + 1, parameterModes[0])] = ReadFunction();
                    ip += 2;
                    break;
                case OP_OUT:
                    lastOutput = GetValue(memory, ip + 1, parameterModes[0]);
                    LogFunction($"OUT >> {lastOutput}");
                    ip += 2;
                    break;
                case OP_JE:
                    if (GetValue(memory, ip + 1, parameterModes[0]) != 0) {
                        ip = GetValue(memory, ip + 2, parameterModes[1]);
                    } else {
                        ip += 3;
                    }
                    break;
                case OP_JNE:
                    if (GetValue(memory, ip + 1, parameterModes[0]) == 0) {
                        ip = GetValue(memory, ip + 2, parameterModes[1]);
                    } else {
                        ip += 3;
                    }
                    break;
                case OP_LT:
                    if (GetValue(memory, ip + 1, parameterModes[0]) < GetValue(memory, ip + 2, parameterModes[1])) {
                        memory[GetMemoryAddress(memory, ip + 3, parameterModes[2])] = 1;
                    } else {
                        memory[GetMemoryAddress(memory, ip + 3, parameterModes[2])] = 0;
                    }
                    ip += 4;
                    break;
                case OP_EQ:
                    if (GetValue(memory, ip + 1, parameterModes[0]) == GetValue(memory, ip + 2, parameterModes[1])) {
                        memory[GetMemoryAddress(memory, ip + 3, parameterModes[2])] = 1;
                    } else {
                        memory[GetMemoryAddress(memory, ip + 3, parameterModes[2])] = 0;
                    }
                    ip += 4;
                    break;
                default:
                    throw new InvalidOperationException();
            }
        }

        return LastOutputIsResult ? lastOutput : memory[0];
    }

    private static int GetOpCode(int opCode, out int[] parameterModes) {
        int op = opCode % 100;
        parameterModes = op switch {
            OP_ADD => GetParameters(opCode, 3),
            OP_MUL => GetParameters(opCode, 3),
            OP_IN => GetParameters(opCode, 1),
            OP_OUT => GetParameters(opCode, 1),
            OP_JE => GetParameters(opCode, 2),
            OP_JNE => GetParameters(opCode, 2),
            OP_LT => GetParameters(opCode, 3),
            OP_EQ => GetParameters(opCode, 3),
            _ => throw new InvalidOperationException()
        };
        return op;
    }

    private static int[] GetParameters(int opCode, int parameterCount) {
        int[] result = new int[parameterCount];

        opCode /= 100;

        for (int i = 0; i < parameterCount; i++, opCode /= 10)
            result[i] = opCode % 10;

        return result;
    }

    private static int GetMemoryAddress(int[] memory, int address, int parameterMode) {
        return parameterMode switch {
            PARA_POSITION => memory[address],
            PARA_IMMEDIATE => address,
            _ => throw new InvalidOperationException()
        };
    }

    private static int GetValue(int[] memory, int address, int parameterMode) {
        return parameterMode switch {
            PARA_POSITION => memory[memory[address]],
            PARA_IMMEDIATE => memory[address],
            _ => throw new InvalidOperationException()
        };
    }
}
