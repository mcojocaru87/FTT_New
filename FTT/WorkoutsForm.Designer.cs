using FTT.CustomControls;

namespace FTT
{
    partial class WorkoutsForm
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
            panel1 = new Panel();
            lblMonthYear = new Label();
            panel2 = new Panel();
            dtMonthYear = new MonthYearPicker();
            panel3 = new Panel();
            label7 = new Label();
            label1 = new Label();
            label2 = new Label();
            label6 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            daysContainer = new FlowLayoutPanel();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(lblMonthYear);
            panel1.Controls.Add(panel2);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(857, 49);
            panel1.TabIndex = 0;
            // 
            // lblMonthYear
            // 
            lblMonthYear.AutoSize = true;
            lblMonthYear.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblMonthYear.Location = new Point(12, 6);
            lblMonthYear.Name = "lblMonthYear";
            lblMonthYear.Size = new Size(189, 37);
            lblMonthYear.TabIndex = 0;
            lblMonthYear.Text = "January 2024";
            // 
            // panel2
            // 
            panel2.Controls.Add(dtMonthYear);
            panel2.Dock = DockStyle.Right;
            panel2.Location = new Point(657, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(200, 49);
            panel2.TabIndex = 0;
            // 
            // dtMonthYear
            // 
            dtMonthYear.CustomFormat = "MMMM yyyy";
            dtMonthYear.Format = DateTimePickerFormat.Custom;
            dtMonthYear.Location = new Point(8, 13);
            dtMonthYear.Name = "dtMonthYear";
            dtMonthYear.ShowUpDown = true;
            dtMonthYear.Size = new Size(185, 23);
            dtMonthYear.TabIndex = 0;
            dtMonthYear.ValueChanged += dtMonthYear_ValueChanged;
            // 
            // panel3
            // 
            panel3.Controls.Add(label7);
            panel3.Controls.Add(label1);
            panel3.Controls.Add(label2);
            panel3.Controls.Add(label6);
            panel3.Controls.Add(label3);
            panel3.Controls.Add(label4);
            panel3.Controls.Add(label5);
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(0, 49);
            panel3.Name = "panel3";
            panel3.Size = new Size(857, 48);
            panel3.TabIndex = 1;
            // 
            // label7
            // 
            label7.Font = new Font("Segoe UI", 13F);
            label7.Location = new Point(735, 3);
            label7.Name = "label7";
            label7.Padding = new Padding(5);
            label7.Size = new Size(116, 40);
            label7.TabIndex = 3;
            label7.Text = "Sunday";
            label7.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI", 13F);
            label1.Location = new Point(3, 3);
            label1.Name = "label1";
            label1.Padding = new Padding(5);
            label1.Size = new Size(116, 40);
            label1.TabIndex = 0;
            label1.Text = "Monday";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.Font = new Font("Segoe UI", 13F);
            label2.Location = new Point(125, 3);
            label2.Name = "label2";
            label2.Padding = new Padding(5);
            label2.Size = new Size(116, 40);
            label2.TabIndex = 1;
            label2.Text = "Tuesday";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            label6.Font = new Font("Segoe UI", 13F);
            label6.Location = new Point(613, 3);
            label6.Name = "label6";
            label6.Padding = new Padding(5);
            label6.Size = new Size(116, 40);
            label6.TabIndex = 3;
            label6.Text = "Saturday";
            label6.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            label3.Font = new Font("Segoe UI", 13F);
            label3.Location = new Point(247, 3);
            label3.Name = "label3";
            label3.Padding = new Padding(5);
            label3.Size = new Size(116, 40);
            label3.TabIndex = 2;
            label3.Text = "Wednesday";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            label4.Font = new Font("Segoe UI", 13F);
            label4.Location = new Point(369, 3);
            label4.Name = "label4";
            label4.Padding = new Padding(5);
            label4.Size = new Size(116, 40);
            label4.TabIndex = 3;
            label4.Text = "Thursday";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            label5.Font = new Font("Segoe UI", 13F);
            label5.Location = new Point(491, 3);
            label5.Name = "label5";
            label5.Padding = new Padding(5);
            label5.Size = new Size(116, 40);
            label5.TabIndex = 3;
            label5.Text = "Friday";
            label5.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // daysContainer
            // 
            daysContainer.Dock = DockStyle.Fill;
            daysContainer.Location = new Point(0, 97);
            daysContainer.Name = "daysContainer";
            daysContainer.Size = new Size(857, 353);
            daysContainer.TabIndex = 0;
            // 
            // WorkoutsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(857, 450);
            Controls.Add(daysContainer);
            Controls.Add(panel3);
            Controls.Add(panel1);
            MaximizeBox = false;
            Name = "WorkoutsForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Calendar";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel3.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Label lblMonthYear;
        private Panel panel3;
        private Label label3;
        private Label label2;
        private Label label1;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private FlowLayoutPanel daysContainer;
        private MonthYearPicker dtMonthYear;
    }
}