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

                if (el.TagName == "INPUT")
                {
                    el.SetAttribute("value", Text);
                }
                else if (el.TagName == "TEXTAREA")
                {
                    el.InnerText = Text;
                }

                result = true;
            }

            onRunned?.Invoke(this, result);
            
            return result;
        }

        public override string ToString()
        {
            return "输入\"" + Text + "\"到" + Element.ToString();
        }
    }
}
