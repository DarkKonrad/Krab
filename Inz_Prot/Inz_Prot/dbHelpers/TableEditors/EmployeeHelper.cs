using Inz_Prot.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
namespace Inz_Prot.dbHelpers.TableEditors
{
    public static class EmployeeHelper
    {
        public static void AddEmployee(string name, string surname, string pesel, string address, string position, DateTime birthDay, DateTime hireFrom, DateTime? expDate)
        {
            string command = "INSERT INTO employees VALUES (@null,@name,@surname,@birthDay,@pesel,@address,@birthDay,@hireDate,@expDate)";

            var query = new MySql.Data.MySqlClient.MySqlCommand(command, dbTools.dbAgent.GetConnection());

            query.Parameters.AddWithValue("@null", null);
            query.Parameters.AddWithValue("@name", name);
            query.Parameters.AddWithValue("@surname", surname);
            query.Parameters.AddWithValue("@birthDay", birthDay);
            query.Parameters.AddWithValue("@pesel", pesel);
            query.Parameters.AddWithValue("@address", address);
            query.Parameters.AddWithValue("@birthday", birthDay.Date.ToString("yyyy-MM-dd"));
            query.Parameters.AddWithValue("@hireDate", hireFrom.Date.ToString("yyyy-MM-dd"));
            query.Parameters.AddWithValue("@adtPerm", position);

            if (!expDate.HasValue)
            {
                query.Parameters.AddWithValue("@expDate", null);
            }
            else
            {
                query.Parameters.AddWithValue("@expDate", expDate.Value.Date.ToString("yyyy-MM-dd"));
            }

            try
            {
                dbTools.dbAgent.GetConnection().Open();

                query.ExecuteNonQuery();


            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show(ex.Message, "Nastąpił błąd połączenia z bazą danych", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Debug.WriteLine(ex.Message + Environment.NewLine + ex.Data);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Dodanie nowego pracownika nie powiodło się." + Environment.NewLine + " Jesli problem bedzie się powtarzać, skontaktuj się z producentem", "Nastąpił błąd połączenia z bazą danych" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dbTools.dbAgent.GetConnection().Close();
            }
        }
        // ID Name Surname BirthdayDate PESEL Address HireDate HireExpirationDate Position
        public static void EditEmployee(Employee employee)
        {
            string command = "UPDATE Employees SET Name=@name, Surname=@surname,BirthdayDate=@birthday,PESEL =@pesel,Address=@address,HireDate=@hiredate,HireExpirationDate=@hireExp,Position=@position WHERE ID=@id";
            var query = new MySql.Data.MySqlClient.MySqlCommand(command, dbTools.dbAgent.GetConnection());

            query.Parameters.AddWithValue("@id", employee.ID);
            query.Parameters.AddWithValue("@name", employee.Name);
            query.Parameters.AddWithValue("@surname", employee.Surname);
            query.Parameters.AddWithValue("@birthday", employee.BirthDay.Date.ToString("yyyy-MM-dd"));
            query.Parameters.AddWithValue("@pesel", employee.Pesel);
            query.Parameters.AddWithValue("@address", employee.Address);
            query.Parameters.AddWithValue("@hiredate", employee.HireFrom.Date.ToString("yyyy-MM-dd"));
            query.Parameters.AddWithValue("@hireExp", employee.HireExp.HasValue ? employee.HireExp.Value.Date.ToString("yyyy-MM-dd") : null);
            query.Parameters.AddWithValue("@position", employee.Position);

            try
            {
                dbTools.dbAgent.GetConnection().Open();
                query.ExecuteNonQuery();
            }

            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show(ex.Message, "Nastąpił błąd połączenia z bazą danych", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Debug.WriteLine(ex.Message + Environment.NewLine + ex.Data);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Nieznany błąd" + Environment.NewLine + " Jesli problem bedzie się powtarzać, skontaktuj się z producentem", "Nastąpił błąd połączenia z bazą danych" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Debug.WriteLine(ex.Message + "  " + ex.StackTrace);
            }
            finally
            {
                dbTools.dbAgent.GetConnection().Close();
            }


        }
        public static List<Employee> GetAllEmployees()
        {
            List<Employee> listOfEmployees = new List<Employee>();
            try
            {
                dbTools.dbAgent.GetConnection().Open();
                string command = "SELECT * FROM employees";
                var query = new MySql.Data.MySqlClient.MySqlCommand(command, dbTools.dbAgent.GetConnection());

                var reader = query.ExecuteReader();

                int? ID;
                string name, surname, pesel, address, position;
                DateTime birthDay, hireFrom;
                DateTime? expDate = null;

                while (reader.Read())
                {
                    ID = (int) reader["ID"];
                    name = reader["Name"].ToString();
                    surname = reader["Surname"].ToString();
                    birthDay = (DateTime) reader["BirthdayDate"];
                    pesel = reader["PESEL"].ToString();
                    address = reader["Address"].ToString();
                    hireFrom = (DateTime) reader["HireDate"];

                    var tmp = reader.GetOrdinal("HireExpirationDate");
                    if (!reader.IsDBNull(tmp))
                    {
                        expDate = (DateTime?) reader["HireExpirationDate"];
                    }

                    position = reader["Position"].ToString();
                    listOfEmployees.Add(new Employee(
                        ID, name, surname, pesel, address, position, birthDay, hireFrom, expDate.HasValue ? expDate : null));
                }

            }


            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show(ex.Message, "Nastąpił błąd połączenia z bazą danych", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Debug.WriteLine(ex.Message + Environment.NewLine + ex.Data);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Nieznany błąd" + Environment.NewLine + " Jesli problem bedzie się powtarzać, skontaktuj się z producentem", "Nastąpił błąd połączenia z bazą danych" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Debug.WriteLine(ex.Message + "  " + ex.StackTrace);
            }
            finally
            {
                dbTools.dbAgent.GetConnection().Close();
            }
            return listOfEmployees;
        }

        public static void AddEmployee(Employee employee)
        {
            string command = "INSERT INTO employees VALUES (@null,@name,@surname,@birthDay,@pesel,@address,@hireDate,@expDate,@position)";

            var query = new MySql.Data.MySqlClient.MySqlCommand(command, dbTools.dbAgent.GetConnection());

            query.Parameters.AddWithValue("@null", null);
            query.Parameters.AddWithValue("@name", employee.Name);
            query.Parameters.AddWithValue("@surname", employee.Surname);
            query.Parameters.AddWithValue("@pesel", employee.Pesel);
            query.Parameters.AddWithValue("@address", employee.Address);
            query.Parameters.AddWithValue("@birthday", employee.BirthDay.Date.ToString("yyyy-MM-dd"));
            query.Parameters.AddWithValue("@hireDate", employee.HireFrom.Date.ToString("yyyy-MM-dd"));
            query.Parameters.AddWithValue("@position", employee.Position);
            // query.Parameters.AddWithValue("@expDate", employee.position);

            if (!employee.HireExp.HasValue)
            {
                query.Parameters.AddWithValue("@expDate", null);
            }
            else
            {
                query.Parameters.AddWithValue("@expDate", employee.HireExp.Value.Date.ToString("yyyy-MM-dd"));
            }

            try
            {
                dbTools.dbAgent.GetConnection().Open();

                query.ExecuteNonQuery();


            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show(ex.Message, "Nastąpił błąd połączenia z bazą danych", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Debug.WriteLine(ex.Message + Environment.NewLine + ex.Data);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Dodanie nowego pracownika nie powiodło się." + Environment.NewLine + " Jesli problem bedzie się powtarzać, skontaktuj się z producentem", "Nastąpił błąd połączenia z bazą danych" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dbTools.dbAgent.GetConnection().Close();
            }

        }

        public static void DeleteEmployee(int id)
        {
            string command = "DELETE FROM employees WHERE ID=@id";
            var query = new MySql.Data.MySqlClient.MySqlCommand(command, dbTools.dbAgent.GetConnection());

            query.Parameters.AddWithValue("@id", id);

            try
            {
                dbTools.dbAgent.GetConnection().Open();

                query.ExecuteNonQuery();


            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show(ex.Message, "Nastąpił błąd połączenia z bazą danych", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Debug.WriteLine(ex.Message + Environment.NewLine + ex.Data);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Dodanie nowego pracownika nie powiodło się." + Environment.NewLine + " Jesli problem bedzie się powtarzać, skontaktuj się z producentem", "Nastąpił błąd połączenia z bazą danych" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dbTools.dbAgent.GetConnection().Close();
            }

        }

        public static void DeleteEmployee( Employee employee)
        {
            string command = "DELETE FROM employees WHERE ID=@id";
            var query = new MySql.Data.MySqlClient.MySqlCommand(command, dbTools.dbAgent.GetConnection());

            query.Parameters.AddWithValue("@id", employee.ID);

            try
            {
                dbTools.dbAgent.GetConnection().Open();

                query.ExecuteNonQuery();


            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show(ex.Message, "Nastąpił błąd połączenia z bazą danych", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Debug.WriteLine(ex.Message + Environment.NewLine + ex.Data);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Dodanie nowego pracownika nie powiodło się." + Environment.NewLine + " Jesli problem bedzie się powtarzać, skontaktuj się z producentem", "Nastąpił błąd połączenia z bazą danych" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dbTools.dbAgent.GetConnection().Close();
            }

        }
    }
}
