using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Autotask
{
    public static class ObjectExtensions
    {
        public static void CopyTo<T>(this T source, T destination, BindingFlags bindingAttr = BindingFlags.Public | BindingFlags.Instance)
        {
            if(source == null)
            {
                throw new ArgumentNullException("source");
            }
            if (destination == null)
            {
                throw new ArgumentNullException("destination");
            }

            var type = source.GetType();

            var properties = type.GetProperties(bindingAttr);

            foreach (var property in properties)
            {
                if (property.CanWrite)
                {
                    property.SetValue(destination, property.GetValue(source));
                }
            }
        }
    }
}
