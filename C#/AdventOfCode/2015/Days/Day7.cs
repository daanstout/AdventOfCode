namespace _2015.Days;

public class Day7 : AdventDay {
    private class Wire {
        public bool IsReady { get; private set; } = false;

        public ushort Charge { get; private set; }

        private readonly List<Gate> to;
        private readonly string name;
        private Gate? input;

        public Wire(string name) {
            to = new List<Gate>();
            this.name = name;
        }

        public override string ToString() => $"{name}({Charge})";

        public void ConnectGate(Gate gate) => to.Add(gate);

        public void Power(ushort value) {
            if (IsReady) {
                System.Diagnostics.Debugger.Break();
            }

            IsReady = true;
            Charge = value;

            foreach (var gate in to) {
                gate.NotifyReady();
            }
        }
        public void SetInput(Gate input) {
            if (this.input != null) {
                System.Diagnostics.Debugger.Break();
            }

            this.input = input;
        }
    }

    private abstract class Gate {
        protected abstract bool IsReady { get; }
        protected readonly Wire output;

        private bool hasInvoked = false;

        protected Gate(Wire output) {
            this.output = output;
        }

        public void NotifyReady() {
            if (IsReady) {
                Console.WriteLine($"Firing gate {this}");
                if (hasInvoked) {
                    System.Diagnostics.Debugger.Break();
                }
                hasInvoked = true;
                Propogate();
            }
        }

        protected abstract void Propogate();
    }

    private class AndGate : Gate {
        protected override bool IsReady => (left?.IsReady ?? true) && right.IsReady;

        private readonly int valueLeft;
        private readonly Wire? left;
        private readonly Wire right;

        public AndGate(Wire left, Wire right, Wire output) : base(output) {
            this.left = left;
            this.right = right;
        }

        public AndGate(int valueLeft, Wire right, Wire output) : base(output) {
            this.valueLeft = valueLeft;
            this.right = right;
        }

        protected override void Propogate() {
            output.Power((ushort)(left?.Charge ?? valueLeft & right.Charge));
        }

        public override string ToString() => $"{(left == null ? valueLeft : left)} AND {right} => {output}";
    }

    private class OrGate : Gate {
        protected override bool IsReady => left.IsReady && right.IsReady;

        private readonly Wire left;
        private readonly Wire right;

        public OrGate(Wire left, Wire right, Wire output) : base(output) {
            this.left = left;
            this.right = right;
        }

        protected override void Propogate() {
            output.Power((ushort)(left.Charge | right.Charge));
        }

        public override string ToString() => $"{left} OR {right} => {output}";
    }

    private class LShiftGate : Gate {
        protected override bool IsReady => wire.IsReady;

        private readonly Wire wire;
        private readonly int amount;

        public LShiftGate(Wire wire, int amount, Wire output) : base(output) {
            this.wire = wire;
            this.amount = amount;
        }

        protected override void Propogate() {
            output.Power((ushort)(wire.Charge << amount));
        }

        public override string ToString() => $"{wire} << {amount} => {output}";
    }

    private class RShiftGate : Gate {
        protected override bool IsReady => wire.IsReady;

        private readonly Wire wire;
        private readonly int amount;

        public RShiftGate(Wire wire, int amount, Wire output) : base(output) {
            this.wire = wire;
            this.amount = amount;
        }

        protected override void Propogate() {
            output.Power((ushort)(wire.Charge >> amount));
        }

        public override string ToString() => $"{wire} >> {amount} => {output}";
    }

    private class NotGate : Gate {
        protected override bool IsReady => wire.IsReady;

        private readonly Wire wire;

        public NotGate(Wire wire, Wire output) : base(output) {
            this.wire = wire;
        }

        protected override void Propogate() {
            output.Power((ushort)~wire.Charge);
        }

        public override string ToString() => $"NOT {wire} => {output}";
    }

    private class WireGate : Gate {
        protected override bool IsReady => wire.IsReady;

        private readonly Wire wire;

        public WireGate(Wire wire, Wire output) : base(output) {
            this.wire = wire;
        }

        protected override void Propogate() {
            output.Power(wire.Charge);
        }

        public override string ToString() => $"{wire} => {output}";
    }

    private class LoadGate : Gate {
        protected override bool IsReady => true;

        private readonly ushort amount;

        public LoadGate(ushort amount, Wire output) : base(output) {
            this.amount = amount;
        }

        protected override void Propogate() {
            output.Power(amount);
        }

        public override string ToString() => $"{amount} => {output}";
    }

    public Day7() : base(7, 2015, "Some Assembly Required") { }

    protected override object SolvePart1() {
        //Dictionary<string, ushort> values = new Dictionary<string, ushort>();
        //Dictionary<string, Func<ushort>> gates = new Dictionary<string, Func<ushort>>();

        //foreach (var line in Lines) {
        //    var command = line.Split(' ');
        //    string target = command[^1];

        //    if (command.Length == 3) {
        //        if (ushort.TryParse(command[0], out var value)) {
        //            gates[target] = () => value;
        //            values[target] = value;
        //        } else {
        //            gates[command[2]] = () => {
        //                if (!values.TryGetValue(target, out value)) {
        //                    value = gates[command[0]]();
        //                    values[target] = value;
        //                };
        //                return value;
        //            };
        //        }
        //    } else if (command.Length == 4) {
        //        gates[target] = () => {
        //            if(!values.TryGetValue(target, out var value)) {
        //                value = 
        //            }
        //        }
        //    }
        //}

        //return gates["a"]();
        return null!;
    }

    protected override object SolvePart2() {

        return null!;
    }
}
