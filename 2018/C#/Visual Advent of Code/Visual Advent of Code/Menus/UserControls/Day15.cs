using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Visual_Advent_of_Code.Utils.Creatures;
using Visual_Advent_of_Code.Utils.GridSystem;

namespace Visual_Advent_of_Code.Menus {
    public partial class Day15 : UserControl {
        //string input = File.ReadAllText($"{AdventOfCode.path}Advent of Code - Day 15 - Goblens vs Elfs.txt");
        string input = File.ReadAllText($"{AdventOfCode.path}Advent of Code - Day 15 - Test - Goblens vs Elfs.txt");

        Grid grid;
        public Day15() {
            InitializeComponent();

            string[] inputs = input.Split('\n');

            grid = new Grid(new Size(inputs[0].Length - 1, inputs.Length));
            grid.SetupGrid(inputs);

            //grid.Move();

            viewPanel.Invalidate();
        }

        private void viewPanel_Paint(object sender, PaintEventArgs e) {
            Size tileSize = new Size(10, 10);

            for (int x = 0; x < grid.gridSize.Width; x++) {
                for (int y = 0; y < grid.gridSize.Height; y++) {
                    e.Graphics.FillRectangle(grid.grid[x, y].tileType == Tile.tiles.wall ? Brushes.Black : Brushes.LightGray,
                        new Rectangle(x * tileSize.Width, y * tileSize.Height, tileSize.Width, tileSize.Height)
                    );
                    if (grid.grid[x, y].creature is Goblin)
                        e.Graphics.FillEllipse(Brushes.Red, new Rectangle(x * tileSize.Width, y * tileSize.Height, tileSize.Width, tileSize.Height));
                    else if(grid.grid[x, y].creature is Elf)
                        e.Graphics.FillEllipse(Brushes.Green, new Rectangle(x * tileSize.Width, y * tileSize.Height, tileSize.Width, tileSize.Height));
                }
            }
        }

        private void moveStep_Click(object sender, EventArgs e) {
            grid.Move();

            viewPanel.Invalidate();
        }
    }
}
