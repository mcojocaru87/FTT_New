namespace FTT.UserControls
{
    partial class SettingsUC
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            txtFailAttempts = new TextBox();
            txtMaxReps = new TextBox();
            SaveButton = new Button();
            CleanupButton = new Button();
            txtMinReps = new TextBox();
            label3 = new Label();
            cbExercises = new ComboBox();
            label4 = new Label();
            MainPanel = new Panel();
            cbProgressTrys = new ComboBox();
            label8 = new Label();
            cbMinSets = new ComboBox();
            IntervalsPanel = new Panel();
            label7 = new Label();
            lblCancel = new LinkLabel();
            cbIntervals = new ComboBox();
            lblCustom = new LinkLabel();
            label6 = new Label();
            lblMode = new Label();
            label5 = new Label();
            CancelButton = new Button();
            PreSetButton = new Button();
            chkDisplayTimer = new CheckBox();
            MainPanel.SuspendLayout();
            IntervalsPanel.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label1.Location = new Point(165, 21);
            label1.Name = "label1";
            label1.Size = new Size(81, 15);
            label1.TabIndex = 0;
            label1.Text = "Fail Attempts";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label2.Location = new Point(292, 77);
            label2.Name = "label2";
            label2.Size = new Size(61, 15);
            label2.TabIndex = 1;
            label2.Text = "Max Reps";
            // 
            // txtFailAttempts
            // 
            txtFailAttempts.Location = new Point(165, 38);
            txtFailAttempts.Margin = new Padding(3, 2, 3, 2);
            txtFailAttempts.Name = "txtFailAttempts";
            txtFailAttempts.Size = new Size(110, 23);
            txtFailAttempts.TabIndex = 2;
            // 
            // txtMaxReps
            // 
            txtMaxReps.Location = new Point(291, 94);
            txtMaxReps.Margin = new Padding(3, 2, 3, 2);
            txtMaxReps.Name = "txtMaxReps";
            txtMaxReps.Size = new Size(110, 23);
            txtMaxReps.TabIndex = 3;
            // 
            // SaveButton
            // 
            SaveButton.Location = new Point(292, 217);
            SaveButton.Margin = new Padding(3, 2, 3, 2);
            SaveButton.Name = "SaveButton";
            SaveButton.Size = new Size(109, 22);
            SaveButton.TabIndex = 4;
            SaveButton.Text = "Update";
            SaveButton.UseVisualStyleBackColor = true;
            SaveButton.Click += SaveButton_Click;
            // 
            // CleanupButton
            // 
            CleanupButton.Location = new Point(21, 106);
            CleanupButton.Margin = new Padding(3, 2, 3, 2);
            CleanupButton.Name = "CleanupButton";
            CleanupButton.Size = new Size(89, 22);
            CleanupButton.TabIndex = 5;
            CleanupButton.Text = "Clean Up";
            CleanupButton.UseVisualStyleBackColor = true;
            CleanupButton.Click += CleanupButton_Click;
            // 
            // txtMinReps
            // 
            txtMinReps.Location = new Point(165, 94);
            txtMinReps.Margin = new Padding(3, 2, 3, 2);
            txtMinReps.Name = "txtMinReps";
            txtMinReps.Size = new Size(110, 23);
            txtMinReps.TabIndex = 7;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label3.Location = new Point(165, 77);
            label3.Name = "label3";
            label3.Size = new Size(58, 15);
            label3.TabIndex = 6;
            label3.Text = "Min Reps";
            // 
            // cbExercises
            // 
            cbExercises.FormattingEnabled = true;
            cbExercises.Location = new Point(21, 78);
            cbExercises.Name = "cbExercises";
            cbExercises.Size = new Size(216, 23);
            cbExercises.TabIndex = 8;
            cbExercises.SelectedIndexChanged += cbExercises_SelectedIndexChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label4.Location = new Point(21, 60);
            label4.Name = "label4";
            label4.Size = new Size(99, 15);
            label4.TabIndex = 9;
            label4.Text = "Choose Exercise:";
            // 
            // MainPanel
            // 
            MainPanel.Controls.Add(cbProgressTrys);
            MainPanel.Controls.Add(label8);
            MainPanel.Controls.Add(cbMinSets);
            MainPanel.Controls.Add(IntervalsPanel);
            MainPanel.Controls.Add(label6);
            MainPanel.Controls.Add(lblMode);
            MainPanel.Controls.Add(label5);
            MainPanel.Controls.Add(CancelButton);
            MainPanel.Controls.Add(label1);
            MainPanel.Controls.Add(label2);
            MainPanel.Controls.Add(txtFailAttempts);
            MainPanel.Controls.Add(txtMinReps);
            MainPanel.Controls.Add(SaveButton);
            MainPanel.Controls.Add(txtMaxReps);
            MainPanel.Controls.Add(label3);
            MainPanel.Dock = DockStyle.Right;
            MainPanel.Location = new Point(243, 0);
            MainPanel.Name = "MainPanel";
            MainPanel.Size = new Size(436, 286);
            MainPanel.TabIndex = 10;
            MainPanel.Visible = false;
            // 
            // cbProgressTrys
            // 
            cbProgressTrys.FormattingEnabled = true;
            cbProgressTrys.Location = new Point(292, 149);
            cbProgressTrys.Name = "cbProgressTrys";
            cbProgressTrys.Size = new Size(109, 23);
            cbProgressTrys.TabIndex = 19;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label8.Location = new Point(291, 131);
            label8.Name = "label8";
            label8.Size = new Size(80, 15);
            label8.TabIndex = 18;
            label8.Text = "Progress Trys";
            // 
            // cbMinSets
            // 
            cbMinSets.FormattingEnabled = true;
            cbMinSets.Location = new Point(166, 149);
            cbMinSets.Name = "cbMinSets";
            cbMinSets.Size = new Size(109, 23);
            cbMinSets.TabIndex = 17;
            // 
            // IntervalsPanel
            // 
            IntervalsPanel.Controls.Add(label7);
            IntervalsPanel.Controls.Add(lblCancel);
            IntervalsPanel.Controls.Add(cbIntervals);
            IntervalsPanel.Controls.Add(lblCustom);
            IntervalsPanel.Location = new Point(0, 9);
            IntervalsPanel.Name = "IntervalsPanel";
            IntervalsPanel.Size = new Size(154, 83);
            IntervalsPanel.TabIndex = 17;
            IntervalsPanel.Visible = false;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label7.Location = new Point(13, 11);
            label7.Name = "label7";
            label7.Size = new Size(56, 15);
            label7.TabIndex = 13;
            label7.Text = "Intervals";
            // 
            // lblCancel
            // 
            lblCancel.AutoSize = true;
            lblCancel.Location = new Point(91, 55);
            lblCancel.Name = "lblCancel";
            lblCancel.Size = new Size(43, 15);
            lblCancel.TabIndex = 16;
            lblCancel.TabStop = true;
            lblCancel.Text = "Cancel";
            lblCancel.Visible = false;
            lblCancel.LinkClicked += lblCancel_LinkClicked;
            // 
            // cbIntervals
            // 
            cbIntervals.FormattingEnabled = true;
            cbIntervals.Location = new Point(13, 29);
            cbIntervals.Name = "cbIntervals";
            cbIntervals.Size = new Size(121, 23);
            cbIntervals.TabIndex = 14;
            cbIntervals.SelectedIndexChanged += cbIntervals_SelectedIndexChanged;
            // 
            // lblCustom
            // 
            lblCustom.AutoSize = true;
            lblCustom.Location = new Point(13, 55);
            lblCustom.Name = "lblCustom";
            lblCustom.Size = new Size(49, 15);
            lblCustom.TabIndex = 15;
            lblCustom.TabStop = true;
            lblCustom.Text = "Custom";
            lblCustom.LinkClicked += lblCustom_LinkClicked;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label6.Location = new Point(165, 131);
            label6.Name = "label6";
            label6.Size = new Size(55, 15);
            label6.TabIndex = 11;
            label6.Text = "Min Sets";
            // 
            // lblMode
            // 
            lblMode.AutoSize = true;
            lblMode.ForeColor = Color.Green;
            lblMode.Location = new Point(338, 21);
            lblMode.Name = "lblMode";
            lblMode.Size = new Size(0, 15);
            lblMode.TabIndex = 10;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label5.Location = new Point(291, 21);
            label5.Name = "label5";
            label5.Size = new Size(42, 15);
            label5.TabIndex = 9;
            label5.Text = "Mode:";
            // 
            // CancelButton
            // 
            CancelButton.Location = new Point(292, 243);
            CancelButton.Margin = new Padding(3, 2, 3, 2);
            CancelButton.Name = "CancelButton";
            CancelButton.Size = new Size(109, 22);
            CancelButton.TabIndex = 8;
            CancelButton.Text = "Cancel";
            CancelButton.UseVisualStyleBackColor = true;
            CancelButton.Click += CancelButton_Click;
            // 
            // PreSetButton
            // 
            PreSetButton.Location = new Point(148, 106);
            PreSetButton.Margin = new Padding(3, 2, 3, 2);
            PreSetButton.Name = "PreSetButton";
            PreSetButton.Size = new Size(89, 22);
            PreSetButton.TabIndex = 11;
            PreSetButton.Text = "Pre-Set";
            PreSetButton.UseVisualStyleBackColor = true;
            PreSetButton.Click += PreSetButton_Click;
            // 
            // chkDisplayTimer
            // 
            chkDisplayTimer.AutoSize = true;
            chkDisplayTimer.Location = new Point(22, 233);
            chkDisplayTimer.Name = "chkDisplayTimer";
            chkDisplayTimer.Size = new Size(88, 19);
            chkDisplayTimer.TabIndex = 12;
            chkDisplayTimer.Text = "Show Timer";
            chkDisplayTimer.UseVisualStyleBackColor = true;
            chkDisplayTimer.CheckedChanged += chkDisplayTimer_CheckedChanged;
            // 
            // SettingsUC
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonFace;
            Controls.Add(chkDisplayTimer);
            Controls.Add(PreSetButton);
            Controls.Add(MainPanel);
            Controls.Add(label4);
            Controls.Add(cbExercises);
            Controls.Add(CleanupButton);
            Margin = new Padding(3, 2, 3, 2);
            Name = "SettingsUC";
            Size = new Size(679, 286);
            MainPanel.ResumeLayout(false);
            MainPanel.PerformLayout();
            IntervalsPanel.ResumeLayout(false);
            IntervalsPanel.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox txtFailAttempts;
        private TextBox txtMaxReps;
        private Button SaveButton;
        private Button CleanupButton;
        private TextBox txtMinReps;
        private Label label3;
        private ComboBox cbExercises;
        private Label label4;
        private Panel MainPanel;
        private Button CancelButton;
        private Button PreSetButton;
        private Label lblMode;
        private Label label5;
        private Label label6;
        private CheckBox chkDisplayTimer;
        private Label label7;
        private LinkLabel lblCancel;
        private LinkLabel lblCustom;
        private ComboBox cbIntervals;
        private Panel IntervalsPanel;
        private ComboBox cbMinSets;
        private ComboBox cbProgressTrys;
        private Label label8;
    }
}
