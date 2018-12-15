using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Inz_Prot.Models;
using MySql.Data.MySqlClient;

namespace Inz_Prot.dbHelpers.TableEditors
{
  public static class QualificationHelper
    {
        public static void AddQualification(Qualification qualification)
        {
            string command = "INSERT INTO qualifications Qualification_Name,Qualification_Descr VALUES(@name,@description)";
            var query = new MySqlCommand(command, dbTools.dbAgent.GetConnection());

            query.Parameters.AddWithValue("@name", qualification.Name);
            query.Parameters.AddWithValue("@description", qualification.Description);
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

        public static Qualification GetQualification(int ID)
        {
            string command = "SELECT * FROM qualifications WHERE ID = @id";
            var query = new MySqlCommand(command, dbTools.dbAgent.GetConnection());

            query.Parameters.AddWithValue("@id", ID);

            try
            {
                dbTools.dbAgent.GetConnection().Open();
                var reader= query.ExecuteReader();
                string name="", descr="";
                while(reader.Read())
                {
                     name = reader["Qualification_Name"].ToString();
                     descr = reader["Qualification_Descr"].ToString();

                }
                return new Qualification(ID, name, descr);
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
            return null;
            
        }

        public static Qualification GetQualification(string Name)
        {
            string command = "SELECT * FROM qualifications WHERE Qualification_Name = @name";
            var query = new MySqlCommand(command, dbTools.dbAgent.GetConnection());

            query.Parameters.AddWithValue("@name", Name);

            try
            {
                dbTools.dbAgent.GetConnection().Open();
                var reader = query.ExecuteReader();
                string  descr = "";
                int ID = 0;
                while (reader.Read())
                {
                    ID = (int) reader["ID"];
                    descr = reader["Qualification_Descr"].ToString();

                }
                return new Qualification(ID, Name, descr);
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
            return null;

        }

        public static List<Qualification> GetAllQualifications()
        {
            List<Qualification> listOfAllQualifications = new List<Qualification>();

            string command = "SELECT * FROM qualifications ";
            var query = new MySqlCommand(command, dbTools.dbAgent.GetConnection());

            try
            {
                dbTools.dbAgent.GetConnection().Open();
                var reader = query.ExecuteReader();
                string descr = "",name ="";
                int ID = 0;
                while (reader.Read())
                {
                    ID = (int) reader["ID"];
                    descr = reader["Qualification_Descr"].ToString();
                    name = reader["Qualification_Name"].ToString();

                    listOfAllQualifications.Add(new Qualification(
                        ID, name, descr));
                }
                return listOfAllQualifications;
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
            return null;

        }
    }
}
