using Autotask.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Autotask
{
    public static class EnumExtensions
    {
        public static string GetDescription(this Enum enumItem)
        {
            var descs = enumItem.GetType().GetField(enumItem.ToString()).GetCustomAttributes(typeof(DescriptionAttribute), false);

            return descs.HasValue() ? ((DescriptionAttribute)descs.First()).Description : "";
        }

        public static EnumEntry[] GetEnumEntries(Type enumType)
        {
            EnumEntry[] entries;
            
            var fields = enumType.GetFields(BindingFlags.Public | BindingFlags.Static);
            
            entries = new EnumEntry[fields.Length];
            
            for (int i = 0; i < fields.Length; i++)
            {
                var description = fields[i].GetCustomAttributes(typeof(DescriptionAttribute), false).OfType<DescriptionAttribute>().FirstOrDefault();

                entries[i] = new EnumEntry(fields[i].Name, Convert.ChangeType(fields[i].GetValue(null), Enum.GetUnderlyingType(enumType)), description.Description);
            }

            return entries;
        }
    }
}
