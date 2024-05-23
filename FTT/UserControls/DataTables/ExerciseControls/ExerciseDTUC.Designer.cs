namespace FTT.UserControls.DataTables.ExerciseControls
{
    partial class ExerciseDTUC
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
            dgvExercise = new DataGridView();
            AddNewButton = new Button();
            EditButton = new Button();
            RemoveButton = new Button();
            RefreshButton = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvExercise).BeginInit();
            SuspendLayout();
            // 
            // dgvExercise
            // 
            dgvExercise.AllowUserToAddRows = false;
            dgvExercise.AllowUserToDeleteRows = false;
            dgvExercise.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvExercise.Location = new Point(3, 38);
            dgvExercise.MultiSelect = false;
            dgvExercise.Name = "dgvExercise";
            dgvExercise.ReadOnly = true;
            dgvExercise.RowHeadersWidth = 51;
            dgvExercise.Size = new Size(764, 280);
            dgvExercise.TabIndex = 0;
            dgvExercise.SelectionChanged += dgvExercise_SelectionChanged;
            // 
            // AddNewButton
            // 
            AddNewButton.Location = new Point(3, 3);
            AddNewButton.Name = "AddNewButton";
            AddNewButton.Size = new Size(94, 29);
            AddNewButton.TabIndex = 1;
            AddNewButton.Text = "Add New";
            AddNewButton.UseVisualStyleBackColor = true;
            AddNewButton.Click += AddNewButton_Click;
            // 
            // EditButton
            // 
            EditButton.Location = new Point(103, 3);
            EditButton.Name = "EditButton";
            EditButton.Size = new Size(94, 29);
            EditButton.TabIndex = 2;
            EditButton.Text = "Edit";
            EditButton.UseVisualStyleBackColor = true;
            EditButton.Click += EditButton_Click;
            // 
            // RemoveButton
            // 
            RemoveButton.ForeColor = Color.Red;
            RemoveButton.Location = new Point(673, 3);
            RemoveButton.Name = "RemoveButton";
            RemoveButton.Size = new Size(94, 29);
            RemoveButton.TabIndex = 3;
            RemoveButton.Text = "Remove";
            RemoveButton.UseVisualStyleBackColor = true;
            RemoveButton.Click += RemoveButton_Click;
            // 
            // RefreshButton
            // 
            RefreshButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            RefreshButton.ForeColor = Color.FromArgb(0, 192, 0);
            RefreshButton.Location = new Point(203, 3);
            RefreshButton.Name = "RefreshButton";
            RefreshButton.Size = new Size(45, 29);
            RefreshButton.TabIndex = 4;
            RefreshButton.Text = "♻";
            RefreshButton.UseVisualStyleBackColor = true;
            RefreshButton.Click += RefreshButton_Click;
            // 
            // ExerciseDTUC
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(RefreshButton);
            Controls.Add(RemoveButton);
            Controls.Add(EditButton);
            Controls.Add(AddNewButton);
            Controls.Add(dgvExercise);
            Name = "ExerciseDTUC";
            Size = new Size(770, 321);
            ((System.ComponentModel.ISupportInitialize)dgvExercise).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvExercise;
        private Button AddNewButton;
        private Button EditButton;
        private Button RemoveButton;
        private Button RefreshButton;
    }
}
