using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using Inz_Prot.Models.dbCustomTable;
using Inz_Prot.dbHelpers.TableEditors;
namespace Inz_Prot.Windows.SpecifiedControlls
{
    public class JuxtapositionControls
    {
        private static int i = 0;
        private static int unique_Num = 1;
        private int index = 0;
        private string containerPanelName;
        private readonly int containerPanelDefaultHeight;
        private List<TableInfo> tables;
        private TableInfo selectedTable =null;
        private ColumnInfo selectedColumn = null;
        private bool isControlPanelClicked = false;
        private ComboBox comboChosenTable, comboChosenColumn;
        private Panel ownerPanel, containerPanel;
        private Label labelOrderNumber,labelChooseTable,labelChooseColumn;

        private Control[] controls;

        public Panel ContainerPanel { get => containerPanel; set => containerPanel = value; }
        public bool IsControlPanelClicked { get => isControlPanelClicked; set => isControlPanelClicked = value; }
        public ComboBox ChosenTable { get => comboChosenTable; set => comboChosenTable = value; }
        public ComboBox ChosenColumn { get => comboChosenColumn; set => comboChosenColumn = value; }
        public TableInfo SelectedTable { get => selectedTable; set => selectedTable = value; }
      //  public ColumnInfo SelectedColumn { get => selectedColumn; set => selectedColumn = value; }

        public JuxtapositionControls(Panel mainPanel,EventHandler panelClicked)
        {
            i++;
            index = i;

            containerPanelName = "containerPanel" + unique_Num++.ToString();

            ownerPanel = mainPanel;

            comboChosenTable = new ComboBox();
            comboChosenColumn = new ComboBox();
            comboChosenTable.SelectedIndexChanged += ReactForComboTableIChange;
        //    comboChosenTable.
            containerPanel = new Panel();
            containerPanelDefaultHeight = containerPanel.Height;
            containerPanel.Name = containerPanelName;
            labelOrderNumber = new Label();
            labelChooseColumn = new Label();
            labelChooseTable = new Label();

            labelChooseTable.Font = new Font("Arial", 6, FontStyle.Regular);
            labelChooseColumn.Font = new Font("Arial", 6, FontStyle.Regular);

            labelChooseColumn.Text = "Wybierz kolumnę";
            labelChooseTable.Text = "Wybierz tabelę";

            controls = new Control[] { labelChooseTable, labelChooseColumn, labelOrderNumber, comboChosenColumn, comboChosenTable };

            containerPanel.Controls.AddRange(controls);
            mainPanel.Controls.Add(containerPanel);

            containerPanel.Dock = DockStyle.Top;
            containerPanel.BringToFront();
            containerPanel.BorderStyle = BorderStyle.FixedSingle;
            containerPanel.Click += panelClicked;
            Refresh();
            FillComboBoxTable();

        }

        void FillComboBoxTable()
        {
          tables = CustomTableHelper.GetTableInfosAboutCustomTables();

            foreach (TableInfo table  in tables)
            {
                comboChosenTable.Items.Add(table.TableName);
            }
        }

        void FillComboBoxColumns()
        {
            if (comboChosenTable.Items.Count <= 0 )
                return;

            var selectedItemString = comboChosenTable.SelectedItem.ToString();

             selectedTable = CustomTableHelper.GetTableInfoAboutTable(selectedItemString);

            foreach(ColumnInfo column in selectedTable.ColumnInfos_Row)
            {
                comboChosenColumn.Items.Add(column.Name);
            }
        }

       public ColumnInfo GetSelectedColumn()
        {
            foreach (ColumnInfo column in selectedTable.ColumnInfos_Row)
            {
                if (column.Name == comboChosenColumn.SelectedItem.ToString())
                {
                    return column;
                }
            }
            return null;
        }

        void ReactForComboTableIChange(object sender, EventArgs e)
        {
            FillComboBoxColumns();
        }

        public void Refresh()
        {
            labelOrderNumber.Location = new Point(
                10,
                containerPanel.Height / 3);

            comboChosenTable.Location = new Point(
                labelOrderNumber.Location.X + 20 + labelOrderNumber.Width,
                containerPanel.Height / 3);

            comboChosenColumn.Location = new Point(
                comboChosenTable.Location.X + 20 + comboChosenTable.Width,
                containerPanel.Height / 3);

            labelChooseTable.Location = new Point(
                comboChosenTable.Location.X ,
                containerPanel.Height / 3 + 20);

            labelChooseColumn.Location = new Point(
                comboChosenColumn.Location.X,
                containerPanel.Height / 3 + 20);
        }

        public void ShowControl()
        {
            foreach (Control control in controls)
            {
                control.Show();
            }
        }
    }
}
