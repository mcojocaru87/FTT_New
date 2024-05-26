namespace FTT.UserControls.CustomCalendar
{
    partial class BlankCalendarDay
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
            lblWorkout.TabIndex = 6;
            lblWorkout.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblDay
            // 
            lblDay.BackColor = Color.White;
            lblDay.Dock = DockStyle.Top;
            lblDay.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblDay.ForeColor = Color.Black;
            lblDay.Location = new Point(0, 0);
            lblDay.Margin = new Padding(0);
            lblDay.Name = "lblDay";
            lblDay.Size = new Size(116, 23);
            lblDay.TabIndex = 5;
            lblDay.Text = "label8";
            lblDay.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // BlankCalendarDay
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(lblWorkout);
            Controls.Add(lblDay);
            Name = "BlankCalendarDay";
            Size = new Size(116, 58);
            ResumeLayout(false);
        }

        #endregion

        private Label lblWorkout;
        private Label lblDay;
    }
}
