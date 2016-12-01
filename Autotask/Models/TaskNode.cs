using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Autotask.Models
{
    /// <summary>
    /// 任务节点
    /// </summary>
    public class TaskNode : ITaskNode
    {
        #region 公共属性

        public Guid Id { get; private set; }

        public TaskNodeMode Mode { get; set; }

        /// <summary>
        /// 是否必须
        /// </summary>
        public bool IsRequired { get; set; } = true;
        
        #endregion

        #region 构造方法

        public TaskNode()
        {
            Id = Guid.NewGuid();
        }

        public TaskNode(TaskNodeMode mode)
        {
            Id = Guid.NewGuid();
            Mode = mode;
        }

        #endregion

        #region 公共方法

        /// <summary>
        /// 验证是否可执行。
        /// </summary>
        /// <param name="browser"></param>
        /// <returns></returns>
        public virtual bool CanRun(WebBrowser browser)
        {
            return true;
        }

        /// <summary>
        /// 执行
        /// </summary>
        /// <param name="browser"></param>
        public virtual bool Run(WebBrowser browser, Action<ITaskNode> onRunning = null, Action<ITaskNode, bool> onRunned = null)
        {
            return true;
        }

        #endregion
    }
}
