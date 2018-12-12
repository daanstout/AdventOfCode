using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace AdventOfCode {
    class Program {
        //const string path = @"C:\Users\Daan\Desktop\AdventOfCode\2015\Input\";
        const string path = @"C:\Users\daans\Desktop\AdventOfCode\2015\Input\";

        static void Main(string[] args) {
            Console.WriteLine("Advent of Code - Year 2015");

            //Day1_Question1();
            //Day1_Question2();
            //Day2_Question1();
            //Day2_Question2();
            //Day3();
            //Day4();
            //Day5();
            Day6();

            Console.WriteLine("Done! Press a key to end the console.");

            Console.ReadKey();
        }

        private static void Day1_Question1() {
            Console.WriteLine("Day 1 - Question 1:");

            string input = File.ReadAllText($"{path}Advent of Code - Day 1 - Floors.txt");

            int floor = 0;

            foreach (char c in input)
                floor += c == '(' ? 1 : -1;

            Console.WriteLine($"Answer Q1.1: {floor}\n");
        }

        private static void Day1_Question2() {
            Console.WriteLine("Day 1 - Question 2:");

            string input = File.ReadAllText($"{path}Advent of Code - Day 1 - Floors.txt");

            int floor = 0;

            for (int i = 0; i < input.Length; i++) {
                floor += input[i] == '(' ? 1 : -1;

                if (floor == -1) {
                    Console.WriteLine($"Answer Q1.2: {i + 1}\n");
                    break;
                }
            }
        }

        private static void Day2_Question1() {
            Console.WriteLine("Day 2 - Question 1:");

            int Area(int l, int w, int h) => (2 * l * w) + (2 * l * h) + (2 * w * h);

            string input = File.ReadAllText($"{path}Advent of Code - Day 2 -Box Dimensions.txt");

            string[] inputs = input.Split('\n');

            int totalArea = 0;

            foreach (string s in inputs) {
                int l, w, h;
                string[] sizes = s.Trim().Split('x');
                l = Convert.ToInt32(sizes[0]);
                w = Convert.ToInt32(sizes[1]);
                h = Convert.ToInt32(sizes[2]);

                totalArea += Area(l, w, h);

                if (l * w < l * h && l * w < w * h)
                    totalArea += (l * w);
                else if (l * h < w * h)
                    totalArea += (l * h);
                else
                    totalArea += (w * h);
            }

            Console.WriteLine($"Answer Q2.1: {totalArea}\n");
        }

        private static void Day2_Question2() {
            Console.WriteLine("Day 2 - Question 2:");

            string input = File.ReadAllText($"{path}Advent of Code - Day 2 -Box Dimensions.txt");

            string[] inputs = input.Split('\n');

            int ribbonLength = 0;

            foreach (string s in inputs) {
                int l, w, h;
                string[] sizes = s.Trim().Split('x');
                l = Convert.ToInt32(sizes[0]);
                w = Convert.ToInt32(sizes[1]);
                h = Convert.ToInt32(sizes[2]);

                if (l > w && l > h)
                    ribbonLength += (2 * w) + (2 * h);
                else if (w > h)
                    ribbonLength += (2 * l) + (2 * h);
                else
                    ribbonLength += (2 * l) + (2 * w);

                ribbonLength += (l * w * h);
            }

            Console.WriteLine($"Answer Q2.2: {ribbonLength}\n");
        }

        private static void Day3() {
            string input = File.ReadAllText($"{path}Advent of Code - Day 3 - Directions.txt");

            {
                Console.WriteLine("Day 3 - Question 1:");

                Dictionary<Point, int> map = new Dictionary<Point, int>();

                int x = 0, y = 0;
                map.Add(new Point(x, y), 1);

                foreach (char c in input) {
                    switch (c) {
                        case '^':
                            y += 1;
                            break;
                        case '>':
                            x += 1;
                            break;
                        case 'v':
                            y -= 1;
                            break;
                        case '<':
                            x -= 1;
                            break;
                    }

                    if (map.ContainsKey(new Point(x, y)))
                        map[new Point(x, y)] += 1;
                    else
                        map.Add(new Point(x, y), 1);
                }

                Console.WriteLine($"Answer Q3.1: {map.Values.Count}\n");
            }
            {
                Console.WriteLine("Day 3 - Question 2:");

                Dictionary<Point, int> map = new Dictionary<Point, int>();

                int santaX = 0, santaY = 0;
                int robotX = 0, robotY = 0;

                map.Add(new Point(santaX, santaY), 1);

                bool santa = true;

                foreach (char c in input) {
                    switch (c) {
                        case '^':
                            if (santa)
                                santaY += 1;
                            else
                                robotY += 1;
                            break;
                        case '>':
                            if (santa)
                                santaX += 1;
                            else
                                robotX += 1;
                            break;
                        case 'v':
                            if (santa)
                                santaY -= 1;
                            else
                                robotY -= 1;
                            break;
                        case '<':
                            if (santa)
                                santaX -= 1;
                            else
                                robotX -= 1;
                            break;
                    }

                    Point house;

                    if (santa)
                        house = new Point(santaX, santaY);
                    else
                        house = new Point(robotX, robotY);

                    if (map.ContainsKey(house))
                        map[house] += 1;
                    else
                        map.Add(house, 1);

                    santa = !santa;
                }

                Console.WriteLine($"Answer Q3.2: {map.Values.Count}\n");
            }
        }

        private static void Day4() {
            string input = "yzbqklnj";

            using (MD5 hash = MD5.Create()) {
                Console.WriteLine("Day 4 - Question 1:");

                int i = 1;
                while (true) {
                    string hashed = GetMD5Hash(hash, input + i);

                    if (hashed.Substring(0, 5).Equals("00000")) {
                        Console.WriteLine($"Answer Q4.1: {i}\n");
                        break;
                    }

                    i++;
                }
            }

            using (MD5 hash = MD5.Create()) {
                Console.WriteLine("Day 4 - Question 2:");

                int i = 1;
                while (true) {
                    string hashed = GetMD5Hash(hash, input + i);

                    if (hashed.Substring(0, 6).Equals("000000")) {
                        Console.WriteLine($"Answer Q4.2: {i}\n");
                        break;
                    }

                    i++;
                }
            }
        }

        private static string GetMD5Hash(MD5 hash, string input) {
            byte[] data = hash.ComputeHash(Encoding.UTF8.GetBytes(input));
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
                sb.Append(data[i].ToString("x2"));
            return sb.ToString();
        }

        private static void Day5() {
            Console.WriteLine("Day 5 - Question 1:");

            string input = File.ReadAllText($"{path}Advent of Code - Day 5 - Nice or Naughty.txt");

            string[] inputs = input.Split('\n');

            {
                char[] vowels = new char[5] { 'a', 'e', 'i', 'o', 'u' };
                string[] naughtyStrings = new string[4] { "ab", "cd", "pq", "xy" };

                List<string> nice = new List<string>();
                List<string> naughty = new List<string>();

                foreach (string s in inputs) {
                    bool isNaughty = false;

                    foreach (string n in naughtyStrings)
                        if (s.Contains(n))
                            isNaughty = true;

                    if (isNaughty) {
                        naughty.Add(s);
                        continue;
                    }

                    int numVowels = 0;
                    bool hasDouble = false;
                    for (int i = 0; i < s.Length; i++) {
                        if (vowels.Contains(s[i]))
                            numVowels++;

                        if (i < s.Length - 1)
                            if (s[i] == s[i + 1])
                                hasDouble = true;

                    }

                    if (numVowels >= 3 && hasDouble)
                        nice.Add(s);
                    else
                        naughty.Add(s);
                }

                Console.WriteLine($"Answer Q5.1: {nice.Count}\n");
            }
            {
                Console.WriteLine("Day 5 - Question 2:");

                List<string> nice = new List<string>();
                List<string> naughty = new List<string>();

                foreach (string s in inputs) {
                    bool hasRepeat = false;
                    bool hasDouble = false;
                    for (int i = 0; i < s.Length - 3; i++) {
                        if (s[i] == s[i + 2])
                            hasDouble = true;

                        if (s.Length - s.Replace(s.Substring(i, 2), "").Length >= 4)
                            hasRepeat = true;
                    }

                    if (hasRepeat && hasDouble)
                        nice.Add(s);
                    else
                        naughty.Add(s);
                }

                Console.WriteLine($"Answer Q5.2: {nice.Count}\n");
            }
        }

        private static void Day6() {
            Console.WriteLine("Day 6 - Question 1:");

            string input = File.ReadAllText($"{path}Advent of Code - Day 6 - Lights.txt");

            string[] inputs = input.Split('\n');

            {
                bool[,] grid = new bool[1000, 1000];

                foreach (string s in inputs) {
                    string[] split = s.Split(' ');
                    string[] start;
                    string[] end;
                    Point startP;
                    Point endP;
                    switch (split[0]) {
                        case "toggle":
                            start = split[1].Split(',');
                            end = split[3].Split(',');
                            startP = new Point(Convert.ToInt32(start[0]), Convert.ToInt32(start[1]));
                            endP = new Point(Convert.ToInt32(end[0]), Convert.ToInt32(end[1]));

                            for (int x = startP.X; x <= endP.X; x++) {
                                for (int y = startP.Y; y <= endP.Y; y++) {
                                    grid[x, y] = !grid[x, y];
                                }
                            }
                            break;
                        case "turn":
                            start = split[2].Split(',');
                            end = split[4].Split(',');
                            startP = new Point(Convert.ToInt32(start[0]), Convert.ToInt32(start[1]));
                            endP = new Point(Convert.ToInt32(end[0]), Convert.ToInt32(end[1]));

                            for (int x = startP.X; x <= endP.X; x++) {
                                for (int y = startP.Y; y <= endP.Y; y++) {
                                    grid[x, y] = split[1].Equals("on");
                                }
                            }
                            break;
                    }
                }

                int count = 0;

                foreach (bool b in grid)
                    if (b)
                        count++;

                Console.WriteLine($"Answer Q6.1: {count}\n");
            }
        }
    }
}
