namespace FTT.UserControls
{
    partial class TrackUC
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
            lblExercise = new Label();
            cbExercises = new ComboBox();
            label2 = new Label();
            dtWorkingDate = new DateTimePicker();
            MainPanel = new Panel();
            UpdateWorkoutDateButton = new Button();
            RemoveFromButton = new Button();
            AddToButton = new Button();
            groupHistory = new GroupBox();
            ViewGraphButton = new Button();
            dgvHistory = new DataGridView();
            lstTrack = new ListBox();
            AddToTrackButton = new Button();
            txtVolume = new TextBox();
            label5 = new Label();
            txtWeight = new TextBox();
            txtReps = new TextBox();
            label4 = new Label();
            label3 = new Label();
            groupLastTracking = new GroupBox();
            lblSet6Data = new Label();
            lblSet5Data = new Label();
            lblSet4Data = new Label();
            lblSet3Data = new Label();
            lblSet2Data = new Label();
            lblSet6Display = new Label();
            lblSet5Display = new Label();
            lblSet4Display = new Label();
            lblSet1Data = new Label();
            lblSet3Display = new Label();
            lblSet2Display = new Label();
            lblSet1Display = new Label();
            lblTotalVolume = new Label();
            label9 = new Label();
            lblWorkingDate = new Label();
            label6 = new Label();
            StartButton = new Button();
            FinishButton = new Button();
            groupNotes = new GroupBox();
            txtNotes = new TextBox();
            lblStrikes = new Label();
            label10 = new Label();
            MainPanel.SuspendLayout();
            groupHistory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvHistory).BeginInit();
            groupLastTracking.SuspendLayout();
            groupNotes.SuspendLayout();
            SuspendLayout();
            // 
            // lblExercise
            // 
            lblExercise.AutoSize = true;
            lblExercise.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblExercise.Location = new Point(0, 0);
            lblExercise.Name = "lblExercise";
            lblExercise.Size = new Size(76, 20);
            lblExercise.TabIndex = 0;
            lblExercise.Text = "Exercises:";
            // 
            // cbExercises
            // 
            cbExercises.FormattingEnabled = true;
            cbExercises.Location = new Point(3, 23);
            cbExercises.Name = "cbExercises";
            cbExercises.Size = new Size(239, 28);
            cbExercises.TabIndex = 1;
            cbExercises.SelectedIndexChanged += cbExercises_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label2.ForeColor = Color.Black;
            label2.Location = new Point(22, 0);
            label2.Name = "label2";
            label2.Size = new Size(110, 20);
            label2.TabIndex = 2;
            label2.Text = "Working Date:";
            // 
            // dtWorkingDate
            // 
            dtWorkingDate.Location = new Point(21, 24);
            dtWorkingDate.Name = "dtWorkingDate";
            dtWorkingDate.Size = new Size(221, 27);
            dtWorkingDate.TabIndex = 3;
            dtWorkingDate.ValueChanged += dtWorkingDate_ValueChanged;
            // 
            // MainPanel
            // 
            MainPanel.BackColor = SystemColors.ControlLight;
            MainPanel.Controls.Add(UpdateWorkoutDateButton);
            MainPanel.Controls.Add(RemoveFromButton);
            MainPanel.Controls.Add(AddToButton);
            MainPanel.Controls.Add(groupHistory);
            MainPanel.Controls.Add(lstTrack);
            MainPanel.Controls.Add(AddToTrackButton);
            MainPanel.Controls.Add(txtVolume);
            MainPanel.Controls.Add(label5);
            MainPanel.Controls.Add(txtWeight);
            MainPanel.Controls.Add(txtReps);
            MainPanel.Controls.Add(label4);
            MainPanel.Controls.Add(label3);
            MainPanel.Controls.Add(label2);
            MainPanel.Controls.Add(dtWorkingDate);
            MainPanel.Dock = DockStyle.Right;
            MainPanel.Location = new Point(249, 0);
            MainPanel.Name = "MainPanel";
            MainPanel.Size = new Size(527, 381);
            MainPanel.TabIndex = 4;
            MainPanel.Visible = false;
            // 
            // UpdateWorkoutDateButton
            // 
            UpdateWorkoutDateButton.Location = new Point(21, 52);
            UpdateWorkoutDateButton.Name = "UpdateWorkoutDateButton";
            UpdateWorkoutDateButton.Size = new Size(221, 29);
            UpdateWorkoutDateButton.TabIndex = 14;
            UpdateWorkoutDateButton.Text = "Update Current Workout Date";
            UpdateWorkoutDateButton.UseVisualStyleBackColor = true;
            UpdateWorkoutDateButton.Click += UpdateWorkoutDateButton_Click;
            // 
            // RemoveFromButton
            // 
            RemoveFromButton.Location = new Point(339, 137);
            RemoveFromButton.Name = "RemoveFromButton";
            RemoveFromButton.Size = new Size(171, 31);
            RemoveFromButton.TabIndex = 13;
            RemoveFromButton.Text = "Remove From Workout";
            RemoveFromButton.UseVisualStyleBackColor = true;
            RemoveFromButton.Click += RemoveFromButton_Click;
            // 
            // AddToButton
            // 
            AddToButton.Location = new Point(261, 137);
            AddToButton.Name = "AddToButton";
            AddToButton.Size = new Size(171, 31);
            AddToButton.TabIndex = 12;
            AddToButton.Text = "Add To Workout";
            AddToButton.UseVisualStyleBackColor = true;
            AddToButton.Click += AddToButton_Click;
            // 
            // groupHistory
            // 
            groupHistory.Controls.Add(ViewGraphButton);
            groupHistory.Controls.Add(dgvHistory);
            groupHistory.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            groupHistory.Location = new Point(3, 173);
            groupHistory.Name = "groupHistory";
            groupHistory.Size = new Size(521, 204);
            groupHistory.TabIndex = 6;
            groupHistory.TabStop = false;
            groupHistory.Text = "History";
            // 
            // ViewGraphButton
            // 
            ViewGraphButton.Location = new Point(429, 17);
            ViewGraphButton.Margin = new Padding(3, 4, 3, 4);
            ViewGraphButton.Name = "ViewGraphButton";
            ViewGraphButton.Size = new Size(86, 31);
            ViewGraphButton.TabIndex = 1;
            ViewGraphButton.Text = "Graph";
            ViewGraphButton.UseVisualStyleBackColor = true;
            ViewGraphButton.Click += ViewGraphButton_Click;
            // 
            // dgvHistory
            // 
            dgvHistory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvHistory.Location = new Point(6, 55);
            dgvHistory.Name = "dgvHistory";
            dgvHistory.RowHeadersWidth = 51;
            dgvHistory.Size = new Size(509, 147);
            dgvHistory.TabIndex = 0;
            // 
            // lstTrack
            // 
            lstTrack.FormattingEnabled = true;
            lstTrack.Location = new Point(261, 24);
            lstTrack.Name = "lstTrack";
            lstTrack.Size = new Size(250, 104);
            lstTrack.TabIndex = 11;
            // 
            // AddToTrackButton
            // 
            AddToTrackButton.Location = new Point(21, 137);
            AddToTrackButton.Margin = new Padding(0);
            AddToTrackButton.Name = "AddToTrackButton";
            AddToTrackButton.Size = new Size(221, 31);
            AddToTrackButton.TabIndex = 10;
            AddToTrackButton.Text = "Add";
            AddToTrackButton.UseVisualStyleBackColor = true;
            AddToTrackButton.Click += AddToTrackButton_Click;
            // 
            // txtVolume
            // 
            txtVolume.Location = new Point(171, 107);
            txtVolume.Name = "txtVolume";
            txtVolume.ReadOnly = true;
            txtVolume.Size = new Size(69, 27);
            txtVolume.TabIndex = 9;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label5.ForeColor = Color.Black;
            label5.Location = new Point(171, 84);
            label5.Name = "label5";
            label5.Size = new Size(19, 20);
            label5.TabIndex = 8;
            label5.Text = "V";
            // 
            // txtWeight
            // 
            txtWeight.Location = new Point(97, 107);
            txtWeight.Name = "txtWeight";
            txtWeight.Size = new Size(69, 27);
            txtWeight.TabIndex = 7;
            txtWeight.TextChanged += txtWeight_TextChanged;
            // 
            // txtReps
            // 
            txtReps.Location = new Point(22, 107);
            txtReps.Name = "txtReps";
            txtReps.Size = new Size(69, 27);
            txtReps.TabIndex = 6;
            txtReps.TextChanged += txtReps_TextChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label4.ForeColor = Color.Black;
            label4.Location = new Point(97, 84);
            label4.Name = "label4";
            label4.Size = new Size(24, 20);
            label4.TabIndex = 5;
            label4.Text = "W";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label3.ForeColor = Color.Black;
            label3.Location = new Point(22, 84);
            label3.Name = "label3";
            label3.Size = new Size(19, 20);
            label3.TabIndex = 4;
            label3.Text = "R";
            // 
            // groupLastTracking
            // 
            groupLastTracking.Controls.Add(lblSet6Data);
            groupLastTracking.Controls.Add(lblSet5Data);
            groupLastTracking.Controls.Add(lblSet4Data);
            groupLastTracking.Controls.Add(lblSet3Data);
            groupLastTracking.Controls.Add(lblSet2Data);
            groupLastTracking.Controls.Add(lblSet6Display);
            groupLastTracking.Controls.Add(lblSet5Display);
            groupLastTracking.Controls.Add(lblSet4Display);
            groupLastTracking.Controls.Add(lblSet1Data);
            groupLastTracking.Controls.Add(lblSet3Display);
            groupLastTracking.Controls.Add(lblSet2Display);
            groupLastTracking.Controls.Add(lblSet1Display);
            groupLastTracking.Controls.Add(lblTotalVolume);
            groupLastTracking.Controls.Add(label9);
            groupLastTracking.Controls.Add(lblWorkingDate);
            groupLastTracking.Controls.Add(label6);
            groupLastTracking.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            groupLastTracking.Location = new Point(3, 189);
            groupLastTracking.Name = "groupLastTracking";
            groupLastTracking.Size = new Size(240, 188);
            groupLastTracking.TabIndex = 5;
            groupLastTracking.TabStop = false;
            groupLastTracking.Text = "Last Tracking";
            groupLastTracking.Visible = false;
            // 
            // lblSet6Data
            // 
            lblSet6Data.AutoSize = true;
            lblSet6Data.Font = new Font("Segoe UI", 9F);
            lblSet6Data.Location = new Point(97, 165);
            lblSet6Data.Name = "lblSet6Data";
            lblSet6Data.Size = new Size(106, 20);
            lblSet6Data.TabIndex = 15;
            lblSet6Data.Text = "R12 x W55  x 2";
            lblSet6Data.Visible = false;
            // 
            // lblSet5Data
            // 
            lblSet5Data.AutoSize = true;
            lblSet5Data.Font = new Font("Segoe UI", 9F);
            lblSet5Data.Location = new Point(97, 147);
            lblSet5Data.Name = "lblSet5Data";
            lblSet5Data.Size = new Size(106, 20);
            lblSet5Data.TabIndex = 14;
            lblSet5Data.Text = "R12 x W55  x 2";
            lblSet5Data.Visible = false;
            // 
            // lblSet4Data
            // 
            lblSet4Data.AutoSize = true;
            lblSet4Data.Font = new Font("Segoe UI", 9F);
            lblSet4Data.Location = new Point(97, 125);
            lblSet4Data.Name = "lblSet4Data";
            lblSet4Data.Size = new Size(106, 20);
            lblSet4Data.TabIndex = 13;
            lblSet4Data.Text = "R12 x W55  x 2";
            lblSet4Data.Visible = false;
            // 
            // lblSet3Data
            // 
            lblSet3Data.AutoSize = true;
            lblSet3Data.Font = new Font("Segoe UI", 9F);
            lblSet3Data.Location = new Point(97, 107);
            lblSet3Data.Name = "lblSet3Data";
            lblSet3Data.Size = new Size(106, 20);
            lblSet3Data.TabIndex = 12;
            lblSet3Data.Text = "R12 x W55  x 2";
            lblSet3Data.Visible = false;
            // 
            // lblSet2Data
            // 
            lblSet2Data.AutoSize = true;
            lblSet2Data.Font = new Font("Segoe UI", 9F);
            lblSet2Data.Location = new Point(97, 85);
            lblSet2Data.Name = "lblSet2Data";
            lblSet2Data.Size = new Size(106, 20);
            lblSet2Data.TabIndex = 11;
            lblSet2Data.Text = "R12 x W55  x 2";
            lblSet2Data.Visible = false;
            // 
            // lblSet6Display
            // 
            lblSet6Display.AutoSize = true;
            lblSet6Display.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblSet6Display.Location = new Point(38, 165);
            lblSet6Display.Name = "lblSet6Display";
            lblSet6Display.Size = new Size(53, 20);
            lblSet6Display.TabIndex = 10;
            lblSet6Display.Text = "Set #6";
            lblSet6Display.Visible = false;
            // 
            // lblSet5Display
            // 
            lblSet5Display.AutoSize = true;
            lblSet5Display.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblSet5Display.Location = new Point(38, 147);
            lblSet5Display.Name = "lblSet5Display";
            lblSet5Display.Size = new Size(53, 20);
            lblSet5Display.TabIndex = 9;
            lblSet5Display.Text = "Set #5";
            lblSet5Display.Visible = false;
            // 
            // lblSet4Display
            // 
            lblSet4Display.AutoSize = true;
            lblSet4Display.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblSet4Display.Location = new Point(38, 125);
            lblSet4Display.Name = "lblSet4Display";
            lblSet4Display.Size = new Size(53, 20);
            lblSet4Display.TabIndex = 8;
            lblSet4Display.Text = "Set #4";
            lblSet4Display.Visible = false;
            // 
            // lblSet1Data
            // 
            lblSet1Data.AutoSize = true;
            lblSet1Data.Font = new Font("Segoe UI", 9F);
            lblSet1Data.Location = new Point(97, 67);
            lblSet1Data.Name = "lblSet1Data";
            lblSet1Data.Size = new Size(106, 20);
            lblSet1Data.TabIndex = 7;
            lblSet1Data.Text = "R12 x W55  x 2";
            lblSet1Data.Visible = false;
            // 
            // lblSet3Display
            // 
            lblSet3Display.AutoSize = true;
            lblSet3Display.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblSet3Display.Location = new Point(38, 107);
            lblSet3Display.Name = "lblSet3Display";
            lblSet3Display.Size = new Size(53, 20);
            lblSet3Display.TabIndex = 6;
            lblSet3Display.Text = "Set #3";
            lblSet3Display.Visible = false;
            // 
            // lblSet2Display
            // 
            lblSet2Display.AutoSize = true;
            lblSet2Display.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblSet2Display.Location = new Point(38, 85);
            lblSet2Display.Name = "lblSet2Display";
            lblSet2Display.Size = new Size(53, 20);
            lblSet2Display.TabIndex = 5;
            lblSet2Display.Text = "Set #2";
            lblSet2Display.Visible = false;
            // 
            // lblSet1Display
            // 
            lblSet1Display.AutoSize = true;
            lblSet1Display.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblSet1Display.Location = new Point(38, 67);
            lblSet1Display.Name = "lblSet1Display";
            lblSet1Display.Size = new Size(53, 20);
            lblSet1Display.TabIndex = 4;
            lblSet1Display.Text = "Set #1";
            lblSet1Display.Visible = false;
            // 
            // lblTotalVolume
            // 
            lblTotalVolume.AutoSize = true;
            lblTotalVolume.Font = new Font("Segoe UI", 9F);
            lblTotalVolume.Location = new Point(120, 43);
            lblTotalVolume.Name = "lblTotalVolume";
            lblTotalVolume.Size = new Size(55, 20);
            lblTotalVolume.TabIndex = 3;
            lblTotalVolume.Text = "250 Kg";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label9.Location = new Point(9, 43);
            label9.Name = "label9";
            label9.Size = new Size(105, 20);
            label9.TabIndex = 2;
            label9.Text = "Total Volume:";
            // 
            // lblWorkingDate
            // 
            lblWorkingDate.AutoSize = true;
            lblWorkingDate.Font = new Font("Segoe UI", 9F);
            lblWorkingDate.Location = new Point(120, 23);
            lblWorkingDate.Name = "lblWorkingDate";
            lblWorkingDate.Size = new Size(94, 20);
            lblWorkingDate.TabIndex = 1;
            lblWorkingDate.Text = "Dec 31, 2024";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label6.Location = new Point(6, 23);
            label6.Name = "label6";
            label6.Size = new Size(108, 20);
            label6.TabIndex = 0;
            label6.Text = "Working date:";
            // 
            // StartButton
            // 
            StartButton.Location = new Point(3, 57);
            StartButton.Name = "StartButton";
            StartButton.Size = new Size(94, 29);
            StartButton.TabIndex = 6;
            StartButton.Text = "Start";
            StartButton.UseVisualStyleBackColor = true;
            StartButton.Visible = false;
            StartButton.Click += StartButton_Click;
            // 
            // FinishButton
            // 
            FinishButton.Location = new Point(149, 57);
            FinishButton.Name = "FinishButton";
            FinishButton.Size = new Size(94, 29);
            FinishButton.TabIndex = 7;
            FinishButton.Text = "Finish";
            FinishButton.UseVisualStyleBackColor = true;
            FinishButton.Visible = false;
            FinishButton.Click += FinishButton_Click;
            // 
            // groupNotes
            // 
            groupNotes.Controls.Add(txtNotes);
            groupNotes.Controls.Add(lblStrikes);
            groupNotes.Controls.Add(label10);
            groupNotes.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            groupNotes.Location = new Point(3, 92);
            groupNotes.Name = "groupNotes";
            groupNotes.Size = new Size(240, 88);
            groupNotes.TabIndex = 6;
            groupNotes.TabStop = false;
            groupNotes.Text = "Notes";
            groupNotes.Visible = false;
            // 
            // txtNotes
            // 
            txtNotes.ForeColor = SystemColors.InfoText;
            txtNotes.Location = new Point(11, 49);
            txtNotes.Multiline = true;
            txtNotes.Name = "txtNotes";
            txtNotes.ReadOnly = true;
            txtNotes.Size = new Size(223, 27);
            txtNotes.TabIndex = 3;
            txtNotes.Text = "Increase";
            txtNotes.TextAlign = HorizontalAlignment.Center;
            // 
            // lblStrikes
            // 
            lblStrikes.AutoSize = true;
            lblStrikes.ForeColor = Color.Red;
            lblStrikes.Location = new Point(75, 23);
            lblStrikes.Name = "lblStrikes";
            lblStrikes.Size = new Size(97, 20);
            lblStrikes.TabIndex = 2;
            lblStrikes.Text = "❌❌❌❌";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label10.Location = new Point(9, 23);
            label10.Name = "label10";
            label10.Size = new Size(60, 20);
            label10.TabIndex = 1;
            label10.Text = "Strikes:";
            // 
            // TrackUC
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonFace;
            Controls.Add(groupNotes);
            Controls.Add(FinishButton);
            Controls.Add(StartButton);
            Controls.Add(groupLastTracking);
            Controls.Add(MainPanel);
            Controls.Add(cbExercises);
            Controls.Add(lblExercise);
            Name = "TrackUC";
            Size = new Size(776, 381);
            MainPanel.ResumeLayout(false);
            MainPanel.PerformLayout();
            groupHistory.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvHistory).EndInit();
            groupLastTracking.ResumeLayout(false);
            groupLastTracking.PerformLayout();
            groupNotes.ResumeLayout(false);
            groupNotes.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblExercise;
        private ComboBox cbExercises;
        private Label label2;
        private DateTimePicker dtWorkingDate;
        private Panel MainPanel;
        private TextBox txtVolume;
        private Label label5;
        private TextBox txtWeight;
        private TextBox txtReps;
        private Label label4;
        private Label label3;
        private GroupBox groupLastTracking;
        private Button AddToTrackButton;
        private ListBox lstTrack;
        private GroupBox groupHistory;
        private Button StartButton;
        private Button FinishButton;
        private GroupBox groupNotes;
        private Label lblTotalVolume;
        private Label label9;
        private Label lblWorkingDate;
        private Label label6;
        private Label label10;
        private Label lblStrikes;
        private TextBox txtNotes;
        private Label lblSet1Data;
        private Label lblSet3Display;
        private Label lblSet2Display;
        private Label lblSet1Display;
        private Label lblSet6Display;
        private Label lblSet5Display;
        private Label lblSet4Display;
        private Label lblSet6Data;
        private Label lblSet5Data;
        private Label lblSet4Data;
        private Label lblSet3Data;
        private Label lblSet2Data;
        private DataGridView dgvHistory;
        private Button RemoveFromButton;
        private Button AddToButton;
        private Button UpdateWorkoutDateButton;
        private Button ViewGraphButton;
    }
}
