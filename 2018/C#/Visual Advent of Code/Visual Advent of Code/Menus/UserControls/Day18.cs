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

namespace Visual_Advent_of_Code.Menus {
    public partial class Day18 : UserControl {
        string input = File.ReadAllText($"{AdventOfCode.path}Advent of Code - Day 18 - Lumber.txt");
        //string input = File.ReadAllText($"{AdventOfCode.path}Advent of Code - Day 18 - Test - Lumber.txt");

        LumberField field;

        long tickTime = 1000000000;

        public Day18() {
            InitializeComponent();

            field = new LumberField(input);

            int[] count = field.CountTileTypes();

            minutes.Text = $"Minute: {field.minute}\n\n" +
                $"Lumber Acres: {count[(int)LumberField.lumberTypes.lumber]}\n" +
                $"Wood Acres: {count[(int)LumberField.lumberTypes.wood]}\n" +
                $"Clear Acres: {count[(int)LumberField.lumberTypes.clear]}";

            viewPanel.Invalidate();
        }

        private void viewPanel_Paint(object sender, PaintEventArgs e) {
            field.Draw(e.Graphics);
        }

        private void tick_Click(object sender, EventArgs e) {
            field.Tick();

            int[] count = field.CountTileTypes();

            minutes.Text = $"Minute: {field.minute}\n\n" +
                $"Lumber Acres: {count[(int)LumberField.lumberTypes.lumber]}\n" +
                $"Wood Acres: {count[(int)LumberField.lumberTypes.wood]}\n" +
                $"Clear Acres: {count[(int)LumberField.lumberTypes.clear]}";

            viewPanel.Invalidate();
        }

        private void tickTimer_Tick(object sender, EventArgs e) {
            if(tickTime == 0) {
                tickTimer.Enabled = false;
                return;
            }

            field.Tick();

            int[] count = field.CountTileTypes();

            minutes.Text = $"Minute: {field.minute}\n\n" +
                $"Lumber Acres: {count[(int)LumberField.lumberTypes.lumber]}\n" +
                $"Wood Acres: {count[(int)LumberField.lumberTypes.wood]}\n" +
                $"Clear Acres: {count[(int)LumberField.lumberTypes.clear]}";

            viewPanel.Invalidate();

            tickTime--;
        }

        private void toggleTimer_Click(object sender, EventArgs e) {
            tickTimer.Enabled = !tickTimer.Enabled;
        }
    }
}
