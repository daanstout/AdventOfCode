using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
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
            Day4();

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

            string input = File.ReadAllText($"{path}Advent of Code Box Dimensions.txt");

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

            string input = File.ReadAllText($"{path}Advent of Code Box Dimensions.txt");

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

                    if(hashed.Substring(0, 5).Equals("00000")) {
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
            for(int i = 0; i < data.Length; i++) 
                sb.Append(data[i].ToString("x2"));
            return sb.ToString();
        }
    }
}
