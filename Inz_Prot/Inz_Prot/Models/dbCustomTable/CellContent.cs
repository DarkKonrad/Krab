using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inz_Prot.Models.dbCustomTable
{
  public class CellContent
    {
        DateTime? dateTime ;
        string shortText, description;
        int? numeric;
        int id;
     private  object obj;
     private  TypeCode code;
        private CellContent(object obj, TypeCode code)
        {
            this.obj = obj;
            this.code = code;
        }
        private object Obj { get => obj; set => obj = value; }

        private CellContent() { }
     
        public CellContent(DateTime dateTime,int rowID)
        {
            this.dateTime = dateTime;
            id = rowID;
        }
        
       

        public CellContent(string text,int rowID)
        {
            if (text.Length <= 80)
            {
                shortText = text;
            }
            else
            {
                description = text;
            }
            id = rowID;
        }

        public CellContent(int num,int rowID)
        {
            numeric = num;
            id = rowID;
        }

       public object Value { get
            {
                if (dateTime != null)
                {
                    return dateTime;
                }
                else if (shortText != null && shortText != "")
                {
                    return shortText;
                }
                else if (description != null && description != "")
                {
                    return description;
                }
                else if (numeric != null)
                {
                    return numeric;
                }
                throw new Exception("ColumnContent Exception. Type of Data Error. See Value Getter");
            }
        }
        /// <summary>
        /// Returns ID of row where cell belong
        /// </summary>
        public int ID { get => id; private set => id = value; }

        public TypeCode GetType()
        {
            if (dateTime != null)
            {
                return TypeCode.DateTime;
            }
            else if (shortText != null && shortText != "")
            {   //necessary to make difference between shortText and description
                return TypeCode.Char;
            }
            else if (description != null && description != "")
            {
                return TypeCode.String;
            }
            else if (numeric != null)
            {
                return TypeCode.Int32;
            }

            throw new Exception("ColumnContent Exception. Type of Data Error");
        }
    }
}
