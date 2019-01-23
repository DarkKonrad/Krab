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
   public class TableTemplate //: Control
    {
       private readonly static int space = 10;
       private readonly static int txtColumnWidth = 150;
       private static int i = 0;
       private static int unique_Num = 1;
       private int index = 0;
       private readonly int containerPanelDefaultHeight;
       private string containerPanelName;

       private bool isControlPanelClicked = false;
 
       private TextBox txtColumnName;
       private RadioButton radioTypeInteger,radioTypeFloat, radioDescription, radioPlaneText,radioDataType;
       private Label labelOrderNumber, labelGeneralDescr,typeLabel;
       private Panel ownerPanel, containerPanel;
   

       private Control[] controls;

        //Constructor
        public TableTemplate(Panel MainPanel, EventHandler panelClicked)
        {
            i++;
            index = i;
           containerPanelName="containerPanel"+unique_Num++.ToString();

            #region Standard Allocation
            ownerPanel = MainPanel;
         //   panel.Controls.Add(this);
            containerPanel = new Panel();
            containerPanelDefaultHeight = containerPanel.Height;
            containerPanel.Name = containerPanelName;    

            txtColumnName = new TextBox();

            labelOrderNumber = new Label();
            labelGeneralDescr = new Label();
            typeLabel = new Label();

            radioTypeInteger = new RadioButton();
            radioDescription = new RadioButton();
            radioPlaneText = new RadioButton();
            radioDataType = new RadioButton();
            radioTypeFloat = new RadioButton();
            #endregion

            radioTypeInteger.Text = "Liczba całkowita ";
            radioDescription.Text = "Opis";
            radioPlaneText.Text="Krótki tekst ";
            radioDataType.Text = "Data";
            radioTypeFloat.Text = "Liczba zmiennoprzecinkowa";

            labelGeneralDescr.Text = "Nazwa pola";
            typeLabel.Text = "Określ typ pola";

         
            //Individual Controls are added to Container Panel

            
            containerPanel.Controls.Add(txtColumnName);
            containerPanel.Controls.Add(radioTypeInteger);
            containerPanel.Controls.Add(radioTypeFloat);
            containerPanel.Controls.Add(radioDescription);
            containerPanel.Controls.Add(radioPlaneText);
            containerPanel.Controls.Add(labelOrderNumber);
            containerPanel.Controls.Add(labelGeneralDescr);
            containerPanel.Controls.Add(typeLabel);
            containerPanel.Controls.Add(radioDataType);

            controls = new Control[] { txtColumnName, radioTypeInteger,radioTypeFloat,radioDescription,radioPlaneText,radioDataType,labelOrderNumber,labelGeneralDescr,typeLabel,containerPanel };
            // We need to add ONLY container Panel NOT ANY OTHER CONTROL to main Panel
            containerPanel.Click += panelClicked;
            
            MainPanel.Height += containerPanel.Height;
            MainPanel.Controls.Add(containerPanel);
            
            containerPanel.Location = new Point(
                  containerPanel.Location.X + 20,
                 MainPanel.Location.Y - 5);
            
            containerPanel.Dock = DockStyle.Top;
            containerPanel.BringToFront();
          //  containerPanel.Dock = DockStyle.Top;
            containerPanel.BorderStyle = BorderStyle.FixedSingle;

           
            Refresh();


        }

        public ColumnInfo GetColumnInfo()
        {
            
            string buffor = txtColumnName.Text;
         
            buffor.Trim();

            if (radioDescription.Checked == true)
            {
                return new ColumnInfo(buffor, ColumnType.Description);
            }
            else if (radioPlaneText.Checked == true)
            {
                return new ColumnInfo(buffor, ColumnType.ShortText);
            }
            else if (Numeric.Checked == true)
            {
                return new ColumnInfo(buffor, ColumnType.Integer);
            }
            else if(radioDataType.Checked == true)
            {
                return new ColumnInfo(buffor, ColumnType.DataType);
            }               
            else if (radioTypeFloat.Checked == true)
            {
                return new ColumnInfo(buffor, ColumnType.Float);
            }
            throw new Exception("GetColumnInfoProblem");
            

        }



        public void Dispose()
        {
            foreach(Control control in controls)
            {
                control.Dispose();
            }
            
        }

        public void Refresh()
        {
            containerPanel.Height = containerPanelDefaultHeight - 30;
            containerPanel.Dock = DockStyle.Top;
            containerPanel.BringToFront();

            txtColumnName.Location = new Point(
            (int) (containerPanel.Width / 4),
            (int) (containerPanel.Height / 3 -5));
            txtColumnName.Width = txtColumnWidth + radioTypeInteger.Width;
            txtColumnName.Refresh();
            txtColumnName.Show();

            labelOrderNumber.Font = new Font("Arial", 18, FontStyle.Bold);
            labelOrderNumber.Width = 40;
            labelOrderNumber.Text = index.ToString();
            labelOrderNumber.Location = new Point(
                containerPanel.Location.X + 5,
               txtColumnName.Location.Y-10);
            labelOrderNumber.Refresh();

            radioPlaneText.AutoSize = true;
            radioPlaneText.Location = new Point(
                txtColumnName.Location.X,
                txtColumnName.Height + txtColumnName.Location.Y + 5);
            radioPlaneText.Checked = true;
            radioPlaneText.Refresh();

            radioDescription.AutoSize = true;         
            radioDescription.Location = new Point(
                radioPlaneText.Location.X + radioPlaneText.Width +5 ,
                radioPlaneText.Location.Y);
            radioDescription.Refresh();

            radioTypeInteger.AutoSize = true;
          //  radioTypeInteger.Width = 125;
            radioTypeInteger.Location = new Point(
                radioDescription.Location.X + radioDescription.Width + 5,
                radioPlaneText.Location.Y);
            radioTypeInteger.Refresh();

            radioTypeFloat.AutoSize = true;
           // radioTypeFloat.Width = 170;
            radioTypeFloat.Location = new Point(
                radioTypeInteger.Location.X + radioTypeInteger.Width +5,
                radioPlaneText.Location.Y);       
            radioTypeFloat.Refresh();

            radioDataType.AutoSize = true;
            radioDataType.Location = new Point(
                radioTypeFloat.Location.X + radioTypeFloat.Width + 5 ,
                radioPlaneText.Location.Y);
            radioDataType.Refresh();

            labelGeneralDescr.Location = new Point(
                txtColumnName.Location.X - labelGeneralDescr.Width - 5,
                txtColumnName.Location.Y);
            labelGeneralDescr.Refresh();

            typeLabel.Location = new Point(
                radioPlaneText.Location.X - typeLabel.Width - 5,
                radioPlaneText.Location.Y);
            typeLabel.Refresh();

        }

        public void Show()
        {
            foreach (Control control in controls)
            {
                control.Show();
            }
        }
        #region Getters And Setters
        public TextBox TxtColumnName { get => txtColumnName; set => txtColumnName = value; }
        public RadioButton Numeric { get => radioTypeInteger; set => radioTypeInteger = value; }
        public RadioButton Description { get => radioDescription; set => radioDescription = value; }
        public RadioButton PlaneText { get => radioPlaneText; set => radioPlaneText = value; }
        public Label OrderNumber { get => labelOrderNumber; set => labelOrderNumber = value; }
        public Label Label { get => labelGeneralDescr; set => labelGeneralDescr = value; }
        public Panel OwnerPanel { get => ownerPanel; set => ownerPanel = value; }
        public Panel ContainerPanel { get => containerPanel; set => containerPanel = value; }
        public Control[] Controls { get => controls; set => controls = value; }
        public int Index { get => index; private set => index = value; }
        public bool IsControlPanelClicked { get => isControlPanelClicked; set => isControlPanelClicked = value; }
        public RadioButton RadioDataType { get => radioDataType; set => radioDataType = value; }

        #endregion

        public static TableTemplate Compare(TableTemplate A, TableTemplate B)
        {
            return A.index > B.index ? A : B;
        }

        public static void ReGenerateIndexes(List<TableTemplate> list)
        {
            i = 0;
            list.Reverse();
            foreach(TableTemplate rowTemplate in list)
            {
                i++;
                rowTemplate.index = i;
                
            }
         //   list.Reverse();

            foreach (TableTemplate rowTemplate in list)
            {
                rowTemplate.Refresh();
            }

        }
    }
}
