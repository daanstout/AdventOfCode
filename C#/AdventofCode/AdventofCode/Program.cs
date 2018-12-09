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
        static readonly string path = @"C:\Users\Daan\Desktop\AdventOfCode\Input\";

        static void Main(string[] args) {
            //Day1_Question1();
            //Day1_Question2();
            //Day2_Question1();
            //Day2_Question2();
            //Day3_Question1();
            //Day3_Question2();
            //Day4_Question1();
            //Day5_Question1();
            Day6_Question1(435, 71184);
            Day6_Question1(435, 7118400);

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

                if (noMatch)
                    Console.WriteLine($"Answer Q3.2: {i + 1}\n");
            }
        }

        private static void Day4_Question1() {
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
                    Console.WriteLine($"Answer Day 4 - Question 1: {gi.guardId} - {gi.MinuteAsleep()} --> {gi.guardId * gi.MinuteAsleep()}");
                }
            }

            GuardInfo mostAsleep = info[0];

            int gId = info[0].guardId;
            int highestAsleep = info[0].MostAsleep();

            foreach (GuardInfo gi in info) {
                if (mostAsleep.minutesAsleep[mostAsleep.MostAsleep()] < gi.minutesAsleep[gi.MostAsleep()])
                    mostAsleep = gi;
            }

            Console.WriteLine(mostAsleep.guardId * mostAsleep.MostAsleep());
        }

        private static void Day5_Question1() {
            Console.WriteLine("Day 5 - Question 1:");

            string input = File.ReadAllText(path + "Advent of Code License.txt");
            //string input = "2 3 0 3 10 11 12 1 1 0 1 99 2 1 1 2";
            //string input = "2 3 0 3 10 11 12 0 1 2 1 1 2";

            string[] inputs = input.Split(" ");

            int[] convertedInput = Array.ConvertAll(inputs, s => int.Parse(s));

            Tree tree = new Tree();

            tree.ProcessInput(convertedInput);

            Console.WriteLine(tree.GetMeta());
            Console.WriteLine(tree.GetRootMeta());
        }

        private static void Day6_Question1(int numPlayers, int numMarbles) {
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

                //Console.WriteLine(i);
            }

            int highest = 0;
            foreach (int i in scores)
                if (i > highest)
                    highest = i;

            Console.WriteLine(highest);
        }

        private static int mod(int x, int m) {
            int r = x % m;
            return r < 0 ? r + m : r;
        }
    }
}
