using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inz_Prot.Models;
using System.Windows.Forms;
using Inz_Prot.dbHelpers.TableEditors;

namespace Inz_Prot.Windows.DialogBoxes
{
    public partial class AddEditUserDialog : Form
    {
        public AddEditUserDialog()
        {
            InitializeComponent();
            foreach(var item in Enum.GetValues(typeof(User.Privileges)))
            {
                comboPriv.Items.Add(item);
            }
        }
        private void ClearErrors()
        {
            lblError.Text = "";
            lblError.Visible = false;
        }

        private bool AreInputsCorrect()
        {
            ClearErrors();
            bool isOk = true;

            if(Utilities.isStringNumber(txtName.Text) || Utilities.isStringNumber(txtSurname.Text) 
                || Utilities.StringContainsSpecialChars(txtName.Text) || Utilities.StringContainsSpecialChars(txtSurname.Text))
            {
                lblError.Text += "Cyfry oraz znaki specjalne są niedozwolone" + Environment.NewLine;
                lblError.Visible = true;
                isOk = false;
            }
            if (!( txtPassword.Text == txtPasswordV.Text ))
            {
                lblError.Text += "Hasła nie są jednakowe" + Environment.NewLine;
                lblError.Visible = true;
                isOk = false;
            }
            if(!Utilities.VerifyPasswordRequirements(txtPassword.Text))
            {
                lblError.Text += "Hasło powinno składać się z minimum 6 znaków i jednej cyfry" + Environment.NewLine;
                lblError.Visible = true;
                isOk = false;
            }
            return isOk;
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (AreInputsCorrect()==false)
            {
                DialogResult = DialogResult.Abort;
                return;
            }
                
            UserHelper.AddUser(txtName.Text,txtSurname.Text,txtPassword.Text,(User.Privileges) comboPriv.SelectedItem);

            this.Hide();
            this.Dispose();
        }

        private void AddEditUserDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            
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
