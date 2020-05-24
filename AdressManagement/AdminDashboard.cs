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
    public partial class AdminDashboard : Form
    {
        public AdminDashboard()
        {
            InitializeComponent();
        }

        private void AdminDashboard_Load(object sender, EventArgs e)
        {
           addressDBEntities addressDBEntities = new addressDBEntities();
           var users = addressDBEntities.UserLogins.Join(addressDBEntities.Registrations,
               user => user.ID,
               sa => sa.UserId,
             (user, sa) => new { UserName = user.UserName,
                                  UserRole = user.Role.RoleName,
                                  Contact = sa.Contact,
                                  Email = sa.Email,
                                  FirstName = sa.FirstName,
                                  LastName = sa.LastName                                            
                  })
 .           Select(userAndRegistration => userAndRegistration).ToList();
            dataGridView.DataSource = users;

        }

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView.SelectedRows.Count != 0)
            {
                DataGridViewRow row = this.dataGridView.SelectedRows[0];
                txtUsername.Text = row.Cells["UserName"].Value.ToString();
            }

        }

      
    }
}
