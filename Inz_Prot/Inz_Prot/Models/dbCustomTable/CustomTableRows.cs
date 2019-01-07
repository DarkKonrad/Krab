using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inz_Prot.Models.dbCustomTable
{
   public class CustomTableRows
    {
        List<List<CellContent>> tableRow;

     public CustomTableRows()
        {
            tableRow = new List<List<CellContent>>();
        }

        public List<List<CellContent>> Row { get => tableRow; private set => tableRow = value; }

        public void AddRow( List<CellContent> columnContent)
        {
            tableRow.Add(columnContent);
        }
    }
}
