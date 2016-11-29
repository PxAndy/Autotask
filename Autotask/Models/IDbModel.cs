using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autotask.Models
{
    /// <summary>
    /// 数据模型
    /// </summary>
    public interface IDbModel
    {
        Guid Id { get; set; }
    }
}
