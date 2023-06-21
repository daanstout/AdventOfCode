using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2019.Days;

public class Day6 : AdventDay<Dictionary<string, Day6.Node>> {
    public class Node : IEquatable<Node?> {
        public Node? Parent { get; set; } = null;

        public string Name { get; init; } = string.Empty;

        public List<Node> Children { get; } = new List<Node>();

        public int Depth => Parent?.Depth + 1 ?? 0;

        public override string ToString() => $"{Name} - {Depth}";

        public override bool Equals(object? obj) => Equals(obj as Node);
        public bool Equals(Node? other) => other is not null && Name == other.Name;
        public override int GetHashCode() => HashCode.Combine(Name);

        public static bool operator ==(Node? left, Node? right) => EqualityComparer<Node>.Default.Equals(left, right);
        public static bool operator !=(Node? left, Node? right) => !(left == right);
    }

    public Day6() : base(6, 2019, "Universal Orbit Map") { }

    protected override object SolvePart1(out Dictionary<string, Node> state) {
        state = new Dictionary<string, Node>();

        foreach (var line in Lines) {
            var objects = line.Split(')');
            var parent = state.GetOrCreate(objects[0], () => new Node { Name = objects[0] });
            var child = state.GetOrCreate(objects[1], () => new Node { Name = objects[1] });
            parent.Children.Add(child);
            child.Parent = parent;
        }

        return state.Values.Sum(node => node.Depth);
    }

    protected override object SolvePart2(Dictionary<string, Node> state) {
        HashSet<Node> nodes = new HashSet<Node>();

        Node? current = state["YOU"];

        do {
            nodes.Add(current);
            current = current.Parent;
        } while (current != null);

        current = state["SAN"];

        do {
            if (!nodes.Add(current)) {
                break;
            }
            current = current.Parent;
        } while (current != null);

        return state["YOU"].Depth + state["SAN"].Depth - 2 * current!.Depth - 2;
    }
}