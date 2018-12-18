using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Visual_Advent_of_Code.Menus;

namespace Visual_Advent_of_Code {
    public partial class AdventOfCode : Form {
        public const string path = @"C:\Users\daans\Desktop\AdventOfCode\2018\Input\";
        //public const string path = @"C:\Users\Daan\Desktop\AdventOfCode\2018\Input\";

        Menus.Menu menu = new Menus.Menu(true, 25);

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        public AdventOfCode() {
            InitializeComponent();

            //menu.CreateTab("Day 1", new Day1());
            //menu.CreateTab("Day 15", new Day15());
            //menu.CreateTab("Day 17", new Day17());
            menu.CreateTab("Day 18", new Day18());

            UserControl control = menu.MouseClick(new Point(0, 1));

            if (control != null) {
                taskPanel.Controls.Clear();
                taskPanel.Controls.Add(control);
            }

            menuPanel.Invalidate();
        }

        private void menuPanel_Paint(object sender, PaintEventArgs e) {
            menu.Draw(e.Graphics, ((Control)sender).Size);
        }

        private void menuPanel_MouseClick(object sender, MouseEventArgs e) {
            UserControl control = menu.MouseClick(e.Location);

            if (control != null) {
                taskPanel.Controls.Clear();
                taskPanel.Controls.Add(control);
            }
        }

        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        private void bannerPanel_Paint(object sender, PaintEventArgs e) {
            Control control = (Control)sender;
            using (Pen pen = new Pen(Color.White)) {
                e.Graphics.DrawLine(pen, new Point(0, control.Height - 1), new Point(control.Width, control.Height - 1));
            }

            e.Graphics.DrawString("Advent of Code 2018 - Visual Representation", new Font("Arial", 12), Brushes.White, new Point(3, 3));
        }

        private void bannerPanel_MouseDown(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Left) {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
    }
}
