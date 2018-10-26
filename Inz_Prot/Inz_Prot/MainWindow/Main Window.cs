using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Inz_Prot.MainWindow
{
    public partial class Main_Window : Form
    {
        private Main_Window()
        {
            InitializeComponent();
        }

       public Main_Window(Models.User user)
        {
            InitializeComponent();
            labelUser.Text = user.Name + "  " + user.Surname;
        }

        private void Main_Window_Load(object sender, EventArgs e)
        {

        }
    }
}
