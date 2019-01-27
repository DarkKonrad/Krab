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
namespace Inz_Prot.Windows.DialogBoxes
{
    public partial class EditColumnsUDT : Form
    {
        TableInfo tableInfo;
        private EditColumnsUDT()
        {
            InitializeComponent();
        }

        public EditColumnsUDT(TableInfo tableInfo)
        {
            InitializeComponent();
            this.tableInfo = tableInfo;
            comboColumnName.Items.AddRange(tableInfo.ColumnsNames_String().ToArray());
        }

     private ColumnType GetRadioButtonResult()
        {
            if (radioData.Checked)
            {
                return ColumnType.DataType;
            }
            else if (radioDecr.Checked)
            {
                return ColumnType.Description;
            }
            else if (radiofloat.Checked)
            {
                return ColumnType.Float;
            }
            else if (radioInt.Checked)
            {
                return ColumnType.Integer;
            }
            else if (radioShortText.Checked)
            {
                return ColumnType.ShortText;
            }
            else
                throw new Exception("RadioButton Check Exception");
            
        }

        private void comboColumnName_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtColName.Text = comboColumnName.SelectedItem.ToString();;
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            var newType = GetRadioButtonResult();
            var selectedColumnName = comboColumnName.SelectedItem.ToString();
            ColumnInfo columnModified= null;
            for(int i =0;i< tableInfo.Count; i++)//   foreach(ref var columnInfo in tableInfo.ColumnInfos_Row)
            {
                if(tableInfo.ColumnInfos_Row[i].Name == selectedColumnName)
                {
                    columnModified = tableInfo.ColumnInfos_Row[i];
                    break;
                }
            }
            columnModified.ChangeType(newType);
            CustomTableHelper.AlterColumnDataType(tableInfo.TableName, columnModified);
        }
    }
}
