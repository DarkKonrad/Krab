using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inz_Prot.Models.dbCustomTable.Juxaposition
{
    public class Juxaposition
    {
        string name;
        List<JuxapositionColumn> juxapositionColumns;
        List<JuxapositionColumnInfo> juxapositionColumnInfos;
        public Juxaposition (string name)
        {
            this.name = name;
            juxapositionColumns = new List<JuxapositionColumn>();
            juxapositionColumnInfos = new List<JuxapositionColumnInfo>();
        }

        public bool HasValues { get
            {
                if (juxapositionColumns.Count == 0)
                    return false;
                else
                    return true;
            }
        }
        public bool HasInfos { get
            {
                if (juxapositionColumnInfos.Count == 0)
                    return false;
                else
                    return true;
            }
        }
        public List<JuxapositionColumn> JuxapositionColumns { get => juxapositionColumns;}
        public string Name { get => name;  }
        public List<JuxapositionColumnInfo> JuxapositionColumnInfos { get => juxapositionColumnInfos; set => juxapositionColumnInfos = value; }

        public void AddColumnToJuxaposition(JuxapositionColumn column)
        {
            juxapositionColumns.Add(column);
        }

        public void AddColumnInfoToJuxaposition ( JuxapositionColumnInfo columnInfo)
        {
            juxapositionColumnInfos.Add(columnInfo);
        }

        public string GetInfoJuxapositionString ()
        {
            string juxInfoString = "";

            for(int i = juxapositionColumns.Count -1; i>=0;i--)
            {
                if (i != 0)
                    juxInfoString += juxapositionColumns[i].ParentTableName + "%" + juxapositionColumns[i].ColumnInfo.Name + "#" + juxapositionColumns[i].ColumnInfo.Type_String + ( juxapositionColumns[i].ColumnInfo.TypeCapacity.HasValue ? "$" + juxapositionColumns[i].ColumnInfo.TypeCapacity.Value.ToString() : "" ) + "|";
                else
                    juxInfoString += juxapositionColumns[i].ParentTableName + "%" + juxapositionColumns[i].ColumnInfo.Name + "#" + juxapositionColumns[i].ColumnInfo.Type_String + ( juxapositionColumns[i].ColumnInfo.TypeCapacity.HasValue ? "$" + juxapositionColumns[i].ColumnInfo.TypeCapacity.Value.ToString() : "" );
            }

            return juxInfoString;
        }


    }
}
