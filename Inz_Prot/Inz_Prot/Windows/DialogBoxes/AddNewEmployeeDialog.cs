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
    public partial class AddNewEmployeeDialog : Form
    {
        public AddNewEmployeeDialog()
        {
            InitializeComponent();
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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void AddNewEmployeeDialog_Load(object sender, EventArgs e)
        {

        }
    }
}
