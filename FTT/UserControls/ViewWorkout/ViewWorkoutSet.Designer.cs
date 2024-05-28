namespace FTT.UserControls.ViewWorkout
{
    partial class ViewWorkoutSet
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
            lblSet = new Label();
            SuspendLayout();
            // 
            // lblSet
            // 
            lblSet.Dock = DockStyle.Fill;
            lblSet.Location = new Point(0, 0);
            lblSet.Name = "lblSet";
            lblSet.Size = new Size(313, 25);
            lblSet.TabIndex = 0;
            lblSet.Text = "label1";
            lblSet.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // ViewWorkoutSet
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(lblSet);
            Name = "ViewWorkoutSet";
            Size = new Size(313, 25);
            ResumeLayout(false);
        }

        #endregion

        private Label lblSet;
    }
}
