using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AdressManagement
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
                    
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            addressDBEntities addressDBEntities = new addressDBEntities();
            if (addressDBEntities.UserLogins.Select(c => c.UserName).Contains(txtUsername.Text.Trim()))
            {
                var user = addressDBEntities.UserLogins.Where(x => x.UserName == txtUsername.Text.Trim()).FirstOrDefault();
                if (user.Password == txtPassword.Text.Trim() && user.Role.RoleName == "User")
                {
                    Dashboard dashboard = new Dashboard();
                    dashboard.Show();
                    
                }
                else if (user.Password == txtPassword.Text.Trim() && user.Role.RoleName == "Admin")
                {
                    AdminDashboard dashboard = new AdminDashboard();
                    dashboard.Show();
                }
            }
            else
            {
                MessageBox.Show("User does not exist");
            }
        }
    }
}
