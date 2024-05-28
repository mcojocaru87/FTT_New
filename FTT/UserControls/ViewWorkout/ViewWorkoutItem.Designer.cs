namespace FTT.UserControls.ViewWorkout
{
    partial class ViewWorkoutItem
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
            panel1 = new Panel();
            lblExerciseName = new Label();
            MainPanel = new FlowLayoutPanel();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.Highlight;
            panel1.Controls.Add(lblExerciseName);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(313, 37);
            panel1.TabIndex = 0;
            // 
            // lblExerciseName
            // 
            lblExerciseName.Dock = DockStyle.Fill;
            lblExerciseName.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblExerciseName.ForeColor = Color.White;
            lblExerciseName.Location = new Point(0, 0);
            lblExerciseName.Name = "lblExerciseName";
            lblExerciseName.Size = new Size(313, 37);
            lblExerciseName.TabIndex = 0;
            lblExerciseName.Text = "label1";
            lblExerciseName.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // MainPanel
            // 
            MainPanel.AutoScroll = true;
            MainPanel.Dock = DockStyle.Fill;
            MainPanel.Location = new Point(0, 37);
            MainPanel.Name = "MainPanel";
            MainPanel.Size = new Size(313, 109);
            MainPanel.TabIndex = 1;
            MainPanel.Layout += MainPanel_Layout;
            // 
            // ViewWorkoutItem
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(MainPanel);
            Controls.Add(panel1);
            Name = "ViewWorkoutItem";
            Size = new Size(313, 146);
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label lblExerciseName;
        private FlowLayoutPanel MainPanel;
    }
}
