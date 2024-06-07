namespace FTT.UserControls.DataTables.RepRangeIntervalControls
{
    partial class RepRangeIntervalForm
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
            cbIsSelected = new ComboBox();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            txtId = new TextBox();
            label2 = new Label();
            CancelButton = new Button();
            SaveButton = new Button();
            label1 = new Label();
            txtMinReps = new TextBox();
            txtMaxReps = new TextBox();
            SuspendLayout();
            // 
            // cbExercises
            // 
            cbExercises.FormattingEnabled = true;
            cbExercises.Location = new Point(73, 72);
            cbExercises.Margin = new Padding(3, 2, 3, 2);
            cbExercises.Name = "cbExercises";
            cbExercises.Size = new Size(110, 23);
            cbExercises.TabIndex = 37;
            // 
            // cbIsSelected
            // 
            cbIsSelected.FormattingEnabled = true;
            cbIsSelected.Location = new Point(73, 153);
            cbIsSelected.Margin = new Padding(3, 2, 3, 2);
            cbIsSelected.Name = "cbIsSelected";
            cbIsSelected.Size = new Size(110, 23);
            cbIsSelected.TabIndex = 36;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(2, 156);
            label6.Name = "label6";
            label6.Size = new Size(65, 15);
            label6.TabIndex = 35;
            label6.Text = "Is Selected:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(6, 129);
            label5.Name = "label5";
            label5.Size = new Size(61, 15);
            label5.TabIndex = 33;
            label5.Text = "Max Reps:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(8, 102);
            label4.Name = "label4";
            label4.Size = new Size(59, 15);
            label4.TabIndex = 31;
            label4.Text = "Min Reps:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(15, 75);
            label3.Name = "label3";
            label3.Size = new Size(52, 15);
            label3.TabIndex = 30;
            label3.Text = "Exercise:";
            // 
            // txtId
            // 
            txtId.Location = new Point(73, 45);
            txtId.Margin = new Padding(3, 2, 3, 2);
            txtId.Name = "txtId";
            txtId.ReadOnly = true;
            txtId.Size = new Size(110, 23);
            txtId.TabIndex = 29;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(46, 48);
            label2.Name = "label2";
            label2.Size = new Size(21, 15);
            label2.TabIndex = 28;
            label2.Text = "ID:";
            // 
            // CancelButton
            // 
            CancelButton.Location = new Point(146, 199);
            CancelButton.Margin = new Padding(3, 2, 3, 2);
            CancelButton.Name = "CancelButton";
            CancelButton.Size = new Size(82, 22);
            CancelButton.TabIndex = 27;
            CancelButton.Text = "Cancel";
            CancelButton.UseVisualStyleBackColor = true;
            CancelButton.Click += CancelButton_Click;
            // 
            // SaveButton
            // 
            SaveButton.Location = new Point(3, 199);
            SaveButton.Margin = new Padding(3, 2, 3, 2);
            SaveButton.Name = "SaveButton";
            SaveButton.Size = new Size(82, 22);
            SaveButton.TabIndex = 26;
            SaveButton.Text = "Save";
            SaveButton.UseVisualStyleBackColor = true;
            SaveButton.Click += SaveButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label1.Location = new Point(40, 7);
            label1.Name = "label1";
            label1.Size = new Size(150, 21);
            label1.TabIndex = 25;
            label1.Text = "Add / Edit Interval";
            // 
            // txtMinReps
            // 
            txtMinReps.Location = new Point(73, 99);
            txtMinReps.Name = "txtMinReps";
            txtMinReps.Size = new Size(110, 23);
            txtMinReps.TabIndex = 38;
            // 
            // txtMaxReps
            // 
            txtMaxReps.Location = new Point(73, 126);
            txtMaxReps.Name = "txtMaxReps";
            txtMaxReps.Size = new Size(110, 23);
            txtMaxReps.TabIndex = 39;
            // 
            // RepRangeIntervalForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(230, 228);
            Controls.Add(txtMaxReps);
            Controls.Add(txtMinReps);
            Controls.Add(cbExercises);
            Controls.Add(cbIsSelected);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(txtId);
            Controls.Add(label2);
            Controls.Add(CancelButton);
            Controls.Add(SaveButton);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "RepRangeIntervalForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "RepRangeIntervalForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cbExercises;
        private ComboBox cbIsSelected;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private TextBox txtId;
        private Label label2;
        private Button CancelButton;
        private Button SaveButton;
        private Label label1;
        private TextBox txtMinReps;
        private TextBox txtMaxReps;
    }
}