namespace FTT
{
    partial class TimerForm
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
            components = new System.ComponentModel.Container();
            chkDoNotShow = new CheckBox();
            lblSkip = new LinkLabel();
            lblTime = new Label();
            timer = new System.Windows.Forms.Timer(components);
            cbExercises = new ComboBox();
            txtNotes = new TextBox();
            label1 = new Label();
            label2 = new Label();
            lblCurrentTime = new Label();
            lblWorkoutTime = new Label();
            label4 = new Label();
            currentTimeTimer = new System.Windows.Forms.Timer(components);
            workoutTimeTimer = new System.Windows.Forms.Timer(components);
            Add30SecButton = new Button();
            Take30SecButton = new Button();
            SuspendLayout();
            // 
            // chkDoNotShow
            // 
            chkDoNotShow.AutoSize = true;
            chkDoNotShow.Location = new Point(12, 307);
            chkDoNotShow.Name = "chkDoNotShow";
            chkDoNotShow.Size = new Size(137, 19);
            chkDoNotShow.TabIndex = 0;
            chkDoNotShow.Text = "Do not show again ...";
            chkDoNotShow.UseVisualStyleBackColor = true;
            chkDoNotShow.CheckedChanged += chkDoNotShow_CheckedChanged;
            // 
            // lblSkip
            // 
            lblSkip.AutoSize = true;
            lblSkip.Font = new Font("Segoe UI", 15F);
            lblSkip.Location = new Point(638, 297);
            lblSkip.Name = "lblSkip";
            lblSkip.Size = new Size(50, 28);
            lblSkip.TabIndex = 1;
            lblSkip.TabStop = true;
            lblSkip.Text = "Skip";
            lblSkip.LinkClicked += lblSkip_LinkClicked;
            // 
            // lblTime
            // 
            lblTime.AutoSize = true;
            lblTime.Font = new Font("Impact", 70F);
            lblTime.Location = new Point(157, 124);
            lblTime.Name = "lblTime";
            lblTime.Size = new Size(387, 115);
            lblTime.TabIndex = 2;
            lblTime.Text = "00:00:00";
            // 
            // timer
            // 
            timer.Interval = 1000;
            timer.Tick += timer_Tick;
            // 
            // cbExercises
            // 
            cbExercises.FormattingEnabled = true;
            cbExercises.Location = new Point(221, 27);
            cbExercises.Name = "cbExercises";
            cbExercises.Size = new Size(258, 23);
            cbExercises.TabIndex = 3;
            cbExercises.Visible = false;
            cbExercises.SelectedIndexChanged += cbExercises_SelectedIndexChanged;
            // 
            // txtNotes
            // 
            txtNotes.Location = new Point(221, 56);
            txtNotes.Name = "txtNotes";
            txtNotes.ReadOnly = true;
            txtNotes.Size = new Size(258, 23);
            txtNotes.TabIndex = 4;
            txtNotes.Visible = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            label1.Location = new Point(178, 100);
            label1.Name = "label1";
            label1.Size = new Size(129, 37);
            label1.TabIndex = 5;
            label1.Text = "Rest For:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label2.Location = new Point(178, 250);
            label2.Name = "label2";
            label2.Size = new Size(113, 21);
            label2.TabIndex = 6;
            label2.Text = "Current Time:";
            // 
            // lblCurrentTime
            // 
            lblCurrentTime.AutoSize = true;
            lblCurrentTime.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblCurrentTime.Location = new Point(173, 271);
            lblCurrentTime.Name = "lblCurrentTime";
            lblCurrentTime.Size = new Size(127, 37);
            lblCurrentTime.TabIndex = 7;
            lblCurrentTime.Text = "00:00:00";
            // 
            // lblWorkoutTime
            // 
            lblWorkoutTime.AutoSize = true;
            lblWorkoutTime.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblWorkoutTime.Location = new Point(374, 271);
            lblWorkoutTime.Name = "lblWorkoutTime";
            lblWorkoutTime.Size = new Size(127, 37);
            lblWorkoutTime.TabIndex = 9;
            lblWorkoutTime.Text = "00:00:00";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label4.Location = new Point(379, 250);
            label4.Name = "label4";
            label4.Size = new Size(123, 21);
            label4.TabIndex = 8;
            label4.Text = "Workout Time:";
            // 
            // currentTimeTimer
            // 
            currentTimeTimer.Interval = 1000;
            currentTimeTimer.Tick += currentTimeTimer_Tick;
            // 
            // workoutTimeTimer
            // 
            workoutTimeTimer.Interval = 1000;
            workoutTimeTimer.Tick += workoutTimeTimer_Tick;
            // 
            // Add30SecButton
            // 
            Add30SecButton.FlatAppearance.BorderSize = 0;
            Add30SecButton.FlatStyle = FlatStyle.Flat;
            Add30SecButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            Add30SecButton.Location = new Point(550, 154);
            Add30SecButton.Name = "Add30SecButton";
            Add30SecButton.Size = new Size(98, 56);
            Add30SecButton.TabIndex = 10;
            Add30SecButton.Text = "+ 30 SEC";
            Add30SecButton.UseVisualStyleBackColor = true;
            Add30SecButton.Click += Add30SecButton_Click;
            // 
            // Take30SecButton
            // 
            Take30SecButton.FlatAppearance.BorderSize = 0;
            Take30SecButton.FlatStyle = FlatStyle.Flat;
            Take30SecButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            Take30SecButton.Location = new Point(53, 154);
            Take30SecButton.Name = "Take30SecButton";
            Take30SecButton.Size = new Size(98, 56);
            Take30SecButton.TabIndex = 11;
            Take30SecButton.Text = "- 30 SEC";
            Take30SecButton.UseVisualStyleBackColor = true;
            Take30SecButton.Click += Take30SecButton_Click;
            // 
            // TimerForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 338);
            Controls.Add(Take30SecButton);
            Controls.Add(Add30SecButton);
            Controls.Add(lblWorkoutTime);
            Controls.Add(label4);
            Controls.Add(lblCurrentTime);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtNotes);
            Controls.Add(cbExercises);
            Controls.Add(lblTime);
            Controls.Add(lblSkip);
            Controls.Add(chkDoNotShow);
            Font = new Font("Segoe UI", 9F);
            FormBorderStyle = FormBorderStyle.None;
            Name = "TimerForm";
            Opacity = 0.98D;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "TimerForm";
            Load += TimerForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CheckBox chkDoNotShow;
        private LinkLabel lblSkip;
        private Label lblTime;
        private System.Windows.Forms.Timer timer;
        private ComboBox cbExercises;
        private TextBox txtNotes;
        private Label label1;
        private Label label2;
        private Label lblCurrentTime;
        private Label lblWorkoutTime;
        private Label label4;
        private System.Windows.Forms.Timer currentTimeTimer;
        private System.Windows.Forms.Timer workoutTimeTimer;
        private Button Add30SecButton;
        private Button Take30SecButton;
    }
}