namespace FTT.UserControls.DataTables.EquipmentControls
{
    partial class EquipmentItemsViewForm
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
            CloseButton = new Button();
            label1 = new Label();
            txtSelectedEquipment = new TextBox();
            dgItems = new DataGridView();
            AddButton = new Button();
            EditButton = new Button();
            DeleteButton = new Button();
            MainPanel = new Panel();
            label2 = new Label();
            cbEquipment = new ComboBox();
            cbUnits = new ComboBox();
            label3 = new Label();
            label4 = new Label();
            cbWeight = new TextBox();
            cbUoM = new ComboBox();
            label5 = new Label();
            SaveButton = new Button();
            CancelButton = new Button();
            ((System.ComponentModel.ISupportInitialize)dgItems).BeginInit();
            MainPanel.SuspendLayout();
            SuspendLayout();
            // 
            // CloseButton
            // 
            CloseButton.Location = new Point(584, 7);
            CloseButton.Name = "CloseButton";
            CloseButton.Size = new Size(62, 23);
            CloseButton.TabIndex = 0;
            CloseButton.Text = "Close";
            CloseButton.UseVisualStyleBackColor = true;
            CloseButton.Click += CloseButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(115, 15);
            label1.TabIndex = 1;
            label1.Text = "Selected Equipment:";
            // 
            // txtSelectedEquipment
            // 
            txtSelectedEquipment.Location = new Point(133, 6);
            txtSelectedEquipment.Name = "txtSelectedEquipment";
            txtSelectedEquipment.ReadOnly = true;
            txtSelectedEquipment.Size = new Size(172, 23);
            txtSelectedEquipment.TabIndex = 2;
            // 
            // dgItems
            // 
            dgItems.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgItems.Location = new Point(12, 35);
            dgItems.Name = "dgItems";
            dgItems.Size = new Size(293, 155);
            dgItems.TabIndex = 3;
            dgItems.SelectionChanged += dgItems_SelectionChanged;
            // 
            // AddButton
            // 
            AddButton.ForeColor = Color.Green;
            AddButton.Location = new Point(311, 5);
            AddButton.Name = "AddButton";
            AddButton.Size = new Size(50, 23);
            AddButton.TabIndex = 4;
            AddButton.Text = "Add";
            AddButton.UseVisualStyleBackColor = true;
            // 
            // EditButton
            // 
            EditButton.ForeColor = Color.DarkOrange;
            EditButton.Location = new Point(367, 5);
            EditButton.Name = "EditButton";
            EditButton.Size = new Size(50, 23);
            EditButton.TabIndex = 5;
            EditButton.Text = "Edit";
            EditButton.UseVisualStyleBackColor = true;
            // 
            // DeleteButton
            // 
            DeleteButton.ForeColor = Color.Red;
            DeleteButton.Location = new Point(422, 5);
            DeleteButton.Name = "DeleteButton";
            DeleteButton.Size = new Size(50, 23);
            DeleteButton.TabIndex = 6;
            DeleteButton.Text = "Delete";
            DeleteButton.UseVisualStyleBackColor = true;
            // 
            // MainPanel
            // 
            MainPanel.Controls.Add(CancelButton);
            MainPanel.Controls.Add(SaveButton);
            MainPanel.Controls.Add(cbUoM);
            MainPanel.Controls.Add(label5);
            MainPanel.Controls.Add(cbWeight);
            MainPanel.Controls.Add(label4);
            MainPanel.Controls.Add(cbUnits);
            MainPanel.Controls.Add(label3);
            MainPanel.Controls.Add(cbEquipment);
            MainPanel.Controls.Add(label2);
            MainPanel.Location = new Point(311, 35);
            MainPanel.Name = "MainPanel";
            MainPanel.Size = new Size(335, 155);
            MainPanel.TabIndex = 7;
            MainPanel.Visible = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(41, 19);
            label2.Name = "label2";
            label2.Size = new Size(68, 15);
            label2.TabIndex = 8;
            label2.Text = "Equipment:";
            // 
            // cbEquipment
            // 
            cbEquipment.DropDownStyle = ComboBoxStyle.DropDownList;
            cbEquipment.Enabled = false;
            cbEquipment.FormattingEnabled = true;
            cbEquipment.Location = new Point(41, 37);
            cbEquipment.Name = "cbEquipment";
            cbEquipment.Size = new Size(121, 23);
            cbEquipment.TabIndex = 9;
            // 
            // cbUnits
            // 
            cbUnits.FormattingEnabled = true;
            cbUnits.Location = new Point(173, 37);
            cbUnits.Name = "cbUnits";
            cbUnits.Size = new Size(121, 23);
            cbUnits.TabIndex = 11;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(173, 19);
            label3.Name = "label3";
            label3.Size = new Size(37, 15);
            label3.TabIndex = 10;
            label3.Text = "Units:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(41, 63);
            label4.Name = "label4";
            label4.Size = new Size(48, 15);
            label4.TabIndex = 12;
            label4.Text = "Weight:";
            // 
            // cbWeight
            // 
            cbWeight.Location = new Point(41, 81);
            cbWeight.Name = "cbWeight";
            cbWeight.Size = new Size(120, 23);
            cbWeight.TabIndex = 13;
            // 
            // cbUoM
            // 
            cbUoM.FormattingEnabled = true;
            cbUoM.Location = new Point(172, 81);
            cbUoM.Name = "cbUoM";
            cbUoM.Size = new Size(121, 23);
            cbUoM.TabIndex = 15;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(172, 63);
            label5.Name = "label5";
            label5.Size = new Size(94, 15);
            label5.TabIndex = 14;
            label5.Text = "Unit of Measure:";
            // 
            // SaveButton
            // 
            SaveButton.Location = new Point(41, 119);
            SaveButton.Name = "SaveButton";
            SaveButton.Size = new Size(75, 23);
            SaveButton.TabIndex = 16;
            SaveButton.Text = "Save";
            SaveButton.UseVisualStyleBackColor = true;
            // 
            // CancelButton
            // 
            CancelButton.Location = new Point(218, 119);
            CancelButton.Name = "CancelButton";
            CancelButton.Size = new Size(75, 23);
            CancelButton.TabIndex = 17;
            CancelButton.Text = "Cancel";
            CancelButton.UseVisualStyleBackColor = true;
            // 
            // EquipmentItemsViewForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(658, 202);
            Controls.Add(MainPanel);
            Controls.Add(DeleteButton);
            Controls.Add(EditButton);
            Controls.Add(AddButton);
            Controls.Add(dgItems);
            Controls.Add(txtSelectedEquipment);
            Controls.Add(label1);
            Controls.Add(CloseButton);
            FormBorderStyle = FormBorderStyle.None;
            Name = "EquipmentItemsViewForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "EquipmentItemsViewForm";
            ((System.ComponentModel.ISupportInitialize)dgItems).EndInit();
            MainPanel.ResumeLayout(false);
            MainPanel.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button CloseButton;
        private Label label1;
        private TextBox txtSelectedEquipment;
        private DataGridView dgItems;
        private Button AddButton;
        private Button EditButton;
        private Button DeleteButton;
        private Panel MainPanel;
        private ComboBox cbEquipment;
        private Label label2;
        private ComboBox cbUnits;
        private Label label3;
        private Label label4;
        private Button CancelButton;
        private Button SaveButton;
        private ComboBox cbUoM;
        private Label label5;
        private TextBox cbWeight;
    }
}