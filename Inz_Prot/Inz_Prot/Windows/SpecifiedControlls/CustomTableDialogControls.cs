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

        Label labelColumnName,labelDataType_PL;
        Panel mainPanel;
        Panel containerPanel;
        ColumnInfo columnInfo;

        Control[] controls;

      //  bool ContainerPanelClicked { get; set; }

        public TextBox TxtInputValue { get => txtInputValue; set => txtInputValue = value; }
        public DateTimePicker TimePicker { get => timePicker; set => timePicker = value; }
        public Label LabelColumnName { get => labelColumnName; set => labelColumnName = value; }
        public Panel MainPanel { get => mainPanel; set => mainPanel = value; }
        public Panel ContainerPanel { get => containerPanel; private set => containerPanel = value; }
        public ColumnInfo ColumnInfo { get => columnInfo; private set => columnInfo = value; }
        public Control[] Controls { get => controls; private set => controls = value; }

        public string ValueString { get 
            {
                string strValue ="";
                
                if(columnInfo.ColumnType == ColumnType.DataType)
                {
                    var dataVal = timePicker.Value;
                    strValue = dataVal.ToString("yyyy-MM-dd HH-mm-ss");

                    return strValue;
                }
                if (!AreInputDataCorrect())
                    throw new Exception("Input Data Type is not correct");

                strValue = txtInputValue.Text;

                return strValue;
            }
        }

        public TypeCode Type
        {
            get
            {
                if (columnInfo.ColumnType == ColumnType.Description)
                {
                    return TypeCode.String;
                }
                else if (columnInfo.ColumnType == ColumnType.ShortText)
                {
                    return TypeCode.Char;
                }
                else if (columnInfo.ColumnType == ColumnType.Integer)
                {
                    return TypeCode.Int32;
                }
                else if (columnInfo.ColumnType == ColumnType.DataType)
                {
                    return TypeCode.DateTime;
                }
                else if(columnInfo.ColumnType == ColumnType.Float)
                {
                    return TypeCode.Double;
                }
                    
                    throw new Exception("Invalid ColumnType" + Environment.NewLine + "Error: CustomTableDialogControls");
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
            else if (columnInfo.ColumnType == ColumnType.ShortText)
            {
                if (txtInputValue.Text.Length > 80)
                {
                    return false;
                }
            }
            else if (columnInfo.ColumnType == ColumnType.Integer )
            {
                int result = 0;
                if(!Int32.TryParse(txtInputValue.Text, out result))
                {
                    return false;
                }
                
            }
            else if (columnInfo.ColumnType == ColumnType.Float)
            {
                float result = 0;
                if(!float.TryParse(txtInputValue.Text,out result))
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
            labelDataType_PL = new Label();

            this.MainPanel = mainPanel;
            this.ColumnInfo = columnInfo;

            ContainerPanel.Name = "containerPanel" + unique_Num++.ToString();
            LabelColumnName.Text = columnInfo.Name;
            labelDataType_PL.Font = new Font("Arial", 8, FontStyle.Regular);
            labelDataType_PL.Text = "(" + columnInfo.ConvertedTypeToUser_PL + ")";
            labelDataType_PL.AutoSize = true;
            labelColumnName.AutoSize = true;
            if (columnInfo.ColumnType == ColumnType.DataType)
            {
                TimePicker = new DateTimePicker();
                
            //    btnChooseFromDataTimePicker = new Button();
                controls = new Control[] { /*txtInputValue, */TimePicker, /* btnChooseFromDataTimePicker,*/ LabelColumnName, labelDataType_PL };
            }
            else
            {
                TxtInputValue = new TextBox();
                controls = new Control[] { TxtInputValue, LabelColumnName,labelDataType_PL };
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

            labelDataType_PL.Location = new Point(
                0,
              ContainerPanel.Height / 2 );
           
            if (ColumnInfo.ColumnType == ColumnType.DataType)
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
