namespace Visual_Advent_of_Code {
    partial class AdventOfCode {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.taskPanel = new System.Windows.Forms.Panel();
            this.menuPanel = new System.Windows.Forms.Panel();
            this.bannerPanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // taskPanel
            // 
            this.taskPanel.Location = new System.Drawing.Point(0, 25);
            this.taskPanel.Name = "taskPanel";
            this.taskPanel.Size = new System.Drawing.Size(850, 575);
            this.taskPanel.TabIndex = 0;
            // 
            // menuPanel
            // 
            this.menuPanel.Location = new System.Drawing.Point(850, 25);
            this.menuPanel.Name = "menuPanel";
            this.menuPanel.Size = new System.Drawing.Size(150, 575);
            this.menuPanel.TabIndex = 1;
            this.menuPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.menuPanel_Paint);
            this.menuPanel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.menuPanel_MouseClick);
            // 
            // bannerPanel
            // 
            this.bannerPanel.Location = new System.Drawing.Point(0, 0);
            this.bannerPanel.Name = "bannerPanel";
            this.bannerPanel.Size = new System.Drawing.Size(1000, 25);
            this.bannerPanel.TabIndex = 2;
            this.bannerPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.bannerPanel_Paint);
            this.bannerPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.bannerPanel_MouseDown);
            // 
            // AdventOfCode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(1000, 600);
            this.Controls.Add(this.bannerPanel);
            this.Controls.Add(this.menuPanel);
            this.Controls.Add(this.taskPanel);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AdventOfCode";
            this.Text = "Advent of Code 2018 - Visual Representation";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel taskPanel;
        private System.Windows.Forms.Panel menuPanel;
        private System.Windows.Forms.Panel bannerPanel;
    }
}

