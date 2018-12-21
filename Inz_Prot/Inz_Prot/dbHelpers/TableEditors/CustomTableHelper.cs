using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inz_Prot.Models.dbCustomTable;
using Inz_Prot.dbTools;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Diagnostics;
namespace Inz_Prot.dbHelpers.TableEditors
{
  public static class CustomTableHelper
    {
        public static void AddCustomTable(TableInfo tableInfo)
        {
            var createTableQuery = tableInfo.GetQuery();
            createTableQuery.Connection = dbAgent.GetConnection();

            string insertCommand = @"INSERT INTO usertableinfo VALUES(@null,@name,@types)";

            var insertTableQuery = new MySqlCommand(insertCommand, dbAgent.GetConnection());

            insertTableQuery.Parameters.AddWithValue("@null", null);
            insertTableQuery.Parameters.AddWithValue("@name", tableInfo.TableName.ToLower());
            insertTableQuery.Parameters.AddWithValue("@types", tableInfo.GetColumnsTypeString());

            dbAgent.GetConnection().Open();
            var transaction = dbAgent.GetConnection().BeginTransaction();

            try
            {
                createTableQuery.Transaction = transaction;
                insertTableQuery.Transaction = transaction;

                insertTableQuery.ExecuteNonQuery();
                createTableQuery.ExecuteNonQuery();

                transaction.Commit();
            }

            catch (MySqlException ex)
            {
                MessageBox.Show("Nastąpił błąd połączenia z bazą danych. Jeśli problem będzie się powtrzał skontaktuj się z zarządcą bazy danych", "Błąd połączenia z bazą danych" + Environment.NewLine + ex.ErrorCode, MessageBoxButtons.OK, MessageBoxIcon.Error);

                transaction.Rollback();

                Debug.WriteLine("Exception Message: " + ex.Message);
                Debug.WriteLine("Exception Error Code: " + ex.ErrorCode);
                Debug.WriteLine("Exception Source: " + ex.Source);
            }
            catch (Exception ex)
            {
                transaction.Rollback();

                MessageBox.Show("Wystąpił  błąd " + Environment.NewLine + ex.Message + "Operacja nie powiodła się", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Debug.WriteLine("Exception Message: " + ex.Message);
                Debug.WriteLine("Exception Source: " + ex.Source);
            }
            finally
            {
                dbTools.dbAgent.GetConnection().Close();

            }

        }
      
        public static void GetInfoAboutTables()
        {
            string command = @"SELECT * FROM usertableinfo";
            var query = new MySqlCommand(command, dbAgent.GetConnection());

            dbAgent.GetConnection().Open();



            try
            {
                var reader = query.ExecuteReader();
                
                while(reader.Read())
                {


                }
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
               

                MessageBox.Show("Wystąpił  błąd " + Environment.NewLine + ex.Message + "Operacja nie powiodła się", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Debug.WriteLine("Exception Message: " + ex.Message);
                Debug.WriteLine("Exception Source: " + ex.Source);
            }
            finally
            {
                dbTools.dbAgent.GetConnection().Close();

            }

        }


    }
}

//CREATE TABLE Persons(
//    PersonID int,
//    LastName varchar(255),
//    FirstName varchar(255),
//    Address varchar(255),
//    City varchar(255)
//);