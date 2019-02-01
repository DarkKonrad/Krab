using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inz_Prot.Models.dbCustomTable;
namespace Inz_Prot.dbHelpers
{
   public static  class NamesTypes
    {
        public static readonly string VARCHAR = "VARCHAR";
        public static readonly string INT = "INT";
        public static readonly string DATETYPE = "DATETIME";
   
        public static readonly string VARCHAR80 = "VARCHAR80";
        public static readonly string VARCHAR2048 = "VARCHAR2048";

        public static readonly int MAKS_DESCRIPTION_LENGHT = 2048;
        public static readonly int MAKS_SHORTTEXT_LENGHT = 80;

        public static readonly string CommonCustomTableName_POLISH = "Zbior Danych";
        public static readonly string CommonCustomTableName_POLISH_ADJECTIVE = "Zbiorów Danych";

        public static readonly string UserCustomTables_TABLE = "usertableinfo";
        public static readonly string Juxtapositions_TABLE_NAME = "juxtapositions";

        static Dictionary<string, ColumnType> stringColumnTypePairs;
        static Dictionary<string, ColumnType> rawStringColumnTypePairs;
    //    static Dictionary<ColumnType, string> columnTypeEnumToString;

        public static Dictionary<string, ColumnType> RawStringColumnTypePairs { get
            {
                if (stringColumnTypePairs == null)
                {
                    rawStringColumnTypePairs = new Dictionary<string, ColumnType>();
                    rawStringColumnTypePairs.Add("VARCHAR$80", ColumnType.ShortText);
                    rawStringColumnTypePairs.Add("VARCHAR$2048", ColumnType.Description);
                    rawStringColumnTypePairs.Add("INT", ColumnType.Integer);
                    rawStringColumnTypePairs.Add("DATETIME", ColumnType.DataType); //DATATYPE
                    rawStringColumnTypePairs.Add("FLOAT", ColumnType.Float);

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
                stringColumnTypePairs.Add("VARCHAR80", ColumnType.ShortText);
                stringColumnTypePairs.Add("VARCHAR2048", ColumnType.Description);
                stringColumnTypePairs.Add("INT", ColumnType.Integer);
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
                rawStringColumnTypePairs.Add("VARCHAR$80", ColumnType.ShortText);
                rawStringColumnTypePairs.Add("VARCHAR$2048", ColumnType.Description);
                rawStringColumnTypePairs.Add("INT", ColumnType.Integer);
                rawStringColumnTypePairs.Add("DATETIME", ColumnType.DataType); // DATATYPE

                return rawStringColumnTypePairs;
            }
            else
                return rawStringColumnTypePairs;
        }
    }
}
