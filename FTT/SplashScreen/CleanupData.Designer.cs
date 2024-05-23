namespace FTT
{
    partial class CleanupData
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
            progressBar.Location = new Point(48, 28);
            progressBar.Name = "progressBar";
            progressBar.Size = new Size(205, 29);
            progressBar.TabIndex = 1;
            // 
            // CleanupData
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(301, 84);
            ControlBox = false;
            Controls.Add(progressBar);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "CleanupData";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Cleanning up ... Please Wait!";
            Shown += CleanupData_Shown;
            ResumeLayout(false);
        }

        #endregion
        private ProgressBar progressBar;
    }
}