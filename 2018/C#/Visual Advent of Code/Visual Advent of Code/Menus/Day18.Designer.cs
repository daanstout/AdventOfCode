namespace Visual_Advent_of_Code.Menus {
    partial class Day18 {
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
            this.viewPanel = new System.Windows.Forms.Panel();
            this.tick = new System.Windows.Forms.Button();
            this.minutes = new System.Windows.Forms.Label();
            this.tickTimer = new System.Windows.Forms.Timer(this.components);
            this.toggleTimer = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // viewPanel
            // 
            this.viewPanel.Location = new System.Drawing.Point(25, 25);
            this.viewPanel.Name = "viewPanel";
            this.viewPanel.Size = new System.Drawing.Size(500, 500);
            this.viewPanel.TabIndex = 0;
            this.viewPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.viewPanel_Paint);
            // 
            // tick
            // 
            this.tick.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.tick.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tick.Font = new System.Drawing.Font("Arial", 8F);
            this.tick.ForeColor = System.Drawing.Color.White;
            this.tick.Location = new System.Drawing.Point(554, 25);
            this.tick.Name = "tick";
            this.tick.Size = new System.Drawing.Size(110, 23);
            this.tick.TabIndex = 3;
            this.tick.Text = "Tick";
            this.tick.UseVisualStyleBackColor = true;
            this.tick.Click += new System.EventHandler(this.tick_Click);
            // 
            // minutes
            // 
            this.minutes.AutoSize = true;
            this.minutes.Location = new System.Drawing.Point(554, 55);
            this.minutes.Name = "minutes";
            this.minutes.Size = new System.Drawing.Size(38, 13);
            this.minutes.TabIndex = 4;
            this.minutes.Text = "Day: 1";
            // 
            // tickTimer
            // 
            this.tickTimer.Enabled = true;
            this.tickTimer.Interval = 1;
            this.tickTimer.Tick += new System.EventHandler(this.tickTimer_Tick);
            // 
            // toggleTimer
            // 
            this.toggleTimer.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.toggleTimer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.toggleTimer.Font = new System.Drawing.Font("Arial", 8F);
            this.toggleTimer.ForeColor = System.Drawing.Color.White;
            this.toggleTimer.Location = new System.Drawing.Point(681, 25);
            this.toggleTimer.Name = "toggleTimer";
            this.toggleTimer.Size = new System.Drawing.Size(110, 23);
            this.toggleTimer.TabIndex = 5;
            this.toggleTimer.Text = "Toggle Timer";
            this.toggleTimer.UseVisualStyleBackColor = true;
            this.toggleTimer.Click += new System.EventHandler(this.toggleTimer_Click);
            // 
            // Day18
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.Controls.Add(this.toggleTimer);
            this.Controls.Add(this.minutes);
            this.Controls.Add(this.tick);
            this.Controls.Add(this.viewPanel);
            this.Name = "Day18";
            this.Size = new System.Drawing.Size(850, 575);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel viewPanel;
        private System.Windows.Forms.Button tick;
        private System.Windows.Forms.Label minutes;
        private System.Windows.Forms.Timer tickTimer;
        private System.Windows.Forms.Button toggleTimer;
    }
}
