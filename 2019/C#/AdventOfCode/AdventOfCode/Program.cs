using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using DaanLib;
using DaanLib.Maths;
using MoreLinq;

namespace AdventOfCode {
    class Program {
        static void Main(string[] args) {
            string baseDir = @"D:\Github\AdventOfCode\2019\Input\Advent of Code Input Day ";

            //Day1(File.ReadAllText(baseDir + "1.txt"));
            //Day2(File.ReadAllText(baseDir + "2.txt"));
            //Day3(File.ReadAllText(baseDir + "3.txt"));
            //Day4(172930, 683082);
            //Day5(File.ReadAllText(baseDir + "5.txt"));
            Day6(File.ReadAllText(baseDir + "6.txt"));
        }

        static void Day1(string input) {
            string[] inputLines = input.Split("\r\n");

            int totalOldFuel = 0;
            int totalFuel = 0;

            foreach (string s in inputLines) {
                int mass = Convert.ToInt32(s);

                mass /= 3;

                mass -= 2;

                int moduleFuel = mass;

                while (moduleFuel > 0) {
                    moduleFuel /= 3;

                    moduleFuel -= 2;

                    if (moduleFuel > 0)
                        totalFuel += moduleFuel;
                }

                totalOldFuel += mass;
                totalFuel += mass;
            }

            Console.WriteLine("Day 1 - Part 1: " + totalOldFuel);

            Console.WriteLine("Day 1 - Part 2: " + totalFuel);
        }

        static void Day2(string input) {
            string[] inputLines = input.Split(',');

            List<int> intcode = new List<int>();

            foreach (string s in inputLines)
                intcode.Add(Convert.ToInt32(s));

            int[] mem = intcode.ToArray();

            {
                intcode[1] = 12;
                intcode[2] = 2;

                int programCounter = 0;
                int stepSize = 4;

                while (intcode[programCounter] != 99) {
                    switch (intcode[programCounter]) {
                        case 1:
                            intcode[intcode[programCounter + 3]] = intcode[intcode[programCounter + 1]] + intcode[intcode[programCounter + 2]];
                            break;
                        case 2:
                            intcode[intcode[programCounter + 3]] = intcode[intcode[programCounter + 1]] * intcode[intcode[programCounter + 2]];
                            break;
                        default:
                            Console.WriteLine($"Unknown opcode at position {programCounter}: {intcode[programCounter]}");
                            break;
                    }

                    programCounter += stepSize;
                }

                Console.WriteLine("Day 2 - Part 1: " + intcode[0]);
            }

            int numToCheck = 19690720;

            for (int x = 0; x < 100; x++) {
                for (int y = 0; y < 100; y++) {
                    intcode = mem.ToList();

                    intcode[1] = x;
                    intcode[2] = y;

                    int programCounter = 0;
                    int stepSize = 4;

                    while (intcode[programCounter] != 99) {
                        switch (intcode[programCounter]) {
                            case 1:
                                intcode[intcode[programCounter + 3]] = intcode[intcode[programCounter + 1]] + intcode[intcode[programCounter + 2]];
                                break;
                            case 2:
                                intcode[intcode[programCounter + 3]] = intcode[intcode[programCounter + 1]] * intcode[intcode[programCounter + 2]];
                                break;
                            default:
                                Console.WriteLine($"Unknown opcode at position {programCounter}: {intcode[programCounter]}");
                                break;
                        }

                        programCounter += stepSize;
                    }

                    if (intcode[0] == numToCheck) {
                        Console.WriteLine($"Day 2 - Part 2: " + (100 * x + y));
                    }
                }
            }
        }

