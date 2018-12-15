using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Inz_Prot.Models;
using Inz_Prot.Windows;
namespace Inz_Prot.MainWindow
{
    public partial class Main_Window : Form
    {
        User CurrentUser;
       const int interspace = 60;
        private Main_Window()
        {
            InitializeComponent();
            
        }
        private void CenterButtons()
        {
            var controls = this.MainMenuPanel.Controls;
            int i = 1;
            foreach(Control control in controls)
            {
                control.Location = new Point(
                    MainMenuPanel.Width / 3,
                     interspace * i);
                i++;
            }
            
        }
       public Main_Window(User user)
        {
            InitializeComponent();
            labelUser.Text = user.Name + Environment.NewLine + user.Surname;
            CurrentUser = user;
            CenterButtons();

            
        }

        private void btnEmployees_Click(object sender, EventArgs e)
        {
            var emplForm = new Windows.EmployeeFrame();
            emplForm.Size = this.Size;
            emplForm.StartPosition = this.StartPosition;       
            emplForm.Show(this);
            this.Hide();
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            var usersTable = new Windows.UserFrame();
            usersTable.Size = this.Size;
            usersTable.StartPosition = this.StartPosition;
            usersTable.Show(this);
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            var ChangePassForm = new Windows.DialogBoxes.ChangePassDialog(CurrentUser);
            ChangePassForm.Show();

        }

        private void MainMenuPanel_SizeChanged(object sender, EventArgs e)
        {
            CenterButtons();

        }

        private void btnStrServ_Click(object sender, EventArgs e)
        {
            var createTable = new TableCreatorFrame();
            createTable.Show();
        }
    }
}
