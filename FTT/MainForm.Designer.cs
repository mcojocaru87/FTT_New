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
            WorkoutsButton = new Button();
            WorkoutStatusPanel.SuspendLayout();
            SuspendLayout();
            // 
            // DatabaseButton
            // 
            DatabaseButton.Location = new Point(607, 9);
            DatabaseButton.Margin = new Padding(3, 2, 3, 2);
            DatabaseButton.Name = "DatabaseButton";
            DatabaseButton.Size = new Size(82, 22);
            DatabaseButton.TabIndex = 0;
            DatabaseButton.Text = "Database";
            DatabaseButton.UseVisualStyleBackColor = true;
            DatabaseButton.Click += DatabaseButton_Click;
            // 
            // SettingsButton
            // 
            SettingsButton.Location = new Point(520, 9);
            SettingsButton.Margin = new Padding(3, 2, 3, 2);
            SettingsButton.Name = "SettingsButton";
            SettingsButton.Size = new Size(82, 22);
            SettingsButton.TabIndex = 1;
            SettingsButton.Text = "Settings";
            SettingsButton.UseVisualStyleBackColor = true;
            SettingsButton.Click += SettingsButton_Click;
            // 
            // TrackButton
            // 
            TrackButton.Location = new Point(10, 9);
            TrackButton.Margin = new Padding(3, 2, 3, 2);
            TrackButton.Name = "TrackButton";
            TrackButton.Size = new Size(82, 22);
            TrackButton.TabIndex = 2;
            TrackButton.Text = "Track";
            TrackButton.UseVisualStyleBackColor = true;
            TrackButton.Click += TrackButton_Click;
            // 
            // MainPanel
            // 
            MainPanel.Location = new Point(10, 43);
            MainPanel.Margin = new Padding(3, 2, 3, 2);
            MainPanel.Name = "MainPanel";
            MainPanel.Size = new Size(679, 286);
            MainPanel.TabIndex = 3;
            // 
            // BeginWorkoutButton
            // 
            BeginWorkoutButton.Location = new Point(98, 9);
            BeginWorkoutButton.Margin = new Padding(3, 2, 3, 2);
            BeginWorkoutButton.Name = "BeginWorkoutButton";
            BeginWorkoutButton.Size = new Size(108, 22);
            BeginWorkoutButton.TabIndex = 4;
            BeginWorkoutButton.Text = "Begin Workout";
            BeginWorkoutButton.UseVisualStyleBackColor = true;
            BeginWorkoutButton.Click += BeginWorkoutButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label1.Location = new Point(16, 10);
            label1.Name = "label1";
            label1.Size = new Size(45, 15);
            label1.TabIndex = 5;
            label1.Text = "Status:";
            // 
            // WorkoutStatusPanel
            // 
            WorkoutStatusPanel.Controls.Add(lblWorkoutStatus);
            WorkoutStatusPanel.Controls.Add(label1);
            WorkoutStatusPanel.Location = new Point(211, 2);
            WorkoutStatusPanel.Margin = new Padding(3, 2, 3, 2);
            WorkoutStatusPanel.Name = "WorkoutStatusPanel";
            WorkoutStatusPanel.Size = new Size(169, 37);
            WorkoutStatusPanel.TabIndex = 5;
            WorkoutStatusPanel.Visible = false;
            // 
            // lblWorkoutStatus
            // 
            lblWorkoutStatus.AutoSize = true;
            lblWorkoutStatus.ForeColor = Color.FromArgb(0, 64, 0);
            lblWorkoutStatus.Location = new Point(71, 10);
            lblWorkoutStatus.Name = "lblWorkoutStatus";
            lblWorkoutStatus.Size = new Size(77, 15);
            lblWorkoutStatus.TabIndex = 0;
            lblWorkoutStatus.Text = "In Progress ...";
            // 
            // WorkoutsButton
            // 
            WorkoutsButton.Location = new Point(439, 9);
            WorkoutsButton.Name = "WorkoutsButton";
            WorkoutsButton.Size = new Size(75, 23);
            WorkoutsButton.TabIndex = 6;
            WorkoutsButton.Text = "Workouts";
            WorkoutsButton.UseVisualStyleBackColor = true;
            WorkoutsButton.Click += WorkoutsButton_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 338);
            Controls.Add(WorkoutsButton);
            Controls.Add(WorkoutStatusPanel);
            Controls.Add(BeginWorkoutButton);
            Controls.Add(MainPanel);
            Controls.Add(TrackButton);
            Controls.Add(SettingsButton);
            Controls.Add(DatabaseButton);
            Margin = new Padding(3, 2, 3, 2);
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
        private Button WorkoutsButton;
    }
}