using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
namespace Inz_Prot.Models
{   public class User
    {
      public enum Privileges
        {
            Normal=1,
            CEO=2,
            Security=3,
            HR=4
        }
        string name, surname;
        DateTime bDayDate;
        int salary;
        Privileges privilege;

        public string Name { get => name; set => name = value; }
        public string Surname { get => surname; set => surname = value; }

        public User(string name,string surname,Privileges privileges)
        {
            this.name = name;
            this.surname = surname;
            this.privilege = privileges;

        }


        public static User GetUser(string Login, string Password)
        {
            try
            {
                dbTools.dbAgent.GetConnection().Open();

                string command = "Select * from user WHERE Login=@login AND Password=@password";
                var query = new MySql.Data.MySqlClient.MySqlCommand(command, dbTools.dbAgent.GetConnection());

                query.Parameters.AddWithValue("@login", Login);
                query.Parameters.AddWithValue("@password", Password);

                var reader = query.ExecuteReader();
                string imie = "";
                string nazwisko = "";
                int privTmp = 0;
                while (reader.Read())
                {
                    imie = reader["Name"].ToString();
                    nazwisko = reader["Surname"].ToString();
                    privTmp = (int)reader["Privileges"];

                }
                return new User(imie, nazwisko, (Privileges)privTmp);
            }

            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                System.Windows.Forms.MessageBox.Show("Nieprawdiłowy login lub hasło", "Błąd",
                     System.Windows.Forms.MessageBoxButtons.OK,
                     System.Windows.Forms.MessageBoxIcon.Warning);
            }
            finally
            {
                dbTools.dbAgent.GetConnection().Close();
            }
            return null;
        }
        
        public static void AddUser(string Login,string Password, string Name, string Surname,string PESEL,Privileges level)
        {
            string command = "INSERT INTO user VALUES(@login,@password,@name,@surname,@pesel,@lvl";

            var query = new MySql.Data.MySqlClient.MySqlCommand(command, dbTools.dbAgent.GetConnection());

            query.Parameters.AddWithValue("@login", Login);
            query.Parameters.AddWithValue("@password", Password);
            query.Parameters.AddWithValue("@Name", Name);
            query.Parameters.AddWithValue("@Surname", Surname);
            query.Parameters.AddWithValue("@pesel", PESEL);
            query.Parameters.AddWithValue("@lvl", level);

            dbTools.dbAgent.GetConnection().Open();

            Debug.WriteLine(
                query.ExecuteNonQuery());
            
        }

    }
}
