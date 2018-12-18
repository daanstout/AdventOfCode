using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Visual_Advent_of_Code.Utils;
using System.Diagnostics;

namespace Visual_Advent_of_Code.Menus {
    public partial class Day17 : UserControl {
        string input = File.ReadAllText($"{AdventOfCode.path}Advent of Code - Day 17 - Clay Deposits.txt");

        Field field = new Field(615, 2064) {
            startX = 332,
            startY = 12,
            endX = 615,
            endY = 2064
        };

        public Day17() {
            InitializeComponent();

            string[] inputs = input.Split('\n');

            field.SetField(inputs);
            field.field[500, 0] = Field.tileTypes.water_source;

            //drawPanel.Invalidate();

            Draw();

            //timer1.Enabled = true;


            //int smallestX = int.MaxValue, smallestY = int.MaxValue, largestX = int.MinValue, largestY = int.MinValue;



            //foreach (string s in inputs) {
            //    string[] parts = s.Split(',');
            //    foreach (string p in parts) {
            //        if (p[0] == 'x') {
            //            string[] coords = p.Substring(2).Split('.');
            //            int x = Convert.ToInt32(coords[0]);
            //            if (x < smallestX)
            //                smallestX = x;
            //            else if (x > largestX)
            //                largestX = x;
            //            if (coords.Length > 1) {
            //                x = Convert.ToInt32(coords[2]);
            //                if (x < smallestX)
            //                    smallestX = x;
            //                else if (x > largestX)
            //                    largestX = x;
            //            }
            //        } else if (p[0] == 'y') {
            //            string[] coords = p.Substring(2).Split('.');
            //            int y = Convert.ToInt32(coords[0]);
            //            if (y < smallestY)
            //                smallestY = y;
            //            else if (y > largestY)
            //                largestY = y;
            //            if (coords.Length > 1) {
            //                y = Convert.ToInt32(coords[2]);
            //                if (y < smallestY)
            //                    smallestY = y;
            //                else if (y > largestY)
            //                    largestY = y;
            //            }
            //        }
            //    }
            //}

            //Console.WriteLine($"{smallestX} - {smallestY} -- {largestX} - {largestY}");
        }

        private void Draw() {
            Bitmap bm = new Bitmap(616, 2065);

            field.Draw(bm);

            drawPanel.BackgroundImage?.Dispose();
            drawPanel.BackgroundImage = bm;
        }

        private void drawPanel_Paint(object sender, PaintEventArgs e) {
            //Console.WriteLine("Draw");

            field.Draw((Bitmap)drawPanel.BackgroundImage);
        }

        private void solveTimer_Tick(object sender, EventArgs e) {
            //Console.WriteLine("Tick");
            field.Tick();

            drawPanel.Invalidate();

            //Draw();
        }

        private void tick_Click(object sender, EventArgs e) {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            field.Tick();

            drawPanel.Invalidate();
            //Draw();

            Console.WriteLine(sw.ElapsedMilliseconds);
        }

        private void toggleTimer_Click(object sender, EventArgs e) {
            timer1.Enabled = !timer1.Enabled;
        }
    }
}
