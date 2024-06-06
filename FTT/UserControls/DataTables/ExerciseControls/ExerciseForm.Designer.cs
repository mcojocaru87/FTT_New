namespace FTT.UserControls.DataTables.ExerciseControls
{
    partial class ExerciseForm
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
            label1 = new Label();
            SaveButton = new Button();
            CancelButton = new Button();
            label2 = new Label();
            txtId = new TextBox();
            label3 = new Label();
            label4 = new Label();
            txtName = new TextBox();
            cbMultiplier = new ComboBox();
            cbCategory = new ComboBox();
            label5 = new Label();
            cbEquipment = new ComboBox();
            label6 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label1.Location = new Point(32, 26);
            label1.Name = "label1";
            label1.Size = new Size(152, 21);
            label1.TabIndex = 0;
            label1.Text = "Add / Edit Exercise";
            // 
            // SaveButton
            // 
            SaveButton.Location = new Point(10, 208);
            SaveButton.Margin = new Padding(3, 2, 3, 2);
            SaveButton.Name = "SaveButton";
            SaveButton.Size = new Size(82, 22);
            SaveButton.TabIndex = 1;
            SaveButton.Text = "Save";
            SaveButton.UseVisualStyleBackColor = true;
            SaveButton.Click += SaveButton_Click;
            // 
            // CancelButton
            // 
            CancelButton.Location = new Point(153, 208);
            CancelButton.Margin = new Padding(3, 2, 3, 2);
            CancelButton.Name = "CancelButton";
            CancelButton.Size = new Size(82, 22);
            CancelButton.TabIndex = 2;
            CancelButton.Text = "Cancel";
            CancelButton.UseVisualStyleBackColor = true;
            CancelButton.Click += CancelButton_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(50, 67);
            label2.Name = "label2";
            label2.Size = new Size(21, 15);
            label2.TabIndex = 3;
            label2.Text = "ID:";
            // 
            // txtId
            // 
            txtId.Location = new Point(79, 64);
            txtId.Margin = new Padding(3, 2, 3, 2);
            txtId.Name = "txtId";
            txtId.ReadOnly = true;
            txtId.Size = new Size(110, 23);
            txtId.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(29, 92);
            label3.Name = "label3";
            label3.Size = new Size(42, 15);
            label3.TabIndex = 5;
            label3.Text = "Name:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(10, 117);
            label4.Name = "label4";
            label4.Size = new Size(61, 15);
            label4.TabIndex = 6;
            label4.Text = "Multiplier:";
            // 
            // txtName
            // 
            txtName.Location = new Point(79, 89);
            txtName.Margin = new Padding(3, 2, 3, 2);
            txtName.Name = "txtName";
            txtName.Size = new Size(110, 23);
            txtName.TabIndex = 7;
            // 
            // cbMultiplier
            // 
            cbMultiplier.FormattingEnabled = true;
            cbMultiplier.Location = new Point(79, 114);
            cbMultiplier.Margin = new Padding(3, 2, 3, 2);
            cbMultiplier.Name = "cbMultiplier";
            cbMultiplier.Size = new Size(110, 23);
            cbMultiplier.TabIndex = 8;
            // 
            // cbCategory
            // 
            cbCategory.FormattingEnabled = true;
            cbCategory.Location = new Point(79, 140);
            cbCategory.Margin = new Padding(3, 2, 3, 2);
            cbCategory.Name = "cbCategory";
            cbCategory.Size = new Size(110, 23);
            cbCategory.TabIndex = 10;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(13, 143);
            label5.Name = "label5";
            label5.Size = new Size(58, 15);
            label5.TabIndex = 9;
            label5.Text = "Category:";
            // 
            // cbEquipment
            // 
            cbEquipment.FormattingEnabled = true;
            cbEquipment.Location = new Point(79, 167);
            cbEquipment.Margin = new Padding(3, 2, 3, 2);
            cbEquipment.Name = "cbEquipment";
            cbEquipment.Size = new Size(110, 23);
            cbEquipment.TabIndex = 12;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(3, 170);
            label6.Name = "label6";
            label6.Size = new Size(68, 15);
            label6.TabIndex = 11;
            label6.Text = "Equipment:";
            // 
            // ExerciseForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(246, 256);
            Controls.Add(cbEquipment);
            Controls.Add(label6);
            Controls.Add(cbCategory);
            Controls.Add(label5);
            Controls.Add(cbMultiplier);
            Controls.Add(txtName);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(txtId);
            Controls.Add(label2);
            Controls.Add(CancelButton);
            Controls.Add(SaveButton);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 2, 3, 2);
            Name = "ExerciseForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ExerciseForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button SaveButton;
        private Button CancelButton;
        private Label label2;
        private TextBox txtId;
        private Label label3;
        private Label label4;
        private TextBox txtName;
        private ComboBox cbMultiplier;
        private ComboBox cbCategory;
        private Label label5;
        private ComboBox cbEquipment;
        private Label label6;
    }
}