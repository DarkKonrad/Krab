using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inz_Prot.Models
{
  public class Qualification
    {
        string description;
        string name;
        int id;

        public Qualification(int id, string name, string description)
        {
            this.description = description;
            this.name = name;
            this.id = id;
        }

        public string Description { get => description; set => description = value; }
        public string Name { get => name; set => name = value; }
        public int ID { get => id; set => id = value; }


    }
}
