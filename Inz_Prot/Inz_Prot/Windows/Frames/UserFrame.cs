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
using Inz_Prot.Windows.DialogBoxes;
namespace Inz_Prot.Windows
{
    public partial class UserFrame : Form
    {
        List<User> listOfUsers;
        
        public UserFrame()
        {
            InitializeComponent();
            dataGridUsers.MultiSelect = false;
            dataGridUsers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridUsers.AllowUserToAddRows = false;
            dataGridUsers.AllowUserToDeleteRows = false;           
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
            var AddUserDialog = new AddEditUserDialog();
           var DialogResult =  AddUserDialog.ShowDialog(this);
        }

        private void UserFrame_FormClosed(object sender, FormClosedEventArgs e)
        {
            Owner.Show();
            this.Hide();
            this.Dispose();
        }

        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            if(dataGridUsers.SelectedRows.Count >1)
            {
                MessageBox.Show("Wystapil błąd. Nie należy zaznaczać więcej niż jeden wiersz.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var selectedRow = dataGridUsers.SelectedRows[0];

            foreach (User user in listOfUsers)
            {
                if (user.Login ==  (string)selectedRow.Cells[2].Value)
                {
                    var dialogResult = MessageBox.Show("Czy na pewno chcesz usunac tego uzytkownika z systemu ?", "Uwaga", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    if (dialogResult == DialogResult.OK)
                    {
                        UserHelper.DeleteUser(user);
                        RefreshTable();
                        break;
                    }
                    else
                        return;
                }
        }   }
    }
}
