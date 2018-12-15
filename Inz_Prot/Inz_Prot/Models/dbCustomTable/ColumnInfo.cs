using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inz_Prot.Models.dbCustomTable
{
  public  class ColumnInfo
    {
        string name, type;

        public ColumnInfo(string name, string type)
        {
            this.name = name;
            this.type = type;
        }

        public string Name { get => name; set => name = value; }
        public string Type { get => type; set => type = value; }
    }
}
