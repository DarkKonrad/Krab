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
    /*
     * TO DO: DataGird sprawdzic czy obsluguje datetime
     * wyswietlanie TRESCI tabeli i dodawanie nowych wartosci
     * Urozmaicic dialogBoxa
     * 
     * 
     */
    public class CustomTableDialogControls
    {
        static int unique_Num = 1;
        private TextBox txtInputValue;
        DateTimePicker timePicker;

        Label labelColumnName;
        Panel mainPanel;
        Panel containerPanel;
        ColumnInfo columnInfo;

        Control[] controls;

        public TextBox TxtInputValue { get => txtInputValue; set => txtInputValue = value; }
        public DateTimePicker TimePicker { get => timePicker; set => timePicker = value; }
        public Label LabelColumnName { get => labelColumnName; set => labelColumnName = value; }
        public Panel MainPanel { get => mainPanel; set => mainPanel = value; }
        public Panel ContainerPanel { get => containerPanel; private set => containerPanel = value; }
        public ColumnInfo ColumnInfo { get => columnInfo; private set => columnInfo = value; }
        public Control[] Controls { get => controls; private set => controls = value; }

        public string Value { get 
            {
                string strValue ="";
                
                if(columnInfo.ColumnType == ColumnType.DataType)
                {
                    var dataVal = timePicker.Value;
                    strValue = dataVal.ToString("dd-MM-yyyy HH-mm-ss");

                    return strValue;
                }
                if (!AreInputDataCorrect())
                    throw new Exception("Input Data Type is not correct");

                strValue = txtInputValue.Text;

                return strValue;
            }
        }

        private bool AreInputDataCorrect()
        {

            if (columnInfo.ColumnType == ColumnType.Description)
            {
                if (txtInputValue.Text.Length > 2048)
                {
                    return false;
                }
            }
            else if (columnInfo.ColumnType == ColumnType.shortText)
            {
                if (txtInputValue.Text.Length > 80)
                {
                    return false;
                }
            }
            else if (columnInfo.ColumnType == ColumnType.Numeric )
            {
                int result = 0;
                if(!Int32.TryParse(txtInputValue.Text, out result))
                {
                    return false;
                }
                
            }
            return true;
        }
        public CustomTableDialogControls(Panel mainPanel, ColumnInfo columnInfo)
        {
            LabelColumnName = new Label();           
            ContainerPanel = new Panel();

            this.MainPanel = mainPanel;
            this.ColumnInfo = columnInfo;

            ContainerPanel.Name = "containerPanel" + unique_Num++.ToString();
            LabelColumnName.Text = columnInfo.Name;
            if (columnInfo.ColumnType == ColumnType.DataType)
            {
                TimePicker = new DateTimePicker();
            //    btnChooseFromDataTimePicker = new Button();
                controls = new Control[] { /*txtInputValue, */TimePicker, /* btnChooseFromDataTimePicker,*/ LabelColumnName };
            }
            else
            {
                TxtInputValue = new TextBox();
                controls = new Control[] { TxtInputValue, LabelColumnName };
            }

            ContainerPanel.Controls.AddRange(controls);
            mainPanel.Height += ContainerPanel.Height;
            mainPanel.Controls.Add(ContainerPanel);

            ContainerPanel.Location = new Point(
              ContainerPanel.Location.X + 20,
             mainPanel.Location.Y - 5);

            ContainerPanel.Dock = DockStyle.Top;
            ContainerPanel.BringToFront();
            ContainerPanel.BorderStyle = BorderStyle.FixedSingle;

            Refresh();
     
        }

        public void ShowControl()
        {
            foreach (Control control in controls)
            {
                control.Show();
            }
        }

        public void Refresh()
        {
            //containerPanel.Dock = DockStyle.Top;
            LabelColumnName.Location = new Point(
                0,
                ContainerPanel.Height / 3);

           

            if(ColumnInfo.ColumnType == ColumnType.DataType)
            {
                TimePicker.Location = new Point(
               ContainerPanel.Width / 4,
               ContainerPanel.Height / 3);
                //btnChooseFromDataTimePicker.Location = new Point(
                //    containerPanel.Width / 2,
                //     containerPanel.Height / 3);
                //btnChooseFromDataTimePicker.Width = 100;
                //btnChooseFromDataTimePicker.Text = "Kalendarz";
                //btnChooseFromDataTimePicker.Click += buttonShowDataTimePicker_Click;
            }
            else
            {
                TxtInputValue.Location = new Point(
               ContainerPanel.Width / 4,
               ContainerPanel.Height / 3);
            }

        }
             


    }
}
