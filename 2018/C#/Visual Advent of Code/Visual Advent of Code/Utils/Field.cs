using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visual_Advent_of_Code.Utils {
    public class Field {
        public enum tileTypes {
            sand,
            clay,
            water_source,
            flowing_water
        }

        public int startX;
        public int startY;
        public int endX;
        public int endY;

        public tileTypes[,] field { get; private set; }

        public Field(int maxX, int maxY) {
            field = new tileTypes[maxX + 1, maxY + 1];

            for (int i = 0; i < field.GetLength(0); i++)
                for (int j = 0; j < field.GetLength(1); j++)
                    field[i, j] = tileTypes.sand;
        }

        public void SetField(string[] input) {
            foreach (string s in input) {
                string[] parts = s.Split(',');
                int startX = -1, startY = -1, endX = -1, endY = -1;
                foreach (string p in parts) {
                    string t = p.Trim();
                    if (t[0] == 'x') {
                        string[] coords = t.Substring(2).Split('.');
                        startX = Convert.ToInt32(coords[0]);
                        if (coords.Length > 1) {
                            endX = Convert.ToInt32(coords[2]);
                        }
                    } else if (t[0] == 'y') {
                        string[] coords = t.Substring(2).Split('.');
                        startY = Convert.ToInt32(coords[0]);
                        if (coords.Length > 1) {
                            endY = Convert.ToInt32(coords[2]);
                        }
                    }
                }
                if (endX == -1) {
                    for (int i = startY; i <= endY; i++)
                        field[startX, i] = tileTypes.clay;
                } else {
                    for (int i = startX; i <= endX; i++)
                        field[i, startY] = tileTypes.clay;
                }
            }
        }

        public void Draw(Bitmap bm) {
            for (int y = 0; y < field.GetLength(1); y++) {
                for (int x = 300; x < field.GetLength(0); x++) {
                    switch (field[x, y]) {
                        case tileTypes.clay:
                            bm.SetPixel(x - 300, y, Color.Gray);
                            break;
                        case tileTypes.flowing_water:
                            bm.SetPixel(x - 300, y, Color.LightBlue);
                            break;
                        case tileTypes.sand:
                            bm.SetPixel(x - 300, y, Color.Orange);
                            break;
                        case tileTypes.water_source:
                            bm.SetPixel(x - 300, y, Color.DarkBlue);
                            break;
                    }
                }
            }
        }

        public void Tick() {
            for (int y = field.GetLength(1) - 2; y >= 0; y--) {
                for (int x = 300; x < field.GetLength(0) - 1; x++) {
                    if (field[x, y] == tileTypes.water_source || field[x, y] == tileTypes.flowing_water) {
                        if (field[x, y + 1] == tileTypes.sand) {
                            field[x, y + 1] = tileTypes.flowing_water;
                            if (field[x, y] == tileTypes.flowing_water)
                                field[x, y] = tileTypes.sand;
                        } else if(field[x - 1, y] == tileTypes.sand){
                            field[x - 1, y] = tileTypes.flowing_water;
                            if (field[x, y] == tileTypes.flowing_water)
                                field[x, y] = tileTypes.sand;
                        }else if(field[x + 1, y] == tileTypes.sand) {
                            field[x + 1, y] = tileTypes.flowing_water;
                            if (field[x, y] == tileTypes.flowing_water)
                                field[x, y] = tileTypes.sand;
                        }
                    }
                }
            }
        }
    }
}
