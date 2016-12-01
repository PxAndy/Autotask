using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Autotask.Models
{
    /// <summary>
    /// 表示聚焦的任务节点
    /// </summary>
    public class FocusTaskNode : ElementTaskNodeBase
    {
        public FocusTaskNode(TaskElement element)
            :base(TaskNodeMode.FocusElement, element)
        {

        }

        public override bool Run(WebBrowser browser, Action<ITaskNode> onRunning = null, Action<ITaskNode, bool> onRunned = null)
        {
            onRunning?.Invoke(this);

            var result = true;

            if (!CanRun(browser))
            {
                result = false;
            }
            else
            {
                var el = GetElement(browser);

                el.Focus();

                result = true;
            }

            onRunned?.Invoke(this, result);
            
            return result;
        }

        public override string ToString()
        {
            return "聚焦" + Element.ToString();
        }
    }
}
