using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
namespace Inz_Prot.Models
{
   public class Employee
    {
        int? ID;
        string name, surname, pesel,address,position;
        DateTime birthDay, hireFrom;
        DateTime? expDate;
       
        

        #region Getters and Setters
        public string Name { get => name; set => name = value; }
        public string Surname { get => surname; set => surname = value; }
        public string Pesel { get => pesel; set => pesel = value; }
        public string Address { get => address; set => address = value; }
        public DateTime BirthDay { get => birthDay; set => birthDay = value; }
        public DateTime HireFrom { get => hireFrom; set => hireFrom = value; }
        public DateTime? HireExp { get => expDate; set => expDate = value; }
        public string Position { get => position; set => position = value; }


        #endregion
        public Employee(int? id,string name, string surname, string pesel, string address, string position, DateTime birthDay, DateTime hireFrom, DateTime? expDate)
        {
            this.name = name;
            this.surname = surname;
            this.pesel = pesel;
            this.address = address;
            this.birthDay = birthDay;
            this.hireFrom = hireFrom;
            this.expDate = expDate;
            this.position = position;
            // Warning
            this.ID = id;
        }
        public int Age()
        {

            var age = DateTime.Now - BirthDay.Date;
            return int.Parse(( age.Days / 365 ).ToString());
            
        }
        public static void AddEmployee(string name, string surname, string pesel, string address,string position, DateTime birthDay, DateTime hireFrom, DateTime? expDate)
        {
            string command = "INSERT INTO employees VALUES (@name,@surname,@pesel,@address,@birthDay,@hireDate,@expDate)";
            var query = new MySql.Data.MySqlClient.MySqlCommand(command, dbTools.dbAgent.GetConnection());

            query.Parameters.AddWithValue("@name", name);
            query.Parameters.AddWithValue("@surname", surname);
            query.Parameters.AddWithValue("@pesel", pesel);
            query.Parameters.AddWithValue("@address", address);
            query.Parameters.AddWithValue("@birthday",birthDay.Date.ToString("DD-MM-YYYY"));
            query.Parameters.AddWithValue("@hireDate", hireFrom.Date.ToString("DD-MM-YYYY"));
            query.Parameters.AddWithValue("@adtPerm", position);

            if (!expDate.HasValue)
            {
                query.Parameters.AddWithValue("@hireExp",null);
            }
            query.Parameters.AddWithValue("@expDate", expDate.Value.Date.ToString("DD-MM-YYYY"));

            try
            {
                dbTools.dbAgent.GetConnection().Open();

                query.ExecuteNonQuery();

                
            }
            catch(MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show(ex.Message, "Nastąpił błąd połączenia z bazą danych", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Debug.WriteLine(ex.Message + Environment.NewLine + ex.Data);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Dodanie nowego pracownika nie powiodło się." + Environment.NewLine + " Jesli problem bedzie się powtarzać, skontaktuj się z producentem", "Nastąpił błąd połączenia z bazą danych" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dbTools.dbAgent.GetConnection().Close();
            }
        }

      
        public static List<Employee> GetAllEmployees( )
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
                DateTime? expDate=null;

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
                        expDate = (DateTime?) reader["HireExpirationDate"];

                    position = reader["Position"].ToString();
                    listOfEmployees.Add(new Employee(
                        ID, name, surname, pesel, address, position, birthDay, hireFrom, expDate.HasValue ? expDate : null));
                }

            }

              
            catch(MySql.Data.MySqlClient.MySqlException ex)
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


    }
}
