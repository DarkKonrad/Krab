using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inz_Prot.Models;
using System.Diagnostics;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace Inz_Prot.dbHelpers.TableEditors
{
   public static class UserHelper
    {
        public static User CreateAdmin(string name, string surname, string password)
        {
            string command = "INSERT INTO user (Login,Password,Name,Surname,Privileges) VALUES(@login,@password,@name,@surname,@lvl)";
            var Password_Hashed = dbTools.Password_Hasher.Hash(password);
            string login = GenerateLogin(name, surname);
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

            return GetUser(login, password);
        }
        public static bool VerifyPasswordRequirements(string password)
        {
            if (password.Length > 6 || password.Any(c => char.IsDigit(c)))
                return true;
            return false;
        }
        private static void _CreateAdmin(string name, string surname, string password)
        {
            string command = "INSERT INTO user (Login,Password,Name,Surname,Privileges) VALUES(@login,@password,@name,@surname,@lvl)";
            var Password_Hashed = dbTools.Password_Hasher.Hash(password);
            string login = GenerateLogin(name, surname);

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

        public static void ChangePassword(User user,string Password)
        {
            string command = " UPDATE  user SET Password=@pass WHERE ID=@id ";
            string hashedPassword = dbTools.Password_Hasher.Hash(Password);
            var query = new MySqlCommand(command, dbTools.dbAgent.GetConnection());
            query.Parameters.AddWithValue("@id", user.ID);
            query.Parameters.AddWithValue("pass", hashedPassword);
            try
            {
                dbTools.dbAgent.GetConnection().Open();
                query.ExecuteNonQuery();

            }

            catch (MySqlException ex)
            {
                MessageBox.Show("Nastąpił błąd połączenia z bazą danych. Jeśli problem będzie się powtrzał skontaktuj się z zarządcą bazy danych", "Błąd połączenia z bazą danych" + Environment.NewLine + ex.ErrorCode, MessageBoxButtons.OK, MessageBoxIcon.Error);

                Debug.WriteLine("Exception Message: " + ex.Message);
                Debug.WriteLine("Exception Error Code: " + ex.ErrorCode);
                Debug.WriteLine("Exception Source: " + ex.Source);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Wystąpił  błąd " + Environment.NewLine + ex.Message, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Debug.WriteLine("Exception Message: " + ex.Message);
                Debug.WriteLine("Exception Source: " + ex.Source);
            }
            finally
            {
                dbTools.dbAgent.GetConnection().Close();

            }
         
        }
      
        public static bool VerifyPasswordFromDB(User user, string password)
        {
            string command = " SELECT Password FROM user WHERE ID=@id " ;
            var query = new MySqlCommand(command, dbTools.dbAgent.GetConnection());
            query.Parameters.AddWithValue("@id", user.ID);

            try
            {
                dbTools.dbAgent.GetConnection().Open();
                var reader=query.ExecuteReader();
                string hashedPassword = "";
                while(reader.Read())
                {
                    hashedPassword = reader["Password"].ToString();
                }

                if (dbTools.Password_Hasher.Verify(password, hashedPassword))
                    return true;

                
            }
            
            catch(MySqlException ex)
            {
                MessageBox.Show("Nastąpił błąd połączenia z bazą danych. Jeśli problem będzie się powtrzał skontaktuj się z zarządcą bazy danych", "Błąd połączenia z bazą danych" + Environment.NewLine + ex.ErrorCode, MessageBoxButtons.OK, MessageBoxIcon.Error);

                Debug.WriteLine("Exception Message: " +ex.Message);
                Debug.WriteLine("Exception Error Code: "+ex.ErrorCode);
                Debug.WriteLine("Exception Source: "+ ex.Source);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Wystąpił  błąd "+ Environment.NewLine + ex.Message, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Debug.WriteLine("Exception Message: " + ex.Message);
                Debug.WriteLine("Exception Source: " + ex.Source);
            }
            finally
            {
                dbTools.dbAgent.GetConnection().Close();
                
            }
            return false;
        }
        public static User GetUser(string Login, string Password)
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
                int privTmp = 0, id=0;
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
                    id = (int)reader["ID"];
                    return new User(id,imie, nazwisko, (User.Privileges) privTmp);
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
        public static void AddUser(string Login, string Password, string Name, string Surname, string PESEL, User.Privileges level)
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
        public static void AddUser(string Name, string Surname, string Password, User.Privileges level)
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
            surname.Length > 6 ? 6 : surname.Length));
            login.Trim(' ');

            return login;


        }

        /// <summary>
        /// Making the form to check for default Login and password for Admin account
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
            catch (Exception ex)
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
