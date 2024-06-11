namespace FTT
{
    partial class CalculatorForm
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
            cbExercises = new ComboBox();
            label1 = new Label();
            CloseButton = new Button();
            label2 = new Label();
            txtWeight = new TextBox();
            SuspendLayout();
            // 
            // cbExercises
            // 
            cbExercises.FormattingEnabled = true;
            cbExercises.Location = new Point(155, 69);
            cbExercises.Name = "cbExercises";
            cbExercises.Size = new Size(192, 23);
            cbExercises.TabIndex = 0;
            cbExercises.SelectedIndexChanged += cbExercises_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(155, 51);
            label1.Name = "label1";
            label1.Size = new Size(52, 15);
            label1.TabIndex = 1;
            label1.Text = "Exercise:";
            // 
            // CloseButton
            // 
            CloseButton.Location = new Point(534, 253);
            CloseButton.Name = "CloseButton";
            CloseButton.Size = new Size(75, 23);
            CloseButton.TabIndex = 2;
            CloseButton.Text = "Close";
            CloseButton.UseVisualStyleBackColor = true;
            CloseButton.Click += CloseButton_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(155, 113);
            label2.Name = "label2";
            label2.Size = new Size(73, 15);
            label2.TabIndex = 3;
            label2.Text = "Weight (Kg):";
            // 
            // txtWeight
            // 
            txtWeight.Location = new Point(155, 131);
            txtWeight.Name = "txtWeight";
            txtWeight.Size = new Size(100, 23);
            txtWeight.TabIndex = 4;
            // 
            // CalculatorForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 338);
            Controls.Add(txtWeight);
            Controls.Add(label2);
            Controls.Add(CloseButton);
            Controls.Add(label1);
            Controls.Add(cbExercises);
            FormBorderStyle = FormBorderStyle.None;
            Name = "CalculatorForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "CalculatorForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cbExercises;
        private Label label1;
        private Button CloseButton;
        private Label label2;
        private TextBox txtWeight;
    }
}