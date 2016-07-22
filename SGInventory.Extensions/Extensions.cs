using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SGInventory.Enums;
using System.Linq.Expressions;
using SGInventory.Model;

namespace SGInventory.Extensions
{
    public static class Extensions
    {
        static Dictionary<int, string> _codeLetters;
        public static bool ValidateMaxLength(this string input, int maxLength)
        {
            return input.Length > maxLength ? false : true;
        }

        public static int GetLastIndex<T>(this List<T> list)
        {
            var retValue = 0;
            if (list.Count > 0)
            {
                retValue = list.Count - 1;
            }

            return retValue;
        }

        public static string GetCorrespondingSgiMonthCodeLetter(this DateTime dateTime)
        {
            return GetCorrespondingCodeLetter(dateTime.Month);
        }

        public static string GetCorrespondingSgYearCodeLetter(this DateTime dateTime)
        {
            return GetCorrespondingCodeLetter(dateTime.Year - 2000);
        }

        private static string GetCorrespondingCodeLetter(int periodValue)
        {
            _codeLetters = _codeLetters ?? GenerateCodeLetters();

            return _codeLetters[periodValue];
            
        }

        private static Dictionary<int, string> GenerateCodeLetters()
        {
            var returnValue = new Dictionary<int, string>();

            var values = Enum.GetValues(typeof(Years)).Cast<int>().ToList<int>();

            values.ForEach(value => returnValue[value]= Enum.GetName(typeof(Years), value));
            
            return returnValue;
        }
      
    }
}
