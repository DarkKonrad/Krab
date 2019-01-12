using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inz_Prot
{
   public static class Utilities
    {
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
