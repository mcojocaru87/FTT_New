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
            groupBox1 = new GroupBox();
            label3 = new Label();
            lable5 = new Label();
            label5 = new Label();
            cbIntervals = new ComboBox();
            label6 = new Label();
            lblDefaultRange = new Label();
            lblEquipmentUsed = new Label();
            lblVolumeRange = new Label();
            groupBox1.SuspendLayout();
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
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(lblVolumeRange);
            groupBox1.Controls.Add(lblEquipmentUsed);
            groupBox1.Controls.Add(lblDefaultRange);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(lable5);
            groupBox1.Controls.Add(label3);
            groupBox1.Font = new Font("Segoe UI", 9F);
            groupBox1.Location = new Point(357, 51);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(228, 147);
            groupBox1.TabIndex = 5;
            groupBox1.TabStop = false;
            groupBox1.Text = "INFO";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label3.Location = new Point(19, 38);
            label3.Name = "label3";
            label3.Size = new Size(90, 15);
            label3.TabIndex = 6;
            label3.Text = "Default Range:";
            // 
            // lable5
            // 
            lable5.AutoSize = true;
            lable5.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lable5.Location = new Point(6, 65);
            lable5.Name = "lable5";
            lable5.Size = new Size(101, 15);
            lable5.TabIndex = 7;
            lable5.Text = "Equipment Used:";
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
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label6.Location = new Point(17, 93);
            label6.Name = "label6";
            label6.Size = new Size(90, 15);
            label6.TabIndex = 8;
            label6.Text = "Volume Range:";
            // 
            // lblDefaultRange
            // 
            lblDefaultRange.AutoSize = true;
            lblDefaultRange.Location = new Point(109, 38);
            lblDefaultRange.Name = "lblDefaultRange";
            lblDefaultRange.Size = new Size(30, 15);
            lblDefaultRange.TabIndex = 9;
            lblDefaultRange.Text = "1 - 2";
            // 
            // lblEquipmentUsed
            // 
            lblEquipmentUsed.AutoSize = true;
            lblEquipmentUsed.Location = new Point(109, 65);
            lblEquipmentUsed.Name = "lblEquipmentUsed";
            lblEquipmentUsed.Size = new Size(59, 15);
            lblEquipmentUsed.TabIndex = 10;
            lblEquipmentUsed.Text = "Dumbbell";
            // 
            // lblVolumeRange
            // 
            lblVolumeRange.AutoSize = true;
            lblVolumeRange.Location = new Point(109, 93);
            lblVolumeRange.Name = "lblVolumeRange";
            lblVolumeRange.Size = new Size(74, 15);
            lblVolumeRange.TabIndex = 11;
            lblVolumeRange.Text = "62.5 - 100 Kg";
            // 
            // CalculatorForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 338);
            Controls.Add(label5);
            Controls.Add(cbIntervals);
            Controls.Add(groupBox1);
            Controls.Add(txtWeight);
            Controls.Add(label2);
            Controls.Add(CloseButton);
            Controls.Add(label1);
            Controls.Add(cbExercises);
            FormBorderStyle = FormBorderStyle.None;
            Name = "CalculatorForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "CalculatorForm";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cbExercises;
        private Label label1;
        private Button CloseButton;
        private Label label2;
        private TextBox txtWeight;
        private GroupBox groupBox1;
        private Label lable5;
        private Label label3;
        private Label label5;
        private ComboBox cbIntervals;
        private Label label6;
        private Label lblDefaultRange;
        private Label lblEquipmentUsed;
        private Label lblVolumeRange;
    }
}