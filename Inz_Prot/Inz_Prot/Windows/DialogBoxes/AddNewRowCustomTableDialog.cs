using Inz_Prot.Models.dbCustomTable;
using Inz_Prot.Windows.SpecifiedControlls;
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
    public partial class AddNewRowCustomTableDialog : Form
    {
        //CustomTableDialogControls customTableDialog;
        List<CustomTableDialogControls> listOfControls;
        TableInfo tableInfo;
        private AddNewRowCustomTableDialog()
        {
            InitializeComponent();
          //  customTableDialog = new CustomTableDialogControls(flowMainPanel,)
        }
        public AddNewRowCustomTableDialog(TableInfo tableInfo)
        {
            InitializeComponent();
            listOfControls = new List<CustomTableDialogControls>();
            this.tableInfo = tableInfo;
            foreach(ColumnInfo columnInfo in tableInfo.Columns)
            {
                listOfControls.Add(new CustomTableDialogControls(mainPanel, columnInfo));
            }


        }

        private void flowMainPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            List<object> vals = new List<object>();
            foreach(CustomTableDialogControls dialogControls in listOfControls)
            {
                // WSZYSTKO musi byc string
                // kolejnosc parametrów taka jak kolejnosc kolumn w tabeli
                vals.Add(dialogControls.Value);

            }
            CustomTableHelper.AddRowToCustomTable(tableInfo, vals.ToArray());

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Dispose();
        }
    }
}
