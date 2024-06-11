namespace FTT
{
    partial class SwitchIntervalRangeForm
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
            cbInterval = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            txtExerciseName = new TextBox();
            SaveButton = new Button();
            CancelButton = new Button();
            txtMinReps = new TextBox();
            label3 = new Label();
            txtMaxReps = new TextBox();
            label4 = new Label();
            MainPanel = new GroupBox();
            lblCancelCustom = new LinkLabel();
            MainPanel.SuspendLayout();
            SuspendLayout();
            // 
            // cbInterval
            // 
            cbInterval.FormattingEnabled = true;
            cbInterval.Location = new Point(237, 102);
            cbInterval.Name = "cbInterval";
            cbInterval.Size = new Size(231, 23);
            cbInterval.TabIndex = 0;
            cbInterval.SelectedIndexChanged += cbInterval_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(237, 84);
            label1.Name = "label1";
            label1.Size = new Size(49, 15);
            label1.TabIndex = 1;
            label1.Text = "Interval:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(237, 31);
            label2.Name = "label2";
            label2.Size = new Size(52, 15);
            label2.TabIndex = 2;
            label2.Text = "Exercise:";
            // 
            // txtExerciseName
            // 
            txtExerciseName.Location = new Point(237, 49);
            txtExerciseName.Name = "txtExerciseName";
            txtExerciseName.ReadOnly = true;
            txtExerciseName.Size = new Size(231, 23);
            txtExerciseName.TabIndex = 3;
            // 
            // SaveButton
            // 
            SaveButton.Location = new Point(613, 274);
            SaveButton.Name = "SaveButton";
            SaveButton.Size = new Size(75, 23);
            SaveButton.TabIndex = 4;
            SaveButton.Text = "Save";
            SaveButton.UseVisualStyleBackColor = true;
            SaveButton.Click += SaveButton_Click;
            // 
            // CancelButton
            // 
            CancelButton.Location = new Point(613, 303);
            CancelButton.Name = "CancelButton";
            CancelButton.Size = new Size(75, 23);
            CancelButton.TabIndex = 5;
            CancelButton.Text = "Cancel";
            CancelButton.UseVisualStyleBackColor = true;
            CancelButton.Click += CancelButton_Click;
            // 
            // txtMinReps
            // 
            txtMinReps.Location = new Point(25, 50);
            txtMinReps.Name = "txtMinReps";
            txtMinReps.Size = new Size(231, 23);
            txtMinReps.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(25, 32);
            label3.Name = "label3";
            label3.Size = new Size(59, 15);
            label3.TabIndex = 4;
            label3.Text = "Min Reps:";
            // 
            // txtMaxReps
            // 
            txtMaxReps.Location = new Point(25, 106);
            txtMaxReps.Name = "txtMaxReps";
            txtMaxReps.Size = new Size(231, 23);
            txtMaxReps.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(25, 88);
            label4.Name = "label4";
            label4.Size = new Size(61, 15);
            label4.TabIndex = 6;
            label4.Text = "Max Reps:";
            // 
            // MainPanel
            // 
            MainPanel.Controls.Add(txtMaxReps);
            MainPanel.Controls.Add(label3);
            MainPanel.Controls.Add(label4);
            MainPanel.Controls.Add(txtMinReps);
            MainPanel.Location = new Point(210, 146);
            MainPanel.Name = "MainPanel";
            MainPanel.Size = new Size(280, 161);
            MainPanel.TabIndex = 8;
            MainPanel.TabStop = false;
            MainPanel.Text = "Custom";
            MainPanel.Visible = false;
            // 
            // lblCancelCustom
            // 
            lblCancelCustom.AutoSize = true;
            lblCancelCustom.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblCancelCustom.Location = new Point(474, 102);
            lblCancelCustom.Name = "lblCancelCustom";
            lblCancelCustom.Size = new Size(20, 21);
            lblCancelCustom.TabIndex = 9;
            lblCancelCustom.TabStop = true;
            lblCancelCustom.Text = "X";
            lblCancelCustom.Visible = false;
            lblCancelCustom.LinkClicked += lblCancelCustom_LinkClicked;
            // 
            // SwitchIntervalRangeForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 338);
            Controls.Add(lblCancelCustom);
            Controls.Add(MainPanel);
            Controls.Add(CancelButton);
            Controls.Add(SaveButton);
            Controls.Add(txtExerciseName);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(cbInterval);
            FormBorderStyle = FormBorderStyle.None;
            Name = "SwitchIntervalRangeForm";
            Opacity = 0.9D;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SwitchIntervalRangeForm";
            MainPanel.ResumeLayout(false);
            MainPanel.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cbInterval;
        private Label label1;
        private Label label2;
        private TextBox txtExerciseName;
        private Button SaveButton;
        private Button CancelButton;
        private TextBox txtMaxReps;
        private Label label4;
        private TextBox txtMinReps;
        private Label label3;
        private GroupBox MainPanel;
        private LinkLabel lblCancelCustom;
    }
}