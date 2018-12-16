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
        public TableCreatorFrame()
        {
            InitializeComponent();
            listOfRowTemplates = new List<dbRowTemplate>();
        }

        private void btnAddField_Click(object sender, EventArgs e)
        {
            var tableRowTemplate = new dbRowTemplate(MainPanel);
            listOfRowTemplates.Add(tableRowTemplate);
            tableRowTemplate.Show();
            MainPanel.Refresh();
            
            foreach(dbRowTemplate dbRow in listOfRowTemplates)
            {
                dbRow.Refresh();
            }
        }
    }
}
