using System.Text.RegularExpressions;
using System;
namespace LP_Lab09
{
    class StringEditor
    {
        public static string RemovePunctuation(string str)
        {
            return Regex.Replace(str, "[.,;:]", string.Empty);
        }

        public static string RemoveSpaces(string str)
        {
            return str.Replace(" ", string.Empty);
        }

        public static string InsertFromSymbol(string str1,string str2,char symb)
        {

            return str1.Insert(str1.IndexOf(symb)+1,str2);
        }

        public static string ToLower(string str)
        {
            return str.ToLower();
        }

        public static string CreateTitle(string str)
        { 
           str = str.PadLeft(str.Length+5, '*');
           return str.PadRight(str.Length+5, '*');
        }
        
    }
}