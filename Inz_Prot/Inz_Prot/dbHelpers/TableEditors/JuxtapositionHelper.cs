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
using Inz_Prot.Models.dbCustomTable.Juxaposition;

namespace Inz_Prot.dbHelpers.TableEditors
{
   public static class JuxtapositionHelper
    {
        public static bool IsNameInUse(string name)
        {
            string command = @"SELECT JuxName FROM juxtaposition";
            var query = new MySqlCommand(command, dbAgent.GetConnection());

            try
            {
                dbAgent.GetConnection().Open();
                var reader = query.ExecuteReader();

                while(reader.Read())
                {
                    var nameFormDb = reader["JuxName"].ToString();
                    if (nameFormDb == name)
                        return true;

                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Nastąpił błąd połączenia z bazą danych. Jeśli problem będzie się powtrzał skontaktuj się z zarządcą bazy danych", "Błąd połączenia z bazą danych" + Environment.NewLine + ex.ErrorCode, MessageBoxButtons.OK, MessageBoxIcon.Error);

                Debug.WriteLine("Exception Message: " + ex.Message);
                Debug.WriteLine("Exception Error Code: " + ex.ErrorCode);
                Debug.WriteLine("Exception Source: " + ex.Source);
                Debug.WriteLine("Juxaposition: IsNameInUse");
            }
            catch (Exception ex)
            {

                MessageBox.Show("Wystąpił  błąd " + Environment.NewLine + ex.Message + "Operacja nie powiodła się", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Debug.WriteLine("Exception Message: " + ex.Message);
                Debug.WriteLine("Exception Source: " + ex.Source);
                Debug.WriteLine("Juxaposition: IsNameInUse");
            }
            finally
            {
                dbTools.dbAgent.GetConnection().Close();

            }
            return false;
        }
        public static void AddJuxaposition(Juxaposition juxaposition)
        {
            string command = @"INSERT INTO " + NamesTypes.Juxtapositions_TABLE_NAME + " VALUES (@null,@juxName,@juxContent)";
            var query = new MySqlCommand(command, dbAgent.GetConnection());

            query.Parameters.AddWithValue("@null", null);
            query.Parameters.AddWithValue("@juxName", juxaposition.Name);
            query.Parameters.AddWithValue("@juxContent", juxaposition.GetInfoJuxapositionString());

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
                Debug.WriteLine("Juxaposition: AddJuxaposition");
            }
            catch (Exception ex)
            {

                MessageBox.Show("Wystąpił  błąd " + Environment.NewLine + ex.Message + "Operacja nie powiodła się", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Debug.WriteLine("Exception Message: " + ex.Message);
                Debug.WriteLine("Exception Source: " + ex.Source);
                Debug.WriteLine("Juxaposition: AddJuxaposition");
            }
            finally
            {
                dbTools.dbAgent.GetConnection().Close();

            }


        }

        public static void EditCell(string tableName,string columnName,int cellID ,object value)
        {
            string command = @"UPDATE " + tableName + " SET " + columnName + "= @val WHERE ID=@id"; //where
            var query = new MySqlCommand(command, dbAgent.GetConnection());
            query.Parameters.AddWithValue("@val", value);
            query.Parameters.AddWithValue("@id", cellID);
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
                Debug.WriteLine("Juxaposition: EditCell_String");
            }
            catch (Exception ex)
            {

                MessageBox.Show("Wystąpił  błąd " + Environment.NewLine + ex.Message + "Operacja nie powiodła się", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Debug.WriteLine("Exception Message: " + ex.Message);
                Debug.WriteLine("Exception Source: " + ex.Source);
                Debug.WriteLine("Juxaposition: EditCell_String");
            }
            finally
            {
                dbTools.dbAgent.GetConnection().Close();

            }
        }

        public static void EditCell (JuxapositionColumnInfo juxapositionColumn,object value)
        {
            string command = @"UPDATE " + juxapositionColumn.ParentTableName + "SET " + juxapositionColumn.ColumnInfo.Name + " = @val"; //where
            var query = new MySqlCommand(command, dbAgent.GetConnection());
            query.Parameters.AddWithValue("@val", value);
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
                Debug.WriteLine("Juxaposition: EditCell");
            }
            catch (Exception ex)
            {

                MessageBox.Show("Wystąpił  błąd " + Environment.NewLine + ex.Message + "Operacja nie powiodła się", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Debug.WriteLine("Exception Message: " + ex.Message);
                Debug.WriteLine("Exception Source: " + ex.Source);
                Debug.WriteLine("Juxaposition: EditCell");
            }
            finally
            {
                dbTools.dbAgent.GetConnection().Close();

            }
        }
        public static Juxaposition GetJuxaposition_InfoOnly(string juxName)
        {
            Juxaposition juxaposition = null;
            string command = @"SELECT * FROM "+ NamesTypes.Juxtapositions_TABLE_NAME+" WHERE JuxName = @juxName";
            var query = new MySqlCommand(command, dbAgent.GetConnection());
            query.Parameters.AddWithValue("@juxName", juxName);
            try
            {
                dbAgent.GetConnection().Open();
                var reader = query.ExecuteReader();

                int id = 0;
                string rawColumns_SingleString = "", rawTableName = "";

                while (reader.Read())
                {
                    id = (int) reader["ID"];
                    rawTableName = reader["JuxName"].ToString();
                    rawColumns_SingleString = reader["Components"].ToString();
                }
                if (rawTableName == "" || rawTableName == null)
                {
                    return null;
                }
                juxaposition = new Juxaposition(rawTableName);

                var rawColumns = rawColumns_SingleString.Split('|');

                for (int i = 0; i < rawColumns.Length; i++)
                {
                    var izeroTName = rawColumns[i].Split('%');
                    
                    for(int j=1;j< izeroTName.Length;j++) // ignore j[0] <-- ParentTableName
                    {
                        var columnData = izeroTName[j].Split('#');
                        juxaposition.AddColumnInfoToJuxaposition(new JuxapositionColumnInfo(izeroTName[0],new ColumnInfo(
                        columnData[0],
                        NamesTypes.RawStringColumnTypePairs[columnData[1]]
                        )));
                    }
                    
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Nastąpił błąd połączenia z bazą danych. Jeśli problem będzie się powtrzał skontaktuj się z zarządcą bazy danych", "Błąd połączenia z bazą danych" + Environment.NewLine + ex.ErrorCode, MessageBoxButtons.OK, MessageBoxIcon.Error);

                Debug.WriteLine("Exception Message: " + ex.Message);
                Debug.WriteLine("Exception Error Code: " + ex.ErrorCode);
                Debug.WriteLine("Exception Source: " + ex.Source);
                Debug.WriteLine("Juxaposition: GetJuxaposition_InfoOnly");
            }
            catch (Exception ex)
            {

                MessageBox.Show("Wystąpił  błąd " + Environment.NewLine + ex.Message + "Operacja nie powiodła się", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Debug.WriteLine("Exception Message: " + ex.Message);
                Debug.WriteLine("Exception Source: " + ex.Source);
                Debug.WriteLine("Juxaposition: GetJuxaposition_InfoOnly");
            }
            finally
            {
                dbTools.dbAgent.GetConnection().Close();

            }
            return juxaposition;
        }

        public static  List<Juxaposition> GetAllJuxapositions_InfoOnly()
        {       
            List<Juxaposition> listOfJuxapositions = new List<Juxaposition>();
            string command = @"SELECT * FROM " + NamesTypes.Juxtapositions_TABLE_NAME;
            var query = new MySqlCommand(command, dbAgent.GetConnection());

            try
            {
                dbAgent.GetConnection().Open();
                var reader = query.ExecuteReader();
                int k = 0;
                int id = 0;
                string rawColumns_SingleString = "", rawTableName = "";
                while(reader.Read())
                {
                 
                    id = (int) reader["ID"];
                    rawTableName = reader["JuxName"].ToString();
                    rawColumns_SingleString = reader["Components"].ToString();
                    
                    if (rawTableName == "" || rawTableName == null|| rawColumns_SingleString== null || rawColumns_SingleString =="")
                    {
                        return null;
                    }
                    listOfJuxapositions.Add(new Juxaposition(rawTableName));

                    var rawColumns = rawColumns_SingleString.Split('|');

                    for (int i = 0; i < rawColumns.Length; i++)
                    {
                        var izeroTName = rawColumns[i].Split('%');

                        for (int j = 1; j < izeroTName.Length; j++) // ignore j[0] <-- ParentTableName
                        {
                            var columnData = izeroTName[j].Split('#');

                            listOfJuxapositions[k].AddColumnInfoToJuxaposition(new JuxapositionColumnInfo(izeroTName[0], new ColumnInfo(
                            columnData[0],
                            NamesTypes.RawStringColumnTypePairs[columnData[1]]
                            )));
                        }
                      
                    }
                    k++;
                } // end of While
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Nastąpił błąd połączenia z bazą danych. Jeśli problem będzie się powtrzał skontaktuj się z zarządcą bazy danych", "Błąd połączenia z bazą danych" + Environment.NewLine + ex.ErrorCode, MessageBoxButtons.OK, MessageBoxIcon.Error);

                Debug.WriteLine("Exception Message: " + ex.Message);
                Debug.WriteLine("Exception Error Code: " + ex.ErrorCode);
                Debug.WriteLine("Exception Source: " + ex.Source);
                Debug.WriteLine("Juxaposition: GetAllJuxapositions_InfoOnly");
            }
            catch (Exception ex)
            {

                MessageBox.Show("Wystąpił  błąd " + Environment.NewLine + ex.Message + "Operacja nie powiodła się", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Debug.WriteLine("Exception Message: " + ex.Message);
                Debug.WriteLine("Exception Source: " + ex.Source);
                Debug.WriteLine("Juxaposition: GetAllJuxapositions_InfoOnly");
            }
            finally
            {
                dbTools.dbAgent.GetConnection().Close();
            }
            return listOfJuxapositions;
        }

        public static JuxapositionColumn GetColumnFromUDT(string tableName,ColumnInfo columnInfo)
        {
            
            List<CellContent> collection = new List<CellContent>();
            int rowInColumnCount = CustomTableHelper.GetRowCount(tableName);

            string command = string.Format(@"SELECT ID,{0} FROM {1}",columnInfo.Name, tableName); // Possible need to change to string.format style
            var query = new MySqlCommand(command, dbAgent.GetConnection());

            // Possible need to change to string.Format type

            //query.Parameters.AddWithValue("@columnName", columnInfo.Name);
            //query.Parameters.AddWithValue("@tableName", tableName);


            dbAgent.GetConnection().Open();
            try
            {
                int i = 0;
                var reader = query.ExecuteReader();
                collection = new List<CellContent>();
                while (reader.Read())
                {
                  //  collection = new List<CellContent>();
                    // for every columns in row
                  
                        // To determine what action we need to do, we need to check for every column type.
                        switch (columnInfo.ColumnType)
                        {
                            case ColumnType.DataType:
                                DateTime date;
                                if (reader[columnInfo.Name].ToString().Contains("00.00.0000") || reader.IsDBNull(i))
                                    date = DateTime.Now;
                                else
                                    date = Convert.ToDateTime(reader[columnInfo.Name]); //date = (DateTime) reader[customTableInfo.ColumnInfos_Row[i].Name];
                                collection.Add(new CellContent(date, (int) reader["ID"]));
                                break;
                            case ColumnType.Description:
                                var descr = reader[columnInfo.Name].ToString();
                                collection.Add(new CellContent(descr, (int) reader["ID"]));
                                break;
                            case ColumnType.ShortText:
                                var shrtText = reader[columnInfo.Name].ToString();
                                collection.Add(new CellContent(shrtText, (int) reader["ID"]));
                                break;
                            case ColumnType.Integer:
                                var num = (int) reader[columnInfo.Name];
                                collection.Add(new CellContent(num, (int) reader["ID"]));
                                break;
                            case ColumnType.Float:
                                var num_float = (float) reader[columnInfo.Name];
                                collection.Add(new CellContent(num_float, (int) reader["ID"]));
                                break;

                            default:
                                throw new Exception("Custom Table Helper GetAllRowsFromCustomTable method, switch Error ");

                        }
                    i++;
                    
                   

                }
                return new JuxapositionColumn(tableName, columnInfo, collection);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Nastąpił błąd połączenia z bazą danych. Jeśli problem będzie się powtrzał skontaktuj się z zarządcą bazy danych", "Błąd połączenia z bazą danych" + Environment.NewLine + ex.ErrorCode, MessageBoxButtons.OK, MessageBoxIcon.Error);

                Debug.WriteLine("Exception Message: " + ex.Message);
                Debug.WriteLine("Exception Error Code: " + ex.ErrorCode);
                Debug.WriteLine("Exception Source: " + ex.Source);
                Debug.WriteLine("Juxaposition: GetColumnFromUDT");
            }
            catch (Exception ex)
            {

                MessageBox.Show("Wystąpił  błąd " + Environment.NewLine + ex.Message + "Operacja nie powiodła się", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Debug.WriteLine("Exception Message: " + ex.Message);
                Debug.WriteLine("Exception Source: " + ex.Source);
                Debug.WriteLine("Juxaposition: GetColumnFromUDT");
            }
            finally
            {
                dbTools.dbAgent.GetConnection().Close();

            }

            return null;
        }
    }
}
