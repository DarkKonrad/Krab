using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
namespace Inz_Prot.Models
{
    public class User
    {
        public enum Privileges
        {
            Normal = 1,
            Admin = 2,
            Security = 3,
            HR = 4
        }
        string name, surname, login;
        DateTime bDayDate;
        int salary;
        Privileges privilege;

        public string Name { get => name; set => name = value; }
        public string Surname { get => surname; set => surname = value; }
        public string Login { get => login; set => login = value; }

        public User(string name, string surname, Privileges privileges)
        {
            this.name = name;
            this.surname = surname;
            this.privilege = privileges;

        }


        public static User GetUser(string Login, string Password)
        {
            try
            {
            

                string command = "SELECT * FROM user WHERE Login='@login' AND Password='@password'";
                var query = new MySql.Data.MySqlClient.MySqlCommand(command, dbTools.dbAgent.GetConnection());             
                var Password_Hashed = dbTools.Password_Hasher.Hash(Password);

                query.Parameters.AddWithValue("@login", Login);
                query.Parameters.AddWithValue("@password", Password_Hashed);

                dbTools.dbAgent.GetConnection().Open();
                var reader = query.ExecuteReader();
                string imie = "";
                string nazwisko = "";
                int privTmp = 0;
               
                while (reader.Read())
                {
                    imie = reader["Name"].ToString();
                    nazwisko = reader["Surname"].ToString();
                    privTmp = (int) reader["Privileges"];
                    Login = reader["Login"].ToString();
                    return new User(imie, nazwisko, (Privileges) privTmp);
                }
               
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
        public static User _GetUser(string Login, string Password)
        {
            try
            {

                dbTools.dbAgent.GetConnection().Open();
                string command = "SELECT * FROM user WHERE Login=@login";
                var query = new MySql.Data.MySqlClient.MySqlCommand(command, dbTools.dbAgent.GetConnection());

                query.Parameters.AddWithValue("@login", Login);
               // query.Parameters.add
                
                var reader = query.ExecuteReader();
            
                string imie = "";
                string nazwisko = "";
                int privTmp = 0;
                string Password_Hashed = "";
                if (reader.Read())
                {
                    Password_Hashed = reader["Password"].ToString();
                    if (!dbTools.Password_Hasher.Verify(Password, Password_Hashed))
                               return null;
                    imie = reader["Name"].ToString();
                    nazwisko = reader["Surname"].ToString();
                    privTmp = (int) reader["Privileges"];
                    Login = reader["Login"].ToString();
                    return new User(imie, nazwisko, (Privileges) privTmp);
                }

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
        // INSERT INTO sprawdzic manualnie poprawic 
        public static void AddUser(string Login, string Password, string Name, string Surname, string PESEL, Privileges level)
        {
            string command = "INSERT INTO user VALUES(@ID,@login,@password,@name,@surname,@pesel,@lvl)";

            var query = new MySql.Data.MySqlClient.MySqlCommand(command, dbTools.dbAgent.GetConnection());

            query.Parameters.AddWithValue("@ID", null);
            query.Parameters.AddWithValue("@login", Login);
            query.Parameters.AddWithValue("@password", Password);
            query.Parameters.AddWithValue("@Name", Name);
            query.Parameters.AddWithValue("@Surname", Surname);
            query.Parameters.AddWithValue("@pesel", PESEL);
            query.Parameters.AddWithValue("@lvl", level);

            dbTools.dbAgent.GetConnection().Open();

            Debug.WriteLine(
                query.ExecuteNonQuery());

            dbTools.dbAgent.GetConnection().Close();
        }
        public static void AddUser(string Name, string Surname, string Password, Privileges level)
        {
            string command = "INSERT INTO user VALUES(@login,@password,@name,@surname,@pesel,@lvl)";

            var query = new MySql.Data.MySqlClient.MySqlCommand(command, dbTools.dbAgent.GetConnection());

            // query.Parameters.AddWithValue("@login", Login);
            query.Parameters.AddWithValue("@password", Password);
            query.Parameters.AddWithValue("@Name", Name);
            query.Parameters.AddWithValue("@Surname", Surname);
            query.Parameters.AddWithValue("@lvl", level);
            //  query.Parameters.AddWithValue("@pesel", PESEL);
            dbTools.dbAgent.GetConnection().Open();

            Debug.WriteLine(
                query.ExecuteNonQuery());

            dbTools.dbAgent.GetConnection().Close();
        }
    


        public static string GenerateLogin(string name, string surname)
        {
            string login;
            login = string.Concat(name.Substring(0, 1),
            surname.Substring(0, 
            surname.Length>6 ? 6 : surname.Length ));
            login.Trim(' ');

            return login;


        }

        //  Sprawdzic INSER INTO
        public static User CreateAdmin(string name, string surname, string password)
        {
            string command = "INSERT INTO user (Login,Password,Name,Surname,Privileges) VALUES(@login,@password,@name,@surname,@lvl)";
            var Password_Hashed = dbTools.Password_Hasher.Hash(password);
            string login = User.GenerateLogin(name, surname);

            var query = new MySql.Data.MySqlClient.MySqlCommand(command, dbTools.dbAgent.GetConnection());

           // query.Parameters.AddWithValue("@ID", null);
            query.Parameters.AddWithValue("@password", Password_Hashed);
            query.Parameters.AddWithValue("@name", name);
            query.Parameters.AddWithValue("login", login);
            query.Parameters.AddWithValue("@lvl", User.Privileges.Admin);
            query.Parameters.AddWithValue("@surname", surname);

            dbTools.dbAgent.GetConnection().Open();

            Debug.WriteLine(
                query.ExecuteNonQuery());

            dbTools.dbAgent.GetConnection().Close();

            return _GetUser(login, password);
        }

        public static void _CreateAdmin(string name, string surname, string password)
        {
            string command = "INSERT INTO user (Login,Password,Name,Surname,Privileges) VALUES(@login,@password,@name,@surname,@lvl)";
            var Password_Hashed = dbTools.Password_Hasher.Hash(password);
            string login = User.GenerateLogin(name, surname);

            var query = new MySql.Data.MySqlClient.MySqlCommand(command, dbTools.dbAgent.GetConnection());

            // query.Parameters.AddWithValue("@ID", null);
            query.Parameters.AddWithValue("@password", Password_Hashed);
            query.Parameters.AddWithValue("@name", name);
            query.Parameters.AddWithValue("login", login);
            query.Parameters.AddWithValue("@lvl", User.Privileges.Admin);
            query.Parameters.AddWithValue("@surname", surname);

            dbTools.dbAgent.GetConnection().Open();

            Debug.WriteLine(
                query.ExecuteNonQuery());

            dbTools.dbAgent.GetConnection().Close();

           
        }


        /// <summary>
        /// Making the form checking for default Login and password for Admin account
        /// </summary>
        /// <param name="Login"></param>
        /// <param name="Password"></param>
        public static bool CheckForAdmin()
        {
           
                string command = "SELECT * FROM user WHERE Privileges = 2";
                var query = new MySql.Data.MySqlClient.MySqlCommand(command, dbTools.dbAgent.GetConnection());

            try
            {
                dbTools.dbAgent.GetConnection().Open();

                query.ExecuteNonQuery();

               

                var reader = query.ExecuteReader();


                if (!reader.Read())
                {
                    return false;
                }
                else
                {
                    return true;
                }

            }
              catch(Exception ex)
            {
               
                System.Windows.Forms.MessageBox.Show(
                    ex.Message, "Wystapił błąd połączenia sieciowego",
                    System.Windows.Forms.MessageBoxButtons.OK,
                    System.Windows.Forms.MessageBoxIcon.Warning);

                // Bardzo nieeleganckie, ale w przypadku gdy nie bedzie polaczenia a uzytkownik wprowadzi defaultowe dane,
                // nie mozemy dopuscic, do sytuacji,w ktorej bedzie mogl dodac kolejnego admina.
                return true;
            }
            finally
            {
                
                dbTools.dbAgent.GetConnection().Close();
            }
        }

    }
}
