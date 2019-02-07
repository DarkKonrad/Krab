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
            if(Utilities.isStringNumber(txtName.Text)|| Utilities.isStringNumber(txtSurname.Text)
                || Utilities.StringContainsSpecialChars(txtName.Text) || Utilities.StringContainsSpecialChars(txtSurname.Text))
            {
                lblWarning.Text = "Pole imienia i nazwiska nie mogą zawierać cyfr ani znaków specjalnych";
                lblWarning.Visible = true;
                return;
            }
            if (txtPass.Text == txtPassVer.Text || txtPass.Text.Length > 6) 
            {
                
              var admin =  UserHelper.CreateAdmin(txtName.Text, txtSurname.Text, txtPass.Text);
                MessageBox.Show("Został wygenerowany unikalny login. Zapisz go oraz używaj od tego momentu w celu uzyskania dostępu do systemu",
                    "Wygenerowano login", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loginForm.SetGeneratedLoginLabel("Twój wygenerowany login to:" + Environment.NewLine + admin.Login);
                this.Dispose();
               
            }
          else
            {
                lblWarning.Text = "Hasła muszą być jednakowe oraz składać się z minimum 6 znaków";
                lblWarning.Visible = true;
                return;
            }

        }

        private void AdminChangeCredentials_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
