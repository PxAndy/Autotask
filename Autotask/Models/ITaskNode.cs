using System;
using System.Windows.Forms;

namespace Autotask.Models
{
    /// <summary>
    /// 任务节点
    /// </summary>
    public interface ITaskNode
    {
        #region 公共属性

        Guid Id { get; }
        TaskNodeMode Mode { get; set; }

        bool IsRequired { get; set; }
        
        #endregion

        #region 公共方法

        /// <summary>
        /// 验证是否可执行。
        /// </summary>
        /// <param name="browser"></param>
        /// <returns></returns>
        bool CanRun(WebBrowser browser);

        /// <summary>
        /// 执行
        /// </summary>
        /// <param name="browser"></param>
        bool Run(WebBrowser browser, Action<ITaskNode> onRunning = null, Action<ITaskNode, bool> onRunned = null);

        #endregion
    }
}