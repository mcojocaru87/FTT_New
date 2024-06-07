namespace FTT.UserControls.DataTables.RepRangeIntervalControls
{
    partial class RepRangeIntervalDTUC
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
            RefreshButton = new Button();
            RemoveButton = new Button();
            EditButton = new Button();
            AddNewButton = new Button();
            dgvExercise = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvExercise).BeginInit();
            SuspendLayout();
            // 
            // RefreshButton
            // 
            RefreshButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            RefreshButton.ForeColor = Color.FromArgb(0, 192, 0);
            RefreshButton.Location = new Point(178, 2);
            RefreshButton.Margin = new Padding(3, 2, 3, 2);
            RefreshButton.Name = "RefreshButton";
            RefreshButton.Size = new Size(39, 22);
            RefreshButton.TabIndex = 14;
            RefreshButton.Text = "♻";
            RefreshButton.UseVisualStyleBackColor = true;
            RefreshButton.Click += RefreshButton_Click;
            // 
            // RemoveButton
            // 
            RemoveButton.ForeColor = Color.Red;
            RemoveButton.Location = new Point(589, 2);
            RemoveButton.Margin = new Padding(3, 2, 3, 2);
            RemoveButton.Name = "RemoveButton";
            RemoveButton.Size = new Size(82, 22);
            RemoveButton.TabIndex = 13;
            RemoveButton.Text = "Remove";
            RemoveButton.UseVisualStyleBackColor = true;
            RemoveButton.Click += RemoveButton_Click;
            // 
            // EditButton
            // 
            EditButton.Location = new Point(90, 2);
            EditButton.Margin = new Padding(3, 2, 3, 2);
            EditButton.Name = "EditButton";
            EditButton.Size = new Size(82, 22);
            EditButton.TabIndex = 12;
            EditButton.Text = "Edit";
            EditButton.UseVisualStyleBackColor = true;
            EditButton.Click += EditButton_Click;
            // 
            // AddNewButton
            // 
            AddNewButton.Location = new Point(3, 2);
            AddNewButton.Margin = new Padding(3, 2, 3, 2);
            AddNewButton.Name = "AddNewButton";
            AddNewButton.Size = new Size(82, 22);
            AddNewButton.TabIndex = 11;
            AddNewButton.Text = "Add New";
            AddNewButton.UseVisualStyleBackColor = true;
            AddNewButton.Click += AddNewButton_Click;
            // 
            // dgvExercise
            // 
            dgvExercise.AllowUserToAddRows = false;
            dgvExercise.AllowUserToDeleteRows = false;
            dgvExercise.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvExercise.Location = new Point(3, 28);
            dgvExercise.Margin = new Padding(3, 2, 3, 2);
            dgvExercise.MultiSelect = false;
            dgvExercise.Name = "dgvExercise";
            dgvExercise.ReadOnly = true;
            dgvExercise.RowHeadersWidth = 51;
            dgvExercise.Size = new Size(668, 210);
            dgvExercise.TabIndex = 10;
            dgvExercise.SelectionChanged += dgvExercise_SelectionChanged;
            // 
            // RepRangeIntervalDTUC
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(RefreshButton);
            Controls.Add(RemoveButton);
            Controls.Add(EditButton);
            Controls.Add(AddNewButton);
            Controls.Add(dgvExercise);
            Name = "RepRangeIntervalDTUC";
            Size = new Size(674, 241);
            ((System.ComponentModel.ISupportInitialize)dgvExercise).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button RefreshButton;
        private Button RemoveButton;
        private Button EditButton;
        private Button AddNewButton;
        private DataGridView dgvExercise;
    }
}
