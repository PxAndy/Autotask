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

        public override bool Run(WebBrowser browser, Action<ITaskNode, bool> callback = null)
        {
            browser.Navigate(Url);
            
            var result = SpinWait.SpinUntil(() => 
            {
                return (bool)browser.Invoke(new Func<bool>(() => 
                {
                    return browser.Url != null && browser.Url.Authority == new Uri(Url).Authority && browser.Document != null && browser.Document.Body != null && browser.ReadyState > WebBrowserReadyState.Loaded;
                }));
            }, 10000);
            
            return result;
        }

        public override string ToString()
        {
            return "跳转到 " + Url;
        }
    }
}
