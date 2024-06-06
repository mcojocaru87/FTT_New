namespace FTT.UserControls.DataTables.ToolTimerControls
{
    partial class ToolTimerForm
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
            cbSeconds = new ComboBox();
            label5 = new Label();
            cbMinutes = new ComboBox();
            label4 = new Label();
            label3 = new Label();
            txtId = new TextBox();
            label2 = new Label();
            CancelButton = new Button();
            SaveButton = new Button();
            label1 = new Label();
            cbDisplay = new ComboBox();
            label6 = new Label();
            cbHours = new ComboBox();
            SuspendLayout();
            // 
            // cbSeconds
            // 
            cbSeconds.FormattingEnabled = true;
            cbSeconds.Location = new Point(73, 120);
            cbSeconds.Margin = new Padding(3, 2, 3, 2);
            cbSeconds.Name = "cbSeconds";
            cbSeconds.Size = new Size(110, 23);
            cbSeconds.TabIndex = 21;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(13, 123);
            label5.Name = "label5";
            label5.Size = new Size(54, 15);
            label5.TabIndex = 20;
            label5.Text = "Seconds:";
            // 
            // cbMinutes
            // 
            cbMinutes.FormattingEnabled = true;
            cbMinutes.Location = new Point(73, 93);
            cbMinutes.Margin = new Padding(3, 2, 3, 2);
            cbMinutes.Name = "cbMinutes";
            cbMinutes.Size = new Size(110, 23);
            cbMinutes.TabIndex = 19;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(14, 96);
            label4.Name = "label4";
            label4.Size = new Size(53, 15);
            label4.TabIndex = 17;
            label4.Text = "Minutes:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(25, 69);
            label3.Name = "label3";
            label3.Size = new Size(42, 15);
            label3.TabIndex = 16;
            label3.Text = "Hours:";
            // 
            // txtId
            // 
            txtId.Location = new Point(73, 39);
            txtId.Margin = new Padding(3, 2, 3, 2);
            txtId.Name = "txtId";
            txtId.ReadOnly = true;
            txtId.Size = new Size(110, 23);
            txtId.TabIndex = 15;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(46, 42);
            label2.Name = "label2";
            label2.Size = new Size(21, 15);
            label2.TabIndex = 14;
            label2.Text = "ID:";
            // 
            // CancelButton
            // 
            CancelButton.Location = new Point(146, 193);
            CancelButton.Margin = new Padding(3, 2, 3, 2);
            CancelButton.Name = "CancelButton";
            CancelButton.Size = new Size(82, 22);
            CancelButton.TabIndex = 13;
            CancelButton.Text = "Cancel";
            CancelButton.UseVisualStyleBackColor = true;
            CancelButton.Click += CancelButton_Click;
            // 
            // SaveButton
            // 
            SaveButton.Location = new Point(3, 193);
            SaveButton.Margin = new Padding(3, 2, 3, 2);
            SaveButton.Name = "SaveButton";
            SaveButton.Size = new Size(82, 22);
            SaveButton.TabIndex = 12;
            SaveButton.Text = "Save";
            SaveButton.UseVisualStyleBackColor = true;
            SaveButton.Click += SaveButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label1.Location = new Point(26, 1);
            label1.Name = "label1";
            label1.Size = new Size(134, 21);
            label1.TabIndex = 11;
            label1.Text = "Add / Edit Timer";
            // 
            // cbDisplay
            // 
            cbDisplay.FormattingEnabled = true;
            cbDisplay.Location = new Point(73, 147);
            cbDisplay.Margin = new Padding(3, 2, 3, 2);
            cbDisplay.Name = "cbDisplay";
            cbDisplay.Size = new Size(110, 23);
            cbDisplay.TabIndex = 23;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(19, 150);
            label6.Name = "label6";
            label6.Size = new Size(48, 15);
            label6.TabIndex = 22;
            label6.Text = "Display:";
            // 
            // cbHours
            // 
            cbHours.FormattingEnabled = true;
            cbHours.Location = new Point(73, 66);
            cbHours.Margin = new Padding(3, 2, 3, 2);
            cbHours.Name = "cbHours";
            cbHours.Size = new Size(110, 23);
            cbHours.TabIndex = 24;
            // 
            // ToolTimerForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(230, 228);
            Controls.Add(cbHours);
            Controls.Add(cbDisplay);
            Controls.Add(label6);
            Controls.Add(cbSeconds);
            Controls.Add(label5);
            Controls.Add(cbMinutes);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(txtId);
            Controls.Add(label2);
            Controls.Add(CancelButton);
            Controls.Add(SaveButton);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "ToolTimerForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ToolTimerForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cbSeconds;
        private Label label5;
        private ComboBox cbMinutes;
        private Label label4;
        private Label label3;
        private TextBox txtId;
        private Label label2;
        private Button CancelButton;
        private Button SaveButton;
        private Label label1;
        private ComboBox cbDisplay;
        private Label label6;
        private ComboBox cbHours;
    }
}