using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
namespace Inz_Prot
{
    public partial class LoginForm : Form
    {
        
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Models.User usr = Models.User.GetUser(txtbLogin.Text, txtbPassword.Text);
            MainWindow.Main_Window MainWindow = new MainWindow.Main_Window(usr);
            this.Hide();
            MainWindow.Show();

        }
    }
}
