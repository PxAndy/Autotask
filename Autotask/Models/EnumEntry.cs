using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autotask.Models
{
    /// <summary>
    /// 枚举项
    /// </summary>
    public class EnumEntry
    {
        #region 构造方法

        public EnumEntry()
        {

        }


        public EnumEntry(string name, object value, string description)
        {
            Name = name;
            Value = value;
            Description = description;
        }

        #endregion

        #region 公共属性

        /// <summary>
        /// 枚举项名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 枚举项值
        /// </summary>
        public object Value { get; set; }

        /// <summary>
        /// 枚举项说明
        /// </summary>
        public string Description { get; set; }

        #endregion
    }
}
