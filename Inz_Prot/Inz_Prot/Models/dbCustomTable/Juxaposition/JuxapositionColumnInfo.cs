using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inz_Prot.Models.dbCustomTable.Juxaposition
{
   public class JuxapositionColumnInfo
    {
        ColumnInfo columnInfo;
        List<CellContent> columnContent;
        string parentTableName;
        public JuxapositionColumnInfo(string parentTableName, ColumnInfo columnInfo)
        {
            this.columnInfo = columnInfo;
            this.parentTableName = parentTableName;
        }

        public ColumnInfo ColumnInfo { get => columnInfo; }
        public string ParentTableName { get => parentTableName; }

    }
}
