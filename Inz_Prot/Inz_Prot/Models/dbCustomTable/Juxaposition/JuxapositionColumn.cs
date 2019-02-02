using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inz_Prot.Models.dbCustomTable.Juxaposition
{
    public class JuxapositionColumn
    {
        ColumnInfo columnInfo;
        List<CellContent> columnContent;
        string parentTableName; 
        public JuxapositionColumn(string parentTableName,ColumnInfo columnInfo,List<CellContent> cellContents)
        {
            this.columnInfo = columnInfo;
            this.parentTableName = parentTableName;
            this.columnContent = cellContents;
        }

        public int Length { get => columnContent.Count; }
        public ColumnInfo ColumnInfo { get => columnInfo; }
        public List<CellContent> ColumnContent { get => columnContent; }
        public string ParentTableName { get => parentTableName; }

        //    public static JuxapositionColumn GetJuxapositionColumn()
    }
}
