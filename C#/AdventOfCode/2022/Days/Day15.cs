using System.Data;
using System.Drawing;
using System.Numerics;

using AdventOfCode;

namespace _2022.Days;

public class Day15 : AdventDay {
    private class Sensor {
        public int MinX => (int)Math.Min(Position.X, ClosestBeacon.X);
        public int MaxX => (int)Math.Max(Position.X, ClosestBeacon.X);

        public int DeltaX => Position.X > ClosestBeacon.X ? Position.X - ClosestBeacon.X : ClosestBeacon.X - Position.X;
        public int DeltaY => Position.Y > ClosestBeacon.Y ? Position.Y - ClosestBeacon.Y : ClosestBeacon.Y - Position.Y;

        public int Radius => DeltaX + DeltaY;

        public Point Position { get; init; }
        public Point ClosestBeacon { get; init; }

        public static Sensor FromLine(string line) {
            var parts = line.Split(" ");
            Sensor sensor = new Sensor {
                Position = new Point {
                    X = parts[2][2..^1].ToInt32(),
                    Y = parts[3][2..^1].ToInt32()
                },
                ClosestBeacon = new Point {
                    X = parts[^2][2..^1].ToInt32(),
                    Y = parts[^1][2..].ToInt32()
                }
            };

            return sensor;
        }

        public bool IsCloserThanBeacon(Point location) {
            if (location.X == ClosestBeacon.X && location.Y == ClosestBeacon.Y)
                return true;

            return Position.ManhattenDistance(ClosestBeacon) >= Position.ManhattenDistance(location);
        }
    }

    private int YPos => UseTest ? 10 : 2000000;
    private int MaxSize => UseTest ? 20 : 4000000;

    public Day15() : base(15, 2022, "Beacon Exclusion Zone") { }

    protected override object SolvePart1() {
        List<Sensor> sensors = Lines.Select(Sensor.FromLine).ToList();

        //var minX = sensors.Min(sensor => sensor.MinX) * 2;
        //var maxX = sensors.Max(sensor => sensor.MaxX) * 2;

        //int cannotContainBeacon = 0;

        //for (var x = minX; x < maxX; x++) {
        //    Point current = new Point(x, YPos);
        //    for (int i = 0; i < sensors.Count; i++) {
        //        //if (i == 8)
        //        //    System.Diagnostics.Debugger.Break();
        //        if (sensors[i].IsCloserThanBeacon(current)) {
        //            cannotContainBeacon++;
        //            break;
        //        }
        //    }
        //}

        //return cannotContainBeacon;

        var signals = new HashSet<Point>();
        foreach (var sensor in sensors) {
            var radius = sensor.Radius;

            if (YPos > radius + sensor.Position.Y
                && YPos < sensor.Position.Y - radius)
                continue;

            var rowDistance = YPos > sensor.Position.Y ? (sensor.Position.Y + radius) - YPos : YPos - (sensor.Position.Y - radius);

            for (var x = sensor.Position.X - rowDistance; x < sensor.Position.X + rowDistance; x++)
                signals.Add(new Point(x, YPos));
        }

        return signals.Count;
    }

    protected override object SolvePart2() {
        var sensors = Lines.Select(Sensor.FromLine).ToList();

        for (int sensorIndex = 0; sensorIndex < sensors.Count; sensorIndex++) {
            var sensor = sensors[sensorIndex];
            var radius1 = sensor.Radius + 1;

            int x = sensor.Position.X;
            int y = sensor.Position.Y - radius1;

            int deltaX = 1;
            int deltaY = 1;

            for(int i = 0; i < 4; i++) {
                for(int j = 0; j < radius1; j++) {
                    if (x < 0 || x > MaxSize || y < 0 || y > MaxSize)
                        continue;

                    bool valid = true;
                    Point currentPoint = new Point(x, y);
                    for(int sensorIndex2 = 0; sensorIndex2 < sensors.Count; sensorIndex2++) {
                        if (sensorIndex == sensorIndex2)
                            continue;

                        var otherSensor = sensors[sensorIndex2];

                        valid &= !otherSensor.IsCloserThanBeacon(currentPoint);

                        if (!valid)
                            break;
                    }

                    if (valid) {
                        return (long)x * (long)4000000 + (long)y;
                    }

                    x += deltaX;
                    y += deltaY;
                }

                (deltaX, deltaY) = i switch {
                    0 => (-1, 1),
                    1 => (-1, -1),
                    2 => (1, -1),
                    3 => (1, 1),
                    _ => (1, 1)
                };
            }
        }

        return -1;
    }
}
