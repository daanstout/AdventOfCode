using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Visual_Advent_of_Code.Utils.Cave;

namespace Visual_Advent_of_Code.Menus {
    public partial class Day22 : UserControl {
        private int depth = 6084;
        private Point target = new Point(14, 709);

        Cave cave;

        public Day22() {
            InitializeComponent();

            cave = new Cave(depth, target);
            //cave = new Cave(510, new Point(10, 10));

            riskLabel.Text = $"Total risk: {cave.GetRiskLevel()}";
        }

        private void fieldPanel_Paint(object sender, PaintEventArgs e) {
            cave?.Draw(e.Graphics);
        }
    }
}
