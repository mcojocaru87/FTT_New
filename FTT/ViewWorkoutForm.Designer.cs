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
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // lblWorkoutDate
            // 
            lblWorkoutDate.Dock = DockStyle.Fill;
            lblWorkoutDate.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblWorkoutDate.Location = new Point(0, 0);
            lblWorkoutDate.Name = "lblWorkoutDate";
            lblWorkoutDate.Size = new Size(336, 63);
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
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(338, 65);
            panel1.TabIndex = 1;
            // 
            // MainPanel
            // 
            MainPanel.AutoScroll = true;
            MainPanel.BorderStyle = BorderStyle.FixedSingle;
            MainPanel.Dock = DockStyle.Fill;
            MainPanel.Location = new Point(0, 65);
            MainPanel.Margin = new Padding(3, 4, 3, 4);
            MainPanel.Name = "MainPanel";
            MainPanel.Size = new Size(338, 535);
            MainPanel.TabIndex = 2;
            MainPanel.Layout += MainPanel_Layout;
            // 
            // ViewWorkoutForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(338, 600);
            Controls.Add(MainPanel);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            Name = "ViewWorkoutForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "View Workout";
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Label lblWorkoutDate;
        private Panel panel1;
        private FlowLayoutPanel MainPanel;
    }
}