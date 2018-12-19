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

namespace Inz_Prot.Windows
{
    public partial class TableCreatorFrame : Form
    {
        List<dbRowTemplate> listOfRowTemplates;
        List<Point> listOfOrder;
        
        private void SortRowsInOrder()
        {
            int i = 0;
            foreach (dbRowTemplate dbRow in listOfRowTemplates)
            {
                var containerPanelActualIndex = MainPanel.Parent.Controls.GetChildIndex(dbRow.ContainerPanel);
                var properIndex = dbRow.OrderNumber;

                i++;
            }
        }
        private void PROTOYPE_SortRowsInOrder()
        {
       
        }



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
            listOfOrder = new List<Point>();
            listOfRowTemplates = new List<dbRowTemplate>();
        }

        private void btnAddField_Click(object sender, EventArgs e)
        {
            var tableRowTemplate = new dbRowTemplate(MainPanel);
            listOfRowTemplates.Add(tableRowTemplate);
            tableRowTemplate.Show();
            MainPanel.Refresh();
            listOfOrder.Add(tableRowTemplate.ContainerPanel.Location);

            //    foreach(dbRowTemplate dbRow in listOfRowTemplates)
            //    {
            //        dbRow.Refresh();
            //    }
            //}

            PROTOYPE_SortRowsInOrder();

        }
        private void vScrollBar_Scroll(object sender, ScrollEventArgs e)
        {
          //  MainPanel.VerticalScroll.Value = vScrollBar.Value;
        }
    }
}
