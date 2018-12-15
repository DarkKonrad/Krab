using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Inz_Prot.dbHelpers.TableEditors;
using Inz_Prot.Models;
namespace Inz_Prot.Windows
{
    public partial class UserFrame : Form
    {
        List<User> listOfUsers;
        
        public UserFrame()
        {
            InitializeComponent();
            RefreshTable();
        }

        private void RefreshTable()
        {
            listOfUsers = UserHelper.GetAllUsers();

            dataGridUsers.Rows.Clear();
            dataGridUsers.MultiSelect = false;
            
            int i = 0;

            foreach (User user in listOfUsers)
            {
                dataGridUsers.Rows.Insert(
                  i,
                    user.Name,
                    user.Surname,
                    user.Login,
                    user.Privilege.ToString());

                i++;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Owner.Show();
            this.Hide();
            this.Dispose();
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {

        }

        private void UserFrame_FormClosed(object sender, FormClosedEventArgs e)
        {
            Owner.Show();
            this.Hide();
            this.Dispose();
        }
    }
}
