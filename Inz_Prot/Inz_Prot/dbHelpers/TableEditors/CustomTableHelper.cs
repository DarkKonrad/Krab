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
            insertTableQuery.Parameters.AddWithValue("@types",tableInfo.GetColumnsTypeAndNameString());

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
            string command = string.Format("SELECT COUNT(*) FROM {0}", tableName);
            var query = new MySqlCommand(command, dbAgent.GetConnection());

            int RowsCount = -1;
            dbAgent.GetConnection().Open();
            try
            {
                var reader = query.ExecuteReader();
                while (reader.Read())
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

        public static bool IsTableNameInUse(string tablename)
        {
            bool isReserved = false;
            string command = "SELECT ID from usertableinfo WHERE TableName = @tablename";
            var query = new MySqlCommand(command, dbAgent.GetConnection());
            query.Parameters.AddWithValue("@tablename", tablename);
            int ID = -1;
            try
            {
                dbAgent.GetConnection().Open();

                var reader = query.ExecuteReader();

                while(reader.Read())
                {
                    ID = (int) reader["ID"];
                    if(ID > -1)
                    {
                        isReserved = true;
                        return isReserved;
                    }
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
                Debug.WriteLine(" Custom Table Helper IsTableNameInUse");
            }
            finally
            {
                dbTools.dbAgent.GetConnection().Close();

            }

            return isReserved;
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

            //TableInfo userDefinedTableContent = null;                                
            string command = @"SELECT * FROM " + customTableInfo.TableName;

            var query = new MySqlCommand(command, dbAgent.GetConnection());

            dbAgent.GetConnection().Open();
            try
            {
                var reader = query.ExecuteReader();

                while (reader.Read())
                {
                    collection = new List<CellContent>();
                    // for every columns in row
                    for (int i = 0; i < customTableInfo.Count; i++)
                    {
                        // To determine what action we need to do, we need to check for every column type.
                        switch (customTableInfo.ColumnInfos_Row[i].ColumnType)
                        {
                            case ColumnType.DataType:
                                DateTime date; 
                                if (reader[customTableInfo.ColumnInfos_Row[i].Name].ToString().Contains("00.00.0000") || reader.IsDBNull(i))
                                    date = DateTime.Now;
                                else
                                    date= Convert.ToDateTime(reader[customTableInfo.ColumnInfos_Row[i].Name]);  
                                collection.Add(new CellContent(date, (int) reader["ID"]));
                                break;
                            case ColumnType.Description:
                                var descr = reader[customTableInfo.ColumnInfos_Row[i].Name].ToString();
                                collection.Add(new CellContent(descr, (int) reader["ID"]));
                                break;
                            case ColumnType.ShortText:
                                var shrtText = reader[customTableInfo.ColumnInfos_Row[i].Name].ToString();
                                collection.Add(new CellContent(shrtText, (int) reader["ID"]));
                                break;
                            case ColumnType.Integer:
                                var num = (int) reader[customTableInfo.ColumnInfos_Row[i].Name];
                                collection.Add(new CellContent(num, (int) reader["ID"]));
                                break;
                            case ColumnType.Float:
                                var num_float = (float) reader[customTableInfo.ColumnInfos_Row[i].Name];
                                collection.Add(new CellContent(num_float, (int) reader["ID"]));
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
        public static TableInfo GetTableInfoAboutTables_OneRowVersion()
        {
            // należy dorobić wersję,która udostępni wszystkie wiersze
            List<ColumnInfo> columns = new List<ColumnInfo>();
            TableInfo tableInfo = null;
            string command = @"SELECT * FROM " + NamesTypes.UserCustomTables_TABLE;
            var query = new MySqlCommand(command, dbAgent.GetConnection());

            dbAgent.GetConnection().Open();

            try
            {
                var reader = query.ExecuteReader();

                int id = 0;
                string rawColumns_SingleString = "", rawTableName = "";

                while (reader.Read())
                {
                    id = (int) reader["ID"];
                    rawTableName = reader["TableName"].ToString();
                    rawColumns_SingleString = reader["ColumnsType"].ToString();
                }
                if (rawTableName == "" || rawTableName == null)
                {
                    return null;
                }
                tableInfo = new TableInfo(rawTableName);
                var rawColumns = rawColumns_SingleString.Split('|');

                for (int i = 0; i < rawColumns.Length; i++)
                {
                    var buff = rawColumns[i].Split('#');

                    tableInfo.Add(new ColumnInfo(
                        buff[0],
                        NamesTypes.RawStringColumnTypePairs[buff[1]]
                        ));
                }
            }

            catch (MySqlException ex)
            {
                MessageBox.Show("Nastąpił błąd połączenia z bazą danych. Jeśli problem będzie się powtrzał skontaktuj się z zarządcą bazy danych", "Błąd połączenia z bazą danych" + Environment.NewLine + ex.ErrorCode, MessageBoxButtons.OK, MessageBoxIcon.Error);

                Debug.WriteLine("Exception Message: " + ex.Message);
                Debug.WriteLine("Exception Error Code: " + ex.ErrorCode);
                Debug.WriteLine("Exception Source: " + ex.Source);
                Debug.WriteLine("ERROR: GetTableInfoAboutTables FIRST VERSION ");
                Debug.WriteLine(ex.TargetSite);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Wystąpił  błąd " + Environment.NewLine + ex.Message + "Operacja nie powiodła się", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Debug.WriteLine("Exception Message: " + ex.Message);
                Debug.WriteLine("Exception Source: " + ex.Source);
                Debug.WriteLine("ERROR: GetTableInfoAboutTables FIRST VERSION ");
                Debug.WriteLine(ex.TargetSite);
            }
            finally
            {
                dbTools.dbAgent.GetConnection().Close();

            }
            return tableInfo;
        }


        public static TableInfo GetTableInfoAboutTable(string tableName)
        {
            
            List<ColumnInfo> columns = new List<ColumnInfo>();
            TableInfo tableInfo = null;
            string command = @"SELECT * FROM " + NamesTypes.UserCustomTables_TABLE + " " + @"WHERE TableName = @tablename";
            var query = new MySqlCommand(command, dbAgent.GetConnection());
            query.Parameters.AddWithValue("@tablename", tableName);

            dbAgent.GetConnection().Open();

            try
            {
                var reader = query.ExecuteReader();

                int id = 0;
                string rawColumns_SingleString = "", rawTableName = "";

                while (reader.Read())
                {
                    id = (int) reader["ID"];
                    rawTableName = reader["TableName"].ToString();
                    rawColumns_SingleString = reader["ColumnsType"].ToString();
                }
                if (rawTableName == "" || rawTableName == null)
                {
                    return null;
                }
                tableInfo = new TableInfo(rawTableName);
                var rawColumns = rawColumns_SingleString.Split('|');

                for (int i = 0; i < rawColumns.Length; i++)
                {
                    var buff = rawColumns[i].Split('#');

                    tableInfo.Add(new ColumnInfo(
                        buff[0],
                        NamesTypes.RawStringColumnTypePairs[buff[1]]
                        ));
                }
            }

            catch (MySqlException ex)
            {
                MessageBox.Show("Nastąpił błąd połączenia z bazą danych. Jeśli problem będzie się powtrzał skontaktuj się z zarządcą bazy danych", "Błąd połączenia z bazą danych" + Environment.NewLine + ex.ErrorCode, MessageBoxButtons.OK, MessageBoxIcon.Error);

                Debug.WriteLine("Exception Message: " + ex.Message);
                Debug.WriteLine("Exception Error Code: " + ex.ErrorCode);
                Debug.WriteLine("Exception Source: " + ex.Source);
                Debug.WriteLine("ERROR: GetTableInfoAboutTables FIRST VERSION ");
                Debug.WriteLine(ex.TargetSite);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Wystąpił  błąd " + Environment.NewLine + ex.Message + "Operacja nie powiodła się", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Debug.WriteLine("Exception Message: " + ex.Message);
                Debug.WriteLine("Exception Source: " + ex.Source);
                Debug.WriteLine("ERROR: GetTableInfoAboutTables FIRST VERSION ");
                Debug.WriteLine(ex.TargetSite);
            }
            finally
            {
                dbTools.dbAgent.GetConnection().Close();

            }
            return tableInfo;
        }

        public static void DeleteTable(string tableName)
        {
            string str_com_DeleteFromUserTable = "DELETE FROM usertableinfo WHERE tablename = @tablename ";
            string str_drop_UserTable = "DROP TABLE " + tableName;

            var query_DeleteFromUserTable = new MySqlCommand(str_com_DeleteFromUserTable, dbAgent.GetConnection());
            var query_DropUserTable = new MySqlCommand(str_drop_UserTable, dbAgent.GetConnection());

            query_DeleteFromUserTable.Parameters.AddWithValue("@tablename", tableName);

            dbAgent.GetConnection().Open();
            var transaction = dbAgent.GetConnection().BeginTransaction();

            try
            {
                query_DropUserTable.Transaction = transaction;
                query_DeleteFromUserTable.Transaction = transaction;

                query_DeleteFromUserTable.ExecuteNonQuery();
                query_DropUserTable.ExecuteNonQuery();

                transaction.Commit();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Nastąpił błąd połączenia z bazą danych. Jeśli problem będzie się powtrzał skontaktuj się z zarządcą bazy danych", "Błąd połączenia z bazą danych" + Environment.NewLine + ex.ErrorCode, MessageBoxButtons.OK, MessageBoxIcon.Error);

                Debug.WriteLine("Exception Message: " + ex.Message);
                Debug.WriteLine("Exception Error Code: " + ex.ErrorCode);
                Debug.WriteLine("Exception Source: " + ex.Source);
                Debug.WriteLine("ERROR: CustomTableHelper -->DeleteTable<-- ");
                Debug.WriteLine(ex.TargetSite);
                transaction.Rollback();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Wystąpił  błąd " + Environment.NewLine + ex.Message + "Operacja nie powiodła się", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Debug.WriteLine("Exception Message: " + ex.Message);
                Debug.WriteLine("Exception Source: " + ex.Source);
                Debug.WriteLine("ERROR: CustomTableHelper -->DeleteTable<-- ");
                Debug.WriteLine(ex.TargetSite);
                transaction.Rollback();
            }
            finally
            {
                dbTools.dbAgent.GetConnection().Close();

            }
        }

        public static void DeleteRow(int ID,string TableName)
        {
            string command = "DELETE FROM " + TableName + " " + "WHERE ID=@id";
            var query = new MySqlCommand(command, dbAgent.GetConnection());

            query.Parameters.AddWithValue("@id", ID);

            try
            {
                dbAgent.GetConnection().Open();

                query.ExecuteNonQuery();
            }

            catch (MySqlException ex)
            {
                MessageBox.Show("Nastąpił błąd połączenia z bazą danych. Jeśli problem będzie się powtrzał skontaktuj się z zarządcą bazy danych", "Błąd połączenia z bazą danych" + Environment.NewLine + ex.ErrorCode, MessageBoxButtons.OK, MessageBoxIcon.Error);

                Debug.WriteLine("Exception Message: " + ex.Message);
                Debug.WriteLine("Exception Error Code: " + ex.ErrorCode);
                Debug.WriteLine("Exception Source: " + ex.Source);
                Debug.WriteLine("ERROR: CustomTableHelper -->RemoveRow<--");
                Debug.WriteLine(ex.TargetSite);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Wystąpił  błąd " + Environment.NewLine + ex.Message + "Operacja nie powiodła się", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Debug.WriteLine("Exception Message: " + ex.Message);
                Debug.WriteLine("Exception Source: " + ex.Source);
                Debug.WriteLine("ERROR: CustomTableHelper -->RemoveRow<--");
                Debug.WriteLine(ex.TargetSite);
            }
            finally
            {
                dbTools.dbAgent.GetConnection().Close();

            }

        }

       

        public static List<TableInfo> GetTableInfosAboutCustomTables() // Initially - OK 
        {
          
            List<TableInfo> listOfUserDefinedTables = new List<TableInfo>();

            string command = @"SELECT * FROM " + NamesTypes.UserCustomTables_TABLE;

            var query = new MySqlCommand(command, dbAgent.GetConnection());

            dbAgent.GetConnection().Open();

            try
            {
                int j = 0;
                var reader = query.ExecuteReader();

                int id = 0;
                string rawColumns_SingleString = "", rawTableName = "";

                while (reader.Read())
                {
                    id = (int) reader["ID"];
                    rawTableName = reader["TableName"].ToString();
                    rawColumns_SingleString = reader["ColumnsType"].ToString();
                    listOfUserDefinedTables.Add(new TableInfo(rawTableName));



                    var rawColumns = rawColumns_SingleString.Split('|');

                    for (int i = 0; i < rawColumns.Length; i++)
                    {
                        var buff = rawColumns[i].Split('#');

                        listOfUserDefinedTables[j].Add(new ColumnInfo(
                            buff[0],
                            NamesTypes.RawStringColumnTypePairs[buff[1]]
                            ));
                    }

                    j++;
                }
            }

            catch (MySqlException ex)
            {
                MessageBox.Show("Nastąpił błąd połączenia z bazą danych. Jeśli problem będzie się powtrzał skontaktuj się z zarządcą bazy danych", "Błąd połączenia z bazą danych" + Environment.NewLine + ex.ErrorCode, MessageBoxButtons.OK, MessageBoxIcon.Error);

                Debug.WriteLine("Exception Message: " + ex.Message);
                Debug.WriteLine("Exception Error Code: " + ex.ErrorCode);
                Debug.WriteLine("Exception Source: " + ex.Source);
                Debug.WriteLine("ERROR: GetTableInfosAboutCustomTables FIRST VERSION ");
                Debug.WriteLine(ex.TargetSite);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Wystąpił  błąd " + Environment.NewLine + ex.Message + "Operacja nie powiodła się", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Debug.WriteLine("Exception Message: " + ex.Message);
                Debug.WriteLine("Exception Source: " + ex.Source);
                Debug.WriteLine("ERROR: GetTableInfosAboutCustomTables FIRST VERSION ");
                Debug.WriteLine(ex.TargetSite);
            }
            finally
            {
                dbTools.dbAgent.GetConnection().Close();

            }
   

            return listOfUserDefinedTables;
        }
        /// <summary>
        /// Count: Values -1 becous of ID field
        /// </summary>
        /// <param name="tableInfo"></param>
        /// <param name="Values"></param>
        public static void AddRowToCustomTable(TableInfo tableInfo, params string[] Values)
        {
            string command = @"INSERT INTO " + tableInfo.TableName + @" VALUES (@ID";
            dbAgent.GetConnection().Open();
            float tmp;

            for (int i = 0; i < tableInfo.Count ; i++)
            {
                command += @",@param" + i.ToString();
            }
            command += ")";
            try
            {
                var query = new MySqlCommand(command, dbAgent.GetConnection());

               
                query.Parameters.AddWithValue("@ID", null);

                for (int i = 0; i < tableInfo.Count ;i++)
                {
                    if (float.TryParse(Values[i].ToString(), out tmp))
                    {
                        query.Parameters.AddWithValue(@"@param" + i.ToString(), Values[i].ToString().Replace(',', '.'));
                    }
                    else
                        query.Parameters.AddWithValue(@"@param" + i.ToString(), Values[i]);
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
            string command = @"UPDATE " + tableInfo.TableName + "SET " + ColumnName + " = " + @"@value WHERE ID = @id";
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

        public static void AlterColumnDataType(string tableName,ColumnInfo newColumnType)
        {
            string command = "";

            if (newColumnType.ColumnType == ColumnType.DataType)
            {
                command = string.Format(@"UPDATE {0} SET {1}=2019;ALTER TABLE {0} MODIFY COLUMN {1} {2} ", tableName, newColumnType.Name, newColumnType.GetColumnTypeString());
            }
            else
                command = string.Format(@"ALTER TABLE {0} MODIFY COLUMN {1} {2}", tableName, newColumnType.Name, newColumnType.GetColumnTypeString());

            var query = new MySqlCommand(command, dbAgent.GetConnection());
            string columnsStringToInsert = "";
            string command_usertableinfo = @"SELECT ColumnsType  FROM usertableinfo where TableName = @tableName";
            var query_usertableinfo = new MySqlCommand(command_usertableinfo, dbAgent.GetConnection());

            query_usertableinfo.Parameters.AddWithValue("@tableName", tableName);
            string usertableInfo_RowToModify = "";
            try
            {
                dbAgent.GetConnection().Open();
                var reader = query_usertableinfo.ExecuteReader();

                while(reader.Read())
                {
                    usertableInfo_RowToModify = reader["ColumnsType"].ToString();
                }

                var columns = usertableInfo_RowToModify.Split('|');
                string modified = "";
                int T = 0;
                foreach(var col in columns)
                {
                    
                    if(col.StartsWith(newColumnType.Name))
                    {
                        var index = col.IndexOf('#');
                        var cleared = col.Remove(index +1); // becouse of #
                        cleared = cleared.Insert(index+1, newColumnType.TypeAndOptionalCapacity_UTI);
                        modified = cleared;
                        break;
                    }
                    T++;
                }


                for (int i = 0; i< columns.Length ; i++)
                {
                    if (i != T)
                    {
                        if (i != columns.Length-1)
                        {
                            columnsStringToInsert += columns[i] + "|";
                        }
                        else
                        {
                            columnsStringToInsert += columns[i];
                        }
                    }
                    else
                    {
                        if (i != columns.Length - 1)
                        {
                            columnsStringToInsert += modified + "|";
                        }
                        else
                        {
                            columnsStringToInsert += modified;
                        }
                    }

                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Nastąpił błąd połączenia z bazą danych. Jeśli problem będzie się powtrzał skontaktuj się z zarządcą bazy danych", "Błąd połączenia z bazą danych" + Environment.NewLine + ex.ErrorCode, MessageBoxButtons.OK, MessageBoxIcon.Error);

                Debug.WriteLine("Exception Message: " + ex.Message);
                Debug.WriteLine("Exception Error Code: " + ex.ErrorCode);
                Debug.WriteLine("Exception Source: " + ex.Source);
                Debug.WriteLine("ERROR: AlterColumnDataType");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Wystąpił  błąd " + Environment.NewLine + ex.Message + "Operacja nie powiodła się", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Debug.WriteLine("Exception Message: " + ex.Message);
                Debug.WriteLine("Exception Source: " + ex.Source);
                Debug.WriteLine("ERROR: AlterColumnDataType");
            }
            finally
            {
                dbAgent.GetConnection().Close();
            }

            string command_Insert = string.Format(@"UPDATE usertableinfo SET ColumnsType = @columnsString WHERE TableName = @table");//, columnsStringToInsert, tableName); // /'
            var query_insert = new MySqlCommand(command_Insert, dbAgent.GetConnection());

            query_insert.Parameters.AddWithValue("@columnsString", columnsStringToInsert);
            query_insert.Parameters.AddWithValue("@table", tableName);
            dbAgent.GetConnection().Open();
            var transaction = dbAgent.GetConnection().BeginTransaction();
            // Working
            try
            {

                query.Transaction = transaction;
                query_insert.Transaction = transaction;

                query_insert.ExecuteNonQuery();
                query.ExecuteNonQuery();

                transaction.Commit();

            }
            catch (MySqlException ex)
            {
                transaction.Rollback();
                MessageBox.Show("Nastąpił błąd połączenia z bazą danych. Jeśli problem będzie się powtrzał skontaktuj się z zarządcą bazy danych", "Błąd połączenia z bazą danych" + Environment.NewLine + ex.ErrorCode, MessageBoxButtons.OK, MessageBoxIcon.Error);

                Debug.WriteLine("Exception Message: " + ex.Message);
                Debug.WriteLine("Exception Error Code: " + ex.ErrorCode);
                Debug.WriteLine("Exception Source: " + ex.Source);
                Debug.WriteLine("ERROR: AlterColumnDataType");
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                MessageBox.Show("Wystąpił  błąd " + Environment.NewLine + ex.Message + "Operacja nie powiodła się", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Debug.WriteLine("Exception Message: " + ex.Message);
                Debug.WriteLine("Exception Source: " + ex.Source);
                Debug.WriteLine("ERROR: AlterColumnDataType");
            }
            finally
            {
                transaction.Dispose();
                dbAgent.GetConnection().Close();
            }

            JuxtapositionHelper.RefreshJuxtposition(tableName, newColumnType);


        }

        /// <summary>
        /// It's recomended to pass whole array of values. Still it is possible to pass specific objects one by one but, you need to be sure there all columns are covered with therir object values.
        /// </summary>
        /// <param name="rowID"></param>
        /// <param name="tableInfo"></param>
        /// <param name="ColumnNames"></param>
        /// <param name="Values"></param>
        public static void EditCustomTableCells(int rowID, TableInfo tableInfo,  string[] ColumnNames, params object[] Values)
        {
            float tmp;
            string command = @"UPDATE " + tableInfo.TableName + " SET ";
            for (int i = 0; i < Values.Length; i++)
            {
                if(i == Values.Length -1)
                    command += ColumnNames[i] + " = " + @"@val" + i.ToString() + " ";
                else
                    command += ColumnNames[i] + " = " + @"@val" + i.ToString() + ", ";
            }
            command += @"WHERE ID = @id";

            var query = new MySqlCommand(command, dbAgent.GetConnection());

            query.Parameters.AddWithValue("@id", rowID);

            for (int i = 0; i < Values.Length; i++)
            {
                if (float.TryParse(Values[i].ToString(), out tmp))
                {
                    query.Parameters.AddWithValue(@"@val" + i.ToString(), Values[i].ToString().Replace(',','.'));
                }
                else
                    query.Parameters.AddWithValue(@"@val" + i.ToString(), Values[i]);
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



        //public static void AddRowToCustomTable(TableInfo tableInfo, params object[] Values )
        //{
        //    string command = @"INSERT INTO " + tableInfo.TableName + " VALUES (@ID";

        //    for (int i = 0; i < tableInfo.Count ; i++)
        //    {
        //        command += ",@param" + i.ToString();
        //    }
        //    command += ")";

        //    var query = new MySqlCommand(command, dbAgent.GetConnection());

        //    query.Parameters.AddWithValue("@ID", null);
        //    for (int i = 0; i < tableInfo.Count ; i++)
        //    {
        //        query.Parameters.AddWithValue("@param" + i.ToString(), Values[i]);
        //    }
        //    dbAgent.GetConnection().Open();
        //    try
        //    {
        //        query.ExecuteNonQuery();
        //    }
        //    catch (MySqlException ex)
        //    {
        //        MessageBox.Show("Nastąpił błąd połączenia z bazą danych. Jeśli problem będzie się powtrzał skontaktuj się z zarządcą bazy danych", "Błąd połączenia z bazą danych" + Environment.NewLine + ex.ErrorCode, MessageBoxButtons.OK, MessageBoxIcon.Error);

        //        Debug.WriteLine("Exception Message: " + ex.Message);
        //        Debug.WriteLine("Exception Error Code: " + ex.ErrorCode);
        //        Debug.WriteLine("Exception Source: " + ex.Source);
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Wystąpił  błąd " + Environment.NewLine + ex.Message + "Operacja nie powiodła się", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        Debug.WriteLine("Exception Message: " + ex.Message);
        //        Debug.WriteLine("Exception Source: " + ex.Source);
        //    }
        //    finally
        //    {
        //        dbTools.dbAgent.GetConnection().Close();
        //    }
        //}


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