namespace FTT.UserControls.CustomCalendar
{
    partial class CalendarDay
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
            lblDay = new Label();
            lblViewWorkout = new LinkLabel();
            SuspendLayout();
            // 
            // lblDay
            // 
            lblDay.BackColor = Color.Blue;
            lblDay.Dock = DockStyle.Top;
            lblDay.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblDay.ForeColor = Color.White;
            lblDay.Location = new Point(0, 0);
            lblDay.Margin = new Padding(0);
            lblDay.Name = "lblDay";
            lblDay.Size = new Size(116, 23);
            lblDay.TabIndex = 3;
            lblDay.Text = "label8";
            lblDay.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblViewWorkout
            // 
            lblViewWorkout.Dock = DockStyle.Fill;
            lblViewWorkout.Location = new Point(0, 23);
            lblViewWorkout.Name = "lblViewWorkout";
            lblViewWorkout.Size = new Size(116, 35);
            lblViewWorkout.TabIndex = 4;
            lblViewWorkout.TabStop = true;
            lblViewWorkout.Text = "View Workout";
            lblViewWorkout.TextAlign = ContentAlignment.MiddleCenter;
            lblViewWorkout.LinkClicked += lblViewWorkout_LinkClicked;
            // 
            // CalendarDay
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(lblViewWorkout);
            Controls.Add(lblDay);
            Name = "CalendarDay";
            Size = new Size(116, 58);
            ResumeLayout(false);
        }

        #endregion
        private Label lblDay;
        private LinkLabel lblViewWorkout;
    }
}
