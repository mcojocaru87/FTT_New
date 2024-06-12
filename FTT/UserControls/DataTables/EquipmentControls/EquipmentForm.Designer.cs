namespace FTT.UserControls.DataTables.EquipmentControls
{
    partial class EquipmentForm
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
            txtName = new TextBox();
            label4 = new Label();
            label3 = new Label();
            txtId = new TextBox();
            label2 = new Label();
            label1 = new Label();
            txtShortName = new TextBox();
            CancelButton = new Button();
            SaveButton = new Button();
            rbIsPlate = new RadioButton();
            rbIsDumbbell = new RadioButton();
            SuspendLayout();
            // 
            // txtName
            // 
            txtName.Location = new Point(127, 93);
            txtName.Margin = new Padding(3, 2, 3, 2);
            txtName.Name = "txtName";
            txtName.Size = new Size(110, 23);
            txtName.TabIndex = 14;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(46, 121);
            label4.Name = "label4";
            label4.Size = new Size(73, 15);
            label4.TabIndex = 13;
            label4.Text = "Short Name:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(77, 96);
            label3.Name = "label3";
            label3.Size = new Size(42, 15);
            label3.TabIndex = 12;
            label3.Text = "Name:";
            // 
            // txtId
            // 
            txtId.Location = new Point(127, 68);
            txtId.Margin = new Padding(3, 2, 3, 2);
            txtId.Name = "txtId";
            txtId.ReadOnly = true;
            txtId.Size = new Size(110, 23);
            txtId.TabIndex = 11;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(98, 71);
            label2.Name = "label2";
            label2.Size = new Size(21, 15);
            label2.TabIndex = 10;
            label2.Text = "ID:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label1.Location = new Point(66, 30);
            label1.Name = "label1";
            label1.Size = new Size(174, 21);
            label1.TabIndex = 9;
            label1.Text = "Add / Edit Equipment";
            // 
            // txtShortName
            // 
            txtShortName.Location = new Point(127, 118);
            txtShortName.Name = "txtShortName";
            txtShortName.Size = new Size(110, 23);
            txtShortName.TabIndex = 15;
            // 
            // CancelButton
            // 
            CancelButton.Location = new Point(180, 202);
            CancelButton.Margin = new Padding(3, 2, 3, 2);
            CancelButton.Name = "CancelButton";
            CancelButton.Size = new Size(82, 22);
            CancelButton.TabIndex = 17;
            CancelButton.Text = "Cancel";
            CancelButton.UseVisualStyleBackColor = true;
            CancelButton.Click += CancelButton_Click;
            // 
            // SaveButton
            // 
            SaveButton.Location = new Point(37, 202);
            SaveButton.Margin = new Padding(3, 2, 3, 2);
            SaveButton.Name = "SaveButton";
            SaveButton.Size = new Size(82, 22);
            SaveButton.TabIndex = 16;
            SaveButton.Text = "Save";
            SaveButton.UseVisualStyleBackColor = true;
            SaveButton.Click += SaveButton_Click;
            // 
            // rbIsPlate
            // 
            rbIsPlate.AutoSize = true;
            rbIsPlate.Location = new Point(127, 168);
            rbIsPlate.Name = "rbIsPlate";
            rbIsPlate.Size = new Size(67, 19);
            rbIsPlate.TabIndex = 19;
            rbIsPlate.TabStop = true;
            rbIsPlate.Text = "Is Plate?";
            rbIsPlate.UseVisualStyleBackColor = true;
            // 
            // rbIsDumbbell
            // 
            rbIsDumbbell.AutoSize = true;
            rbIsDumbbell.Location = new Point(127, 147);
            rbIsDumbbell.Name = "rbIsDumbbell";
            rbIsDumbbell.Size = new Size(86, 19);
            rbIsDumbbell.TabIndex = 18;
            rbIsDumbbell.TabStop = true;
            rbIsDumbbell.Text = "Is Dumbbell?";
            rbIsDumbbell.UseVisualStyleBackColor = true;
            // 
            // EquipmentForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(306, 238);
            Controls.Add(rbIsPlate);
            Controls.Add(rbIsDumbbell);
            Controls.Add(CancelButton);
            Controls.Add(SaveButton);
            Controls.Add(txtShortName);
            Controls.Add(txtName);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(txtId);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "EquipmentForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "EquipmentForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox txtName;
        private Label label4;
        private Label label3;
        private TextBox txtId;
        private Label label2;
        private Label label1;
        private TextBox txtShortName;
        private Button CancelButton;
        private Button SaveButton;
        private RadioButton rbIsPlate;
        private RadioButton rbIsDumbbell;
    }
}