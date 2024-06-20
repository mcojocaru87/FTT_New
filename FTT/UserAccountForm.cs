using FTT.Enums;
using FTT.Services.Authentication;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FTT
{
    public partial class UserAccountForm : Form
    {
        private readonly IAuthenticationService _authenticationService;

        public UserAccountForm()
        {
            InitializeComponent();

            _authenticationService = Session.Instance.ServiceProvider.GetRequiredService<IAuthenticationService>();

            SetupUserRoles();
        }

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            var username = txtUsername.Text;
            var password = txtPassword.Text;
            var role = (UserRole)cbUserRoles.SelectedItem;

            if (_authenticationService.Register(username, password, role))
            {
                MessageBox.Show("Registration successful!");

                txtUsername.Clear();
                txtPassword.Clear();
                cbUserRoles.SelectedIndex = 0;

                lstRegisteredUsers.Items.Add(username);
            }
            else
            {
                MessageBox.Show("User already exists.");
            }
        }

        private void SetupUserRoles()
        {
            cbUserRoles.DataSource = Enum.GetValues(typeof(UserRole));
        }
    }
}
