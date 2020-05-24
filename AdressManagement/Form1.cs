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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text.Trim() == string.Empty || txtPassword.Text.Trim() == string.Empty || txtEmail.Text.Trim() == string.Empty)
            {
                MessageBox.Show("UserName, Password & Email cannot be Empty!");
            }
            try
            {
                addressDBEntities addressDBEntities = new addressDBEntities();

                UserLogin userLogin = new UserLogin
                {
                    UserName = txtUsername.Text.Trim(),
                    Role = addressDBEntities.Roles.FirstOrDefault(),
                    RoleId = addressDBEntities.Roles.Where(l => l.RoleName == "User").Select(c => c.ID).FirstOrDefault(),
                    Password = txtPassword.Text.Trim()
                };
                addressDBEntities.UserLogins.Add(userLogin);
                addressDBEntities.SaveChanges();
                //addressDBEntities.UserLogins.Add(new UserLogin
                //{
                //    UserName = txtUsername.Text.Trim(),
                //    RoleId = addressDBEntities.Roles.Where(l=>l.RoleName == "User").Select(c=>c.ID).FirstOrDefault(),
                //    Role = addressDBEntities.Roles.FirstOrDefault(),
                //    Password = txtPassword.Text.Trim()
                //});

                addressDBEntities.Registrations.Add(new Registration
                {
                    FirstName = txtFirstName.Text,
                    LastName = txtLastName.Text,
                    Contact = txtContact.Text,
                    Email = txtEmail.Text,
                    UserId = addressDBEntities.UserLogins.Where(n => n.UserName == txtUsername.Text).Select(u => u.ID).FirstOrDefault(),
                    UserLogin = addressDBEntities.UserLogins.Where(c => c.UserName == txtUsername.Text).FirstOrDefault(),
                });
                addressDBEntities.SaveChanges();
                Login login = new Login();
                this.Hide();
                login.Show();

            }
            catch (Exception ex)
            {

                throw ex;
            }
            

        }

        private void lnkLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Login login = new Login();
            this.Hide();
            login.Show();
        }
    }
}
