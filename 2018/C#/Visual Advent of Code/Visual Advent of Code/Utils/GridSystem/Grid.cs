using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Visual_Advent_of_Code.Utils.Creatures;

namespace Visual_Advent_of_Code.Utils.GridSystem {
    public class Grid {
        public Tile[,] grid { get; private set; }

        public Size gridSize { get; private set; }

        public Grid(Size gridSize) {
            this.gridSize = gridSize;
            grid = new Tile[gridSize.Width, gridSize.Height];

            for (int x = 0; x < gridSize.Width; x++) {
                for (int y = 0; y < gridSize.Height; y++) {
                    grid[x, y] = new Tile(new Point(x, y));
                }
            }
        }

        public void SetupGrid(string[] layers) {
            for (int y = 0; y < layers.Length; y++) {
                for (int x = 0; x < layers[0].Length - 1; x++) {
                    grid[x, y].tileType = (layers[y][x] == '#' ? Tile.tiles.wall : Tile.tiles.space);
                    if (layers[y][x] == 'E')
                        grid[x, y].creature = new Elf(new Point(x, y));
                    else if (layers[y][x] == 'G')
                        grid[x, y].creature = new Goblin(new Point(x, y));
                }
            }
        }

        public void Move() {
            for (int y = 0; y < gridSize.Height; y++) {
                for (int x = 0; x < gridSize.Width; x++) {
                    if (grid[x, y].creature != null)
                        if (!grid[x, y].creature.hasMoved)
                            grid[x, y].creature.CalculateMove(grid);
                }
            }
            for (int y = 0; y < gridSize.Height; y++)
                for (int x = 0; x < gridSize.Width; x++)
                    if (grid[x, y].creature != null)
                        grid[x, y].creature.hasMoved = false;

        }
    }
}