        static void Day3(string input) {
            string[] inputLines = input.Split('\n');

            // Part 1
            {
                Dictionary<Vector2D, int> field = new Dictionary<Vector2D, int>();

                List<Vector2D> intersections = new List<Vector2D>();

                for (int i = 0; i < 2; i++) {
                    string[] directions = inputLines[i].Split(',');

                    Vector2D curPos = new Vector2D(0.0f, 0.0f);

                    foreach (string dir in directions) {
                        char d = dir[0];
                        int length = Convert.ToInt32(dir.Substring(1));

                        for (int j = 0; j < length; j++) {
                            curPos += d switch
                            {
                                'U' => new Vector2D(0.0f, 1.0f),
                                'R' => new Vector2D(1.0f, 0.0f),
                                'D' => new Vector2D(0.0f, -1.0f),
                                'L' => new Vector2D(-1.0f, 0.0f),
                                _ => new Vector2D(0.0f, 0.0f)
                            };

                            if (field.ContainsKey(curPos) && field[curPos] != i) {
                                if (!intersections.Contains(curPos))
                                    intersections.Add(curPos);
                            } else if (!field.ContainsKey(curPos))
                                field.Add(curPos, i);
                        }
                    }
                }

                if (intersections.Count > 0) {
                    Vector2D closest = intersections[0];

                    for (int i = 1; i < intersections.Count; i++) {
                        if (intersections[i].GetManhattan(Vector2D.Zero) < closest.GetManhattan(Vector2D.Zero))
                            closest = intersections[i];
                    }

                    Console.WriteLine("Day 3 - Part 1: " + closest.GetManhattan(Vector2D.Zero));
                }
            }

            // Part 2
            {
                Dictionary<Vector2D, Pair<int, int>> field = new Dictionary<Vector2D, Pair<int, int>>();

                List<Pair<Vector2D, int>> intersections = new List<Pair<Vector2D, int>>();

                for (int i = 0; i < 2; i++) {
                    string[] directions = inputLines[i].Split(',');

                    Vector2D curPos = new Vector2D(0.0f, 0.0f);

                    int traveled = 0;

                    foreach (string dir in directions) {
                        char d = dir[0];
                        int length = Convert.ToInt32(dir.Substring(1));

                        for (int j = 0; j < length; j++) {
                            traveled++;

                            curPos += d switch
                            {
                                'U' => new Vector2D(0.0f, 1.0f),
                                'R' => new Vector2D(1.0f, 0.0f),
                                'D' => new Vector2D(0.0f, -1.0f),
                                'L' => new Vector2D(-1.0f, 0.0f),
                                _ => new Vector2D(0.0f, 0.0f)
                            };

                            if (field.ContainsKey(curPos) && field[curPos].first != i) {
                                if (intersections.All(value => value.first != curPos))
                                    intersections.Add(new Pair<Vector2D, int>(curPos, traveled + field[curPos].second));
                            } else if (!field.ContainsKey(curPos))
                                field.Add(curPos, new Pair<int, int>(i, traveled));
                        }
                    }
                }

                if (intersections.Count > 0) {
                    int closest = intersections[0].second;

                    for (int i = 1; i < intersections.Count; i++) {
                        if (intersections[i].second < closest)
                            closest = intersections[i].second;
                    }

                    Console.WriteLine("Day 3 - Part 2: " + closest);
                }
            }
        }

