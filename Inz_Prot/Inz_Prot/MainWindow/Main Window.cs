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

namespace Inz_Prot.MainWindow
{
    public partial class Main_Window : Form
    {
        User CurrentUser;

        private Main_Window()
        {
            InitializeComponent();
        }

       public Main_Window(User user)
        {
            InitializeComponent();
            labelUser.Text = user.Name + Environment.NewLine + user.Surname;
            CurrentUser = user;
        }

        private void btnEmployees_Click(object sender, EventArgs e)
        {
            var emplForm = new Windows.EmployeeFrame();
            emplForm.Show();
           //this.Hide();
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
        
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            var ChangePassForm = new Windows.DialogBoxes.ChangePassDialog(CurrentUser);
            ChangePassForm.Show();

        }
    }
}
