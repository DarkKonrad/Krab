using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inz_Prot.Models.dbCustomTable
{
  public class ColumnContent
    {
        DateTime? dateTime ;
        string shortText, description;
        int? numeric;

     private  object obj;
     private  TypeCode code;
        private ColumnContent(object obj, TypeCode code)
        {
            this.obj = obj;
            this.code = code;
        }
        private object Obj { get => obj; set => obj = value; }

        private ColumnContent() { }
        public ColumnContent(DateTime dateTime)
        {
            this.dateTime = dateTime;
           
        }
        public ColumnContent(string text)
        {
            if (text.Length <= 80)
            {
                shortText = text;
            }
            else 
            {
                description = text;
            }
        }

        public ColumnContent(int num)
        {
            numeric = num;
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
