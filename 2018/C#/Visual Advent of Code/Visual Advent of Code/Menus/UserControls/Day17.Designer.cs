namespace Visual_Advent_of_Code.Menus {
    partial class Day17 {
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.fieldPanel = new System.Windows.Forms.Panel();
            this.drawPanel = new System.Windows.Forms.Panel();
            this.solve = new System.Windows.Forms.Button();
            this.tick = new System.Windows.Forms.Button();
            this.toggleTimer = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.fieldPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // fieldPanel
            // 
            this.fieldPanel.AutoScroll = true;
            this.fieldPanel.Controls.Add(this.drawPanel);
            this.fieldPanel.Location = new System.Drawing.Point(25, 25);
            this.fieldPanel.Name = "fieldPanel";
            this.fieldPanel.Size = new System.Drawing.Size(650, 525);
            this.fieldPanel.TabIndex = 0;
            // 
            // drawPanel
            // 
            this.drawPanel.Location = new System.Drawing.Point(0, 0);
            this.drawPanel.Name = "drawPanel";
            this.drawPanel.Size = new System.Drawing.Size(650, 2065);
            this.drawPanel.TabIndex = 0;
            this.drawPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.drawPanel_Paint);
            // 
            // solve
            // 
            this.solve.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.solve.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.solve.Font = new System.Drawing.Font("Arial", 8F);
            this.solve.ForeColor = System.Drawing.Color.White;
            this.solve.Location = new System.Drawing.Point(711, 25);
            this.solve.Name = "solve";
            this.solve.Size = new System.Drawing.Size(110, 23);
            this.solve.TabIndex = 3;
            this.solve.Text = "Solve";
            this.solve.UseVisualStyleBackColor = true;
            // 
            // tick
            // 
            this.tick.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.tick.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tick.Font = new System.Drawing.Font("Arial", 8F);
            this.tick.ForeColor = System.Drawing.Color.White;
            this.tick.Location = new System.Drawing.Point(711, 54);
            this.tick.Name = "tick";
            this.tick.Size = new System.Drawing.Size(110, 23);
            this.tick.TabIndex = 4;
            this.tick.Text = "Tick";
            this.tick.UseVisualStyleBackColor = true;
            this.tick.Click += new System.EventHandler(this.tick_Click);
            // 
            // toggleTimer
            // 
            this.toggleTimer.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.toggleTimer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.toggleTimer.Font = new System.Drawing.Font("Arial", 8F);
            this.toggleTimer.ForeColor = System.Drawing.Color.White;
            this.toggleTimer.Location = new System.Drawing.Point(711, 83);
            this.toggleTimer.Name = "toggleTimer";
            this.toggleTimer.Size = new System.Drawing.Size(110, 23);
            this.toggleTimer.TabIndex = 5;
            this.toggleTimer.Text = "Toggle Timer";
            this.toggleTimer.UseVisualStyleBackColor = true;
            this.toggleTimer.Click += new System.EventHandler(this.toggleTimer_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 50;
            this.timer1.Tick += new System.EventHandler(this.solveTimer_Tick);
            // 
            // Day17
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.Controls.Add(this.toggleTimer);
            this.Controls.Add(this.tick);
            this.Controls.Add(this.solve);
            this.Controls.Add(this.fieldPanel);
            this.Name = "Day17";
            this.Size = new System.Drawing.Size(850, 575);
            this.fieldPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel fieldPanel;
        private System.Windows.Forms.Panel drawPanel;
        private System.Windows.Forms.Button solve;
        private System.Windows.Forms.Button tick;
        private System.Windows.Forms.Button toggleTimer;
        private System.Windows.Forms.Timer timer1;
    }
}
