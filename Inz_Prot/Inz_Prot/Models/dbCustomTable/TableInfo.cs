﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inz_Prot.Models.dbCustomTable
{
   public class TableInfo
    {
        List<ColumnInfo> columns;
        protected string tableName;

        public string TableName { get => tableName; set => tableName = value; }
        public int Count { get => columns.Count; }
        // Cell Content ? 
        public List<ColumnInfo> ColumnInfos_Row { get => columns; }
        public static string Separator { get => separator; set => separator = value; }

        private static string separator = "|";

        private string GetCommandString()
        {
            string command = "CREATE TABLE " + tableName + " (";
            

         //   var cols = columns.ToArray();
            
            //                        i>= ??
            for (int i =columns.Count-1 ; i>=0;i--)
            {
                if(i != 0)
                {
                    command += columns[i].GetColumnString() + ",";
                }
              else
                {
                    command += columns[i].GetColumnString();
                }
            }

            command += ")";

            return command;
        }

        public MySql.Data.MySqlClient.MySqlCommand GetQuery()
        {
            string placeholder = string.Format(@"CREATE TABLE {0} ( ID int NOT NULL AUTO_INCREMENT,"
                , tableName);

            for(int i = columns.Count-1; i>=0; i--)
            {
                if (i != 0)
                    placeholder += string.Format("{0} {1}, ",columns[i].Name, columns[i].GetColumnTypeString());
                else
                    placeholder += string.Format("{0} {1}, PRIMARY KEY (ID) )", columns[i].Name, columns[i].GetColumnTypeString());
               
            }
            var query = new MySql.Data.MySqlClient.MySqlCommand(placeholder);

            return query;

        }

        public List<string> ColumnsNames_String()
        {
            List<string> list = new List<string>();

            foreach(ColumnInfo column in columns)
            {
                list.Add(column.Name);
            }

            return list;
        }

        private TableInfo() { }
        public TableInfo(string name)
        {
            columns = new List<ColumnInfo>();
            tableName = name;

        }
        public void Add(ColumnInfo columnInfo)
        {
            columns.Add(columnInfo);

        }
        public void Add(List<ColumnInfo> columnInfos)
        {
            this.columns = columnInfos;
        }
        public void Clear()
        {
            columns.Clear();
        }
   
        private string GetColumnsTypeString()
        {
            string columnsType = "";

            for (int i = columns.Count - 1; i >= 0; i--)
            {
                if (i != 0)
                    columnsType += columns[i].Type_String + ( columns[i].TypeCapacity.HasValue ? "$" + columns[i].TypeCapacity.Value.ToString() : "" ) + "|";
                else
                    columnsType += columns[i].Type_String + ( columns[i].TypeCapacity.HasValue ? "$" + columns[i].TypeCapacity.Value.ToString() : "" );
            }

            return columnsType;
        }


        public string GetColumnsTypeAndNameString()
        {
            string columnsType = "";

            for (int i = columns.Count - 1; i >= 0; i--)
            {
                if (i != 0)
                    columnsType += columns[i].Name+"#"+ columns[i].Type_String + ( columns[i].TypeCapacity.HasValue ? "$" + columns[i].TypeCapacity.Value.ToString() : "" ) + "|";
                else
                    columnsType += columns[i].Name+"#" +columns[i].Type_String + ( columns[i].TypeCapacity.HasValue ? "$" + columns[i].TypeCapacity.Value.ToString() : "" );
            }

            return columnsType;
        }

    }
}
