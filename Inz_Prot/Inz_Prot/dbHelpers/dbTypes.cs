using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inz_Prot.Models.dbCustomTable;
namespace Inz_Prot.dbHelpers
{
   public static  class dbTypes
    {
        public static string VARCHAR = "VARCHAR";
        public static string INT = "INT";
        public static string DATETYPE = "DATETIME";

        public static string VARCHAR80 = "VARCHAR80";
        public static string VARCHAR2048 = "VARCHAR2048";

        static Dictionary<string, ColumnType> stringColumnTypePairs;
        static Dictionary<string, ColumnType> rawStringColumnTypePairs;
    //    static Dictionary<ColumnType, string> columnTypeEnumToString;

        public static Dictionary<string, ColumnType> RawStringColumnTypePairs { get
            {
                if (stringColumnTypePairs == null)
                {
                    rawStringColumnTypePairs = new Dictionary<string, ColumnType>();
                    rawStringColumnTypePairs.Add("VARCHAR$80", ColumnType.shortText);
                    rawStringColumnTypePairs.Add("VARCHAR$2048", ColumnType.Description);
                    rawStringColumnTypePairs.Add("INT", ColumnType.Numeric);
                    rawStringColumnTypePairs.Add("DATETIME", ColumnType.DataType); //DATATYPE

                    return rawStringColumnTypePairs;
                }
                else
                    return rawStringColumnTypePairs;
            }
        }
        ///// <summary>
        ///// Converts enum ColumnType to string-type data information e.g. VARCHAR,INT 
        ///// </summary>
        //public static Dictionary<ColumnType, string> ColumnTypeEnumToString { get {
        //{
        //     if(columnTypeEnumToString == null)
        //            {
        //                columnTypeEnumToString = new Dictionary<ColumnType, string>();                    
        //                columnTypeEnumToString.Add("VARCHAR$80", ColumnType.shortText);
        //                columnTypeEnumToString.Add("VARCHAR$2048", ColumnType.Description);
        //                columnTypeEnumToString.Add("INT", ColumnType.Numeric);
        //                columnTypeEnumToString.Add("DATETIME", ColumnType.DataType); //DATATYPE
        //            }
        //}

        public static Dictionary<string,ColumnType> GetStringColumnTypePairs()
        {
            if (stringColumnTypePairs == null)
            {
                stringColumnTypePairs = new Dictionary<string, ColumnType>();
                stringColumnTypePairs.Add("VARCHAR80", ColumnType.shortText);
                stringColumnTypePairs.Add("VARCHAR2048", ColumnType.Description);
                stringColumnTypePairs.Add("INT", ColumnType.Numeric);
                stringColumnTypePairs.Add("DATATYPE", ColumnType.DataType);

                return stringColumnTypePairs;
            }
            else
                return stringColumnTypePairs;
        }
        private static Dictionary<string, ColumnType> GetRawStringColumnTypePairs()
        {
            if (stringColumnTypePairs == null)
            {
                rawStringColumnTypePairs = new Dictionary<string, ColumnType>();
                rawStringColumnTypePairs.Add("VARCHAR$80", ColumnType.shortText);
                rawStringColumnTypePairs.Add("VARCHAR$2048", ColumnType.Description);
                rawStringColumnTypePairs.Add("INT", ColumnType.Numeric);
                rawStringColumnTypePairs.Add("DATETIME", ColumnType.DataType); // DATATYPE

                return rawStringColumnTypePairs;
            }
            else
                return rawStringColumnTypePairs;
        }
    }
}
