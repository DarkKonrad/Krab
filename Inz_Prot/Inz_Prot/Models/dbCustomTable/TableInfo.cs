using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inz_Prot.Models.dbCustomTable
{
   public class TableInfo
    {
        List<ColumnInfo> columns;
        int count;
        string TableName;

        private TableInfo() { }
        public TableInfo(string name)
        {
            columns = new List<ColumnInfo>();
            count = 0;
            TableName = name;

        }
        public void Add(ColumnInfo columnInfo)
        {
            columns.Add(columnInfo);
            count++;
        }
        public void Clear()
        {
            columns.Clear();
            count = 0;
        }
        public string GetTableName()
        {
            return TableName;
        }

        public List<ColumnInfo> GetColumnInfos()
        {
            return columns;
        }
    }
}
