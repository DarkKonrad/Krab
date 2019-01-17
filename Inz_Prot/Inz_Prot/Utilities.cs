using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inz_Prot
{

    /*
     * https://www.codeproject.com/articles/415732/reading-and-writing-csv-files-in-csharp
     */

    /// <summary>
    /// Class to store one CSV row
    /// </summary>
    public class CsvRow : List<string>
    {
        public string LineText { get; set; }
    }

    /// <summary>
    /// Class to write data to a CSV file
    /// </summary>
    public class CsvFileWriter : StreamWriter
    {
        public CsvFileWriter(Stream stream)
            : base(stream)
        {
        }

        public CsvFileWriter(string filename)
            : base(filename)
        {
        }

        /// <summary>
        /// Writes a single row to a CSV file.
        /// </summary>
        /// <param name="row">The row to be written</param>
        public void WriteRow(CsvRow row)
        {
            StringBuilder builder = new StringBuilder();
            bool firstColumn = true, firstVal=true;
            foreach (string value in row)
            {
                if (!firstColumn)
                if (value.IndexOfAny(new char[] { '"', ',' }) != -1)
                    builder.AppendFormat("\"{0}\"", value.Replace("\"", "\"\""));

                    else
                    {
                        if (firstVal==false)
                        {
                       
                            builder.Append(","); //
                        }
                            
                        builder.Append(value);
                        firstVal = false;
                    }
               firstColumn = false;

            }
            row.LineText = builder.ToString();
            WriteLine(row.LineText);
        }
    }


    public static class Utilities
    {
        public static void SaveToCSV_SaveDialogVersion(DataGridView datagridView)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "CSV files (*.CSV)|*.CSV|txt files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {

               FromDataGridToCSV(datagridView, saveFileDialog1.FileName);
            }

        }

        public static void FromDataGridToCSV(DataGridView dataGridView, string fileNameOrPath)
        {
            var csvWriter = new CsvFileWriter(fileNameOrPath);
            var headers = new CsvRow();
            int cellIndexToIgnore = -1;

            foreach(DataGridViewColumn column in dataGridView.Columns)
            {
                if (column.Name != "TableID" || column.HeaderText != "TableID")
                    headers.Add(column.HeaderText);
                else
                    cellIndexToIgnore = column.Index;
            }
            csvWriter.WriteRow(headers);

            foreach (DataGridViewRow row in dataGridView.Rows)
            {
               
                var rowToSave = new CsvRow();
                foreach(DataGridViewCell cell in row.Cells)
                {
                    if (cell.ColumnIndex != cellIndexToIgnore) // ! Warning 
                        if (cell.Value == null || cell.Value.ToString() =="")
                            rowToSave.Add("-");
                    else
                            rowToSave.Add(cell.Value.ToString());
                }
                csvWriter.WriteRow(rowToSave);
            }
            csvWriter.Close();
            csvWriter.Dispose();
        }


        public static bool isStringNumber(string str)
        {
         
            int result = 0;
            if (!Int32.TryParse(str, out result))
            {
                return false;
            }

            return true;
        }
        public static bool StringContainsSpecialChars(string str)
        {
            foreach (char c in str)
            {
                if (!(( c >= '0' && c <= '9' ) || ( c >= 'A' && c <= 'Z' ) || ( c >= 'a' && c <= 'z' ) || c == '_'))
                {
                    return true;
                }
                //else
                 //   return true;
                
            }
            return false;
        }

        public static string RemoveAllSpecialCharacters( string str)
        {
            StringBuilder sb = new StringBuilder();
            string cleared;
            foreach (char c in str)
            {
                if (( c >= '0' && c <= '9' ) || ( c >= 'A' && c <= 'Z' ) || ( c >= 'a' && c <= 'z' ) || c == '_')
                {
                    sb.Append(c);
                }
            }
           return cleared = sb.ToString();
            
        }
    }
}
