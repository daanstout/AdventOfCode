using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visual_Advent_of_Code.Utils.Creatures {
    public class Goblin : BaseCreature{

        public Goblin(Point loc) : base(loc) {
            type = creatureTypes.goblin;
        }
    }
}
