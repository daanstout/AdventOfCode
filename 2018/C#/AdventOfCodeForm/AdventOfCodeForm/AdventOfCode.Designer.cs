namespace AdventOfCodeForm {
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
            this.components = new System.ComponentModel.Container();
            this.drawingPanel = new System.Windows.Forms.Panel();
            this.Timer = new System.Windows.Forms.Timer(this.components);
            this.tickButton = new System.Windows.Forms.Button();
            this.toggleFlowButton = new System.Windows.Forms.Button();
            this.reverseButton = new System.Windows.Forms.Button();
            this.scaleNumeric = new System.Windows.Forms.NumericUpDown();
            this.acceleration = new System.Windows.Forms.NumericUpDown();
            this.timeLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.scaleNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acceleration)).BeginInit();
            this.SuspendLayout();
            // 
            // drawingPanel
            // 
            this.drawingPanel.BackColor = System.Drawing.Color.White;
            this.drawingPanel.Location = new System.Drawing.Point(12, 12);
            this.drawingPanel.Name = "drawingPanel";
            this.drawingPanel.Size = new System.Drawing.Size(800, 400);
            this.drawingPanel.TabIndex = 0;
            this.drawingPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.drawingPanel_Paint);
            // 
            // Timer
            // 
            this.Timer.Interval = 1;
            this.Timer.Tick += new System.EventHandler(this.Timer_Tick);
            // 
            // tickButton
            // 
            this.tickButton.Location = new System.Drawing.Point(845, 13);
            this.tickButton.Name = "tickButton";
            this.tickButton.Size = new System.Drawing.Size(75, 23);
            this.tickButton.TabIndex = 1;
            this.tickButton.Text = "Tick";
            this.tickButton.UseVisualStyleBackColor = true;
            this.tickButton.Click += new System.EventHandler(this.tickButton_Click);
            // 
            // toggleFlowButton
            // 
            this.toggleFlowButton.Location = new System.Drawing.Point(845, 43);
            this.toggleFlowButton.Name = "toggleFlowButton";
            this.toggleFlowButton.Size = new System.Drawing.Size(75, 23);
            this.toggleFlowButton.TabIndex = 2;
            this.toggleFlowButton.Text = "Toggle Flow";
            this.toggleFlowButton.UseVisualStyleBackColor = true;
            this.toggleFlowButton.Click += new System.EventHandler(this.toggleFlowButton_Click);
            // 
            // reverseButton
            // 
            this.reverseButton.Location = new System.Drawing.Point(845, 73);
            this.reverseButton.Name = "reverseButton";
            this.reverseButton.Size = new System.Drawing.Size(75, 23);
            this.reverseButton.TabIndex = 3;
            this.reverseButton.Text = "Reverse";
            this.reverseButton.UseVisualStyleBackColor = true;
            this.reverseButton.Click += new System.EventHandler(this.reverseButton_Click);
            // 
            // scaleNumeric
            // 
            this.scaleNumeric.Location = new System.Drawing.Point(845, 103);
            this.scaleNumeric.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.scaleNumeric.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.scaleNumeric.Name = "scaleNumeric";
            this.scaleNumeric.Size = new System.Drawing.Size(120, 20);
            this.scaleNumeric.TabIndex = 4;
            this.scaleNumeric.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.scaleNumeric.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // acceleration
            // 
            this.acceleration.Location = new System.Drawing.Point(845, 130);
            this.acceleration.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.acceleration.Name = "acceleration";
            this.acceleration.Size = new System.Drawing.Size(120, 20);
            this.acceleration.TabIndex = 5;
            this.acceleration.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.acceleration.ValueChanged += new System.EventHandler(this.acceleration_ValueChanged);
            // 
            // timeLabel
            // 
            this.timeLabel.AutoSize = true;
            this.timeLabel.Location = new System.Drawing.Point(845, 157);
            this.timeLabel.Name = "timeLabel";
            this.timeLabel.Size = new System.Drawing.Size(35, 13);
            this.timeLabel.TabIndex = 6;
            this.timeLabel.Text = "label1";
            // 
            // AdventOfCode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.timeLabel);
            this.Controls.Add(this.acceleration);
            this.Controls.Add(this.scaleNumeric);
            this.Controls.Add(this.reverseButton);
            this.Controls.Add(this.toggleFlowButton);
            this.Controls.Add(this.tickButton);
            this.Controls.Add(this.drawingPanel);
            this.Name = "AdventOfCode";
            this.Text = "Advent of Code";
            ((System.ComponentModel.ISupportInitialize)(this.scaleNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acceleration)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel drawingPanel;
        private System.Windows.Forms.Timer Timer;
        private System.Windows.Forms.Button tickButton;
        private System.Windows.Forms.Button toggleFlowButton;
        private System.Windows.Forms.Button reverseButton;
        private System.Windows.Forms.NumericUpDown scaleNumeric;
        private System.Windows.Forms.NumericUpDown acceleration;
        private System.Windows.Forms.Label timeLabel;
    }
}

