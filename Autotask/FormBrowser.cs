using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Autotask
{
    public partial class FormBrowser : Form
    {
        public FormBrowser()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 打开指定的 URL ，并在指定的毫秒数之后自动关闭。
        /// </summary>
        /// <param name="url"></param>
        /// <param name="duration">毫秒，-1表示无限期。</param>
        public static void Show(string url, int duration = -1)
        {
            var form = new FormBrowser();
            form.Show();

            form.webBrowser.ScriptErrorsSuppressed = false;

            form.webBrowser.Navigate(url);

            if (duration > -1)
            {
                Task.Factory.StartNew(() => {
                    SpinWait.SpinUntil(() => false, duration);

                    if (!form.IsDisposed)
                    {
                        form.Invoke(new Action(() => { form.Close(); }));
                    }
                });
            }
        }
    }
}
