using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Inz_Prot.Models;
namespace Inz_Prot.Windows
{
    public partial class EmployeeFrame : Form
    {
        List<Employee> listOfEmployees;
        public EmployeeFrame()
        {
            InitializeComponent();
            RefreshTable();
        }
        void RefreshTable()
        {
            dataGridEmployee.Rows.Clear();
            listOfEmployees = Models.Employee.GetAllEmployees();
            int i = 0;

            foreach (Employee employee in listOfEmployees)
            {
                dataGridEmployee.Rows.Insert(
                    i,
                    i + 1,
                    employee.Name,
                    employee.Surname,
                    employee.BirthDay.Date.ToString("dd-MM-yyyy"),
                    employee.Pesel,
                    employee.Address,
                    employee.HireFrom.Date.ToString("dd-MM-yyyy"),
                    employee.HireExp.HasValue ? employee.HireExp.Value.Date.ToString("dd-MM-yyyy") : "Nie dotyczy",
                    employee.Position);

                i++;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnAddEmployee_Click(object sender, EventArgs e)
        {
            var addEmployeeDialog = new DialogBoxes.AddNewEmployeeDialog();
            var dialogResult = addEmployeeDialog.ShowDialog();
        }
    }
}
