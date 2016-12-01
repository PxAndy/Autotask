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
    /// 表示刷新的任务节点
    /// </summary>
    public class RefreshTaskNode : TaskNode
    {
        public RefreshTaskNode()
            :base(TaskNodeMode.RefreshPage)
        {

        }

        public override bool Run(WebBrowser browser, Action<ITaskNode> onRunning = null, Action<ITaskNode, bool> onRunned = null)
        {
            onRunning?.Invoke(this);

            browser.Refresh();

            var result = SpinWait.SpinUntil(() =>
            {
                return !browser.IsDisposed && (bool)browser.Invoke(new Func<bool>(() =>
                {
                    return browser.Document != null && browser.Document.Body != null && browser.ReadyState > WebBrowserReadyState.Loaded;
                }));
            }, 10000);

            onRunned?.Invoke(this, result);
            
            return result;
        }

        public override string ToString()
        {
            return "刷新";
        }
    }
}
