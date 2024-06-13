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
            txtWeight = new TextBox();
            MainPanel = new GroupBox();
            lblMaxWeight = new Label();
            label10 = new Label();
            lblMinWeight = new Label();
            label8 = new Label();
            lblCalculatedVolume = new Label();
            label7 = new Label();
            lblDefaultVolume = new Label();
            lblEquipmentUsed = new Label();
            lblDefaultRange = new Label();
            label6 = new Label();
            lable5 = new Label();
            label3 = new Label();
            label5 = new Label();
            cbIntervals = new ComboBox();
            CalculateButton = new Button();
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
            CloseButton.Location = new Point(510, 257);
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
            label2.Location = new Point(116, 104);
            label2.Name = "label2";
            label2.Size = new Size(77, 15);
            label2.TabIndex = 3;
            label2.Text = "Weight (Kg):";
            // 
            // txtWeight
            // 
            txtWeight.Location = new Point(116, 122);
            txtWeight.Name = "txtWeight";
            txtWeight.Size = new Size(192, 23);
            txtWeight.TabIndex = 4;
            txtWeight.TextChanged += txtWeight_TextChanged;
            // 
            // MainPanel
            // 
            MainPanel.Controls.Add(lblMaxWeight);
            MainPanel.Controls.Add(label10);
            MainPanel.Controls.Add(lblMinWeight);
            MainPanel.Controls.Add(label8);
            MainPanel.Controls.Add(lblCalculatedVolume);
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
            MainPanel.Size = new Size(249, 200);
            MainPanel.TabIndex = 5;
            MainPanel.TabStop = false;
            MainPanel.Text = "INFO";
            MainPanel.Visible = false;
            // 
            // lblMaxWeight
            // 
            lblMaxWeight.AutoSize = true;
            lblMaxWeight.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblMaxWeight.ForeColor = Color.DarkGreen;
            lblMaxWeight.Location = new Point(151, 173);
            lblMaxWeight.Name = "lblMaxWeight";
            lblMaxWeight.Size = new Size(81, 15);
            lblMaxWeight.TabIndex = 17;
            lblMaxWeight.Text = "62.5 - 100 Kg";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label10.ForeColor = Color.Green;
            label10.Location = new Point(7, 173);
            label10.Name = "label10";
            label10.Size = new Size(78, 15);
            label10.TabIndex = 16;
            label10.Text = "Max Weight:";
            // 
            // lblMinWeight
            // 
            lblMinWeight.AutoSize = true;
            lblMinWeight.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblMinWeight.ForeColor = Color.DarkGreen;
            lblMinWeight.Location = new Point(151, 124);
            lblMinWeight.Name = "lblMinWeight";
            lblMinWeight.Size = new Size(81, 15);
            lblMinWeight.TabIndex = 15;
            lblMinWeight.Text = "62.5 - 100 Kg";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label8.ForeColor = Color.Green;
            label8.Location = new Point(7, 124);
            label8.Name = "label8";
            label8.Size = new Size(75, 15);
            label8.TabIndex = 14;
            label8.Text = "Min Weight:";
            // 
            // lblCalculatedVolume
            // 
            lblCalculatedVolume.AutoSize = true;
            lblCalculatedVolume.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblCalculatedVolume.ForeColor = Color.DarkGreen;
            lblCalculatedVolume.Location = new Point(151, 148);
            lblCalculatedVolume.Name = "lblCalculatedVolume";
            lblCalculatedVolume.Size = new Size(81, 15);
            lblCalculatedVolume.TabIndex = 13;
            lblCalculatedVolume.Text = "62.5 - 100 Kg";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label7.ForeColor = Color.Green;
            label7.Location = new Point(7, 148);
            label7.Name = "label7";
            label7.Size = new Size(112, 15);
            label7.TabIndex = 12;
            label7.Text = "Calculated Volume:";
            // 
            // lblDefaultVolume
            // 
            lblDefaultVolume.AutoSize = true;
            lblDefaultVolume.Location = new Point(125, 86);
            lblDefaultVolume.Name = "lblDefaultVolume";
            lblDefaultVolume.Size = new Size(74, 15);
            lblDefaultVolume.TabIndex = 11;
            lblDefaultVolume.Text = "62.5 - 100 Kg";
            // 
            // lblEquipmentUsed
            // 
            lblEquipmentUsed.AutoSize = true;
            lblEquipmentUsed.Location = new Point(125, 58);
            lblEquipmentUsed.Name = "lblEquipmentUsed";
            lblEquipmentUsed.Size = new Size(59, 15);
            lblEquipmentUsed.TabIndex = 10;
            lblEquipmentUsed.Text = "Dumbbell";
            // 
            // lblDefaultRange
            // 
            lblDefaultRange.AutoSize = true;
            lblDefaultRange.Location = new Point(125, 31);
            lblDefaultRange.Name = "lblDefaultRange";
            lblDefaultRange.Size = new Size(30, 15);
            lblDefaultRange.TabIndex = 9;
            lblDefaultRange.Text = "1 - 2";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label6.Location = new Point(18, 86);
            label6.Name = "label6";
            label6.Size = new Size(97, 15);
            label6.TabIndex = 8;
            label6.Text = "Default Volume:";
            // 
            // lable5
            // 
            lable5.AutoSize = true;
            lable5.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lable5.Location = new Point(18, 58);
            lable5.Name = "lable5";
            lable5.Size = new Size(101, 15);
            lable5.TabIndex = 7;
            lable5.Text = "Equipment Used:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label3.Location = new Point(18, 31);
            label3.Name = "label3";
            label3.Size = new Size(90, 15);
            label3.TabIndex = 6;
            label3.Text = "Default Range:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label5.Location = new Point(116, 157);
            label5.Name = "label5";
            label5.Size = new Size(54, 15);
            label5.TabIndex = 7;
            label5.Text = "Interval:";
            // 
            // cbIntervals
            // 
            cbIntervals.FormattingEnabled = true;
            cbIntervals.Location = new Point(116, 175);
            cbIntervals.Name = "cbIntervals";
            cbIntervals.Size = new Size(192, 23);
            cbIntervals.TabIndex = 6;
            cbIntervals.SelectedIndexChanged += cbIntervals_SelectedIndexChanged;
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
            // CalculatorForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 338);
            Controls.Add(CalculateButton);
            Controls.Add(label5);
            Controls.Add(cbIntervals);
            Controls.Add(MainPanel);
            Controls.Add(txtWeight);
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
        private TextBox txtWeight;
        private GroupBox MainPanel;
        private Label lable5;
        private Label label3;
        private Label label5;
        private ComboBox cbIntervals;
        private Label label6;
        private Label lblDefaultRange;
        private Label lblEquipmentUsed;
        private Label lblDefaultVolume;
        private Label lblCalculatedVolume;
        private Label label7;
        private Button CalculateButton;
        private Label lblMaxWeight;
        private Label label10;
        private Label lblMinWeight;
        private Label label8;
    }
}