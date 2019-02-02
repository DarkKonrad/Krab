using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Inz_Prot.Models.dbCustomTable.Juxaposition;
using Inz_Prot.Models.dbCustomTable;
using Inz_Prot.dbHelpers.TableEditors;
namespace Inz_Prot.Windows.DialogBoxes
{
    public partial class ChooseJuxapositionDialog : Form
    {
        List<Juxaposition> listOFJuxapositions;
        Juxaposition chosenJuxaposition;
        bool noElementsToShow = false;
        bool isElementChosen = false;
        public ChooseJuxapositionDialog()
        {
            InitializeComponent();
            RefreshListBox();
        }

        private void RefreshListBox()
        {
            listOFJuxapositions = JuxtapositionHelper.GetAllJuxapositions_InfoOnly();
            if (listOFJuxapositions == null || listOFJuxapositions.Count == 0)
                noElementsToShow = true;
            else
                foreach (Juxaposition juxaposition in listOFJuxapositions)
                {
                    listBoxJux.Items.Add(juxaposition.Name);
                }
        }

        public Juxaposition GetChosen()
        {
            if (isElementChosen == true)
                return chosenJuxaposition;
            else
                return null;
        }

        void  btnChoose_Click(object sender, EventArgs e)
        {
            if(listBoxJux.SelectedItem == null)
            {
                MessageBox.Show("Wybierz pozycje z listy", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.DialogResult = DialogResult.None;
                return;
            }
            chosenJuxaposition = JuxtapositionHelper.GetJuxaposition_InfoOnly(
                listBoxJux.SelectedItem.ToString());

            if(chosenJuxaposition !=null)
            {
                isElementChosen = true;
                this.DialogResult = DialogResult.OK;
                this.Hide();
                
            //    this.Dispose();
            }
            
        }
    }
}
