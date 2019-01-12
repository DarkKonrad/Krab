using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inz_Prot.Models.dbCustomTable
{
    public class RowInfo : TableInfo
    {
        public RowInfo(string tableName) : base(tableName) { }

        [Obsolete("This is not supported in this class.", true)]
        private new string TableName { get; set; }

        public string RowName { get => tableName; set => tableName = value; }
       

    }
}
