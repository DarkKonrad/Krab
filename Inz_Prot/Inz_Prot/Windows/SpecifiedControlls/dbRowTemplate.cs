using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
namespace Inz_Prot.Windows.SpecifiedControlls
{
   public class dbRowTemplate //: Control
    {
        readonly static int space = 10;
        readonly static int txtColumnWidth = 150;
        static int i = 0;

        int index = 0;
        readonly int containerPanelDefaultHeight;
        string containerPanelName;

        
        TextBox txtColumnName;
        RadioButton radioTypeNumeric, radioDescription, radioPlaneText;
        Label labelOrderNumber, labelGeneralDescr,typeLabel;
        Panel ownerPanel, containerPanel;

        Control[] controls;
        public dbRowTemplate(Panel MainPanel)
        {
            i++;
            index = i;
           containerPanelName="containerPanel"+index.ToString();

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

            radioTypeNumeric = new RadioButton();
            radioDescription = new RadioButton();
            radioPlaneText = new RadioButton();
            #endregion

            radioTypeNumeric.Text = "Typ liczbowy";
            radioDescription.Text = "Opis";
            radioPlaneText.Text="Krótki tekst";

            labelGeneralDescr.Text = "Nazwa pola";
            typeLabel.Text = "Określ typ pola";

            //Individual Controls are added to Container Panel

            
            containerPanel.Controls.Add(txtColumnName);
            containerPanel.Controls.Add(radioTypeNumeric);
            containerPanel.Controls.Add(radioDescription);
            containerPanel.Controls.Add(radioPlaneText);
            containerPanel.Controls.Add(labelOrderNumber);
            containerPanel.Controls.Add(labelGeneralDescr);
            containerPanel.Controls.Add(typeLabel);

            controls = new Control[] { txtColumnName, radioTypeNumeric,radioDescription,radioPlaneText,labelOrderNumber,labelGeneralDescr,typeLabel,containerPanel };
            // We need to add ONLY container Panel NOT ANY OTHER CONTROL to main Panel

            MainPanel.Height += containerPanel.Height;
            MainPanel.Controls.Add(containerPanel);
            
            containerPanel.Location = new Point(
                  containerPanel.Location.X + 20,
                 MainPanel.Location.Y - 5);
            

          //  containerPanel.Parent = MainPanel;
            

            
            containerPanel.Dock = DockStyle.Top;
            containerPanel.BringToFront();
          //  containerPanel.Dock = DockStyle.Top;
            containerPanel.BorderStyle = BorderStyle.FixedSingle;

           
            Refresh();


        }

        public void Refresh()
        {
            containerPanel.Height = containerPanelDefaultHeight - 30;
            containerPanel.Dock = DockStyle.Top;


            txtColumnName.Location = new Point(
            (int) (containerPanel.Width / 4),
            (int) (containerPanel.Height / 3 -5));
            txtColumnName.Width = txtColumnWidth + radioTypeNumeric.Width;
            txtColumnName.Refresh();
            txtColumnName.Show();

            labelOrderNumber.Font = new Font("Arial", 18, FontStyle.Bold);
            labelOrderNumber.Width = 40;
            labelOrderNumber.Text = index.ToString();
            labelOrderNumber.Location = new Point(
                containerPanel.Location.X + 5,
               txtColumnName.Location.Y-10);
            labelOrderNumber.Refresh();
            
            radioPlaneText.Location = new Point(
                txtColumnName.Location.X,
                txtColumnName.Height + txtColumnName.Location.Y + 5);
            radioPlaneText.Checked = true;
            radioPlaneText.Refresh();

            radioDescription.Location = new Point(
                radioPlaneText.Location.X + radioPlaneText.Width - 20,
                radioPlaneText.Location.Y);
            radioDescription.Refresh();

            radioTypeNumeric.Location = new Point(
                radioDescription.Location.X + radioDescription.Width -40,
                radioPlaneText.Location.Y);
            radioTypeNumeric.Refresh();

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
        public RadioButton Numeric { get => radioTypeNumeric; set => radioTypeNumeric = value; }
        public RadioButton Description { get => radioDescription; set => radioDescription = value; }
        public RadioButton PlaneText { get => radioPlaneText; set => radioPlaneText = value; }
        public Label OrderNumber { get => labelOrderNumber; set => labelOrderNumber = value; }
        public Label Label { get => labelGeneralDescr; set => labelGeneralDescr = value; }
        public Panel OwnerPanel { get => ownerPanel; set => ownerPanel = value; }
        public Panel ContainerPanel { get => containerPanel; set => containerPanel = value; }
        public Control[] Controls { get => controls; set => controls = value; }
        public int Index { get => index; set => index = value; }
        #endregion

        public static dbRowTemplate Compare(dbRowTemplate A, dbRowTemplate B)
        {
            return A.index > B.index ? A : B;
        }
    }
}
