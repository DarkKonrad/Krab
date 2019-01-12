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
namespace Inz_Prot.MainWindow
{
    public partial class AdminChangeCredentials : Form
    {
        LoginForm loginForm;
        public AdminChangeCredentials(LoginForm form) 
        {
            InitializeComponent();
            lblWarning.Visible = false;
            loginForm = form;
        }

        private void Accept_Click(object sender, EventArgs e)
        {
          if(txtPass.Text == txtPassVer.Text)
            {
              var admin =  UserHelper.CreateAdmin(txtName.Text, txtSurname.Text, txtPass.Text);
                MessageBox.Show("Został wygenerowany unikalny login. Zapisz go oraz używaj od tego momentu w celu uzyskania dostępu do systemu",
                    "Wygenerowano login", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loginForm.SetGeneratedLoginLabel("Twój wygenerowany login to:" + Environment.NewLine + admin.Login);
                this.Dispose();
               
            }
          else
            {
                lblWarning.Show();
            }

        }

        private void AdminChangeCredentials_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
