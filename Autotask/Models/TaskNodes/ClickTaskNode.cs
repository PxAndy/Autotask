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

        public override bool Run(WebBrowser browser, Action<ITaskNode, bool> callback = null)
        {
            if (!CanRun(browser))
            {
                callback?.Invoke(this, false);
                return false;
            }

            var el = GetElement(browser);

            el.InvokeMember("click");

            callback?.Invoke(this, true);

            return true;
        }

        public override string ToString()
        {
            return "点击" + Element.ToString();
        }
    }
}
