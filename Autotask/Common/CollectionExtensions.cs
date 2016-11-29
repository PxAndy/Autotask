using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autotask
{
    public static class CollectionExtensions
    {
        public static bool HasValue<T>(this IEnumerable<T> enums)
        {
            return enums != null && enums.Any();
        }
    }
}
