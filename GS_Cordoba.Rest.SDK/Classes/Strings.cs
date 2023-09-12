using System;
using System.Collections.Generic;
using System.Text;

namespace GS.Cordoba.Rest.SDK.Classes
{
    public class Strings
    {
        public static string strCombine(string s1, string s2, string divider)
        {
            StringBuilder sb = new StringBuilder();
            if (string.IsNullOrEmpty(s1)) sb.Append(s2);
            else if (string.IsNullOrEmpty(s2)) sb.Append(s1);
            else sb.Append(s1 + divider + s2);

            return sb.ToString();
        }

        public static string ListStringCombine<T>(IEnumerable<T> list, Func<T, string> toString, string divider)
        {
            string s = null;
            if (list == null)
                return null;

            foreach (T item in list)
                s = strCombine(s, toString(item), divider);

            return s;
        }

        public static string Range(string from, string to, string extension, bool lt = false)
        {
            if (string.IsNullOrEmpty(from) && string.IsNullOrEmpty(to))
                return null;

            StringBuilder sb = new StringBuilder();
            if (lt && !string.IsNullOrEmpty(from) && string.IsNullOrEmpty(to))
            {
                sb.Append("> ");
            }
            sb.Append(from);
            if (!string.IsNullOrEmpty(to) && (from != to))
            {
                sb.Append(" - " + to);
            }
            if (!string.IsNullOrEmpty(extension))
                sb.Append(" " + extension);
            return sb.ToString();
        }
    }
}