        static int HandleIntCode(int[] intcode) {
            int programCounter = 0;

            while (intcode[programCounter] != 99) {
                int code = intcode[programCounter];

                int opcode = code % 100;
                int par1Mode = (code / 100) % 10;
                int par2Mode = (code / 1000) % 10;
                int par3Mode = (code / 10000) % 10;
                int value1;
                int value2;
                switch (opcode) {
                    case 1:
                        value1 = par1Mode == 0 ? intcode[intcode[programCounter + 1]] : (par1Mode == 1 ? intcode[programCounter + 1] : 0);
                        value2 = par2Mode == 0 ? intcode[intcode[programCounter + 2]] : (par2Mode == 1 ? intcode[programCounter + 2] : 0);
                        intcode[intcode[programCounter + 3]] = value1 + value2;
                        programCounter += 4;
                        break;
                    case 2:
                        value1 = par1Mode == 0 ? intcode[intcode[programCounter + 1]] : (par1Mode == 1 ? intcode[programCounter + 1] : 0);
                        value2 = par2Mode == 0 ? intcode[intcode[programCounter + 2]] : (par2Mode == 1 ? intcode[programCounter + 2] : 0);
                        intcode[intcode[programCounter + 3]] = value1 * value2;
                        programCounter += 4;
                        break;
                    case 3:
                        Console.WriteLine("Please enter a digit");
                        int value = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine();
                        intcode[intcode[programCounter + 1]] = value;
                        programCounter += 2;
                        break;
                    case 4:
                        value1 = par1Mode == 0 ? intcode[intcode[programCounter + 1]] : (par1Mode == 1 ? intcode[programCounter + 1] : 0);
                        Console.WriteLine(value1);
                        programCounter += 2;
                        break;
                    case 5:
                        value1 = par1Mode == 0 ? intcode[intcode[programCounter + 1]] : (par1Mode == 1 ? intcode[programCounter + 1] : 0);
                        value2 = par2Mode == 0 ? intcode[intcode[programCounter + 2]] : (par2Mode == 1 ? intcode[programCounter + 2] : 0);
                        if (value1 != 0)
                            programCounter = value2;
                        else
                            programCounter += 3;
                        break;
                    case 6:
                        value1 = par1Mode == 0 ? intcode[intcode[programCounter + 1]] : (par1Mode == 1 ? intcode[programCounter + 1] : 0);
                        value2 = par2Mode == 0 ? intcode[intcode[programCounter + 2]] : (par2Mode == 1 ? intcode[programCounter + 2] : 0);
                        if (value1 == 0)
                            programCounter = value2;
                        else
                            programCounter += 3;
                        break;
                    case 7:
                        value1 = par1Mode == 0 ? intcode[intcode[programCounter + 1]] : (par1Mode == 1 ? intcode[programCounter + 1] : 0);
                        value2 = par2Mode == 0 ? intcode[intcode[programCounter + 2]] : (par2Mode == 1 ? intcode[programCounter + 2] : 0);
                        intcode[intcode[programCounter + 3]] = value1 < value2 ? 1 : 0;
                        programCounter += 4;
                        break;
                    case 8:
                        value1 = par1Mode == 0 ? intcode[intcode[programCounter + 1]] : (par1Mode == 1 ? intcode[programCounter + 1] : 0);
                        value2 = par2Mode == 0 ? intcode[intcode[programCounter + 2]] : (par2Mode == 1 ? intcode[programCounter + 2] : 0);
                        intcode[intcode[programCounter + 3]] = value1 == value2 ? 1 : 0;
                        programCounter += 4;
                        break;
                    default:
                        Console.WriteLine($"Unknown opcode at position {programCounter}: {intcode[programCounter]}");
                        break;
                }
            }

            return intcode[0];
        }

        static void Day4(int lower, int higher) {
            {
                int found = 0;

                for (int i = lower; i < higher; i++) {
                    int[] digits = new int[] {
                    (i / 100000) % 10,
                    (i / 10000) % 10,
                    (i / 1000) % 10,
                    (i / 100) % 10,
                    (i / 10) % 10,
                    i % 10
                };

                    bool lowers = false;
                    bool hasDouble = false;

                    for (int j = 0; j < 5; j++)
                        if (digits[j] > digits[j + 1])
                            lowers = true;
                        else if (digits[j] == digits[j + 1])
                            hasDouble = true;

                    if (!lowers && hasDouble)
                        found++;
                }

                Console.WriteLine("Day 4 - Part 1: " + found);
            }

            var PartB = Enumerable.Range(lower, higher - lower + 1)
                .Where(i => i.ToString().Window(2).All(x => x[0] <= x[1]))
                .Where(i => i.ToString().GroupAdjacent(c => c).Any(g => g.Count() == 2))
                .Count()
                .ToString();

            Console.WriteLine("Day 4 - Part 2: " + PartB);
            //{
            //    int found = 0;

            //    for (int i = lower; i < higher; i++) {
            //        int[] digits = new int[] {
            //        (i / 100000) % 10,
            //        (i / 10000) % 10,
            //        (i / 1000) % 10,
            //        (i / 100) % 10,
            //        (i / 10) % 10,
            //        i % 10
            //    };

            //        bool lowers = false;
            //        bool hasDouble = false;

            //        for (int j = 0; j < 5; j++) {
            //            if (digits[j] > digits[j + 1])
            //                lowers = true;
            //        }

            //        if (lowers)
            //            continue;

            //        for(int j = 0; j < 5; j++) {
            //            if(digits[j] == digits[j + 1]) {
            //                if (j > 0 && digits[j] == digits[j - 1]) {

            //                } else if (j < 4 && digits[j] == digits[j + 1]) {

            //                } else {
            //                    hasDouble = true;
            //                }
            //            }
            //        }

            //        if (hasDouble)
            //            found++;

            //        Console.WriteLine("Day 4 - Part 2: " + found);
            //    }
        }

