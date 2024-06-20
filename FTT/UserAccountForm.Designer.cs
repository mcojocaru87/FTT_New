namespace FTT
{
    partial class UserAccountForm
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
            label2 = new Label();
            txtUsername = new TextBox();
            txtPassword = new TextBox();
            RegisterButton = new Button();
            lstRegisteredUsers = new ListBox();
            label3 = new Label();
            cbUserRoles = new ComboBox();
            label4 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(37, 30);
            label1.Name = "label1";
            label1.Size = new Size(63, 15);
            label1.TabIndex = 0;
            label1.Text = "Username:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(37, 74);
            label2.Name = "label2";
            label2.Size = new Size(60, 15);
            label2.TabIndex = 1;
            label2.Text = "Password:";
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(37, 48);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(100, 23);
            txtUsername.TabIndex = 2;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(37, 92);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(100, 23);
            txtPassword.TabIndex = 3;
            // 
            // RegisterButton
            // 
            RegisterButton.Location = new Point(37, 164);
            RegisterButton.Name = "RegisterButton";
            RegisterButton.Size = new Size(100, 23);
            RegisterButton.TabIndex = 4;
            RegisterButton.Text = "Register";
            RegisterButton.UseVisualStyleBackColor = true;
            RegisterButton.Click += RegisterButton_Click;
            // 
            // lstRegisteredUsers
            // 
            lstRegisteredUsers.FormattingEnabled = true;
            lstRegisteredUsers.ItemHeight = 15;
            lstRegisteredUsers.Location = new Point(207, 48);
            lstRegisteredUsers.Name = "lstRegisteredUsers";
            lstRegisteredUsers.Size = new Size(120, 139);
            lstRegisteredUsers.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(207, 30);
            label3.Name = "label3";
            label3.Size = new Size(96, 15);
            label3.TabIndex = 6;
            label3.Text = "Registered Users:";
            // 
            // cbUserRoles
            // 
            cbUserRoles.FormattingEnabled = true;
            cbUserRoles.Location = new Point(37, 134);
            cbUserRoles.Name = "cbUserRoles";
            cbUserRoles.Size = new Size(100, 23);
            cbUserRoles.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(37, 118);
            label4.Name = "label4";
            label4.Size = new Size(33, 15);
            label4.TabIndex = 8;
            label4.Text = "Role:";
            // 
            // UserAccountForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 333);
            Controls.Add(label4);
            Controls.Add(cbUserRoles);
            Controls.Add(label3);
            Controls.Add(lstRegisteredUsers);
            Controls.Add(RegisterButton);
            Controls.Add(txtPassword);
            Controls.Add(txtUsername);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "UserAccountForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "User Accounts";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox txtUsername;
        private TextBox txtPassword;
        private Button RegisterButton;
        private ListBox lstRegisteredUsers;
        private Label label3;
        private ComboBox cbUserRoles;
        private Label label4;
    }
}