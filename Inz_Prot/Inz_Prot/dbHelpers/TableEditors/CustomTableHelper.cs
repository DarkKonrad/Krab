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
        //private static List<ColumnInfo> listOfColumnInfosFromDb;
        public static void AddCustomTable(TableInfo tableInfo)
        {
            var createTableQuery = tableInfo.GetQuery();
            createTableQuery.Connection = dbAgent.GetConnection();

            string insertCommand = @"INSERT INTO usertableinfo VALUES(@null,@name,@types)";

            var insertTableQuery = new MySqlCommand(insertCommand, dbAgent.GetConnection());

            insertTableQuery.Parameters.AddWithValue("@null", null);
            insertTableQuery.Parameters.AddWithValue("@name", tableInfo.TableName.ToLower());
            insertTableQuery.Parameters.AddWithValue("@types", tableInfo.GetColumnsTypeAndNameString());

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
        public static int GetRowCount(string tableName)
        {
            string command = string.Format("SELECT COUNT(*) FROM {0}",tableName);
            var query = new MySqlCommand(command, dbAgent.GetConnection());
        
            int RowsCount = -1;
            dbAgent.GetConnection().Open();
            try
            {
                var reader = query.ExecuteReader();

                while(reader.Read())
                {
                    //  RowsCount = (int) reader["COUNT(*)"]; // WARNING !
                    RowsCount = int.Parse(reader["COUNT(*)"].ToString());
                }

                
            }

            catch (MySqlException ex)
            {
                MessageBox.Show("Nastąpił błąd połączenia z bazą danych. Jeśli problem będzie się powtrzał skontaktuj się z zarządcą bazy danych", "Błąd połączenia z bazą danych" + Environment.NewLine + ex.ErrorCode, MessageBoxButtons.OK, MessageBoxIcon.Error);

                

                Debug.WriteLine("Exception Message: " + ex.Message);
                Debug.WriteLine("Exception Error Code: " + ex.ErrorCode);
                Debug.WriteLine("Exception Source: " + ex.Source);
                Debug.WriteLine("Error: CustomTableHelper: Get Row Count");
            }
            catch (Exception ex)
            {
               

                MessageBox.Show("Wystąpił  błąd " + Environment.NewLine + ex.Message + "Operacja nie powiodła się", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Debug.WriteLine("Exception Message: " + ex.Message);
                Debug.WriteLine("Exception Source: " + ex.Source);
                Debug.WriteLine("Error: CustomTableHelper: Get Row Count");
            }
            finally
            {
                dbTools.dbAgent.GetConnection().Close();

            }
            return RowsCount;
        }

        /// <summary>
        /// Returns ROWS from User Defined Custom Table. Requires TableInfo with information about columns and it's type of data.
        /// Obtainable with GetInfoAboutTables.
        /// </summary>
        /// <returns></returns>
        public static CustomTableRows GetAllRowsFromCustomTable(TableInfo customTableInfo)
        {
            List<CellContent> collection;
            CustomTableRows customTableRow = new CustomTableRows();
          
            //TableInfo userDefinedTableContent = null;                                 TABLE CONTENTS ? 
            string command = @"SELECT * FROM " + customTableInfo.TableName;

            var query = new MySqlCommand(command, dbAgent.GetConnection());

            dbAgent.GetConnection().Open();
            try
            {
                var reader = query.ExecuteReader();

                while(reader.Read())
                {
                    collection = new List<CellContent>(); 
                    // for every columns in row
                    for (int i =0; i<customTableInfo.Count;i++)
                    {
                        // To determine what action we need to do, we need to check for every column type.
                        switch (customTableInfo.ColumnInfos_Row[i].ColumnType)
                        {
                            case ColumnType.DataType:
                                var DateTime = (DateTime) reader[customTableInfo.ColumnInfos_Row[i].Name];
                                collection.Add(new CellContent(DateTime,(int)reader["ID"]));
                                break;
                            case ColumnType.Description:
                                var descr = reader[customTableInfo.ColumnInfos_Row[i].Name].ToString();
                                collection.Add(new CellContent(descr, (int) reader["ID"]));
                                break;
                            case ColumnType.ShortText:
                                var shrtText = reader[customTableInfo.ColumnInfos_Row[i].Name].ToString();
                                collection.Add(new CellContent(shrtText, (int) reader["ID"]));
                                break;
                            case ColumnType.Numeric:
                                var num = (int) reader[customTableInfo.ColumnInfos_Row[i].Name];
                                collection.Add(new CellContent(num, (int) reader["ID"]));
                                break;

                            default: throw new Exception("Custom Table Helper GetAllRowsFromCustomTable method, switch Error ");
                               
                        }


                    }
                    // ROWS
                    customTableRow.AddRow(collection);
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
                Debug.WriteLine(" Custom Table Helper GetAllRowsFromCustomDb");
            }
            finally
            {
                dbTools.dbAgent.GetConnection().Close();

            }

            return customTableRow;
        }

        /// <summary>
        /// Returns TableInfo object with information about User Defined - Custom Table WITHOUT its rows
        /// </summary>
        /// <returns></returns>
        public static TableInfo GetTableInfoAboutTables()
        {
            // należy dorobić wersję,która udostępni wszystkie wiersze
            List<ColumnInfo> columns = new List<ColumnInfo>();
            TableInfo tableInfo = null;
            string command = @"SELECT * FROM usertableinfo";
            var query = new MySqlCommand(command, dbAgent.GetConnection());

            dbAgent.GetConnection().Open();

            try
            {
                var reader = query.ExecuteReader();

                int id = 0;
                string rawColumns_SingleString="",rawTableName="";

                while(reader.Read())
                {
                    id = (int) reader["ID"];
                    rawTableName = reader["TableName"].ToString();
                    rawColumns_SingleString= reader["ColumnsType"].ToString();
                }
                tableInfo = new TableInfo(rawTableName);
                var rawColumns = rawColumns_SingleString.Split('|');
                
                for (int i = 0; i < rawColumns.Length; i++)
                {
                    var buff = rawColumns[i].Split('#');

                    tableInfo.Add(new ColumnInfo(
                        buff[0], 
                        dbTypes.RawStringColumnTypePairs[buff[1]]
                        ));
                }
            }
         
            catch (MySqlException ex)
            {
                MessageBox.Show("Nastąpił błąd połączenia z bazą danych. Jeśli problem będzie się powtrzał skontaktuj się z zarządcą bazy danych", "Błąd połączenia z bazą danych" + Environment.NewLine + ex.ErrorCode, MessageBoxButtons.OK, MessageBoxIcon.Error);

                Debug.WriteLine("Exception Message: " + ex.Message);
                Debug.WriteLine("Exception Error Code: " + ex.ErrorCode);
                Debug.WriteLine("Exception Source: " + ex.Source);
                Debug.WriteLine("ERROR: GetTableInfoAboutTables FIRTS VERSION ");
                Debug.WriteLine(ex.TargetSite);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Wystąpił  błąd " + Environment.NewLine + ex.Message + "Operacja nie powiodła się", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Debug.WriteLine("Exception Message: " + ex.Message);
                Debug.WriteLine("Exception Source: " + ex.Source);
                Debug.WriteLine("ERROR: GetTableInfoAboutTables FIRTS VERSION ");
                Debug.WriteLine(ex.TargetSite);
            }
            finally
            {
                dbTools.dbAgent.GetConnection().Close();
                
            }
            return tableInfo;
        }

        /// <summary>
        /// Count: Values -1 becous of ID field
        /// </summary>
        /// <param name="tableInfo"></param>
        /// <param name="Values"></param>
        public static void AddRowToCustomTable(TableInfo tableInfo, params string[] Values)
        {
            string command = @"INSERT INTO " + tableInfo.TableName + @"VALUES (@ID";
            dbAgent.GetConnection().Open();

            //for(int i = tableInfo.Count-1;i>=0; i-- )
            //{
            //    command += @",@param" + i.ToString();
            //}
            for (int i = 0; i < tableInfo.Count - 1; i++)
            {
                command += @",@param" + i.ToString();
            }
            command += ")";
            try
            {
                var query = new MySqlCommand(command, dbAgent.GetConnection());

               
                query.Parameters.AddWithValue("@ID", null);
                //for (int i = tableInfo.Count - 1; i >= 0; i--)
                //{
                //    query.Parameters.AddWithValue("@param" + i.ToString(), Values[i]);
                //}
                
                for (int i = 0; i < tableInfo.Count -1;i++)
                {
                    query.Parameters.AddWithValue("@param" + i.ToString(), Values[i]);
                }
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
                MessageBox.Show("Wystąpił  błąd " + Environment.NewLine + ex.Message + "Operacja nie powiodła się", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Debug.WriteLine("Exception Message: " + ex.Message);
                Debug.WriteLine("Exception Source: " + ex.Source);
            }
            finally
            {
                dbTools.dbAgent.GetConnection().Close();
            }

        }

        public static void EditCustomTableCell(int rowID,TableInfo tableInfo, string ColumnName, object Value)
        {
            string command = @"UPDATE " + tableInfo.TableName + "SET " + ColumnName + " = " + @"value WHERE ID = @id";
            var query = new MySqlCommand(command, dbAgent.GetConnection());

            query.Parameters.AddWithValue("@id", rowID);
            query.Parameters.AddWithValue("@value", Value);
            dbAgent.GetConnection().Open();

            try
            {
                query.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Nastąpił błąd połączenia z bazą danych. Jeśli problem będzie się powtrzał skontaktuj się z zarządcą bazy danych", "Błąd połączenia z bazą danych" + Environment.NewLine + ex.ErrorCode, MessageBoxButtons.OK, MessageBoxIcon.Error);

                Debug.WriteLine("Exception Message: " + ex.Message);
                Debug.WriteLine("Exception Error Code: " + ex.ErrorCode);
                Debug.WriteLine("Exception Source: " + ex.Source);
                Debug.WriteLine("ERROR: EditCustomTableCell");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Wystąpił  błąd " + Environment.NewLine + ex.Message + "Operacja nie powiodła się", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Debug.WriteLine("Exception Message: " + ex.Message);
                Debug.WriteLine("Exception Source: " + ex.Source);
                Debug.WriteLine("ERROR: EditCustomTableCell");
            }
            finally
            {
                dbTools.dbAgent.GetConnection().Close();
            }

        }
        public static void AddRowToCustomTable(TableInfo tableInfo, params object[] Values )
        {
            string command = @"INSERT INTO " + tableInfo.TableName + " VALUES (@ID";

            for (int i = 0; i < tableInfo.Count ; i++)
            {
                command += ",@param" + i.ToString();
            }
            command += ")";

            var query = new MySqlCommand(command, dbAgent.GetConnection());

            query.Parameters.AddWithValue("@ID", null);
            for (int i = 0; i < tableInfo.Count ; i++)
            {

                query.Parameters.AddWithValue("@param" + i.ToString(), Values[i]);
            }
            dbAgent.GetConnection().Open();
            try
            {
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
                MessageBox.Show("Wystąpił  błąd " + Environment.NewLine + ex.Message + "Operacja nie powiodła się", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Debug.WriteLine("Exception Message: " + ex.Message);
                Debug.WriteLine("Exception Source: " + ex.Source);
            }
            finally
            {
                dbTools.dbAgent.GetConnection().Close();
            }
        }


        public static void AddRowToCustomTable(TableInfo tableInfo,List<CellContent> tableRow)
        {
            string command = @"INSERT INTO " + tableInfo.TableName + " VALUES (@ID";

            for(int i =0; i< tableInfo.Count - 1;i++)
            {
                command += ",@param" + i.ToString();
            }
            command += ")";

            var query = new MySqlCommand(command, dbAgent.GetConnection());
            query.Parameters.AddWithValue("@ID", null);

            for (int i = 0; i < tableInfo.Count - 1; i++)
            {
                query.Parameters.AddWithValue("@param" + i.ToString(), tableRow[i].Value);
            }

            dbAgent.GetConnection().Open();
            try
            {
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