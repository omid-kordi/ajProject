using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using ajWebSite.Common.Enums;

namespace ajWebSite.Common.Helpers
{
    public static class EnumHelper
    { 
        public static string ToDescription(this Enum value)
        {
            if (value == null)
                return "";
            var d = value.GetType().GetField(value.ToString());
            if (d == null) return "";
            var attributes = (DescriptionAttribute[])d.GetCustomAttributes(typeof(DescriptionAttribute), false);
            return attributes.Length > 0 ? attributes[0].Description : value.ToString();
        }

        public static Dictionary<int, string> ToDic(this Type enumType)
        {
            return (from Enum e in Enum.GetValues(enumType)
                select new { Value = Convert.ToInt32(e), Title = e.ToDescription() }).ToDictionary(x => x.Value, x => x.Title);
        }

        public static Dictionary<int, string> GetByName(string enumName)
        {

            var namespace_ = typeof(PersonType).Namespace;
            Type type = Type.GetType(namespace_ + "." + enumName);

            var values = Enum.GetValues(type);
            var items = (from Enum value in values select value).ToDictionary(v => Convert.ToInt32(v),
                v => v.ToDescription());

            return items;

        }
    }
}
