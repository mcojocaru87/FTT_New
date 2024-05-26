namespace FTT
{
    partial class ViewWorkoutForm
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
            lblWorkoutDate = new Label();
            panel1 = new Panel();
            flowLayoutPanel1 = new FlowLayoutPanel();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // lblWorkoutDate
            // 
            lblWorkoutDate.AutoSize = true;
            lblWorkoutDate.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblWorkoutDate.Location = new Point(68, 14);
            lblWorkoutDate.Name = "lblWorkoutDate";
            lblWorkoutDate.Size = new Size(109, 21);
            lblWorkoutDate.TabIndex = 0;
            lblWorkoutDate.Text = "May 26, 2024";
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(lblWorkoutDate);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(245, 49);
            panel1.TabIndex = 1;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.BorderStyle = BorderStyle.FixedSingle;
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.Location = new Point(0, 49);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(245, 401);
            flowLayoutPanel1.TabIndex = 2;
            // 
            // ViewWorkoutForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(245, 450);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(panel1);
            MaximizeBox = false;
            Name = "ViewWorkoutForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "View Workout";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label lblWorkoutDate;
        private Panel panel1;
        private FlowLayoutPanel flowLayoutPanel1;
    }
}