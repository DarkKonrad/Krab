using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Inz_Prot.Models.dbCustomTable;
using Inz_Prot.dbHelpers.TableEditors;

namespace Inz_Prot.Windows
{
    public partial class CustomTableFrame : Form
    {
        TableInfo userDefinedTable;
        CustomTableRows tableRows;
      
     
        public CustomTableFrame()
        {
            InitializeComponent();
            // TOD O: CHECK FOR UDT  CHECK DATETIME OBJECT PUSHING TO DB 
            userDefinedTable = CustomTableHelper.GetTableInfoAboutTables_OneRowVersion();
            dgCustomTable.MultiSelect = false;
            InitDataGrid();
        }
        
        public CustomTableFrame(TableInfo table)
        {
            InitializeComponent();
            userDefinedTable = table;
            dgCustomTable.MultiSelect = false;
            InitDataGrid();
        }

        private void InitDataGrid()
        {
            if(userDefinedTable == null)
            {
                MessageBox.Show("Obecnie nie ma żadnych " + dbHelpers.NamesTypes.CommonCustomTableName_POLISH_ADJECTIVE,"Uwaga",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                this.Dispose();
                return;
            }
            //DODAWANIA CUSTOM TABLE   dgCustomTable.
            dgCustomTable.Rows.Clear();
            dgCustomTable.Columns.Clear();

            dgCustomTable.Columns.Add("OrdinalNumber", "L.P.");
            foreach(ColumnInfo columnInfo in userDefinedTable.ColumnInfos_Row)
            {
                dgCustomTable.Columns.Add(columnInfo.Name, columnInfo.Name);

                if(columnInfo.ColumnType == ColumnType.DataType)
                dgCustomTable.Columns[columnInfo.Name].ValueType = typeof(DateTime);
            }
            ////////////
            dgCustomTable.Columns.Add("TableID", "TableID");
            dgCustomTable.Columns["TableID"].Visible = false;
            dgCustomTable.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            ///////////
            int customRowCount = CustomTableHelper.GetRowCount(userDefinedTable.TableName);
            tableRows = CustomTableHelper.GetAllRowsFromCustomTable(userDefinedTable);

            for (int i = 0 ;i<customRowCount  ;i++)
            {
                // Columns
                var currentRow = tableRows.Row[i];
                dgCustomTable.Rows.Add(1);
                dgCustomTable.Rows[i].Cells[0].Value =(int) i + 1;

                // Columns of row
                for (int j=0;j<currentRow.Count ;j++)
                {                 
                    switch (currentRow[j].GetType())
                    {
                        case TypeCode.DateTime:
                            //  buf_DataTime = (DateTime) currentRow[i].Value;
                            dgCustomTable.Rows[i].Cells[j + 1].ValueType = typeof(DateTime);
                            dgCustomTable.Rows[i].Cells[j + 1].Value = (DateTime) currentRow[j].Value;
                            break;
                        case TypeCode.String:
                         //   buf_descr = (string) currentRow[i].Value;
                            dgCustomTable.Rows[i].Cells[j + 1].Value = (string) currentRow[j].Value;
                            break;
                        case TypeCode.Char:
                        //    buf_shortText = (string) currentRow[i].Value;
                            dgCustomTable.Rows[i].Cells[j + 1].Value = (string) currentRow[j].Value;
                            break;
                        case TypeCode.Int32:
                            //   buf_Numeric = (int) currentRow[i].Value;
                            dgCustomTable.Rows[i].Cells[j + 1].ValueType = typeof(int);
                             dgCustomTable.Rows[i].Cells[j + 1].Value = (int) currentRow[j].Value;
                            break;
                        default: throw new Exception("CustomTableFrame Type Code Error");
                    }
                    
                }
                ////////
                dgCustomTable.Rows[i].Cells[dgCustomTable.Rows[i].Cells.Count-1].Value = currentRow[currentRow.Count-1].ID;
                ////////
            }
     
        }
 

        private void CustomTableFrame_Load(object sender, EventArgs e)
        {

        }

        private void btnAddCustomRow_Click(object sender, EventArgs e)
        {
            var customTableDialog = new DialogBoxes.AddEditNewRowCustomTableDialog(userDefinedTable);
            var dialogResult = customTableDialog.ShowDialog(this);
            if (dialogResult == DialogResult.OK)
                InitDataGrid();
        }

        private void CustomTableFrame_FormClosed(object sender, FormClosedEventArgs e)
        {
            Owner.Show();
            this.Hide();
            this.Dispose();
        }

        private void btnEditRow_Click(object sender, EventArgs e)
        {
            var customTableDialog = new DialogBoxes.AddEditNewRowCustomTableDialog(userDefinedTable,dgCustomTable);
            var dialogResult = customTableDialog.ShowDialog(this);
            if (dialogResult == DialogResult.OK)
                InitDataGrid();

        }

        private void btnToCSV_Click(object sender, EventArgs e)
        {
            Utilities.SaveToCSV_SaveDialogVersion(dgCustomTable);
            
        }
    }
}
