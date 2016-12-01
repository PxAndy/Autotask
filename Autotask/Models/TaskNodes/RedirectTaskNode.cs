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
    /// 表示跳转的任务节点
    /// </summary>
    public class RedirectTaskNode : TaskNode
    {
        public string Url { get; set; }

        public RedirectTaskNode(string url)
            : base(TaskNodeMode.RedirectPage)
        {
            Url = url;
        }

        public override bool Run(WebBrowser browser, Action<ITaskNode> onRunning = null, Action<ITaskNode, bool> onRunned = null)
        {
            onRunning?.Invoke(this);

            browser.Navigate(Url);
            
            var result = SpinWait.SpinUntil(() => 
            {
                return !browser.IsDisposed && (bool)browser.Invoke(new Func<bool>(() => 
                {
                    return browser.Url != null && browser.Url.Authority == new Uri(Url).Authority && browser.Document != null && browser.Document.Body != null && browser.ReadyState > WebBrowserReadyState.Loaded;
                }));
            }, 10000);

            onRunned?.Invoke(this, result);
            
            return result;
        }

        public override string ToString()
        {
            return "跳转到 " + Url;
        }
    }
}
