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
using Inz_Prot.Models;
using Inz_Prot.Windows.SpecifiedControlls;
using Inz_Prot.Windows.DialogBoxes;
using Inz_Prot.Models.dbCustomTable.Juxaposition;
using Inz_Prot.Models.dbCustomTable;
using System.Diagnostics;

namespace Inz_Prot.Windows
{

    public partial class JuxapositionFrame : Form
    {
        //  List<JuxtapositionControls> listOfJuxtapositionControls;
        List<string> columnIDNames;
        Juxaposition juxaposition;
        public JuxapositionFrame()
        {
            InitializeComponent();
           columnIDNames = new List<string>();
        }

        void InitDadtaGrid()
        {
            if (juxaposition == null)
            {
                MessageBox.Show("Obecnie nie ma żadnych zestawien " , "Uwaga", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //this.Dispose();
                return;
            }
            //DODAWANIA CUSTOM TABLE   dgCustomTable.
            dgJuxaposition.Rows.Clear();
            dgJuxaposition.Columns.Clear();
           // columnIDNames.Clear();

            dgJuxaposition.Columns.Add("OrdinalNumber", "L.P.");
            foreach (JuxapositionColumnInfo JuxColumnInfo in juxaposition.JuxapositionColumnInfos)
            {
                dgJuxaposition.Columns.Add(JuxColumnInfo.ColumnInfo.Name, JuxColumnInfo.ColumnInfo.Name + " - " + JuxColumnInfo.ColumnInfo.ConvertedTypeToUser_PL + " " + JuxColumnInfo.ParentTableName);

                if (JuxColumnInfo.ColumnInfo.ColumnType == ColumnType.DataType)
                    dgJuxaposition.Columns[JuxColumnInfo.ColumnInfo.Name].ValueType = typeof(DateTime);
                if (JuxColumnInfo.ColumnInfo.ColumnType == ColumnType.Float)
                    dgJuxaposition.Columns[JuxColumnInfo.ColumnInfo.Name].ValueType = typeof(float);
            }
            ////////////

            dgJuxaposition.SelectionMode = DataGridViewSelectionMode.CellSelect;
            
            ///////////

            juxaposition.GetFillJuxtapositionColumns();
            var columns = juxaposition.JuxapositionColumns;
            dgJuxaposition.Rows.Add(juxaposition.LenghtOfLongestColumn);

            //IDS!
            //for (int i = 0; i < juxaposition.JuxapositionColumnInfos.Count - 1; i++)
            //{
            //    dgJuxaposition.Columns.Add(juxaposition.JuxapositionColumnInfos[i].ParentTableName + '_' + juxaposition.JuxapositionColumnInfos[i].ColumnInfo.Name + '_' + "ID",
            //       juxaposition.JuxapositionColumnInfos[i].ParentTableName + '_' + juxaposition.JuxapositionColumnInfos[i].ColumnInfo.Name + '_' + "ID");

            //    columnIDNames.Add(juxaposition.JuxapositionColumnInfos[i].ParentTableName + '_' + juxaposition.JuxapositionColumnInfos[i].ColumnInfo.Name + '_' + "ID");

            //    #region Filling ID Columns

            //    dgJuxaposition.Columns[columnIDNames[i]].Visible = false;
            //    dgJuxaposition.Columns[columnIDNames[i]].Tag = new ColumnID_ParentT_NameC(juxaposition.JuxapositionColumnInfos[i].ParentTableName,
            //        juxaposition.JuxapositionColumnInfos[i].ColumnInfo.Name); // duplicates ?

            //    for (int j = 0; j < juxaposition.JuxapositionColumns[i].ColumnContent.Count - 1; j++)
            //    {
            //        dgJuxaposition.Rows[j].Cells[j].Value    dgJuxaposition.Rows[j].Cells[j].t
            //        Debug.WriteLine(string.Format("ID Columns: Row: {0} CellVal: {1} ", j, juxaposition.JuxapositionColumns[i].ColumnContent[j].ID));
            //    }

            //    #endregion
            //}

            for (int i =0;i<juxaposition.LenghtOfLongestColumn;i++)
            {
                dgJuxaposition.Rows[i].Cells[0].Value = (int) i + 1;
            }


            for (int i = 0; i < columns.Count; i++)
            {
                // Columns
                var currentColumn = columns[i];

                // Columns of row
                for (int j = 0; j < currentColumn.Length; j++)
                {
                    switch (currentColumn.ColumnContent[j].GetType())
                    {
                        case TypeCode.DateTime:
                            //  buf_DataTime = (DateTime) currentRow[i].Value;
                            dgJuxaposition.Rows[j].Cells[i + 1].ValueType = typeof(DateTime);
                            dgJuxaposition.Rows[j].Cells[i + 1].Value = Convert.ToDateTime(currentColumn.ColumnContent[j].Value);//(DateTime) currentColumn.ColumnContent[j].Value;
                            dgJuxaposition.Rows[j].Cells[i + 1].Tag = new CellTag(currentColumn.ColumnContent[j], currentColumn.ParentTableName, currentColumn.ColumnInfo.Name);
                            break;
                        case TypeCode.String:
                            //   buf_descr = (string) currentRow[i].Value;
                            dgJuxaposition.Rows[j].Cells[i + 1].Value = (string) currentColumn.ColumnContent[j].Value;
                            dgJuxaposition.Rows[j].Cells[i + 1].Tag = new CellTag(currentColumn.ColumnContent[j], currentColumn.ParentTableName, currentColumn.ColumnInfo.Name);
                            break;
                        case TypeCode.Char:
                            //    buf_shortText = (string) currentRow[i].Value;
                            dgJuxaposition.Rows[j].Cells[i + 1].Value = (string) currentColumn.ColumnContent[j].Value;
                            dgJuxaposition.Rows[j].Cells[i + 1].Tag = new CellTag(currentColumn.ColumnContent[j], currentColumn.ParentTableName, currentColumn.ColumnInfo.Name);
                            break;
                        case TypeCode.Int32:
                            //   buf_Numeric = (int) currentRow[i].Value;
                            dgJuxaposition.Rows[j].Cells[i + 1].ValueType = typeof(int);
                            dgJuxaposition.Rows[j].Cells[i + 1].Value = (int) currentColumn.ColumnContent[j].Value;
                            dgJuxaposition.Rows[j].Cells[i + 1].Tag = new CellTag(currentColumn.ColumnContent[j], currentColumn.ParentTableName, currentColumn.ColumnInfo.Name);
                            break;
                        case TypeCode.Double:
                            dgJuxaposition.Rows[j].Cells[i + 1].ValueType = typeof(float);
                            dgJuxaposition.Rows[j].Cells[i + 1].Value = (float) currentColumn.ColumnContent[j].Value;
                            dgJuxaposition.Rows[j].Cells[i + 1].Tag = new CellTag(currentColumn.ColumnContent[j], currentColumn.ParentTableName, currentColumn.ColumnInfo.Name);
                            break;
                        default:
                            throw new Exception("CustomTableFrame Type Code Error");
                    }

                }
                ////////
               // dgCustomTable.Rows[i].Cells[dgCustomTable.Rows[i].Cells.Count - 1].Value = currentRow[currentRow.Count - 1].ID;
                ////////
            }

        }
    


        private void JuxapositionFrame_Load(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void btnChooseJuxA_Click(object sender, EventArgs e)
        {

        }
       
        private void btnChooseJuxA_Click_1(object sender, EventArgs e)
        {
            var dialog = new ChooseJuxapositionDialog();
            var dialogResult = dialog.ShowDialog(this);
            if(dialogResult == DialogResult.OK)
            {
                juxaposition = dialog.GetChosen();
                dialog.Hide();
                dialog.Dispose();
                InitDadtaGrid();
            }
        }

        private void btnAddJux_Click(object sender, EventArgs e)
        {
            var dialog = new AddEditJuxtaposition();
            dialog.Show(this);
            //this.Hide();
        }
    }

    class CellTag
    {
        string tableName, columnName;
        CellContent cellContent;
        public CellTag(CellContent cellContent,string tableName, string columnName)
        {
            this.tableName = tableName;
            this.columnName = columnName;
            this.cellContent = cellContent;
        }

        public string TableName { get => tableName; set => tableName = value; }
        public string ColumnName { get => columnName; set => columnName = value; }
        public CellContent CellContent { get => cellContent; set => cellContent = value; }
    }
}
