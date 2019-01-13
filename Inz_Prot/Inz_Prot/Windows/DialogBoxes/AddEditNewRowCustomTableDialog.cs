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
    public partial class AddEditNewRowCustomTableDialog : Form
    {
        //CustomTableDialogControls customTableDialog;
        List<CustomTableDialogControls> listOfControls;
        TableInfo tableInfo;
        DataGridViewRow selectedRow;
        DataGridView dataGrid = null;
        private AddEditNewRowCustomTableDialog()
        {
            InitializeComponent();

        }
        /// <summary>
        /// Pass data grid to go into edit mode
        /// </summary>
        /// <param name="tableInfo"></param>
        /// <param name="dataGrid"></param>
        public AddEditNewRowCustomTableDialog(TableInfo tableInfo, DataGridView dataGrid = null)
        {
            
            InitializeComponent();
            listOfControls = new List<CustomTableDialogControls>();
            this.tableInfo = tableInfo;
            foreach(ColumnInfo columnInfo in tableInfo.ColumnInfos_Row)
            {
                var tmp = new CustomTableDialogControls(mainPanel, columnInfo);
                if(columnInfo.ColumnType == ColumnType.Description)
                {
                    tmp.TxtInputValue.Multiline = true;
                }

                listOfControls.Add(tmp);
            }

            if(dataGrid != null)
            {
              if( dataGrid.SelectedRows.Count != 1)
                { // Potetnial troubleshooting goes here
                    return;
                }
                selectedRow = dataGrid.SelectedRows[0];
                this.dataGrid = dataGrid;
                                                    // - 2 becouse of index[0] and we have one additional hidden cell for table's Row ID 
                                                    // and our listOfControls cover only 'visible' cells 
                for (int i = 0; i < selectedRow.Cells.Count -2 ; i++)
                {   //out of range 
                    if (listOfControls[i].Type == TypeCode.DateTime)
                    {
            
                                                                                        // +1 becouse first cell (column) is Ordinal Number,and we don't need that 
                        listOfControls[i].TimePicker.Value = (DateTime) selectedRow.Cells[i + 1].Value;
                    }
                    else
                    {
                        listOfControls[i].TxtInputValue.Text = selectedRow.Cells[i+1].Value.ToString();
                    }
                }
            }
        }

        private void flowMainPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void WriteErrorAndHighlightRow(CustomTableDialogControls dialogControls,string message)
        {
            lblError.Text = message;
            lblError.Visible = true;
            dialogControls.ContainerPanel.BackColor = Color.Red;
            
        }

        private bool IsInputDataCorrect()
        {
            foreach (CustomTableDialogControls dialogControls in listOfControls)
            {
                if (dialogControls.Type == TypeCode.Int32)
                {
                    if (!Utilities.isStringNumber(dialogControls.TxtInputValue.Text) || dialogControls.TxtInputValue.Text == "")
                    {
                        WriteErrorAndHighlightRow(dialogControls, "W polu liczbowym niedozwolone są znaki alfabetu");
                      
                        return false;
                    }
                }

                if(dialogControls.Type == TypeCode.String)
                {
                    if(Utilities.StringContainsSpecialChars(dialogControls.TxtInputValue.Text) || dialogControls.TxtInputValue.Text == "")
                    {
                        WriteErrorAndHighlightRow(dialogControls, "Znaki specjalne są niedozwolone");
                        return false;
                    }
                    if(dialogControls.TxtInputValue.Text.Length > dbHelpers.NamesTypes.MAKS_DESCRIPTION_LENGHT)
                    {
                        WriteErrorAndHighlightRow(dialogControls, " Tekst przekracza maksymalną długość." + Environment.NewLine + "Maksymalna długość to 2048 znaków");
                        return false;
                    }
                }

                if (dialogControls.Type == TypeCode.Char)
                {
                    if (Utilities.StringContainsSpecialChars(dialogControls.TxtInputValue.Text) || dialogControls.TxtInputValue.Text =="")
                    {
                        WriteErrorAndHighlightRow(dialogControls, "Znaki specjalne są niedozwolone");
                        return false;
                    }
                    if (dialogControls.TxtInputValue.Text.Length > dbHelpers.NamesTypes.MAKS_SHORTTEXT_LENGHT)
                    {
                        WriteErrorAndHighlightRow(dialogControls, " Tekst przekracza maksymalną długość." + Environment.NewLine + "Maksymalna długość to 80 znaków");
                        return false;
                    }
                }
            }
            return true;
        }

        private void AddRowOkClick()
        {
            List<object> vals = new List<object>();
            foreach (CustomTableDialogControls dialogControls in listOfControls)
            {
                // WSZYSTKO musi byc string
                // kolejnosc parametrów taka jak kolejnosc kolumn w tabeli

                vals.Add(dialogControls.ValueString);

            }
            CustomTableHelper.AddRowToCustomTable(tableInfo, vals.ToArray());
        }

        private void EditRowOkClick()
        {
            int ID = (int)selectedRow.Cells[selectedRow.Cells.Count - 1].Value;

            List<object> vals = new List<object>();
            foreach (CustomTableDialogControls dialogControls in listOfControls)
            {
                // WSZYSTKO musi byc string
                // kolejnosc parametrów taka jak kolejnosc kolumn w tabeli

                vals.Add(dialogControls.ValueString);

            }
            CustomTableHelper.EditCustomTableCells(ID, tableInfo, tableInfo.ColumnsNames_String().ToArray(), vals.ToArray());
                    
            


        }

        private void btnOk_Click(object sender, EventArgs e)
        {
           //   this.btnOk.DialogResult = DialogResult.OK;
            if (!IsInputDataCorrect())
            {
                this.DialogResult = DialogResult.None;
           //     this.btnOk.DialogResult = DialogResult.None;
                return;
            }
                

            if (dataGrid !=null)
            {
                EditRowOkClick();
            }
            else
            {
                AddRowOkClick();
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Dispose();
        }
    }
}
