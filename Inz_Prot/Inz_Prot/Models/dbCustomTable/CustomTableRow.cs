using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inz_Prot.Models.dbCustomTable
{
   public class CustomTableRows
    {
        List<List<ColumnContent>> tableRow;

     public CustomTableRows()
        {
            tableRow = new List<List<ColumnContent>>();
        }

        public List<List<ColumnContent>> Row { get => tableRow; private set => tableRow = value; }

        public void AddRow( List<ColumnContent> columnContent)
        {
            tableRow.Add(columnContent);
        }
    }
}
