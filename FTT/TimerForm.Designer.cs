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
            lblTime.Font = new Font("Impact", 90F);
            lblTime.Location = new Point(103, 97);
            lblTime.Name = "lblTime";
            lblTime.Size = new Size(494, 145);
            lblTime.TabIndex = 2;
            lblTime.Text = "00:00:00";
            // 
            // timer
            // 
            timer.Interval = 1000;
            timer.Tick += timer_Tick;
            // 
            // TimerForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 338);
            Controls.Add(lblTime);
            Controls.Add(lblSkip);
            Controls.Add(chkDoNotShow);
            FormBorderStyle = FormBorderStyle.None;
            Name = "TimerForm";
            Opacity = 0.8D;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "TimerForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CheckBox chkDoNotShow;
        private LinkLabel lblSkip;
        private Label lblTime;
        private System.Windows.Forms.Timer timer;
    }
}