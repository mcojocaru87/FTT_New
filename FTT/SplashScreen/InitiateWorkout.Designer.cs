namespace FTT
{
    partial class InitiateWorkout
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
            progressBar = new ProgressBar();
            SuspendLayout();
            // 
            // progressBar
            // 
            progressBar.Location = new Point(25, 36);
            progressBar.Name = "progressBar";
            progressBar.Size = new Size(200, 26);
            progressBar.TabIndex = 1;
            // 
            // InitiateWorkout
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(251, 98);
            ControlBox = false;
            Controls.Add(progressBar);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "InitiateWorkout";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Initiating ...";
            Shown += InitiateWorkout_Shown;
            ResumeLayout(false);
        }

        #endregion
        private ProgressBar progressBar;
    }
}