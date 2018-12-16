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
        static int i = 0;
        int orderNumer = 0;
        readonly static int space = 10;
        readonly static int txtColumnWidth = 150;
        TextBox txtColumnName;
        RadioButton numeric, description, planeText;
        Label labelOrderNumber, label,typeLabel;
        Panel ownerPanel, containerPanel;
        Control[] controls;
        public dbRowTemplate(Panel MainPanel)
        {
            i++;
            orderNumer = i;
            
            #region Standard Allocation
              ownerPanel = MainPanel;
         //   panel.Controls.Add(this);
            containerPanel = new Panel();
                
            txtColumnName = new TextBox();

            labelOrderNumber = new Label();
            label = new Label();
            typeLabel = new Label();

            numeric = new RadioButton();
            description = new RadioButton();
            planeText = new RadioButton();
            #endregion

            numeric.Text = "Typ liczbowy";
            description.Text = "Opis";
            planeText.Text="Krótki tekst";

            label.Text = "Nazwa pola";
            typeLabel.Text = "Określ typ pola";

            //Individual Controls are added to Container Panel
            containerPanel.Controls.Add(txtColumnName);
            containerPanel.Controls.Add(numeric);
            containerPanel.Controls.Add(description);
            containerPanel.Controls.Add(planeText);
            containerPanel.Controls.Add(labelOrderNumber);
            containerPanel.Controls.Add(label);
            containerPanel.Controls.Add(typeLabel);

            controls = new Control[] { txtColumnName, numeric,description,planeText,labelOrderNumber,label,typeLabel,containerPanel };
            // We need to add ONLY container Panel NOT ANY OTHER CONTROL to main Panel
            MainPanel.Controls.Add(containerPanel);
         
            // MAybe not neccessary
            containerPanel.Location = new Point(
                  containerPanel.Location.X + 20,
                  MainPanel.Height - 10);
            MainPanel.Height += containerPanel.Height;

            containerPanel.Dock = DockStyle.Top;
            containerPanel.BorderStyle = BorderStyle.FixedSingle;

            labelOrderNumber.Font = new Font("Arial", 18, FontStyle.Bold);


            Refresh();


        }

        public void Refresh()
        {
           
            txtColumnName.Location = new Point(
            (int) (containerPanel.Width / 3),
            (int) (containerPanel.Height / 2));
            txtColumnName.Width = txtColumnWidth;
            txtColumnName.Refresh();
            txtColumnName.Show();

            labelOrderNumber.Text = orderNumer.ToString();
            labelOrderNumber.Location = new Point(
                containerPanel.Location.X + 5,
               txtColumnName.Location.Y-10);
            labelOrderNumber.Refresh();
            
            planeText.Location = new Point(
                txtColumnName.Location.X,
                txtColumnName.Height + txtColumnName.Location.Y + 5);
            planeText.Checked = true;
            planeText.Refresh();

            description.Location = new Point(
                planeText.Location.X + planeText.Width - 20,
                planeText.Location.Y);
            description.Refresh();

            numeric.Location = new Point(
                description.Location.X + description.Width -40,
                planeText.Location.Y);
            numeric.Refresh();

            label.Location = new Point(
                txtColumnName.Location.X - label.Width - 5,
                txtColumnName.Location.Y);
            label.Refresh();

            typeLabel.Location = new Point(
                planeText.Location.X - typeLabel.Width - 5,
                planeText.Location.Y);
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
        public RadioButton Numeric { get => numeric; set => numeric = value; }
        public RadioButton Description { get => description; set => description = value; }
        public RadioButton PlaneText { get => planeText; set => planeText = value; }
        public Label OrderNumber { get => labelOrderNumber; set => labelOrderNumber = value; }
        public Label Label { get => label; set => label = value; }
        public Panel OwnerPanel { get => ownerPanel; set => ownerPanel = value; }
        public Panel ContainerPanel { get => containerPanel; set => containerPanel = value; }
        public Control[] Controls { get => controls; set => controls = value; }
        #endregion
    }
}
