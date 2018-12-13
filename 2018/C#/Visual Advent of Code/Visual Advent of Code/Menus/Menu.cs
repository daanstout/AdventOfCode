using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Visual_Advent_of_Code.Menus {
    public class Menu {
        private readonly List<Tab> tabList;
        private readonly bool menuRight;
        private readonly int tabHeight;
        private int current = -1;

        public Menu(bool menuRight, int tabHeight) {
            this.menuRight = menuRight;
            tabList = new List<Tab>();
            this.tabHeight = tabHeight;
        }

        public void CreateTab(string tabName, UserControl control) => tabList.Add(new Tab(tabName, control, menuRight));

        public void Draw(Graphics g, SizeF controlSize) {
            using (Pen pen = new Pen(Color.White)) {
                g.DrawRectangle(pen, new Rectangle(0, 0, (int)controlSize.Width, (int)controlSize.Height));

                int y = 0;
                foreach (Tab t in tabList) {
                    t.Draw(g, new SizeF(controlSize.Width, tabHeight), y);
                    y += tabHeight;
                }
            }
        }

        public UserControl MouseClick(Point location) {
            int index = location.Y / tabHeight;
            if (index < 0 || index >= tabList.Count || index == current)
                return null;
            else {
                if (current != -1)
                    tabList[current].Deselect();
                current = index;
                return tabList[current].Select();
            }
        }
    }
}
