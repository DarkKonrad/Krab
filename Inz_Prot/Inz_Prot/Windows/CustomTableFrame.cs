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
             userDefinedTable = CustomTableHelper.GetTableInfoAboutTables();
            InitDataGrid();
        }
        
 

        private void InitDataGrid()
        {
             
            //DODAWANIA CUSTOM TABLE   dgCustomTable.
            dgCustomTable.Columns.Add("OrdinalNumber", "L.P.");
            foreach(ColumnInfo columnInfo in userDefinedTable.Columns)
            {
                dgCustomTable.Columns.Add(columnInfo.Name, columnInfo.Name);
            }

            int customRowCount = CustomTableHelper.GetRowCount(userDefinedTable.TableName);
            tableRows = CustomTableHelper.GetAllRowsFromCustomTable(userDefinedTable);

            for (int i = 0 ;i<customRowCount  ;i++)
            {
                // Columns
               var currentRow = tableRows.Row[i];
                dgCustomTable.Rows.Add(i+1);
               
                // Columns of row
                for(int j=0;j<currentRow.Count ;j++)
                {
                    // SWITCH

                    switch (currentRow[j].GetType())
                    {
                        case TypeCode.DateTime:
                          //  buf_DataTime = (DateTime) currentRow[i].Value;
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
                            dgCustomTable.Rows[i].Cells[j + 1].Value = (int) currentRow[j].Value;
                            break;
                        default: throw new Exception("CustomTableFrame Type Code Error");
                    }
                    
                }
                
            }
     
        }
 

        private void CustomTableFrame_Load(object sender, EventArgs e)
        {

        }

        private void btnAddCustomRow_Click(object sender, EventArgs e)
        {
            var customTableDialog = new DialogBoxes.AddNewRowCustomTableDialog(userDefinedTable);
            var dialogResult = customTableDialog.ShowDialog(this);
            if (dialogResult == DialogResult.OK)
                InitDataGrid();
        }
    }
}
