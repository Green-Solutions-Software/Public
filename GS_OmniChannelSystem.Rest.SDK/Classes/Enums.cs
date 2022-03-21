using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace GS.OmniChannelSystem.Rest.SDK.Classes
{
    public class Enums
    {
        public static string Description(object value)
        {
            return Description(value.GetType(), value);
        }

        public static string Description(Type enumType, object value)
        {
            if (enumType == null || !enumType.IsEnum || value == null)
                return null;

            FieldInfo fi = value.GetType().GetField(value.ToString());
            if (fi == null)
                return Convert.ToString(value);

            DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
            if (attributes.Length > 0)
            {
                return attributes[0].Description;
            }

            return value.ToString();
        }
    }
}
