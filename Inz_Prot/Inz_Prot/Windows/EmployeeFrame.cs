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
using Inz_Prot.dbHelpers.TableEditors;
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
            dataGridEmployee.MultiSelect = false;
            listOfEmployees = EmployeeHelper.GetAllEmployees();
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

        private void button1_Click(object sender, EventArgs e) //Hiding
        {
            Owner.Show();
            this.Hide();
            this.Dispose();
        }

        private void btnAddEmployee_Click(object sender, EventArgs e)
        {
            var addEmployeeDialog = new DialogBoxes.AddEditEmployeeDialog();
            var dialogResult = addEmployeeDialog.ShowDialog();
            var employee = addEmployeeDialog.GetDialogEmployee(dialogResult);
            if (employee == null)
                return;
            EmployeeHelper.AddEmployee(employee);
            RefreshTable();
        }

        private void btnEditEmployee_Click(object sender, EventArgs e)
        {
            if(dataGridEmployee.SelectedRows.Count ==1)
            {
                // var Cells =  dataGridEmployee.SelectedRows[0].Cells;
                //   foreach(DataGridViewCell cell in Cells )
                //   {
                //       dataGridEmployee.SelectedRows[0].i
                //   }
                var EditUserDialog = new DialogBoxes.AddEditEmployeeDialog(
                    listOfEmployees[dataGridEmployee.SelectedRows[0].Index]);
                var dialogResult = EditUserDialog.ShowDialog();
                var employee = EditUserDialog.GetDialogEmployee(dialogResult,
                   listOfEmployees[dataGridEmployee.SelectedRows[0].Index].ID );

                if (employee == null)
                    return;
                EmployeeHelper.EditEmployee(employee);
                RefreshTable();

            }
        }

        private void btnDeleteEmployee_Click(object sender, EventArgs e)
        {
            if (dataGridEmployee.SelectedRows.Count == 1)
            {
                // var Cells =  dataGridEmployee.SelectedRows[0].Cells;
                //   foreach(DataGridViewCell cell in Cells )
                //   {listOfEmployees[dataGridEmployee.SelectedRows[0].Index]
                //       dataGridEmployee.SelectedRows[0].i
                //   }
                var employee = listOfEmployees[dataGridEmployee.SelectedRows[0].Index];
                if (employee == null)
                    return;

                var dialogResult = MessageBox.Show("Potwierdź usunięcie pracownika: " + Environment.NewLine + Environment.NewLine + employee.Name + " " + employee.Surname + Environment.NewLine + "Zmiany te sa NIEODWRACALNE", "Usuwanie pracownika z bazy danych", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);

                if (dialogResult == DialogResult.OK)
                   
                EmployeeHelper.DeleteEmployee(employee);
                RefreshTable();

            }
        }

        private void EmployeeFrame_FormClosed(object sender, FormClosedEventArgs e)
        {
            Owner.Show();
            this.Hide();
            this.Dispose();
        }

        private void btnToCSV_Click(object sender, EventArgs e)
        {
            Utilities.SaveToCSV_SaveDialogVersion(dataGridEmployee);
        }
    }
}
