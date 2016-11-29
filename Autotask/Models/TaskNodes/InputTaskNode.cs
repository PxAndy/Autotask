using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Autotask.Models
{
    /// <summary>
    /// 表示输入的任务节点
    /// </summary>
    public class InputTaskNode : ElementTaskNodeBase
    {
        public string Text { get; set; }

        public InputTaskNode(TaskElement element, string text)
            :base(TaskNodeMode.InputElement, element)
        {
            Text = text;
        }

        public override bool Run(WebBrowser browser, Action<ITaskNode, bool> callback = null)
        {
            if (!CanRun(browser))
            {
                return false;
            }

            var el = GetElement(browser);

            if (el.TagName == "INPUT")
            {
                el.SetAttribute("value", Text);
            }
            else if (el.TagName == "TEXTAREA")
            {
                el.InnerText = Text;
            }

            return true;
        }

        public override string ToString()
        {
            return "输入\"" + Text + "\"到" + Element.ToString();
        }
    }
}
