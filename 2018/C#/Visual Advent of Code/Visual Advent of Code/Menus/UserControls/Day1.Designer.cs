namespace Visual_Advent_of_Code.Menus {
    partial class Day1 {
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint1 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 0D);
            this.frequencyChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.stepSolvePart1 = new System.Windows.Forms.Button();
            this.stepSolveNumeric = new System.Windows.Forms.NumericUpDown();
            this.stepSolveTimer = new System.Windows.Forms.Timer(this.components);
            this.stepSolving1BackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.frequencyLabel = new System.Windows.Forms.Label();
            this.solvePart2 = new System.Windows.Forms.Button();
            this.solving2BackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.solvePart1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.frequencyChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stepSolveNumeric)).BeginInit();
            this.SuspendLayout();
            // 
            // frequencyChart
            // 
            this.frequencyChart.BackColor = System.Drawing.Color.Gray;
            chartArea1.BackColor = System.Drawing.Color.Gray;
            chartArea1.Name = "ChartArea1";
            this.frequencyChart.ChartAreas.Add(chartArea1);
            this.frequencyChart.Location = new System.Drawing.Point(25, 25);
            this.frequencyChart.Name = "frequencyChart";
            this.frequencyChart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Light;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Name = "Series2";
            series1.Points.Add(dataPoint1);
            this.frequencyChart.Series.Add(series1);
            this.frequencyChart.Size = new System.Drawing.Size(700, 525);
            this.frequencyChart.TabIndex = 0;
            // 
            // stepSolvePart1
            // 
            this.stepSolvePart1.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.stepSolvePart1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.stepSolvePart1.Font = new System.Drawing.Font("Arial", 8F);
            this.stepSolvePart1.ForeColor = System.Drawing.Color.White;
            this.stepSolvePart1.Location = new System.Drawing.Point(731, 115);
            this.stepSolvePart1.Name = "stepSolvePart1";
            this.stepSolvePart1.Size = new System.Drawing.Size(110, 23);
            this.stepSolvePart1.TabIndex = 3;
            this.stepSolvePart1.Text = "Step-Solve Part 1";
            this.stepSolvePart1.UseVisualStyleBackColor = true;
            this.stepSolvePart1.Click += new System.EventHandler(this.stepSolvePart1_Click);
            // 
            // stepSolveNumeric
            // 
            this.stepSolveNumeric.BackColor = System.Drawing.Color.DimGray;
            this.stepSolveNumeric.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.stepSolveNumeric.Font = new System.Drawing.Font("Arial", 8F);
            this.stepSolveNumeric.ForeColor = System.Drawing.Color.White;
            this.stepSolveNumeric.Location = new System.Drawing.Point(732, 145);
            this.stepSolveNumeric.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.stepSolveNumeric.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.stepSolveNumeric.Name = "stepSolveNumeric";
            this.stepSolveNumeric.Size = new System.Drawing.Size(110, 20);
            this.stepSolveNumeric.TabIndex = 4;
            this.stepSolveNumeric.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.stepSolveNumeric.ValueChanged += new System.EventHandler(this.stepSolveNumeric_ValueChanged);
            // 
            // stepSolveTimer
            // 
            this.stepSolveTimer.Enabled = true;
            this.stepSolveTimer.Tick += new System.EventHandler(this.stepSolveTimer_Tick);
            // 
            // stepSolving1BackgroundWorker
            // 
            this.stepSolving1BackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.stepSolving1BackgroundWorker_DoWork);
            this.stepSolving1BackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.stepSolving1BackgroundWorker_RunWorkerCompleted);
            // 
            // frequencyLabel
            // 
            this.frequencyLabel.AutoSize = true;
            this.frequencyLabel.Font = new System.Drawing.Font("Arial", 8F);
            this.frequencyLabel.ForeColor = System.Drawing.Color.White;
            this.frequencyLabel.Location = new System.Drawing.Point(730, 25);
            this.frequencyLabel.Name = "frequencyLabel";
            this.frequencyLabel.Size = new System.Drawing.Size(35, 14);
            this.frequencyLabel.TabIndex = 5;
            this.frequencyLabel.Text = "label1";
            // 
            // solvePart2
            // 
            this.solvePart2.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.solvePart2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.solvePart2.Font = new System.Drawing.Font("Arial", 8F);
            this.solvePart2.ForeColor = System.Drawing.Color.White;
            this.solvePart2.Location = new System.Drawing.Point(731, 85);
            this.solvePart2.Name = "solvePart2";
            this.solvePart2.Size = new System.Drawing.Size(110, 23);
            this.solvePart2.TabIndex = 6;
            this.solvePart2.Text = "Solve Part 2";
            this.solvePart2.UseVisualStyleBackColor = true;
            this.solvePart2.Click += new System.EventHandler(this.solvePart2_Click);
            // 
            // solving2BackgroundWorker
            // 
            this.solving2BackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.solving2BackgroundWorker_DoWork);
            this.solving2BackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.solving2BackgroundWorker_RunWorkerCompleted);
            // 
            // solvePart1
            // 
            this.solvePart1.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.solvePart1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.solvePart1.Font = new System.Drawing.Font("Arial", 8F);
            this.solvePart1.ForeColor = System.Drawing.Color.White;
            this.solvePart1.Location = new System.Drawing.Point(731, 55);
            this.solvePart1.Name = "solvePart1";
            this.solvePart1.Size = new System.Drawing.Size(110, 23);
            this.solvePart1.TabIndex = 1;
            this.solvePart1.Text = "Solve Part 1";
            this.solvePart1.UseVisualStyleBackColor = true;
            this.solvePart1.Click += new System.EventHandler(this.solvePart1_Click);
            // 
            // Day1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.Controls.Add(this.solvePart2);
            this.Controls.Add(this.frequencyLabel);
            this.Controls.Add(this.stepSolveNumeric);
            this.Controls.Add(this.stepSolvePart1);
            this.Controls.Add(this.solvePart1);
            this.Controls.Add(this.frequencyChart);
            this.Name = "Day1";
            this.Size = new System.Drawing.Size(850, 575);
            ((System.ComponentModel.ISupportInitialize)(this.frequencyChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stepSolveNumeric)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart frequencyChart;
        private System.Windows.Forms.Button stepSolvePart1;
        private System.Windows.Forms.NumericUpDown stepSolveNumeric;
        private System.Windows.Forms.Timer stepSolveTimer;
        private System.ComponentModel.BackgroundWorker stepSolving1BackgroundWorker;
        private System.Windows.Forms.Label frequencyLabel;
        private System.Windows.Forms.Button solvePart2;
        private System.ComponentModel.BackgroundWorker solving2BackgroundWorker;
        private System.Windows.Forms.Button solvePart1;
    }
}
