using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visual_Advent_of_Code.Utils.Creatures {
    public class Elf : BaseCreature {
        public Elf(Point loc) : base(loc) {
            type = creatureTypes.elf;
        }
    }
}
