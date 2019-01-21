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
namespace Inz_Prot.Windows.DialogBoxes
{
    public partial class ChangePassDialog : Form
    {
        Models.User user;
        public ChangePassDialog(Models.User user)
        {
            InitializeComponent();
            this.user = user;
        }
        

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (!UserHelper.VerifyPasswordFromDB(user, txtCurrentPassword.Text))
            {
                MessageBox.Show("Podane obecne hasło jest nieprawidłowe", "Nieprawidłowe hasło", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtNewPass.Text != txtNewPassVerf.Text)
            {
                MessageBox.Show("Podane hasła różnią się", "Nieprawidłowe hasło", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!Utilities.VerifyPasswordRequirements(txtNewPass.Text))
            {
                MessageBox.Show("Hasło musi zawierać co najmniej 6 znaków oraz jedną cyfrę", "Nieprawidłowe hasło", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            UserHelper.ChangePassword(user, txtNewPass.Text);
            MessageBox.Show("Hasło zostało zmienione", "Zmiana hasła powiodła się", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Hide();
            this.Dispose();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Dispose();
        }
    }
}