        static void Day5(string input) {
            string[] inputLines = input.Split(',');

            List<int> intcode = new List<int>();

            foreach (string s in inputLines)
                intcode.Add(Convert.ToInt32(s));

            Console.WriteLine("For the answer to day 1, give it '1', for the answer to day 2, give it '5'");

            int answer = HandleIntCode(intcode.ToArray());
        }

        static void Day6(string input) {
            //OrbitTree tree = new OrbitTree($"COM)B\r\n" +
            //    $"B)C\r\n" +
            //    $"C)D\r\n" +
            //    $"D)E\r\n" +
            //    $"E)F\r\n" +
            //    $"B)G\r\n" +
            //    $"G)H\r\n" +
            //    $"D)I\r\n" +
            //    $"E)J\r\n" +
            //    $"J)K\r\n" +
            //    $"K)L\r\n" +
            //    $"K)YOU\r\n" +
            //    $"I)SAN");

            OrbitTree tree = new OrbitTree(input);

            Console.WriteLine("Day 6 - Part 1: " + tree.GetTotalOrbits());
            Console.WriteLine("Day 6 - Part 2: " + tree.GetMinimumJumps());
        }
    }

    class OrbitTree {
        readonly Dictionary<string, List<string>> tree = new Dictionary<string,  List<string>>();

        string youOrbit;
        string sanOrbit;

        public OrbitTree(string input) {
            string[] inputLines = input.Split("\r\n");

            foreach (string line in inputLines) {
                string[] orbits = line.Split(')');

                if (tree.ContainsKey(orbits[0])) {
                    tree[orbits[0]].Add(orbits[1]);
                } else {
                    tree.Add(orbits[0],new List<string>() { orbits[1] });
                }

                if (orbits[1] == "SAN")
                    sanOrbit = orbits[0];
                else if (orbits[1] == "YOU")
                    youOrbit = orbits[0];
            }
        }

        public int GetTotalOrbits() {
            int orbits = 0;

            Queue<string> q = new Queue<string>();

            q.Enqueue("COM");

            while (q.Count > 0) {
                string current = q.Dequeue();

                if (!tree.ContainsKey(current))
                    continue;

                orbits += GetChildren(current);

                List<string> orbit = tree[current];

                foreach (string s in orbit)
                    q.Enqueue(s);
            }

            return orbits;
        }

        public int GetChildren(string orbit) {
            int children = 0;

            Queue<string> q = new Queue<string>();

            q.Enqueue(orbit);

            while (q.Count > 0) {
                string current = q.Dequeue();

                if (!tree.ContainsKey(current))
                    continue;

                List<string> orbits = tree[current];

                children += orbits.Count;

                foreach (string s in orbits)
                    q.Enqueue(s);
            }

            return children;
        }

        private string GetParent(string orbit) {
            string current = "COM";

            while (!tree[current].Contains(orbit)) {
                foreach(string s in tree[current]) {
                    bool ho = HasOrbit(s, orbit);
                    if(HasOrbit(s, orbit)) {
                        current = s;
                        break;
                    }
                }
            }

            return current;
        }

        public int GetMinimumJumps() {
            int jumps = 0;

            string current = youOrbit;
            string target = sanOrbit;

            while(!HasOrbit(current, target)) {
                jumps++;
                current = GetParent(current);
            }

            List<string> currentOrbits = tree[current];

            while (!currentOrbits.Contains(target)) {
                jumps++;
                foreach(string s in currentOrbits) {
                    if (HasOrbit(s, target)) {
                        currentOrbits = tree[s];
                        break;
                    }
                }
            }

            return jumps + 1;
        }

        private bool HasOrbit(string orbit, string target) {
            Queue<string> q = new Queue<string>();

            q.Enqueue(orbit);

            while(q.Count > 0) {
                string current = q.Dequeue();

                if (!tree.ContainsKey(current))
                    continue;

                List<string> orbits = tree[current];

                if (orbits.Contains(target))
                    return true;

                foreach (string s in orbits)
                    q.Enqueue(s);
            }

            return false;
        }
    }
}

