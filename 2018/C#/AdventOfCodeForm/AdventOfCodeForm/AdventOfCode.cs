using AdventOfCodeForm.Day10;
using AdventOfCodeForm.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdventOfCodeForm {
    public partial class AdventOfCode : Form {
        private const string path = @"C:\Users\daans\Desktop\AdventOfCode\2018\Input\";

        private float scale = 100f;

        private List<Light> lights = new List<Light>();
        private bool reverse = false;

        private int time = 0;

        public AdventOfCode() {
            InitializeComponent();

            InitDay10();

            //DayTen day = new DayTen();
            //day.Process();

            drawingPanel.Invalidate();

            Timer.Enabled = true;
        }

        private void InitDay10() {
            string input = File.ReadAllText(path + "Advent of Code Lights.txt");
            //string input = File.ReadAllText(path + "Advent of Code Test Lights.txt");

            string[] inputs = input.Split('\n');

            foreach (string s in inputs) {
                string position = s.Substring(0, 25);
                string velocity = s.Substring(26, 17);

                int posX = Convert.ToInt32(position.Substring(10, 6));
                int posY = Convert.ToInt32(position.Substring(19, 5));

                int velX = Convert.ToInt32(velocity.Substring(10, 2));
                int velY = Convert.ToInt32(velocity.Substring(14, 2));

                //string position = s.Substring(0, 17);
                //string velocity = s.Substring(18, 17);

                //int posX = Convert.ToInt32(position.Substring(10, 2));
                //int posY = Convert.ToInt32(position.Substring(14, 2));

                //int velX = Convert.ToInt32(velocity.Substring(10, 2));
                //int velY = Convert.ToInt32(velocity.Substring(14, 2));

                Light l = new Light(new Vector2D(posX, posY), new Vector2D(velX, velY));

                //Console.WriteLine(l);

                lights.Add(l);
            }
        }

        private void Day10_Question1(Graphics g) {
            foreach (Light l in lights) {
                g.FillRectangle(Brushes.Black, (l.location.x / scale) + 200, (l.location.y / scale) + 200, 1, 1);
            }
        }

        private void drawingPanel_Paint(object sender, PaintEventArgs e) {
            Day10_Question1(e.Graphics);
        }

        private void Timer_Tick(object sender, EventArgs e) {
            foreach (Light l in lights) {
                if (reverse) {
                    l.Reverse((int)acceleration.Value);
                } else {
                    l.Update((int)acceleration.Value);
                }
            }

            time += reverse ? (int)-acceleration.Value : (int)acceleration.Value;

            timeLabel.Text = time.ToString();

            drawingPanel.Invalidate();
        }

        private void tickButton_Click(object sender, EventArgs e) {
            foreach (Light l in lights) {
                if (reverse) {
                    l.Reverse((int)acceleration.Value);
                } else {
                    l.Update((int)acceleration.Value);
                }
            }

            time += reverse ? (int)-acceleration.Value : (int)acceleration.Value;


            timeLabel.Text = time.ToString();

            drawingPanel.Invalidate();
        }

        private void toggleFlowButton_Click(object sender, EventArgs e) {
            Timer.Enabled = !Timer.Enabled;
        }

        private void reverseButton_Click(object sender, EventArgs e) {
            reverse = !reverse;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e) {
            scale = (int)scaleNumeric.Value;
            drawingPanel.Invalidate();
        }

        private void acceleration_ValueChanged(object sender, EventArgs e) {

        }
    }
}
