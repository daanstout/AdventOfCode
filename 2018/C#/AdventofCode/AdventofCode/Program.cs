using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AdventofCode {
    class Program {
        //const string path = @"C:\Users\Daan\Desktop\AdventOfCode\2018\Input\";
        const string path = @"C:\Users\daans\Desktop\AdventOfCode\2018\Input\";

        static void Main(string[] args) {
            Console.WriteLine("Advent of Code - Year 2018");

            //Day1_Question1();
            //Day1_Question2();
            //Day2_Question1();
            //Day2_Question2();
            //Day3_Question1();
            //Day3_Question2();
            //Day4();
            //Day5_Question1();
            //Day5_Question2();
            //Day6_Question1();
            //StolenDay6();
            //Day7_Question1();
            //Day8();
            //Day9(435, 71184);
            //Day9(435, 7118400);
            //Day11_Question1();
            StolenDay11();

            Console.WriteLine("Done! Press any key to shut down the window");

            Console.ReadKey();
        }

        private static void Day1_Question1() {
            Console.WriteLine("Day 1 - Question 1");

            string input = File.ReadAllText(path + "Advent of Code Calibration values.txt");

            string[] inputs = input.Split('\n');

            int frequency = 0;

            foreach (string s in inputs) {
                if (s[0] == '-')
                    frequency -= Convert.ToInt32(s.Substring(1));
                else if (s[0] == '+')
                    frequency += Convert.ToInt32(s.Substring(1));
            }

            Console.WriteLine($"Answer Q1.1: {+frequency}\n");
        }

        private static void Day1_Question2() {
            Console.WriteLine("Day 1 - Question 2");

            string input = File.ReadAllText(path + "Advent of Code Calibration values.txt");

            string[] inputs = input.Split('\n');

            List<int> frequencies = new List<int>();

            int frequency = 0;

            frequencies.Add(frequency);

            bool looking = true;

            while (looking) {
                foreach (string s in inputs) {
                    if (s[0] == '-')
                        frequency -= Convert.ToInt32(s.Substring(1));
                    else if (s[0] == '+')
                        frequency += Convert.ToInt32(s.Substring(1));

                    if (frequencies.Contains(frequency)) {
                        Console.WriteLine($"Answer Q1.2: Duplicate Frequency is: {frequency}\n");
                        looking = false;
                        break;
                    } else
                        frequencies.Add(frequency);
                }
            }
        }

        private static void Day2_Question1() {
            Console.WriteLine("Day 2 - Question 1");

            string input = File.ReadAllText(path + "Advent of Code Box Ids.txt");

            string[] inputs = input.Split('\n');

            List<char> containsOnce = new List<char>();
            List<char> containsTwice = new List<char>();
            List<char> containsThrice = new List<char>();

            int twice = 0;
            int thrice = 0;

            foreach (string s in inputs) {
                containsOnce = new List<char>();
                containsTwice = new List<char>();
                containsThrice = new List<char>();

                foreach (char c in s) {
                    if (c == '\\' || c == '\r')
                        continue;

                    if (containsOnce.Contains(c)) {
                        containsOnce.Remove(c);
                        containsTwice.Add(c);
                    } else if (containsTwice.Contains(c)) {
                        containsTwice.Remove(c);
                        containsThrice.Add(c);
                    } else if (containsThrice.Contains(c)) {
                        containsThrice.Remove(c);
                    } else {
                        containsOnce.Add(c);
                    }
                }

                twice += Math.Min(containsTwice.Count, 1);
                thrice += Math.Min(containsThrice.Count, 1);
            }

            Console.WriteLine($"Asnwer Q2.1: {twice * thrice}\n");
        }

        private static void Day2_Question2() {
            Console.WriteLine("Day 2 - Question 2");

            string input = File.ReadAllText(path + "Advent of Code Box Ids.txt");

            string[] inputs = input.Split('\n');

            for (int i = 0; i < inputs.Length; i++) {
                for (int j = i + 1; j < inputs.Length; j++) {
                    bool differFound = false;
                    bool overshot = false;
                    for (int k = 0; k < inputs[i].Length; k++) {
                        if (inputs[i][k] != inputs[j][k]) {
                            if (differFound) {
                                overshot = true;
                                break;
                            } else
                                differFound = true;
                        }
                    }

                    if (differFound && !overshot) {
                        Console.WriteLine($"Answer Q2.2: The strings are:\n{inputs[i]}\n{inputs[j]}\n");
                        return;
                    }
                }
            }
        }

        private static void Day3_Question1() {
            Console.WriteLine("Day 3 - Question 1:");

            string input = File.ReadAllText(path + "Advent of Code Surface.txt");

            string[] inputs = input.Split('\n');

            int[,] sheet = new int[1000, 1001];

            for (int i = 0; i < 1000; i++)
                for (int j = 0; j < 1001; j++)
                    sheet[i, j] = 0;

            int[] xVals = new int[1307];
            int[] yVals = new int[1307];
            int[] wVals = new int[1307];
            int[] hVals = new int[1307];

            foreach (string s in inputs) {
                string[] inputSplit = s.Split(' ');

                string[] XY = inputSplit[2].Substring(0, inputSplit[2].Length - 1).Split(',');
                string[] WH = inputSplit[3].Split('x');

                int x = Convert.ToInt32(XY[0]);
                int y = Convert.ToInt32(XY[1]);
                int w = Convert.ToInt32(WH[0]);
                int h = Convert.ToInt32(WH[1]);

                for (int i = x; i < x + w; i++)
                    for (int j = y; j < y + h; j++)
                        sheet[i, j]++;
            }

            int duplicateClaim = 0;

            for (int i = 0; i < 1000; i++)
                for (int j = 0; j < 1001; j++)
                    if (sheet[i, j] > 1)
                        duplicateClaim++;

            Console.WriteLine($"Answer Q3.1: {duplicateClaim}\n");
        }

        private static void Day3_Question2() {
            Console.WriteLine("Day 3 - Question 2:");

            string input = File.ReadAllText(path + "Advent of Code Surface.txt");

            string[] inputs = input.Split('\n');

            int[] xVals = new int[1307];
            int[] yVals = new int[1307];
            int[] wVals = new int[1307];
            int[] hVals = new int[1307];

            for (int i = 0; i < 1307; i++) {
                string[] inputSplit = inputs[i].Split(' ');

                string[] XY = inputSplit[2].Substring(0, inputSplit[2].Length - 1).Split(',');
                string[] WH = inputSplit[3].Split('x');

                xVals[i] = Convert.ToInt32(XY[0]);
                yVals[i] = Convert.ToInt32(XY[1]);
                wVals[i] = Convert.ToInt32(WH[0]);
                hVals[i] = Convert.ToInt32(WH[1]);
            }

            for (int i = 0; i < 1307; i++) {
                bool noMatch = true;
                for (int j = 0; j < 1307; j++) {
                    if (i == j)
                        continue;

                    Rectangle rectI = new Rectangle(xVals[i], yVals[i], wVals[i], hVals[i]);
                    Rectangle rectJ = new Rectangle(xVals[j], yVals[j], wVals[j], hVals[j]);

                    if (rectI.IntersectsWith(rectJ)) {
                        noMatch = false;
                        break;
                    }
                }

                if (noMatch) {
                    Console.WriteLine($"Answer Q3.2: {i + 1}\n");
                    return;
                }
            }
        }

        private static void Day4() {
            Console.WriteLine("Day 4 - Question 1:");

            string input = File.ReadAllText(path + "Advent of Code Guard Times.txt");

            string[] inputs = input.Split("\n");

            GuardDataTable table = new GuardDataTable();

            foreach (string s in inputs)
                table.AddData(new GuardData(s));

            List<GuardSchedule> schedule = new List<GuardSchedule>();

            int asleep = -1;

            foreach (GuardData data in table.data) {
                string[] text = data.text.Split(' ');

                if (text[0].Equals("Guard")) {
                    DateTime dt = data.dateTime;
                    if (dt.Hour == 23) {
                        dt = dt.AddHours(1);
                        dt = dt.AddMinutes(-dt.Minute);
                    }
                    schedule.Add(new GuardSchedule(Convert.ToInt32(text[1].Substring(1)), dt));
                } else if (text[0].Equals("falls")) {
                    asleep = data.dateTime.Minute;
                } else if (text[0].Equals("wakes")) {
                    schedule[schedule.Count - 1].SetAsleep(asleep, data.dateTime.Minute);
                    asleep = -1;
                }
            }

            List<GuardInfo> info = new List<GuardInfo>();

            foreach (GuardSchedule gs in schedule) {
                if (info.Count == 0) {
                    info.Add(new GuardInfo(gs.guardId));
                    info[0].AddInfo(gs);
                    continue;
                }

                bool added = false;

                for (int i = 0; i < info.Count; i++) {
                    if (info[i].guardId == gs.guardId) {
                        info[i].AddInfo(gs);
                        added = true;
                        break;
                    }
                }

                if (!added) {
                    info.Add(new GuardInfo(gs.guardId));
                    info[info.Count - 1].AddInfo(gs);
                }
            }

            int MostAsleep = info[0].guardId;
            int timeSlept = info[0].TimeSlept();

            for (int i = 1; i < info.Count; i++) {
                if (timeSlept < info[i].TimeSlept()) {
                    MostAsleep = info[i].guardId;
                    timeSlept = info[i].TimeSlept();
                }
            }

            foreach (GuardInfo gi in info) {
                if (gi.guardId == MostAsleep) {
                    Console.WriteLine($"Answer Q4.1: {gi.guardId} - {gi.MinuteAsleep()} --> {gi.guardId * gi.MinuteAsleep()}\n");
                }
            }

            Console.WriteLine("Day 4 - Question 2:");

            GuardInfo mostAsleep = info[0];

            int gId = info[0].guardId;
            int highestAsleep = info[0].MostAsleep();

            foreach (GuardInfo gi in info) {
                if (mostAsleep.minutesAsleep[mostAsleep.MostAsleep()] < gi.minutesAsleep[gi.MostAsleep()])
                    mostAsleep = gi;
            }

            Console.WriteLine($"Answer Q4.2: {mostAsleep.guardId * mostAsleep.MostAsleep()}\n");
        }

        private static void Day5_Question1() {
            Console.WriteLine("Day 5 - Question 1:");

            string input = File.ReadAllText($@"{path}Advent of Code Polymers.txt");

            Console.WriteLine($"Answer Q5.1: {ReactPolymer(input)}\n");
        }

        private static void Day5_Question2() {
            Console.WriteLine("Day 5 - Question 2:");

            string input = File.ReadAllText($@"{path}Advent of Code Polymers.txt");

            List<int> results = new List<int>();

            for (int i = 'a'; i <= 'z'; i++) {
                char remove = (char)i;

                string temp = string.Copy(input);

                temp = temp.Replace(remove.ToString(), "");
                temp = temp.Replace((remove.ToString().ToUpper()), "");

                results.Add(ReactPolymer(temp));
            }

            int lowest = 0;

            for (int i = 1; i < results.Count; i++)
                if (results[lowest] > results[i])
                    lowest = i;

            Console.WriteLine($"Answer Q5.2: Char {(char)('a' + lowest)} - Length: {results[lowest]}");
        }

        private static int ReactPolymer(string input) {
            int i = 0;

            while (i < input.Length - 1) {
                if (i < 0)
                    i = 0;

                char cur = input[i];
                char next = input[i + 1];

                if (cur.ToString().ToUpper().Equals(next.ToString().ToUpper())) {
                    if (cur != next) {
                        input = input.Remove(i, 2);
                        i -= 2;
                    }
                }

                i++;
            }

            return input.Length;
        }

        private static void Day6_Question1() {
            Console.WriteLine("Day 6 - Question 1:");

            string input = File.ReadAllText(@"C:\Users\daans\Desktop\Advant of Code Coordinates.txt");
            //string input = $"1, 1\n1, 6\n8, 3\n3, 4\n5, 5\n8, 9";

            string[] inputs = input.Split('\n');

            List<Point> points = new List<Point>();

            foreach (string s in inputs) {
                string[] coords = s.Split(',');

                points.Add(new Point(Convert.ToInt32(coords[0]), Convert.ToInt32(coords[1])));
            }

            int[] map = new int[160000];

            for (int i = 0; i < 160000; i++)
                map[i] = -1;

            for (int i = 0; i < 160000; i++) {
                bool isCoord = false;

                foreach (Point p in points) {
                    if (i == GetIndex(p)) {
                        isCoord = true;
                        break;
                    }
                }

                if (isCoord)
                    continue;

                foreach (Point p in points) {
                    if (map[i] == -1) {
                        map[i] = GetIndex(p);
                        map[GetIndex(p)]--;
                    }

                    if (GetManhattan(GetPoint(i), p) < GetManhattan(GetPoint(i), GetPoint(map[i]))) {
                        map[map[i]]++;
                        map[i] = GetIndex(p);
                        map[map[i]]--;
                        continue;
                    }
                }
            }

            for (int i = 0; i < 400; i++) {
                bool isCoord = false;

                foreach (Point p in points) {
                    if (i == GetIndex(p)) {
                        isCoord = true;
                        break;
                    }
                }

                if (isCoord)
                    continue;

                foreach (Point p in points) {
                    Point po = GetPoint(map[i]);

                    if (po.X == p.X && po.Y == p.Y) {
                        points.Remove(p);
                        break;
                    }
                }
            }

            for (int i = 0; i < 160000; i += 400) {
                bool isCoord = false;

                foreach (Point p in points) {
                    if (i == GetIndex(p)) {
                        isCoord = true;
                        break;
                    }
                }

                if (isCoord)
                    continue;

                foreach (Point p in points) {
                    Point po = GetPoint(map[i]);

                    if (po.X == p.X && po.Y == p.Y) {
                        points.Remove(p);
                        break;
                    }
                }
            }

            for (int i = 160000 - 400; i < 16000; i++) {
                bool isCoord = false;

                foreach (Point p in points) {
                    if (i == GetIndex(p)) {
                        isCoord = true;
                        break;
                    }
                }

                if (isCoord)
                    continue;

                foreach (Point p in points) {
                    Point po = GetPoint(map[i]);

                    if (po.X == p.X && po.Y == p.Y) {
                        points.Remove(p);
                        break;
                    }
                }
            }

            for (int i = 399; i < 160000; i += 400) {
                bool isCoord = false;

                foreach (Point p in points) {
                    if (i == GetIndex(p)) {
                        isCoord = true;
                        break;
                    }
                }

                if (isCoord)
                    continue;

                foreach (Point p in points) {
                    Point po = GetPoint(map[i]);

                    if (po.X == p.X && po.Y == p.Y) {
                        points.Remove(p);
                        break;
                    }
                }
            }

            Console.WriteLine(points.Count);

            int min = int.MaxValue;

            foreach (Point p in points) {
                if (map[GetIndex(p)] < min)
                    min = map[GetIndex(p)];

                Console.WriteLine(map[GetIndex(p)]);
            }

            Console.WriteLine(min);
        }

        private static void StolenDay6() {
            Console.WriteLine("Day 6 - Question 1:");

            string input = File.ReadAllText(@"C:\Users\daans\Desktop\Advant of Code Coordinates.txt");
            //string input = $"1, 1\n1, 6\n8, 3\n3, 4\n5, 5\n8, 9";

            string[] inputs = input.Split('\n');

            Dictionary<int, Point> points = new Dictionary<int, Point>();

            int maxX = 0;
            int maxY = 0;
            int count = 0;

            foreach (string s in inputs) {
                string[] st = s.Trim().Split(", ");
                int x = Convert.ToInt32(st[0]);
                int y = Convert.ToInt32(st[1]);
                points.Add(count, new Point(x, y));
                count++;
                if (x > maxX)
                    maxX = x;

                if (y > maxY)
                    maxY = y;
            }

            int[,] grid = new int[maxX + 1, maxY + 1];
            Dictionary<int, int> regions = new Dictionary<int, int>();

            for (int x = 0; x < maxX; x++) {
                for (int y = 0; y < maxY; y++) {
                    int best = maxX + maxY;
                    int bestNum = -1;

                    for (int i = 0; i < count; i++) {
                        Point p = points[i];

                        int dist = Math.Abs(x - p.X) + Math.Abs(y - p.Y);
                        if (dist < best) {
                            best = dist;
                            bestNum = i;
                        } else if (dist == best) {
                            bestNum = -1;
                        }
                    }

                    grid[x, y] = bestNum;
                    if (regions.ContainsKey(bestNum)) {
                        regions[bestNum] += 1;
                    } else {
                        regions.Add(bestNum, 1);
                    }
                }
            }

            for (int x = 0; x <= maxX; x++) {
                int bad = grid[x, 0];
                regions.Remove(bad);
                bad = grid[x, maxY];
                regions.Remove(bad);
            }

            for (int y = 0; y <= maxY; y++) {
                int bad = grid[0, y];
                regions.Remove(bad);
                bad = grid[maxX, y];
                regions.Remove(bad);
            }

            int biggest = 0;
            foreach (int size in regions.Values)
                if (size > biggest)
                    biggest = size;

            Console.WriteLine(biggest);

            int inarea = 0;

            for (int x = 0; x < maxX; x++) {
                for (int y = 0; y < maxY; y++) {
                    int size = 0;

                    for (int i = 0; i < count; i++) {
                        Point p = points[i];

                        int dist = Math.Abs(x - p.X) + Math.Abs(y - p.Y);
                        size += dist;
                    }

                    if (size < 10000) {
                        inarea++;
                    }
                }
            }

            Console.WriteLine(inarea);
        }

        private static int GetManhattan(Point a, Point b) {
            return Math.Abs(a.X - b.X) + Math.Abs(a.Y - b.Y);
        }

        private static int GetIndex(Point p) {
            return p.Y * 400 + p.X;
        }

        private static Point GetPoint(int i) {
            return new Point(i % 400, i / 400);
        }

        private static void Day7_Question1() {
            Console.WriteLine("Day 7 - Question 1:");

            //string input = File.ReadAllText(@"C:\Users\daans\Desktop\Advant of Code Assembly Instructions.txt");
            string input = $"Step C must be finished before step A can begin.\nStep C must be finished before step F can begin.\nStep A must be finished before step B can begin.\nStep A must be finished before step D can begin.\nStep B must be finished before step E can begin.\nStep D must be finished before step E can begin.\nStep F must be finished before step E can begin.";

            string[] inputs = input.Split('\n');

            Graph graph = new Graph();

            foreach (string s in inputs) {
                string[] txt = s.Split(' ');
                string v1 = txt[1];
                string v2 = txt[7];

                graph.AddEdge(v1, v2, 0);
            }

            //Console.WriteLine(graph.GetStart());
            //foreach (Vertex v in graph.GetStart())
            //    Console.WriteLine(v);

            foreach (Vertex v in graph.GetOrder())
                //Console.WriteLine(v)
                Console.Write(v.ToString()[0]);
            Console.WriteLine();

            int result = graph.Make();

            Console.WriteLine(result);

            //List<Vertex> v = graph.GetOrder();
            //for (int i = v.Count - 1; i >= 0; i--)
            //    Console.Write(v[i].ToString()[0]);


            //Console.WriteLine(graph);
        }

        private static void Day8() {
            Console.WriteLine("Day 8 - Question 1:");

            string input = File.ReadAllText(path + "Advent of Code License.txt");

            string[] inputs = input.Split(" ");

            int[] convertedInput = Array.ConvertAll(inputs, s => int.Parse(s));

            Tree tree = new Tree();

            tree.ProcessInput(convertedInput);


            Console.WriteLine($"Answer Q8.1: {tree.GetMeta()}\n");
            Console.WriteLine($"Day 8 - Question 2:\nAnswer Q8.2: {tree.GetRootMeta()}\n");
        }

        private static void Day9(int numPlayers, int numMarbles) {
            Console.WriteLine("Day 9");
            int currentMarbleIndex = 0;

            int[] scores = new int[numPlayers];

            for (int i = 0; i < numPlayers; i++)
                scores[i] = 0;

            List<int> circle = new List<int> {
                0
            };

            for (int i = 1; i <= numMarbles; i++) {
                if (i % 23 == 0) {
                    currentMarbleIndex = mod(currentMarbleIndex - 7, circle.Count);
                    scores[mod(i, numPlayers)] += i + circle[currentMarbleIndex];
                    circle.RemoveAt(currentMarbleIndex);
                } else {
                    int insertIndex = mod(currentMarbleIndex + 2, circle.Count);
                    if (insertIndex == 0) {
                        circle.Add(i);
                        currentMarbleIndex = circle.Count - 1;
                    } else {
                        circle.Insert(insertIndex, i);
                        currentMarbleIndex = insertIndex;
                    }
                }
            }

            int highest = 0;
            foreach (int i in scores)
                if (i > highest)
                    highest = i;

            Console.WriteLine($"Answer Q9: {highest}\n");
        }

        private static int mod(int x, int m) {
            int r = x % m;
            return r < 0 ? r + m : r;
        }

        private static void Day11_Question1() {
            Console.WriteLine("Day 11 - Question 1:");

            int input = 2568;
            //int input = 42;

            //Console.WriteLine(CalculateFuelCellPower(3, 5, 8));
            //Console.WriteLine(CalculateFuelCellPower(122, 79, 57));
            //Console.WriteLine(CalculateFuelCellPower(217, 196, 39));
            //Console.WriteLine(CalculateFuelCellPower(101, 153, 71));

            int[,] cells = new int[301, 301];

            for (int x = 1; x <= 300; x++) {
                for (int y = 1; y <= 300; y++) {
                    cells[x, y] = CalculateFuelCellPower(x, y, input);
                }
            }

            int heighest = int.MinValue;
            int xi = 0, yi = 0;

            for (int x = 1; x <= 298; x++) {
                for (int y = 1; y <= 298; y++) {
                    int total = 0;
                    for (int i = 0; i < 3; i++)
                        for (int j = 0; j < 3; j++)
                            total += cells[x + i, y + j];

                    if (total >= heighest) {
                        heighest = total;
                        xi = x;
                        yi = y;
                    }
                }
            }

            Console.WriteLine($"Answer Q11.1: {{{xi}, {yi}}} with level: {heighest}\n");

            Console.WriteLine("Day 11 - Question 2:");

            int si = 0;
            heighest = int.MinValue;

            for (int s = 1; s < 300; s++) {
                for (int x = 1; x <= 300 - s; x++) {
                    for (int y = 1; y <= 300 - s; y++) {
                        int total = 0;

                        for (int i = 0; i < s; i++)
                            for (int j = 0; j < s; j++)
                                total += cells[x + i, y + 1];

                        if (total > heighest) {
                            heighest = total;
                            xi = x;
                            yi = y;
                            si = s;
                        }
                    }
                }
            }

            Console.WriteLine($"Answer Q11.2: {{{xi}, {yi}, {si}}} with level: {heighest}\n");
        }

        private static void StolenDay11() {
            int[,] sum = new int[301, 301];
            int bx = 0, by = 0, bs = 0, best = int.MinValue;
            for (int y = 1; y <= 300; y++) {
                for (int x = 1; x <= 300; x++) {
                    int id = x + 10;
                    int p = id * y + 2568;
                    p = (p * id) / 100 % 10 - 5;
                    sum[y, x] = p + sum[y - 1, x] + sum[y, x - 1] - sum[y - 1, x - 1];
                }
            }

            for (int s = 1; s <= 300; s++) {
                for (int y = s; y <= 300; y++) {
                    for (int x = s; x <= 300; x++) {
                        int iy = y;
                        int ix = x;
                        int iys = y - s;
                        int ixs = x - s;
                        int total = sum[y, x] - sum[y - s, x] - sum[y, x - s] + sum[y - s, x - s];

                        if (total > best) {
                            best = total;
                            bx = x;
                            by = y;
                            bs = s;
                        }
                    }
                }
            }

            Console.WriteLine($"{bx - bs + 1},{by - bs + 1},{bs}");
        }

        private static int CalculateFuelCellPower(int x, int y, int gridSerial) {
            int rackId = x + 10;
            int powerLevel = rackId * y;
            powerLevel += gridSerial;
            powerLevel *= rackId;
            powerLevel = (powerLevel / 100) % 10;
            return powerLevel - 5;
        }
    }
}
