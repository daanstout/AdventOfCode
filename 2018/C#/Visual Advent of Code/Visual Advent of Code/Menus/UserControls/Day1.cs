using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.IO;

namespace Visual_Advent_of_Code.Menus {
    public partial class Day1 : UserControl {
        private readonly string input;
        private bool doStep = false;
        private volatile List<DataPoint> newPoints = new List<DataPoint>();
        private bool freeze = false;

        public Day1() {
            InitializeComponent();

            input = File.ReadAllText($"{AdventOfCode.path}Advent of Code - Day 1 - Calibration values.txt");

            stepSolveTimer.Interval = (int)stepSolveNumeric.Value;
        }

        private void StepSolve1() {
            string[] inputs = input.Split('\n');

            int frequency = 0;
            int index = 0;

            while(freeze) { }
            newPoints.Add(new DataPoint(index, frequency));

            doStep = true;

            foreach (string s in inputs) {
                while (!doStep) { }
                doStep = false;
                index++;
                if (s[0] == '-')
                    frequency -= Convert.ToInt32(s.Substring(1));
                else if (s[0] == '+')
                    frequency += Convert.ToInt32(s.Substring(1));

                while (freeze) { }
                newPoints.Add(new DataPoint(index, frequency));
            }
        }

        private void Solve2() {
            string[] inputs = input.Split('\n');

            List<int> frequencies = new List<int>();

            int frequency = 0;
            int index = 0;

            frequencies.Add(frequency);

            bool looking = true;

            while (looking) {
                foreach (string s in inputs) {
                    if (s[0] == '-')
                        frequency -= Convert.ToInt32(s.Substring(1));
                    else if (s[0] == '+')
                        frequency += Convert.ToInt32(s.Substring(1));

                    while (freeze) { }
                    newPoints.Add(new DataPoint(index, frequency));

                    if (frequencies.Contains(frequency)) {
                        looking = false;
                        break;
                    } else {
                        frequencies.Add(frequency);
                    }
                }
            }
        }

        private void solvePart1_Click(object sender, EventArgs e) {
            solvePart1.Enabled = stepSolvePart1.Enabled = solvePart2.Enabled = false;

            string[] inputs = input.Split('\n');

            int frequency = 0;
            int index = 0;

            frequencyChart.Series[0].Points.Clear();
            frequencyChart.Series[0].Points.Add(new DataPoint(index, frequency));

            foreach (string s in inputs) {


                index++;
                if (s[0] == '-')
                    frequency -= Convert.ToInt32(s.Substring(1));
                else if (s[0] == '+')
                    frequency += Convert.ToInt32(s.Substring(1));

                while (freeze) { }
                frequencyChart.Series[0].Points.Add(new DataPoint(index, frequency));

                frequencyLabel.Text = frequency.ToString();
            }

            solvePart1.Enabled = stepSolvePart1.Enabled = solvePart2.Enabled = true;
        }

        private void solvePart2_Click(object sender, EventArgs e) {
            solvePart1.Enabled = stepSolvePart1.Enabled = solvePart2.Enabled = false;

            frequencyChart.Series[0].Points.Clear();
            frequencyChart.Series[0].Points.Add(new DataPoint(0, 0));

            solving2BackgroundWorker.RunWorkerAsync();
        }

        private void stepSolvePart1_Click(object sender, EventArgs e) {
            solvePart1.Enabled = stepSolvePart1.Enabled = solvePart2.Enabled = false;

            frequencyChart.Series[0].Points.Clear();

            stepSolving1BackgroundWorker.RunWorkerAsync();
        }

        private void stepSolveTimer_Tick(object sender, EventArgs e) {
            freeze = true;
            if (newPoints.Count > 0) {
                foreach (DataPoint dp in newPoints)
                    frequencyChart.Series[0].Points.Add(dp);

                frequencyLabel.Text = newPoints.Last().YValues[0].ToString();
                newPoints = new List<DataPoint>();
            }
            freeze = false;
            doStep = true;
        }

        private void stepSolveNumeric_ValueChanged(object sender, EventArgs e) {
            stepSolveTimer.Interval = (int)((NumericUpDown)sender).Value;
        }

        private void stepSolving1BackgroundWorker_DoWork(object sender, DoWorkEventArgs e) {
            StepSolve1();
        }

        private void stepSolving1BackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
            solvePart1.Enabled = stepSolvePart1.Enabled = solvePart2.Enabled = true;
        }

        private void solving2BackgroundWorker_DoWork(object sender, DoWorkEventArgs e) {
            Solve2();
        }

        private void solving2BackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
            solvePart1.Enabled = stepSolvePart1.Enabled = solvePart2.Enabled = true;
        }
    }
}
