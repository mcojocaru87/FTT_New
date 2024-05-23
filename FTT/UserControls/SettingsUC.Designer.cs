namespace FTT.UserControls
{
    partial class SettingsUC
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
            label1 = new Label();
            label2 = new Label();
            txtFailAttempts = new TextBox();
            txtMaxReps = new TextBox();
            SaveButton = new Button();
            CleanupButton = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label1.Location = new Point(326, 81);
            label1.Name = "label1";
            label1.Size = new Size(104, 20);
            label1.TabIndex = 0;
            label1.Text = "Fail Attempts";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label2.Location = new Point(326, 143);
            label2.Name = "label2";
            label2.Size = new Size(77, 20);
            label2.TabIndex = 1;
            label2.Text = "Max Reps";
            // 
            // txtFailAttempts
            // 
            txtFailAttempts.Location = new Point(326, 104);
            txtFailAttempts.Name = "txtFailAttempts";
            txtFailAttempts.Size = new Size(125, 27);
            txtFailAttempts.TabIndex = 2;
            // 
            // txtMaxReps
            // 
            txtMaxReps.Location = new Point(326, 166);
            txtMaxReps.Name = "txtMaxReps";
            txtMaxReps.Size = new Size(125, 27);
            txtMaxReps.TabIndex = 3;
            // 
            // SaveButton
            // 
            SaveButton.Location = new Point(326, 199);
            SaveButton.Name = "SaveButton";
            SaveButton.Size = new Size(125, 29);
            SaveButton.TabIndex = 4;
            SaveButton.Text = "Update";
            SaveButton.UseVisualStyleBackColor = true;
            SaveButton.Click += SaveButton_Click;
            // 
            // CleanupButton
            // 
            CleanupButton.Location = new Point(326, 302);
            CleanupButton.Name = "CleanupButton";
            CleanupButton.Size = new Size(125, 29);
            CleanupButton.TabIndex = 5;
            CleanupButton.Text = "Clean Up";
            CleanupButton.UseVisualStyleBackColor = true;
            CleanupButton.Click += CleanupButton_Click;
            // 
            // SettingsUC
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonFace;
            Controls.Add(CleanupButton);
            Controls.Add(SaveButton);
            Controls.Add(txtMaxReps);
            Controls.Add(txtFailAttempts);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "SettingsUC";
            Size = new Size(776, 381);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox txtFailAttempts;
        private TextBox txtMaxReps;
        private Button SaveButton;
        private Button CleanupButton;
    }
}
