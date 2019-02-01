using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using Inz_Prot.Models.dbCustomTable;

namespace Inz_Prot.Windows.SpecifiedControlls
{
    public class JuxtapositionControls
    {
        private static int i = 0;
        private static int unique_Num = 1;
        private int index = 0;
        private string containerPanelName;
        private readonly int containerPanelDefaultHeight;

        private ComboBox chosenTable, chosenColumn;
        private Panel ownerPanel, containerPanel;
        private Label labelOrderNumber,labelChooseTable,labelChooseColumn;

        private Control[] controls;

        public JuxtapositionControls(Panel mainPanel)
        {
            i++;
            index = i;

            containerPanelName = "containerPanel" + unique_Num++.ToString();

            ownerPanel = mainPanel;

            containerPanel = new Panel();
            containerPanelDefaultHeight = containerPanel.Height;
            containerPanel.Name = containerPanelName;
            labelOrderNumber = new Label();
            labelChooseColumn = new Label();
            labelChooseTable = new Label();

            labelChooseColumn.Text = "Wybierz kolumnę";
            labelChooseTable.Text = "Wybierz tabelę";

            controls = new Control[] { labelChooseTable, labelChooseColumn, labelOrderNumber, chosenColumn, chosenTable };

            containerPanel.Controls.AddRange(controls);
            mainPanel.Controls.Add(containerPanel);

            containerPanel.Dock = DockStyle.Top;
            containerPanel.BringToFront();
            containerPanel.BorderStyle = BorderStyle.FixedSingle;


        }
    }
}
