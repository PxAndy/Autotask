using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Autotask.Models
{
    /// <summary>
    /// 表示点击的任务节点
    /// </summary>
    public class ClickTaskNode : ElementTaskNodeBase
    {
        public ClickTaskNode(TaskElement element)
            :base(TaskNodeMode.ClickElement, element)
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

                el.InvokeMember("click");

                result = true;
            }

            onRunned?.Invoke(this, result);
            
            return result;
        }

        public override string ToString()
        {
            return "点击" + Element.ToString();
        }
    }
}
