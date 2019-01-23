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
        int? _integer;
        float? _float;
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
        
        public CellContent(float num_float,int rowID)
        {
            _float = num_float;
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
            _integer = num;
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
                else if (_integer != null)
                {
                    return _integer;
                }
                else if(_float !=null)
                {
                    return _float;
                }
                throw new Exception("ColumnContent Exception. Type of Data Error. See Value Getter");
            }
        }
        /// <summary>
        /// Returns ID of row where cell belong
        /// </summary>
        public int ID { get => id; private set => id = value; }

        public new TypeCode GetType()// !new
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
            else if (_integer != null)
            {
                return TypeCode.Int32;
            }
            else if(_float != null)
            {
                return TypeCode.Double;
            }
            throw new Exception("ColumnContent Exception. Type of Data Error");
        }
    }
}
