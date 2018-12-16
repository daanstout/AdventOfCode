using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Visual_Advent_of_Code.Utils.Creatures;

namespace Visual_Advent_of_Code.Utils.GridSystem {
    public class Tile {
        public enum tiles {
            wall,
            space
        }

        public tiles tileType = tiles.wall;

        public readonly Point coords;

        public BaseCreature creature;

        public bool scratch = false;

        public Tile previous;

        public int distance;

        public Tile(Point coords) {
            this.coords = coords;
        }

        public void Reset() {
            scratch = false;
            previous = null;
            distance = int.MaxValue;
        }
    }
}
