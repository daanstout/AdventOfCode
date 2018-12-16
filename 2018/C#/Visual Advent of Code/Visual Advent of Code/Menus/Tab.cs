using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Visual_Advent_of_Code.Menus {
    public class Tab {
        public readonly string tabName;
        public readonly UserControl control;
        private readonly bool menuRight;
        private bool isSelected;

        public Tab(string tabName, UserControl control, bool menuRight) {
            this.tabName = tabName;
            this.control = control;
            this.menuRight = menuRight;
            isSelected = false;
        }

        public UserControl Select() {
            isSelected = true;
            return control;
        }

        public void Deselect() => isSelected = false;

        public void Draw(Graphics g, SizeF tabSize, int y) {
            using (Pen pen = new Pen(Color.White)) {
                g.DrawLine(pen, new PointF(0, tabSize.Height + y), new PointF(tabSize.Width, tabSize.Height + y));

                using (Font font = new Font("Arial", 13)) {
                    SizeF tabNameSize = g.MeasureString(tabName, font);
                    PointF p = new PointF((tabSize.Width - tabNameSize.Width) / 2, (tabSize.Height - tabNameSize.Height) / 2 + y);

                    g.DrawString(tabName, font, Brushes.White, p);
                }

                if (isSelected)
                    g.DrawLine(pen, new PointF(menuRight ? 0 : tabSize.Width, 0), new PointF(menuRight ? 0 : tabSize.Width, tabSize.Height));
            }
        }
    }
}
