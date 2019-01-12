using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Inz_Prot.Windows.SpecifiedControlls;
using Inz_Prot.Models.dbCustomTable;
namespace Inz_Prot.Windows
{
    public partial class TableCreatorFrame : Form
    {
        List<TableTemplate> listOfColumnTemplates;
      

        public void MoveUp()
        {
            if (MainPanel.Parent == null)
                return;

            var index = MainPanel.Parent.Controls.GetChildIndex(this);
            if (index <= MainPanel.Parent.Controls.Count)
                MainPanel.Parent.Controls.SetChildIndex(this, index + 1);
        }

        public void MoveDown()
        {
            if (MainPanel.Parent == null)
                return;

            var index = MainPanel.Parent.Controls.GetChildIndex(this);
            if (index > 0)
                MainPanel.Parent.Controls.SetChildIndex(this, index - 1);
        }



        public TableCreatorFrame()
        {
            InitializeComponent();
            listOfColumnTemplates = new List<TableTemplate>();
            tableNameHelp.SetHelpString(txtTableName, " Nazwij swój zbiór danych. " + Environment.NewLine +"Przykład: \"Magazyn\" lub \"Usługi\" ");
            tableNameHelp.SetShowHelp(txtTableName, true);
        }

        private void containerPanel_Click(object sender, EventArgs e)
        {
            Control control = (Control) sender;
            
            
            foreach(TableTemplate tmp in listOfColumnTemplates)
            {
                if (tmp.ContainerPanel.Name != control.Name)
                {
                    tmp.IsControlPanelClicked = false;
                    tmp.ContainerPanel.BackColor = SystemColors.Control;
                }
                else
                {
                    tmp.IsControlPanelClicked = true;
                    tmp.ContainerPanel.BackColor = Color.LightGreen;
                }
                    
            }

            
        }

        private void btnAddField_Click(object sender, EventArgs e)
        {
            
            var tableRowTemplate = new TableTemplate(MainPanel,containerPanel_Click);
            listOfColumnTemplates.Add(tableRowTemplate);
            tableRowTemplate.Show();
            MainPanel.Refresh();


        }

        private bool AreRowsContainsSpecialChars()
        {
            bool conatinsSpecialCharsOrEmpty = false;
            foreach (TableTemplate dbColumn in listOfColumnTemplates)
            {
                dbColumn.TxtColumnName.Text.Trim();
                if (Utilities.StringContainsSpecialChars(dbColumn.TxtColumnName.Text) || dbColumn.TxtColumnName.Text =="")
                {                  
                    dbColumn.ContainerPanel.BackColor = Color.Red;
                    conatinsSpecialCharsOrEmpty = true;
                }

            }
            txtTableName.Text.Trim();
            if(txtTableName.Text =="" || Utilities.StringContainsSpecialChars(txtTableName.Text))
            {
                txtTableName.BackColor = Color.Red;
                return false;
            }
            return conatinsSpecialCharsOrEmpty;
        }

        private void btnDeleteRow_Click(object sender, EventArgs e)
        {
           
            foreach(TableTemplate dbRow in listOfColumnTemplates)
            {
                if(dbRow.IsControlPanelClicked == true)
                {          
                    dbRow.Dispose();
                    listOfColumnTemplates.Remove(dbRow);
                    break;
                }
                
            }

            TableTemplate.ReGenerateIndexes(listOfColumnTemplates);
        }
        private void SetCustomRowsBackgroundTransparent()
        {
            foreach (TableTemplate dbColumn in listOfColumnTemplates)
            {
                dbColumn.ContainerPanel.BackColor = SystemColors.Control;

            }
        }
        private void btnAcceptAllRows_Click(object sender, EventArgs e)
        {
           // txtTableName.BackColor = 
            lblInfo.Visible = false;
            SetCustomRowsBackgroundTransparent();
            if(AreRowsContainsSpecialChars())
            {
                lblInfo.Text = "Zawartosc pola nazwy nie może być pusta ani zawierać znaków specjalnych";
                lblInfo.Visible = true;
                return;
            }

            var tableInfo = new TableInfo(txtTableName.Text);

            foreach (TableTemplate dbColumn in listOfColumnTemplates)
            {
                tableInfo.Add(dbColumn.GetColumnInfo());
            }

            tableInfo.ColumnInfos_Row.Reverse();

            dbHelpers.TableEditors.CustomTableHelper.AddCustomTable(tableInfo);

            MessageBox.Show("Stworzenie nowego zbioru danych powidło się");

            this.Hide();
          //  Owner.Show();
            this.Dispose();
        }

        private void txtTableName_MouseEnter(object sender, EventArgs e)
        {
          
        }

        private void lblInfo_Click(object sender, EventArgs e)
        {

        }
    }
}
