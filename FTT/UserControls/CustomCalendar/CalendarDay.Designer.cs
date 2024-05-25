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
            lblWorkout = new Label();
            lblDay = new Label();
            SuspendLayout();
            // 
            // lblWorkout
            // 
            lblWorkout.Dock = DockStyle.Fill;
            lblWorkout.Location = new Point(0, 23);
            lblWorkout.Name = "lblWorkout";
            lblWorkout.Size = new Size(116, 35);
            lblWorkout.TabIndex = 4;
            lblWorkout.TextAlign = ContentAlignment.MiddleCenter;
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
            // CalendarDay
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(lblWorkout);
            Controls.Add(lblDay);
            Name = "CalendarDay";
            Size = new Size(116, 58);
            ResumeLayout(false);
        }

        #endregion

        private Label lblWorkout;
        private Label lblDay;
    }
}
