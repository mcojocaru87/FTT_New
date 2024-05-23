namespace FTT.UserControls
{
    partial class DatabaseUC
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
            cbDataTable = new ComboBox();
            label1 = new Label();
            MainPanel = new Panel();
            SuspendLayout();
            // 
            // cbDataTable
            // 
            cbDataTable.FormattingEnabled = true;
            cbDataTable.Location = new Point(3, 23);
            cbDataTable.Name = "cbDataTable";
            cbDataTable.Size = new Size(151, 28);
            cbDataTable.TabIndex = 0;
            cbDataTable.SelectedIndexChanged += cbDataTable_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(94, 20);
            label1.TabIndex = 1;
            label1.Text = "Data Tables:";
            // 
            // MainPanel
            // 
            MainPanel.Location = new Point(3, 57);
            MainPanel.Name = "MainPanel";
            MainPanel.Size = new Size(770, 321);
            MainPanel.TabIndex = 2;
            MainPanel.Visible = false;
            // 
            // DatabaseUC
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonFace;
            Controls.Add(MainPanel);
            Controls.Add(label1);
            Controls.Add(cbDataTable);
            Name = "DatabaseUC";
            Size = new Size(776, 381);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cbDataTable;
        private Label label1;
        private Panel MainPanel;
    }
}
