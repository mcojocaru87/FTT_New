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
            MainPanel = new FlowLayoutPanel();
            panel2 = new Panel();
            lblProgressMade = new Label();
            lblWorkoutTotalTime = new Label();
            lblWorkoutEndDate = new Label();
            lblWorkoutStartDate = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // lblWorkoutDate
            // 
            lblWorkoutDate.Dock = DockStyle.Top;
            lblWorkoutDate.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblWorkoutDate.Location = new Point(0, 0);
            lblWorkoutDate.Name = "lblWorkoutDate";
            lblWorkoutDate.Size = new Size(294, 47);
            lblWorkoutDate.TabIndex = 0;
            lblWorkoutDate.Text = "May 26, 2024";
            lblWorkoutDate.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(lblWorkoutDate);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(296, 49);
            panel1.TabIndex = 1;
            // 
            // MainPanel
            // 
            MainPanel.AutoScroll = true;
            MainPanel.BorderStyle = BorderStyle.FixedSingle;
            MainPanel.Dock = DockStyle.Bottom;
            MainPanel.Location = new Point(0, 117);
            MainPanel.Name = "MainPanel";
            MainPanel.Size = new Size(296, 333);
            MainPanel.TabIndex = 2;
            MainPanel.Layout += MainPanel_Layout;
            // 
            // panel2
            // 
            panel2.Controls.Add(lblProgressMade);
            panel2.Controls.Add(lblWorkoutTotalTime);
            panel2.Controls.Add(lblWorkoutEndDate);
            panel2.Controls.Add(lblWorkoutStartDate);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(label1);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 49);
            panel2.Name = "panel2";
            panel2.Size = new Size(296, 68);
            panel2.TabIndex = 3;
            // 
            // lblProgressMade
            // 
            lblProgressMade.AutoSize = true;
            lblProgressMade.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblProgressMade.Location = new Point(106, 48);
            lblProgressMade.Name = "lblProgressMade";
            lblProgressMade.Size = new Size(121, 15);
            lblProgressMade.TabIndex = 7;
            lblProgressMade.Text = "Workout Start Date:";
            // 
            // lblWorkoutTotalTime
            // 
            lblWorkoutTotalTime.AutoSize = true;
            lblWorkoutTotalTime.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblWorkoutTotalTime.Location = new Point(106, 33);
            lblWorkoutTotalTime.Name = "lblWorkoutTotalTime";
            lblWorkoutTotalTime.Size = new Size(121, 15);
            lblWorkoutTotalTime.TabIndex = 6;
            lblWorkoutTotalTime.Text = "Workout Start Date:";
            // 
            // lblWorkoutEndDate
            // 
            lblWorkoutEndDate.AutoSize = true;
            lblWorkoutEndDate.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblWorkoutEndDate.Location = new Point(106, 18);
            lblWorkoutEndDate.Name = "lblWorkoutEndDate";
            lblWorkoutEndDate.Size = new Size(121, 15);
            lblWorkoutEndDate.TabIndex = 5;
            lblWorkoutEndDate.Text = "Workout Start Date:";
            // 
            // lblWorkoutStartDate
            // 
            lblWorkoutStartDate.AutoSize = true;
            lblWorkoutStartDate.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblWorkoutStartDate.Location = new Point(106, 3);
            lblWorkoutStartDate.Name = "lblWorkoutStartDate";
            lblWorkoutStartDate.Size = new Size(121, 15);
            lblWorkoutStartDate.TabIndex = 4;
            lblWorkoutStartDate.Text = "Workout Start Date:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 48);
            label4.Name = "label4";
            label4.Size = new Size(88, 15);
            label4.TabIndex = 3;
            label4.Text = "Progress Made:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(36, 33);
            label3.Name = "label3";
            label3.Size = new Size(64, 15);
            label3.TabIndex = 2;
            label3.Text = "Total Time:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(43, 18);
            label2.Name = "label2";
            label2.Size = new Size(57, 15);
            label2.TabIndex = 1;
            label2.Text = "End Date:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(39, 3);
            label1.Name = "label1";
            label1.Size = new Size(61, 15);
            label1.TabIndex = 0;
            label1.Text = "Start Date:";
            // 
            // ViewWorkoutForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(296, 450);
            Controls.Add(panel2);
            Controls.Add(MainPanel);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "ViewWorkoutForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "View Workout";
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label lblWorkoutDate;
        private Panel panel1;
        private FlowLayoutPanel MainPanel;
        private Panel panel2;
        private Label lblProgressMade;
        private Label lblWorkoutTotalTime;
        private Label lblWorkoutEndDate;
        private Label lblWorkoutStartDate;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
    }
}