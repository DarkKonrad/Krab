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
namespace Inz_Prot.Windows
{
    public partial class JuxapositionFrame : Form
    {
        //  List<JuxtapositionControls> listOfJuxtapositionControls;
        Juxaposition juxaposition;
        public JuxapositionFrame()
        {
            InitializeComponent();
           
        }

        void InitDadtaGrid()
        {
            if (juxaposition == null)
            {
                MessageBox.Show("Obecnie nie ma żadnych " + dbHelpers.NamesTypes.CommonCustomTableName_POLISH_ADJECTIVE, "Uwaga", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //this.Dispose();
                return;
            }
            //DODAWANIA CUSTOM TABLE   dgCustomTable.
            dgJuxaposition.Rows.Clear();
            dgJuxaposition.Columns.Clear();

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
    
            dgJuxaposition.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            ///////////

            juxaposition.GetFillJuxtapositionColumns();
            var columns = juxaposition.JuxapositionColumns;
            dgJuxaposition.Rows.Add(juxaposition.LenghtOfLongestColumn);

            // IDS!

            for(int i =0;i<juxaposition.LenghtOfLongestColumn;i++)
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
                            dgJuxaposition.Rows[j].Cells[i + 1].Value = (DateTime) currentColumn.ColumnContent[j].Value;
                            break;
                        case TypeCode.String:
                            //   buf_descr = (string) currentRow[i].Value;
                            dgJuxaposition.Rows[j].Cells[i + 1].Value = (string) currentColumn.ColumnContent[j].Value;
                            break;
                        case TypeCode.Char:
                            //    buf_shortText = (string) currentRow[i].Value;
                            dgJuxaposition.Rows[j].Cells[i + 1].Value = (string) currentColumn.ColumnContent[j].Value;
                            break;
                        case TypeCode.Int32:
                            //   buf_Numeric = (int) currentRow[i].Value;
                            dgJuxaposition.Rows[j].Cells[i + 1].ValueType = typeof(int);
                            dgJuxaposition.Rows[j].Cells[i + 1].Value = (int) currentColumn.ColumnContent[j].Value;
                            break;
                        case TypeCode.Double:
                            dgJuxaposition.Rows[j].Cells[i + 1].ValueType = typeof(float);
                            dgJuxaposition.Rows[j].Cells[i + 1].Value = (float) currentColumn.ColumnContent[j].Value;
                            break;
                        default:
                            throw new Exception("CustomTableFrame Type Code Error");
                    }

                }
                ////////
                dgCustomTable.Rows[i].Cells[dgCustomTable.Rows[i].Cells.Count - 1].Value = currentRow[currentRow.Count - 1].ID;
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
            }
        }

        private void btnAddJux_Click(object sender, EventArgs e)
        {
            var dialog = new AddEditJuxtaposition();
            dialog.Show(this);
            this.Hide();
        }
    }
}
