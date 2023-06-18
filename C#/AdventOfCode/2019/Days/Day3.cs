using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace _2019.Days;

public class Day3 : AdventDay {
    public Day3() : base(3, 2019, "Crossed Wires") { }

    protected override object SolvePart1() {
        Dictionary<Point, int> positions = new Dictionary<Point, int>();

        Point currentPos = Point.Empty;

        foreach (var direction in Lines[0].Split(',')) {
            currentPos = direction[0] switch {
                'R' => AddLine(positions, currentPos, new Point(1, 0), 1, direction[1..].ToInt32(), collisionPos => { }),
                'L' => AddLine(positions, currentPos, new Point(-1, 0), 1, direction[1..].ToInt32(), collisionPos => { }),
                'U' => AddLine(positions, currentPos, new Point(0, 1), 1, direction[1..].ToInt32(), collisionPos => { }),
                'D' => AddLine(positions, currentPos, new Point(0, -1), 1, direction[1..].ToInt32(), collisionPos => { }),
                _ => throw new Exception(),
            };
        }

        currentPos = Point.Empty;

        HashSet<Point> collisionPositions = new HashSet<Point>();

        foreach (var direction in Lines[1].Split(',')) {
            currentPos = direction[0] switch {
                'R' => AddLine(positions, currentPos, new Point(1, 0), 2, direction[1..].ToInt32(), collisionPos => collisionPositions.Add(collisionPos)),
                'L' => AddLine(positions, currentPos, new Point(-1, 0), 2, direction[1..].ToInt32(), collisionPos => collisionPositions.Add(collisionPos)),
                'U' => AddLine(positions, currentPos, new Point(0, 1), 2, direction[1..].ToInt32(), collisionPos => collisionPositions.Add(collisionPos)),
                'D' => AddLine(positions, currentPos, new Point(0, -1), 2, direction[1..].ToInt32(), collisionPos => collisionPositions.Add(collisionPos)),
                _ => throw new Exception(),
            };
        }

        return collisionPositions.Aggregate(int.MaxValue, (accumulate, point) => int.Min(accumulate, point.ManhattenDistance(Point.Empty)));
    }

    protected override object SolvePart2() {
        Dictionary<Point, (int wireValue, int[] wireSteps)> positions = new();

        Point currentPos = Point.Empty;

        int wireStepCount = 0;

        foreach(var direction in Lines[0].Split(',')) {
            currentPos = direction[0] switch {
                'R' => AddLine(positions, currentPos, new Point(1, 0), 1, ref wireStepCount, direction[1..].ToInt32(), collisionPos => { }),
                'L' => AddLine(positions, currentPos, new Point(-1, 0), 1, ref wireStepCount, direction[1..].ToInt32(), collisionPos => { }),
                'U' => AddLine(positions, currentPos, new Point(0, 1), 1, ref wireStepCount, direction[1..].ToInt32(), collisionPos => { }),
                'D' => AddLine(positions, currentPos, new Point(0, -1), 1, ref wireStepCount, direction[1..].ToInt32(), collisionPos => { }),
                _ => throw new Exception(),
            };
        }

        currentPos = Point.Empty;
        wireStepCount = 0;

        HashSet<int[]> collisionWireSteps = new HashSet<int[]>();

        foreach (var direction in Lines[1].Split(',')) {
            currentPos = direction[0] switch {
                'R' => AddLine(positions, currentPos, new Point(1, 0), 2, ref wireStepCount, direction[1..].ToInt32(), collisionPos => collisionWireSteps.Add(collisionPos)),
                'L' => AddLine(positions, currentPos, new Point(-1, 0), 2, ref wireStepCount, direction[1..].ToInt32(), collisionPos => collisionWireSteps.Add(collisionPos)),
                'U' => AddLine(positions, currentPos, new Point(0, 1), 2, ref wireStepCount, direction[1..].ToInt32(), collisionPos => collisionWireSteps.Add(collisionPos)),
                'D' => AddLine(positions, currentPos, new Point(0, -1), 2, ref wireStepCount, direction[1..].ToInt32(), collisionPos => collisionWireSteps.Add(collisionPos)),
                _ => throw new Exception(),
            };
        }

        return collisionWireSteps.Aggregate(int.MaxValue, (accumulate, wireSteps) => int.Min(accumulate, wireSteps.Sum()));
    }

    private static Point AddLine(Dictionary<Point, int> positions, Point startPos, Point direction, int wireValue, int numSteps, Action<Point> onCollision) {
        for (int i = 0; i < numSteps; i++) {
            startPos = startPos.Add(direction);
            if (!positions.ContainsKey(startPos)) {
                positions[startPos] = wireValue;
            } else if (positions[startPos] != wireValue) {
                onCollision(startPos);
                positions[startPos] = wireValue;
            }
        }

        return startPos;
    }

    private static Point AddLine(Dictionary<Point, (int wireValue, int[] wireSteps)> positions, Point startPos, Point direction, int wireValue, ref int wireStepCount, int numSteps, Action<int[]> onCollision) {
        for (int i = 0; i < numSteps; i++) {
            wireStepCount++;
            startPos = startPos.Add(direction);
            if (!positions.ContainsKey(startPos)) {
                int[] wireSteps = new int[2] { 0, 0 };
                wireSteps[wireValue - 1] = wireStepCount;
                positions[startPos] = (wireValue, wireSteps);
            } else if (positions[startPos].wireValue != wireValue) {
                positions[startPos].wireSteps[wireValue - 1] = wireStepCount;
                onCollision(positions[startPos].wireSteps);
                positions[startPos] = (wireValue, positions[startPos].wireSteps);
            }
        }

        return startPos;
    }
}
