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
using Inz_Prot.Models.dbCustomTable;
using Inz_Prot.Models.dbCustomTable.Juxaposition;
using Inz_Prot.Windows.SpecifiedControlls;

namespace Inz_Prot.Windows.DialogBoxes
{
    public partial class AddEditJuxtaposition : Form
    {
        List<JuxtapositionControls> listOfJuxtapositionControls;
        public AddEditJuxtaposition()
        {
            InitializeComponent();
            listOfJuxtapositionControls = new List<JuxtapositionControls>();
        }

        private void containerPanel_Click(object sender, EventArgs e)
        {
            Control control = (Control) sender;

            foreach (JuxtapositionControls tmp in listOfJuxtapositionControls)
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

        private void RefreshJuxContorls()
        {
            foreach (JuxtapositionControls controls in listOfJuxtapositionControls)
            {
                controls.Refresh();
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            listOfJuxtapositionControls.Add(new JuxtapositionControls(
                mainPanel, containerPanel_Click));
            RefreshJuxContorls();
        }

        private void AddNewJuxtaposition()
        {
            if (listOfJuxtapositionControls.Count <= 0|| txtJuxName.Text == "")
                return;

            Juxaposition juxaposition = new Juxaposition(txtJuxName.Text);
           // ColumnInfo columnInfo;
            foreach(JuxtapositionControls controls  in listOfJuxtapositionControls)
            {
                var selectedTable = controls.SelectedTable;
                juxaposition.AddColumnInfoToJuxaposition(new JuxapositionColumnInfo(
                    selectedTable.TableName,
                    controls.GetSelectedColumn()));
                
            }
            JuxtapositionHelper.AddJuxaposition(juxaposition);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            AddNewJuxtaposition();
            this.Hide();
            Parent.Show();
            this.Dispose();
        }
    }
}
