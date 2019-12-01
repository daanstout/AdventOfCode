using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Visual_Advent_of_Code.Utils.Cave {
    public class Tile {
        public enum type {
            rocky,
            wet,
            narrow
        }

        public type tileType;
        public Point location;
        public int geologicIndex;
        public int erosionLevel;

        public int fastestTime = int.MaxValue;
        public int terrain;
        public int equip;

        public Tile(Point loc) => location = loc;
    }

    public class Cave {
        private Tile[,] caveSystem;

        private Point target;
        private int depth;

        public Cave(int depth, Point target) {
            this.depth = depth;
            this.target = target;

            caveSystem = new Tile[25, depth];

            for (int x = 0; x < 25; x++)
                for (int y = 0; y < depth; y++)
                    caveSystem[x, y] = new Tile(new Point(x, y));

            CalculateCaveData();
        }

        private void CalculateCaveData() {
            for (int x = 0; x < 25; x++) {
                for (int y = 0; y < depth; y++) {
                    if (caveSystem[x, y].location.X == 0 && caveSystem[x, y].location.Y == 0)
                        caveSystem[x, y].geologicIndex = 0;
                    else if (caveSystem[x, y].location.X == target.X && caveSystem[x, y].location.Y == target.Y)
                        caveSystem[x, y].geologicIndex = 0;
                    else if (caveSystem[x, y].location.Y == 0)
                        caveSystem[x, y].geologicIndex = x * 16807;
                    else if (caveSystem[x, y].location.X == 0)
                        caveSystem[x, y].geologicIndex = y * 48271;
                    else
                        caveSystem[x, y].geologicIndex = caveSystem[x - 1, y].erosionLevel * caveSystem[x, y - 1].erosionLevel;

                    caveSystem[x, y].erosionLevel = (caveSystem[x, y].geologicIndex + depth) % 20183;

                    caveSystem[x, y].tileType = (Tile.type)(caveSystem[x, y].erosionLevel % 3);
                }
            }
        }

        public void Draw(Graphics g) {
            for (int x = 0; x < 25; x++)
                for (int y = 0; y < depth; y++)
                    if (x == 0 && y == 0)
                        g.FillRectangle(Brushes.Green, new Rectangle(x * 5, y * 5, 5, 5));
                    else if (x == target.X && y == target.Y)
                        g.FillRectangle(Brushes.White, new Rectangle(x * 5, y * 5, 5, 5));
                    else if (caveSystem[x, y].tileType == Tile.type.rocky)
                        g.FillRectangle(Brushes.Brown, new Rectangle(x * 5, y * 5, 5, 5));
                    else if (caveSystem[x, y].tileType == Tile.type.wet)
                        g.FillRectangle(Brushes.DarkBlue, new Rectangle(x * 5, y * 5, 5, 5));
                    else if (caveSystem[x, y].tileType == Tile.type.narrow)
                        g.FillRectangle(new SolidBrush(Color.FromArgb(50, 50, 50)), new Rectangle(x * 5, y * 5, 5, 5));
        }

        public int GetRiskLevel() {
            int totalRisk = 0;

            for (int x = 0; x <= target.X; x++)
                for (int y = 0; y <= target.Y;  y++)
                    totalRisk += (int)caveSystem[x, y].tileType;

            return totalRisk;
        }

        public void CalculateFastestTime() {
            caveSystem[0, 0].fastestTime = 0;
            caveSystem[0, 0].equip = 0;

            Queue<Tile> queue = new Queue<Tile>(40);

            queue.Enqueue(caveSystem[0, 0]);

            int non = 1;
            int torch = 2;
            int climbing = 4;

            int rocky = torch | climbing;
            int wet = climbing | non;
            int narrow = torch | non;

            bool allows(int terrain, int equipped) => (terrain & equipped) == equipped;

            while (queue.Count > 0) {
                Tile current = queue.Dequeue();

                List<Tile> neighbours = new List<Tile>();

                if (current.location.X > 0)
                    neighbours.Add(caveSystem[current.location.X = 1, current.location.Y]);
                if (current.location.Y > 0)
                    neighbours.Add(caveSystem[current.location.X, current.location.Y - 1]);
                if (current.location.X < 24)
                    neighbours.Add(caveSystem[current.location.X + 1, current.location.Y]);
                if (current.location.Y < depth - 1)
                    neighbours.Add(caveSystem[current.location.X, current.location.Y + 1]);

                foreach (Tile t in neighbours) {
                    
                }
            }
        }
    }
}
