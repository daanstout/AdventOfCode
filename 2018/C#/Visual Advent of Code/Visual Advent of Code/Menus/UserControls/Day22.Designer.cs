namespace Visual_Advent_of_Code.Menus {
    partial class Day22 {
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
            this.mainPanel = new System.Windows.Forms.Panel();
            this.fieldPanel = new System.Windows.Forms.Panel();
            this.riskLabel = new System.Windows.Forms.Label();
            this.mainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.AutoScroll = true;
            this.mainPanel.Controls.Add(this.fieldPanel);
            this.mainPanel.Location = new System.Drawing.Point(25, 25);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(600, 500);
            this.mainPanel.TabIndex = 0;
            // 
            // fieldPanel
            // 
            this.fieldPanel.Location = new System.Drawing.Point(0, 0);
            this.fieldPanel.Name = "fieldPanel";
            this.fieldPanel.Size = new System.Drawing.Size(550, 30420);
            this.fieldPanel.TabIndex = 0;
            this.fieldPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.fieldPanel_Paint);
            // 
            // riskLabel
            // 
            this.riskLabel.AutoSize = true;
            this.riskLabel.Location = new System.Drawing.Point(663, 25);
            this.riskLabel.Name = "riskLabel";
            this.riskLabel.Size = new System.Drawing.Size(35, 13);
            this.riskLabel.TabIndex = 1;
            this.riskLabel.Text = "label1";
            // 
            // Day22
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.Controls.Add(this.riskLabel);
            this.Controls.Add(this.mainPanel);
            this.Name = "Day22";
            this.Size = new System.Drawing.Size(850, 575);
            this.mainPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Panel fieldPanel;
        private System.Windows.Forms.Label riskLabel;
    }
}
