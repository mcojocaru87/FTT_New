namespace FTT
{
    partial class SplashScreen
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
            panel1 = new Panel();
            label5 = new Label();
            label4 = new Label();
            label1 = new Label();
            progressBar = new ProgressBar();
            label2 = new Label();
            label3 = new Label();
            lblVersion = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.RoyalBlue;
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label4);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(3, 2, 3, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(581, 166);
            panel1.TabIndex = 0;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 13F);
            label5.ForeColor = SystemColors.ActiveCaption;
            label5.Location = new Point(163, 96);
            label5.Name = "label5";
            label5.Size = new Size(239, 25);
            label5.TabIndex = 1;
            label5.Text = "Powered by Marian Cojocaru";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 25F, FontStyle.Bold);
            label4.ForeColor = Color.White;
            label4.Location = new Point(237, 45);
            label4.Name = "label4";
            label4.Size = new Size(79, 46);
            label4.TabIndex = 0;
            label4.Text = "FTT";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(108, 194);
            label1.Name = "label1";
            label1.Size = new Size(88, 15);
            label1.TabIndex = 1;
            label1.Text = "Loading data ...";
            // 
            // progressBar
            // 
            progressBar.Location = new Point(112, 211);
            progressBar.Margin = new Padding(3, 2, 3, 2);
            progressBar.Name = "progressBar";
            progressBar.Size = new Size(350, 17);
            progressBar.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(237, 262);
            label2.Name = "label2";
            label2.Size = new Size(192, 15);
            label2.TabIndex = 3;
            label2.Text = "Copyright © 2024 Marian Cojocaru";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(452, 262);
            label3.Name = "label3";
            label3.Size = new Size(101, 15);
            label3.TabIndex = 4;
            label3.Text = "All rights reserved";
            // 
            // lblVersion
            // 
            lblVersion.AutoSize = true;
            lblVersion.Location = new Point(12, 262);
            lblVersion.Name = "lblVersion";
            lblVersion.Size = new Size(38, 15);
            lblVersion.TabIndex = 5;
            lblVersion.Text = "label6";
            // 
            // SplashScreen
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(581, 286);
            Controls.Add(lblVersion);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(progressBar);
            Controls.Add(label1);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 2, 3, 2);
            Name = "SplashScreen";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SplashScreen";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label label1;
        public ProgressBar progressBar;
        private Label label2;
        private Label label4;
        private Label label3;
        private Label label5;
        private Label lblVersion;
    }
}