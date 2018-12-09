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

        public void SetGeneratedLoginLabel(string text)
        {
            this.lblGeneratedLogin.Text = text;
            lblGeneratedLogin.Visible = true;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            lblLoginCredError.Visible = false;
            lblGeneratedLogin.Visible = false;
            if (string.Equals(txtbLogin.Text, "Admin01") && string.Equals(txtbPassword.Text, "AdminPassword"))
            {
                if(Models.User.CheckForAdmin()==false)
                {
                    var CreateAdminForm = new MainWindow.AdminChangeCredentials(this);
                    CreateAdminForm.Show();
                    return;
                }
            }
                
                Models.User usr = Models.User._GetUser(txtbLogin.Text, txtbPassword.Text);
            if (usr == null)
            {
                lblLoginCredError.Visible = true;
                return;
            }
                
            MainWindow.Main_Window MainWindow = new MainWindow.Main_Window(usr);
            this.Hide();
            MainWindow.Show();

        }
    }
}
