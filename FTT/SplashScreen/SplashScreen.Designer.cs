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
            label1 = new Label();
            progressBar = new ProgressBar();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
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
            panel1.Name = "panel1";
            panel1.Size = new Size(664, 221);
            panel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(124, 258);
            label1.Name = "label1";
            label1.Size = new Size(110, 20);
            label1.TabIndex = 1;
            label1.Text = "Loading data ...";
            // 
            // progressBar
            // 
            progressBar.Location = new Point(128, 281);
            progressBar.Name = "progressBar";
            progressBar.Size = new Size(400, 23);
            progressBar.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(271, 349);
            label2.Name = "label2";
            label2.Size = new Size(240, 20);
            label2.TabIndex = 3;
            label2.Text = "Copyright © 2024 Marian Cojocaru";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(517, 349);
            label3.Name = "label3";
            label3.Size = new Size(128, 20);
            label3.TabIndex = 4;
            label3.Text = "All rights reserved";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 25F, FontStyle.Bold);
            label4.ForeColor = Color.White;
            label4.Location = new Point(271, 60);
            label4.Name = "label4";
            label4.Size = new Size(99, 57);
            label4.TabIndex = 0;
            label4.Text = "FTT";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 13F);
            label5.ForeColor = SystemColors.ActiveCaption;
            label5.Location = new Point(186, 128);
            label5.Name = "label5";
            label5.Size = new Size(293, 30);
            label5.TabIndex = 1;
            label5.Text = "Powered by Marian Cojocaru";
            // 
            // SplashScreen
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(664, 382);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(progressBar);
            Controls.Add(label1);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
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
    }
}