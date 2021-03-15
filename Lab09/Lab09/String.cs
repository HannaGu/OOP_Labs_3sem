using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab09
{
    static class String
    {
        public static string DeleteDrops(this string str)
        {
            string newString = "";
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == '.' || str[i] == ',') continue;
                newString += str[i];
            }
            return newString;
        }

        public static string AddStr(this string str)
        {
            string newString = "." + str;
            return newString;
        }
        public static string Up(this string str)
        {
            string newString = "";
            for (int i = 0; i < str.Length; i++) newString += str[i].ToString().ToUpper();

            return newString;
        }
        public static string DeleteSpaces(this string str)
        {
            string newString = "";
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == ' ') continue;
                newString += str[i];
            }
            return newString;
        }
        public static string Down(this string str)
        {
            string newString = "";
            for (int i = 0; i < str.Length; i++) newString += str[i].ToString().ToLower();

            return newString;
        }
    }
}
