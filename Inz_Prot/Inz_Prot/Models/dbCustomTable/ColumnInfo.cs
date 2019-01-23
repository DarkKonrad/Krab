using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inz_Prot.Models.dbCustomTable
{
    public class InvalidColumnTypeException :  Exception
    {
        string message;
       public InvalidColumnTypeException() : base()
        {
            message = "Probably you forgrot to add implementation for new ColumnType enum in ColumnInfo" + Environment.NewLine + base.Message;
        }

       override public string Message{ get => message;}
    }
    public enum ColumnType
    {
        ShortText,
        Description,
        Integer,
        DataType,
        Float
    }
    public  class ColumnInfo
    {
        string name, type;
        int? typeCapacity;
        ColumnType columnT;
   


        private ColumnInfo() { }
        private ColumnInfo(string name, string type)
        {
            this.name = name;
            this.type = type;
        }
        public ColumnInfo(string name,ColumnType type)
        {
            this.name = name;
            this.columnT = type;
            switch (type)
            {
                case ColumnType.Description:
                    this.type = "VARCHAR";
                    this.typeCapacity = 2048;
                    break;

                case ColumnType.ShortText:
                    this.type = "VARCHAR";
                    this.typeCapacity = 80;
                    break;

                case ColumnType.Integer:
                    this.type = "INT";
                    this.typeCapacity = null;
                    break;

                case ColumnType.DataType:
                    this.type = "DATETIME";
                    this.typeCapacity = null;
                    break;

                case ColumnType.Float:
                    this.type = "FLOAT";
                    this.typeCapacity = null;
                    break;

                 default: throw new InvalidColumnTypeException();
                    
                    
            }
            
        }

        public string GetColumnString()
        {
            string command;

            if(TypeCapacity.HasValue)
            {
                command = name + " " + type + "(" +typeCapacity.Value.ToString() + ")";
            }
            else
            {
                command = name + " " + type;
            }

            return command;
        }

        public string GetColumnTypeString()
        {
          
            if(typeCapacity.HasValue)
            {
              return this.type + "(" + typeCapacity.ToString() + ")";
            }
            

            return type;
        }
        public string Name { get => name; set => name = value; }
        /// <summary>
        /// Deprecated. Use ColumnType.
        /// </summary>
        public string Type_String { get => type; set => type = value; }
        public ColumnType ColumnType { get => columnT; set => columnT = value; }
        public int? TypeCapacity { get => typeCapacity; set => typeCapacity = value; }
    }
}
