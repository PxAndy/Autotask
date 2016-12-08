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
    /// 表示等待的任务节点
    /// </summary>
    public class WaitTaskNode : TaskNode
    {
        public WaitTaskNode()
            : this(1000)
        {
            
        }

        public WaitTaskNode(int milliseconds)
            : base(TaskNodeMode.Wait)
        {
            Milliseconds = milliseconds;
        }

        private int _mlliseconds;

        /// <summary>
        /// 等待的毫秒数，默认 1000 毫秒。
        /// </summary>
        public int Milliseconds
        {
            get
            {
                return _mlliseconds;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("等待的毫秒数不能小于 0。");
                }

                _mlliseconds = value;
            }
        }
        
        public override bool Run(WebBrowser browser, Action<ITaskNode> onRunning = null, Action<ITaskNode, bool> onRunned = null)
        {
            onRunning?.Invoke(this);

            SpinWait.SpinUntil(() => { return false; }, Milliseconds);

            onRunned?.Invoke(this, true);
            
            return true;
        }

        public override string ToString()
        {
            return "等待 " + Milliseconds + " 毫秒。";
        }
    }
}
