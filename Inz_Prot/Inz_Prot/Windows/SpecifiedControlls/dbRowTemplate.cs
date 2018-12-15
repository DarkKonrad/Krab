using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Inz_Prot.Windows.SpecifiedControlls
{
   public class dbRowTemplate //: Control
    {
        static int i = 0;
        readonly static int space = 10;

        TextBox txtColumnName;
        RadioButton numeric, description, planeText;
        Label orderNumber, label;
        Panel ownerPanel, containerPanel;
        Control[] controls;
        public dbRowTemplate(Panel MainPanel)
        {
            #region Standard Allocation
              ownerPanel = MainPanel;
         //   panel.Controls.Add(this);
            containerPanel = new Panel();
                
            txtColumnName = new TextBox();

            orderNumber = new Label();
            label = new Label();

            numeric = new RadioButton();
            description = new RadioButton();
            planeText = new RadioButton();
            #endregion

            numeric.Text = "Typ liczbowy";
            description.Text = "Opis";
            planeText.Text="Krótki tekst";

            label.Text = "Nazwa Pola";

            //Individual Controls are added to Container Panel
            containerPanel.Controls.Add(txtColumnName);
            containerPanel.Controls.Add(numeric);
            containerPanel.Controls.Add(description);
            containerPanel.Controls.Add(planeText);
            containerPanel.Controls.Add(orderNumber);
            containerPanel.Controls.Add(label);
            
            controls = new Control[] { txtColumnName, numeric,description,planeText,orderNumber,label,containerPanel };
            MainPanel.Controls.AddRange(controls);

            containerPanel.Location = new System.Drawing.Point(
                  containerPanel.Location.X + 20,
                  MainPanel.Height - 10);
            MainPanel.Height += containerPanel.Height;

            containerPanel.Dock = DockStyle.Top;
            containerPanel.BorderStyle = BorderStyle.FixedSingle;
            txtColumnName.Location = new System.Drawing.Point(
                containerPanel.Width / 3,
                containerPanel.Height / 2);


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
        public Label OrderNumber { get => orderNumber; set => orderNumber = value; }
        public Label Label { get => label; set => label = value; }
        public Panel OwnerPanel { get => ownerPanel; set => ownerPanel = value; }
        public Panel ContainerPanel { get => containerPanel; set => containerPanel = value; }
        public Control[] Controls { get => controls; set => controls = value; }
        #endregion
    }
}
