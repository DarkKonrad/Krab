using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inz_Prot.Windows.DialogBoxes
{
    public partial class AddEditEmployeeDialog : Form
    {
        public AddEditEmployeeDialog()
        {
            InitializeComponent();
            dateTimeExp.Enabled = false;
        }

        public AddEditEmployeeDialog(Models.Employee employee)
        {
            InitializeComponent();
            txtName.Text = employee.Name;
            txtAddress.Text = employee.Address;
            txtPESEL.Text = employee.Pesel;
            txtPosition.Text = employee.Position;
            txtSurname.Text= employee.Surname;
            dateTimebDay.Value = employee.BirthDay.Date;
            dateTimeWorkStart.Value = employee.HireFrom.Date;

            if(employee.HireExp.HasValue)
            {
                dateTimeExp.Value = employee.HireExp.Value.Date;
                expDateCheckbox.Checked = true;
                dateTimeExp.Enabled = true;
            }
            else
            {
                expDateCheckbox.Checked = false;
                dateTimeExp.Enabled = false;
            }

        }
        private void expDateCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (expDateCheckbox.CheckState == CheckState.Unchecked)
            {
                dateTimeExp.Enabled = false;

            }
            else
                dateTimeExp.Enabled = true;
        }
        public Models.Employee GetDialogEmployee(DialogResult dialogResult,int? id=null)
        {
            if (dialogResult != DialogResult.Yes)
                return null;

            return ( new Models.Employee(
                id,
                txtName.Text,
                txtSurname.Text,
                txtPESEL.Text,
                txtAddress.Text,
                txtPosition.Text,
                dateTimebDay.Value,
                dateTimeWorkStart.Value,
                dateTimeExp.Value) );  // null ? 

        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void AddNewEmployeeDialog_Load(object sender, EventArgs e)
        {

        }
    }
}
