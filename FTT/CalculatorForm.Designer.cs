namespace FTT
{
    partial class CalculatorForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            cbExercises = new ComboBox();
            label1 = new Label();
            CloseButton = new Button();
            label2 = new Label();
            MainPanel = new GroupBox();
            lblCalculatedTotalMaxVolume = new Label();
            label17 = new Label();
            lblCalculatedMaxVolume = new Label();
            label15 = new Label();
            cbMaxWeight = new ComboBox();
            cbMinWeight = new ComboBox();
            lblCalculatedTotalMinVolume = new Label();
            label13 = new Label();
            lblDefaultTotalVolume = new Label();
            label12 = new Label();
            label10 = new Label();
            label8 = new Label();
            lblCalculatedMinVolume = new Label();
            label7 = new Label();
            lblDefaultVolume = new Label();
            lblEquipmentUsed = new Label();
            lblDefaultRange = new Label();
            label6 = new Label();
            lable5 = new Label();
            label3 = new Label();
            label5 = new Label();
            cbDefaultIntervals = new ComboBox();
            CalculateButton = new Button();
            label4 = new Label();
            cbDefaultSets = new ComboBox();
            label9 = new Label();
            cbNewSets = new ComboBox();
            label11 = new Label();
            cbNewIntervals = new ComboBox();
            cbWeight = new ComboBox();
            MainPanel.SuspendLayout();
            SuspendLayout();
            // 
            // cbExercises
            // 
            cbExercises.FormattingEnabled = true;
            cbExercises.Location = new Point(116, 69);
            cbExercises.Name = "cbExercises";
            cbExercises.Size = new Size(192, 23);
            cbExercises.TabIndex = 0;
            cbExercises.SelectedIndexChanged += cbExercises_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label1.Location = new Point(116, 51);
            label1.Name = "label1";
            label1.Size = new Size(56, 15);
            label1.TabIndex = 1;
            label1.Text = "Exercise:";
            // 
            // CloseButton
            // 
            CloseButton.Location = new Point(233, 257);
            CloseButton.Name = "CloseButton";
            CloseButton.Size = new Size(75, 23);
            CloseButton.TabIndex = 2;
            CloseButton.Text = "Close";
            CloseButton.UseVisualStyleBackColor = true;
            CloseButton.Click += CloseButton_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label2.Location = new Point(116, 95);
            label2.Name = "label2";
            label2.Size = new Size(77, 15);
            label2.TabIndex = 3;
            label2.Text = "Weight (Kg):";
            // 
            // MainPanel
            // 
            MainPanel.Controls.Add(lblCalculatedTotalMaxVolume);
            MainPanel.Controls.Add(label17);
            MainPanel.Controls.Add(lblCalculatedMaxVolume);
            MainPanel.Controls.Add(label15);
            MainPanel.Controls.Add(cbMaxWeight);
            MainPanel.Controls.Add(cbMinWeight);
            MainPanel.Controls.Add(lblCalculatedTotalMinVolume);
            MainPanel.Controls.Add(label13);
            MainPanel.Controls.Add(lblDefaultTotalVolume);
            MainPanel.Controls.Add(label12);
            MainPanel.Controls.Add(label10);
            MainPanel.Controls.Add(label8);
            MainPanel.Controls.Add(lblCalculatedMinVolume);
            MainPanel.Controls.Add(label7);
            MainPanel.Controls.Add(lblDefaultVolume);
            MainPanel.Controls.Add(lblEquipmentUsed);
            MainPanel.Controls.Add(lblDefaultRange);
            MainPanel.Controls.Add(label6);
            MainPanel.Controls.Add(lable5);
            MainPanel.Controls.Add(label3);
            MainPanel.Font = new Font("Segoe UI", 9F);
            MainPanel.Location = new Point(336, 51);
            MainPanel.Name = "MainPanel";
            MainPanel.Size = new Size(276, 275);
            MainPanel.TabIndex = 5;
            MainPanel.TabStop = false;
            MainPanel.Text = "INFO";
            MainPanel.Visible = false;
            // 
            // lblCalculatedTotalMaxVolume
            // 
            lblCalculatedTotalMaxVolume.AutoSize = true;
            lblCalculatedTotalMaxVolume.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblCalculatedTotalMaxVolume.ForeColor = Color.DarkGreen;
            lblCalculatedTotalMaxVolume.Location = new Point(147, 253);
            lblCalculatedTotalMaxVolume.Name = "lblCalculatedTotalMaxVolume";
            lblCalculatedTotalMaxVolume.Size = new Size(29, 15);
            lblCalculatedTotalMaxVolume.TabIndex = 27;
            lblCalculatedTotalMaxVolume.Text = "N/A";
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label17.ForeColor = Color.Green;
            label17.Location = new Point(30, 253);
            label17.Name = "label17";
            label17.Size = new Size(109, 15);
            label17.TabIndex = 26;
            label17.Text = "Total Max Volume:";
            // 
            // lblCalculatedMaxVolume
            // 
            lblCalculatedMaxVolume.AutoSize = true;
            lblCalculatedMaxVolume.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblCalculatedMaxVolume.ForeColor = Color.DarkGreen;
            lblCalculatedMaxVolume.Location = new Point(150, 195);
            lblCalculatedMaxVolume.Name = "lblCalculatedMaxVolume";
            lblCalculatedMaxVolume.Size = new Size(29, 15);
            lblCalculatedMaxVolume.TabIndex = 25;
            lblCalculatedMaxVolume.Text = "N/A";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label15.ForeColor = Color.Green;
            label15.Location = new Point(149, 180);
            label15.Name = "label15";
            label15.Size = new Size(79, 15);
            label15.TabIndex = 24;
            label15.Text = "Max Volume:";
            // 
            // cbMaxWeight
            // 
            cbMaxWeight.FormattingEnabled = true;
            cbMaxWeight.Location = new Point(149, 154);
            cbMaxWeight.Name = "cbMaxWeight";
            cbMaxWeight.Size = new Size(98, 23);
            cbMaxWeight.TabIndex = 23;
            cbMaxWeight.SelectedIndexChanged += cbMaxWeight_SelectedIndexChanged;
            // 
            // cbMinWeight
            // 
            cbMinWeight.FormattingEnabled = true;
            cbMinWeight.Location = new Point(31, 154);
            cbMinWeight.Name = "cbMinWeight";
            cbMinWeight.Size = new Size(98, 23);
            cbMinWeight.TabIndex = 22;
            cbMinWeight.SelectedIndexChanged += cbMinWeight_SelectedIndexChanged;
            // 
            // lblCalculatedTotalMinVolume
            // 
            lblCalculatedTotalMinVolume.AutoSize = true;
            lblCalculatedTotalMinVolume.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblCalculatedTotalMinVolume.ForeColor = Color.DarkGreen;
            lblCalculatedTotalMinVolume.Location = new Point(147, 230);
            lblCalculatedTotalMinVolume.Name = "lblCalculatedTotalMinVolume";
            lblCalculatedTotalMinVolume.Size = new Size(29, 15);
            lblCalculatedTotalMinVolume.TabIndex = 21;
            lblCalculatedTotalMinVolume.Text = "N/A";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label13.ForeColor = Color.Green;
            label13.Location = new Point(30, 230);
            label13.Name = "label13";
            label13.Size = new Size(106, 15);
            label13.TabIndex = 20;
            label13.Text = "Total Min Volume:";
            // 
            // lblDefaultTotalVolume
            // 
            lblDefaultTotalVolume.AutoSize = true;
            lblDefaultTotalVolume.Location = new Point(125, 106);
            lblDefaultTotalVolume.Name = "lblDefaultTotalVolume";
            lblDefaultTotalVolume.Size = new Size(30, 15);
            lblDefaultTotalVolume.TabIndex = 19;
            lblDefaultTotalVolume.Text = "0 Kg";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label12.Location = new Point(26, 106);
            label12.Name = "label12";
            label12.Size = new Size(82, 15);
            label12.TabIndex = 18;
            label12.Text = "Total Volume:";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label10.ForeColor = Color.Green;
            label10.Location = new Point(149, 136);
            label10.Name = "label10";
            label10.Size = new Size(78, 15);
            label10.TabIndex = 16;
            label10.Text = "Max Weight:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label8.ForeColor = Color.Green;
            label8.Location = new Point(31, 136);
            label8.Name = "label8";
            label8.Size = new Size(75, 15);
            label8.TabIndex = 14;
            label8.Text = "Min Weight:";
            // 
            // lblCalculatedMinVolume
            // 
            lblCalculatedMinVolume.AutoSize = true;
            lblCalculatedMinVolume.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblCalculatedMinVolume.ForeColor = Color.DarkGreen;
            lblCalculatedMinVolume.Location = new Point(31, 195);
            lblCalculatedMinVolume.Name = "lblCalculatedMinVolume";
            lblCalculatedMinVolume.Size = new Size(29, 15);
            lblCalculatedMinVolume.TabIndex = 13;
            lblCalculatedMinVolume.Text = "N/A";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label7.ForeColor = Color.Green;
            label7.Location = new Point(30, 180);
            label7.Name = "label7";
            label7.Size = new Size(76, 15);
            label7.TabIndex = 12;
            label7.Text = "Min Volume:";
            // 
            // lblDefaultVolume
            // 
            lblDefaultVolume.AutoSize = true;
            lblDefaultVolume.Location = new Point(125, 78);
            lblDefaultVolume.Name = "lblDefaultVolume";
            lblDefaultVolume.Size = new Size(30, 15);
            lblDefaultVolume.TabIndex = 11;
            lblDefaultVolume.Text = "0 Kg";
            // 
            // lblEquipmentUsed
            // 
            lblEquipmentUsed.AutoSize = true;
            lblEquipmentUsed.Location = new Point(125, 50);
            lblEquipmentUsed.Name = "lblEquipmentUsed";
            lblEquipmentUsed.Size = new Size(0, 15);
            lblEquipmentUsed.TabIndex = 10;
            // 
            // lblDefaultRange
            // 
            lblDefaultRange.AutoSize = true;
            lblDefaultRange.Location = new Point(125, 23);
            lblDefaultRange.Name = "lblDefaultRange";
            lblDefaultRange.Size = new Size(30, 15);
            lblDefaultRange.TabIndex = 9;
            lblDefaultRange.Text = "1 - 2";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label6.Location = new Point(11, 78);
            label6.Name = "label6";
            label6.Size = new Size(97, 15);
            label6.TabIndex = 8;
            label6.Text = "Default Volume:";
            // 
            // lable5
            // 
            lable5.AutoSize = true;
            lable5.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lable5.Location = new Point(7, 50);
            lable5.Name = "lable5";
            lable5.Size = new Size(101, 15);
            lable5.TabIndex = 7;
            lable5.Text = "Equipment Used:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label3.Location = new Point(18, 23);
            label3.Name = "label3";
            label3.Size = new Size(90, 15);
            label3.TabIndex = 6;
            label3.Text = "Default Range:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label5.Location = new Point(116, 139);
            label5.Name = "label5";
            label5.Size = new Size(78, 15);
            label5.TabIndex = 7;
            label5.Text = "Def Interval:";
            // 
            // cbDefaultIntervals
            // 
            cbDefaultIntervals.FormattingEnabled = true;
            cbDefaultIntervals.Location = new Point(116, 157);
            cbDefaultIntervals.Name = "cbDefaultIntervals";
            cbDefaultIntervals.Size = new Size(90, 23);
            cbDefaultIntervals.TabIndex = 6;
            cbDefaultIntervals.SelectedIndexChanged += cbDefaultIntervals_SelectedIndexChanged;
            // 
            // CalculateButton
            // 
            CalculateButton.Location = new Point(116, 257);
            CalculateButton.Name = "CalculateButton";
            CalculateButton.Size = new Size(75, 23);
            CalculateButton.TabIndex = 8;
            CalculateButton.Text = "Calculate";
            CalculateButton.UseVisualStyleBackColor = true;
            CalculateButton.Click += CalculateButton_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label4.Location = new Point(220, 139);
            label4.Name = "label4";
            label4.Size = new Size(58, 15);
            label4.TabIndex = 10;
            label4.Text = "Def Sets:";
            // 
            // cbDefaultSets
            // 
            cbDefaultSets.FormattingEnabled = true;
            cbDefaultSets.Location = new Point(220, 157);
            cbDefaultSets.Name = "cbDefaultSets";
            cbDefaultSets.Size = new Size(88, 23);
            cbDefaultSets.TabIndex = 9;
            cbDefaultSets.SelectedIndexChanged += cbDefaultSets_SelectedIndexChanged;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label9.ForeColor = Color.Green;
            label9.Location = new Point(220, 183);
            label9.Name = "label9";
            label9.Size = new Size(63, 15);
            label9.TabIndex = 12;
            label9.Text = "New Sets:";
            // 
            // cbNewSets
            // 
            cbNewSets.BackColor = SystemColors.Window;
            cbNewSets.FormattingEnabled = true;
            cbNewSets.Location = new Point(220, 201);
            cbNewSets.Name = "cbNewSets";
            cbNewSets.Size = new Size(88, 23);
            cbNewSets.TabIndex = 11;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label11.ForeColor = Color.Green;
            label11.Location = new Point(116, 183);
            label11.Name = "label11";
            label11.Size = new Size(83, 15);
            label11.TabIndex = 14;
            label11.Text = "New Interval:";
            // 
            // cbNewIntervals
            // 
            cbNewIntervals.BackColor = SystemColors.Window;
            cbNewIntervals.FormattingEnabled = true;
            cbNewIntervals.Location = new Point(116, 201);
            cbNewIntervals.Name = "cbNewIntervals";
            cbNewIntervals.Size = new Size(90, 23);
            cbNewIntervals.TabIndex = 13;
            // 
            // cbWeight
            // 
            cbWeight.FormattingEnabled = true;
            cbWeight.Location = new Point(116, 113);
            cbWeight.Name = "cbWeight";
            cbWeight.Size = new Size(192, 23);
            cbWeight.TabIndex = 15;
            cbWeight.SelectedIndexChanged += cbWeight_SelectedIndexChanged;
            // 
            // CalculatorForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 338);
            Controls.Add(cbWeight);
            Controls.Add(label11);
            Controls.Add(cbNewIntervals);
            Controls.Add(label9);
            Controls.Add(cbNewSets);
            Controls.Add(label4);
            Controls.Add(cbDefaultSets);
            Controls.Add(CalculateButton);
            Controls.Add(label5);
            Controls.Add(cbDefaultIntervals);
            Controls.Add(MainPanel);
            Controls.Add(label2);
            Controls.Add(CloseButton);
            Controls.Add(label1);
            Controls.Add(cbExercises);
            FormBorderStyle = FormBorderStyle.None;
            Name = "CalculatorForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "CalculatorForm";
            MainPanel.ResumeLayout(false);
            MainPanel.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cbExercises;
        private Label label1;
        private Button CloseButton;
        private Label label2;
        private GroupBox MainPanel;
        private Label lable5;
        private Label label3;
        private Label label5;
        private ComboBox cbDefaultIntervals;
        private Label label6;
        private Label lblDefaultRange;
        private Label lblEquipmentUsed;
        private Label lblDefaultVolume;
        private Label lblCalculatedMinVolume;
        private Label label7;
        private Button CalculateButton;
        private Label label10;
        private Label label8;
        private Label label4;
        private ComboBox cbDefaultSets;
        private Label label9;
        private ComboBox cbNewSets;
        private Label lblDefaultTotalVolume;
        private Label label12;
        private Label lblCalculatedTotalMinVolume;
        private Label label13;
        private Label label11;
        private ComboBox cbNewIntervals;
        private ComboBox cbWeight;
        private ComboBox cbMaxWeight;
        private ComboBox cbMinWeight;
        private Label lblCalculatedTotalMaxVolume;
        private Label label17;
        private Label lblCalculatedMaxVolume;
        private Label label15;
    }
}