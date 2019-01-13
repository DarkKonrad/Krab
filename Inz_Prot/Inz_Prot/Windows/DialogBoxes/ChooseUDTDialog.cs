﻿using System;
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
using Inz_Prot.Models.dbCustomTable;
namespace Inz_Prot.Windows.DialogBoxes
{
    public partial class ChooseUDTDialog : Form
    {
        bool isTableChosen;
        TableInfo chosenTable;
        List<TableInfo> listOfTableInfos;
        public ChooseUDTDialog()
        {
            InitializeComponent();
            isTableChosen = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            listOfTableInfos = CustomTableHelper.GetTableInfosAboutCustomTables();

            foreach(TableInfo tableInfo in listOfTableInfos)
            {
                listBoxCustomTable.Items.Add(tableInfo.TableName);
            }

        }

        public TableInfo GetChosenTable()
        {
            if (isTableChosen == true)
                return chosenTable;
            else
                return null;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            chosenTable = CustomTableHelper.GetTableInfoAboutTable(listBoxCustomTable.SelectedItem.ToString());
           
            if(chosenTable !=null)
            {
                isTableChosen = true;
                this.Hide();
            }
           

        }
    }
}