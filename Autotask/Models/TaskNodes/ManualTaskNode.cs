using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Autotask.Models
{
    /// <summary>
    /// 表示手动处理的任务节点
    /// </summary>
    public class ManualTaskNode : TaskNode
    {
        public ManualTaskNode()
            : base(TaskNodeMode.Manual)
        {
            
        }

        public bool IsFinished { get; set; }
        
        public override bool Run(WebBrowser browser, Action<ITaskNode> onRunning = null, Action<ITaskNode, bool> onRunned = null)
        {
            onRunning?.Invoke(this);

            SpinWait.SpinUntil(() => { return IsFinished; }, -1);

            onRunned?.Invoke(this, true);
            
            return true;
        }

        public override string ToString()
        {
            return "人工操作";
        }
    }
}
