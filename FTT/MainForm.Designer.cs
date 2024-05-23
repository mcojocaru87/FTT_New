namespace FTT
{
    partial class MainForm
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
            DatabaseButton = new Button();
            SettingsButton = new Button();
            TrackButton = new Button();
            MainPanel = new Panel();
            BeginWorkoutButton = new Button();
            label1 = new Label();
            WorkoutStatusPanel = new Panel();
            lblWorkoutStatus = new Label();
            WorkoutStatusPanel.SuspendLayout();
            SuspendLayout();
            // 
            // DatabaseButton
            // 
            DatabaseButton.Location = new Point(694, 12);
            DatabaseButton.Name = "DatabaseButton";
            DatabaseButton.Size = new Size(94, 29);
            DatabaseButton.TabIndex = 0;
            DatabaseButton.Text = "Database";
            DatabaseButton.UseVisualStyleBackColor = true;
            DatabaseButton.Click += DatabaseButton_Click;
            // 
            // SettingsButton
            // 
            SettingsButton.Location = new Point(594, 12);
            SettingsButton.Name = "SettingsButton";
            SettingsButton.Size = new Size(94, 29);
            SettingsButton.TabIndex = 1;
            SettingsButton.Text = "Settings";
            SettingsButton.UseVisualStyleBackColor = true;
            SettingsButton.Click += SettingsButton_Click;
            // 
            // TrackButton
            // 
            TrackButton.Location = new Point(12, 12);
            TrackButton.Name = "TrackButton";
            TrackButton.Size = new Size(94, 29);
            TrackButton.TabIndex = 2;
            TrackButton.Text = "Track";
            TrackButton.UseVisualStyleBackColor = true;
            TrackButton.Click += TrackButton_Click;
            // 
            // MainPanel
            // 
            MainPanel.Location = new Point(12, 57);
            MainPanel.Name = "MainPanel";
            MainPanel.Size = new Size(776, 381);
            MainPanel.TabIndex = 3;
            // 
            // BeginWorkoutButton
            // 
            BeginWorkoutButton.Location = new Point(112, 12);
            BeginWorkoutButton.Name = "BeginWorkoutButton";
            BeginWorkoutButton.Size = new Size(123, 29);
            BeginWorkoutButton.TabIndex = 4;
            BeginWorkoutButton.Text = "Begin Workout";
            BeginWorkoutButton.UseVisualStyleBackColor = true;
            BeginWorkoutButton.Click += BeginWorkoutButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label1.Location = new Point(18, 14);
            label1.Name = "label1";
            label1.Size = new Size(57, 20);
            label1.TabIndex = 5;
            label1.Text = "Status:";
            // 
            // WorkoutStatusPanel
            // 
            WorkoutStatusPanel.Controls.Add(lblWorkoutStatus);
            WorkoutStatusPanel.Controls.Add(label1);
            WorkoutStatusPanel.Location = new Point(241, 2);
            WorkoutStatusPanel.Name = "WorkoutStatusPanel";
            WorkoutStatusPanel.Size = new Size(193, 49);
            WorkoutStatusPanel.TabIndex = 5;
            WorkoutStatusPanel.Visible = false;
            // 
            // lblWorkoutStatus
            // 
            lblWorkoutStatus.AutoSize = true;
            lblWorkoutStatus.ForeColor = Color.FromArgb(0, 64, 0);
            lblWorkoutStatus.Location = new Point(81, 14);
            lblWorkoutStatus.Name = "lblWorkoutStatus";
            lblWorkoutStatus.Size = new Size(94, 20);
            lblWorkoutStatus.TabIndex = 0;
            lblWorkoutStatus.Text = "In Progress ...";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(WorkoutStatusPanel);
            Controls.Add(BeginWorkoutButton);
            Controls.Add(MainPanel);
            Controls.Add(TrackButton);
            Controls.Add(SettingsButton);
            Controls.Add(DatabaseButton);
            MaximizeBox = false;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FTT";
            WorkoutStatusPanel.ResumeLayout(false);
            WorkoutStatusPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button DatabaseButton;
        private Button SettingsButton;
        private Button TrackButton;
        private Panel MainPanel;
        private Button BeginWorkoutButton;
        private Label label1;
        private Panel WorkoutStatusPanel;
        private Label lblWorkoutStatus;
    }
}