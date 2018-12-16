namespace Visual_Advent_of_Code.Menus {
    partial class Day15 {
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
            this.viewPanel = new System.Windows.Forms.Panel();
            this.moveStep = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // viewPanel
            // 
            this.viewPanel.Location = new System.Drawing.Point(25, 25);
            this.viewPanel.Name = "viewPanel";
            this.viewPanel.Size = new System.Drawing.Size(650, 525);
            this.viewPanel.TabIndex = 0;
            this.viewPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.viewPanel_Paint);
            // 
            // moveStep
            // 
            this.moveStep.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.moveStep.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.moveStep.Font = new System.Drawing.Font("Arial", 8F);
            this.moveStep.ForeColor = System.Drawing.Color.White;
            this.moveStep.Location = new System.Drawing.Point(712, 25);
            this.moveStep.Name = "moveStep";
            this.moveStep.Size = new System.Drawing.Size(110, 23);
            this.moveStep.TabIndex = 2;
            this.moveStep.Text = "Move 1 Step";
            this.moveStep.UseVisualStyleBackColor = true;
            this.moveStep.Click += new System.EventHandler(this.moveStep_Click);
            // 
            // Day15
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.Controls.Add(this.moveStep);
            this.Controls.Add(this.viewPanel);
            this.Name = "Day15";
            this.Size = new System.Drawing.Size(850, 575);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel viewPanel;
        private System.Windows.Forms.Button moveStep;
    }
}
