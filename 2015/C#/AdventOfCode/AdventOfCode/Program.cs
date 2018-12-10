using System;
using System.Collections.Generic;
using System.IO;

namespace AdventOfCode {
    class Program {
        //const string path = @"C:\Users\Daan\Desktop\AdventOfCode\2015\Input\";
        const string path = @"C:\Users\daans\Desktop\AdventOfCode\2015\Input\";

        static void Main(string[] args) {
            Console.WriteLine("Advent of Code - Year 2015");

            //Day1_Question1();
            //Day1_Question2();
            Day2_Question1();
            Day2_Question2();

            Console.WriteLine("Done! Press a key to end the console.");

            Console.ReadKey();
        }

        private static void Day1_Question1() {
            Console.WriteLine("Day 1 - Question 1:");

            string input = File.ReadAllText($"{path}Advent of Code Floors.txt");

            int floor = 0;

            foreach (char c in input)
                floor += c == '(' ? 1 : -1;

            Console.WriteLine($"Answer Q1.1: {floor}\n");
        }

        private static void Day1_Question2() {
            Console.WriteLine("Day 1 - Question 2:");

            string input = File.ReadAllText($"{path}Advent of Code Floors.txt");

            int floor = 0;
            
            for(int i = 0; i < input.Length; i++) {
                floor += input[i] == '(' ? 1 : -1;

                if(floor == -1) {
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

            foreach(string s in inputs) {
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
    }
}
