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

        public override bool Run(WebBrowser browser, Action<ITaskNode, bool> callback = null)
        {
            if (!CanRun(browser))
            {
                return false;
            }

            var el = GetElement(browser);

            el.Focus();

            return true;
        }

        public override string ToString()
        {
            return "聚焦" + Element.ToString();
        }
    }
}
