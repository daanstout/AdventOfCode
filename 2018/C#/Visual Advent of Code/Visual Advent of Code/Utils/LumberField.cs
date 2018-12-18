using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visual_Advent_of_Code.Utils {
    public class LumberField {
        public enum lumberTypes {
            lumber,
            clear,
            wood
        }

        public lumberTypes[,] field;

        public int width;
        public int height;

        public int minute = 1;

        public LumberField(string input) {
            string[] inputs = input.Split('\n');

            width = inputs[0].Trim().Length;
            height = inputs.Length;

            field = new lumberTypes[width, height];

            for (int x = 0; x < width; x++) {
                for (int y = 0; y < height; y++) {
                    if (inputs[y][x] == '.')
                        field[x, y] = lumberTypes.clear;
                    else if (inputs[y][x] == '|')
                        field[x, y] = lumberTypes.wood;
                    else
                        field[x, y] = lumberTypes.lumber;
                }
            }
        }

        public void Draw(Graphics g) {
            for (int x = 0; x < width; x++) {
                for (int y = 0; y < height; y++) {
                    if (field[x, y] == lumberTypes.clear)
                        g.FillRectangle(Brushes.White, new Rectangle(x * 10, y * 10, 10, 10));
                    else if (field[x, y] == lumberTypes.lumber)
                        g.FillRectangle(Brushes.Brown, new Rectangle(x * 10, y * 10, 10, 10));
                    else
                        g.FillRectangle(Brushes.Green, new Rectangle(x * 10, y * 10, 10, 10));
                }
            }
        }

        public void Tick() {
            minute++;

            lumberTypes[,] temp = new lumberTypes[width, height];

            for (int x = 0; x < width; x++) {
                for (int y = 0; y < height; y++) {
                    if (field[x, y] == lumberTypes.clear) {
                        temp[x, y] = CountNeighbours(x, y, lumberTypes.wood) >= 3 ? lumberTypes.wood : lumberTypes.clear;
                    } else if (field[x, y] == lumberTypes.lumber) {
                        bool hasLumber = false, hasTrees = false;
                        if (x > 0) {
                            if (field[x - 1, y] == lumberTypes.wood)
                                hasTrees = true;
                            else if (field[x - 1, y] == lumberTypes.lumber)
                                hasLumber = true;
                            if (y > 0) {
                                if (field[x - 1, y - 1] == lumberTypes.wood)
                                    hasTrees = true;
                                if (field[x - 1, y - 1] == lumberTypes.lumber)
                                    hasLumber = true;
                            }
                            if (y < height - 1) {
                                if (field[x - 1, y + 1] == lumberTypes.wood)
                                    hasTrees = true;
                                if (field[x - 1, y + 1] == lumberTypes.lumber)
                                    hasLumber = true;
                            }
                        }
                        if (x < width - 1) {
                            if (field[x + 1, y] == lumberTypes.wood)
                                hasTrees = true;
                            if (field[x + 1, y] == lumberTypes.lumber)
                                hasLumber = true;
                            if (y > 0) {
                                if (field[x + 1, y - 1] == lumberTypes.wood)
                                    hasTrees = true;
                                if (field[x + 1, y - 1] == lumberTypes.lumber)
                                    hasLumber = true;
                            }
                            if (y < height - 1) {
                                if (field[x + 1, y + 1] == lumberTypes.wood)
                                    hasTrees = true;
                                if (field[x + 1, y + 1] == lumberTypes.lumber)
                                    hasLumber = true;
                            }
                        }
                        if (y > 0) {
                            if (field[x, y - 1] == lumberTypes.wood)
                                hasTrees = true;
                            if (field[x, y - 1] == lumberTypes.lumber)
                                hasLumber = true;
                        }
                        if (y < height - 1) {
                            if (field[x, y + 1] == lumberTypes.wood)
                                hasTrees = true;
                            if (field[x, y + 1] == lumberTypes.lumber)
                                hasLumber = true;
                        }

                        temp[x, y] = (hasTrees && hasLumber) ? lumberTypes.lumber : lumberTypes.clear;
                    } else {
                        temp[x, y] = CountNeighbours(x, y, lumberTypes.lumber) >= 3 ? lumberTypes.lumber : lumberTypes.wood;
                    }
                }
            }

            field = temp;
        }

        public int[] CountTileTypes() {
            int[] count = { 0, 0, 0 };

            for (int x = 0; x < width; x++) {
                for (int y = 0; y < height; y++) {
                    if (field[x, y] == lumberTypes.clear)
                        count[(int)lumberTypes.clear]++;
                    else if (field[x, y] == lumberTypes.lumber)
                        count[(int)lumberTypes.lumber]++;
                    else
                        count[(int)lumberTypes.wood]++;
                }
            }

            return count;
        }

        public int CountNeighbours(int x, int y, lumberTypes type) {
            int count = 0;
            if (x > 0) {
                if (field[x - 1, y] == type)
                    count++;
                if (y > 0)
                    if (field[x - 1, y - 1] == type)
                        count++;
                if (y < height - 1)
                    if (field[x - 1, y + 1] == type)
                        count++;
            }
            if (x < width - 1) {
                if (field[x + 1, y] == type)
                    count++;
                if (y > 0)
                    if (field[x + 1, y - 1] == type)
                        count++;
                if (y < height - 1)
                    if (field[x + 1, y + 1] == type)
                        count++;
            }
            if (y > 0)
                if (field[x, y - 1] == type)
                    count++;
            if (y < height - 1)
                if (field[x, y + 1] == type)
                    count++;

            return count;
        }
    }
}
