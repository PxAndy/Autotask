using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Autotask.Models;

namespace Autotask.Controls
{
    public partial class RedirectNodeControl : UserControl, ITaskNodeControl
    {
        public RedirectNodeControl()
        {
            InitializeComponent();
        }

        RedirectTaskNode _node;

        public void SetNode(ITaskNode node)
        {
            if (!(node is RedirectTaskNode))
            {
                throw new ArgumentException("参数“node”必须是 RedirectTaskNode 类型。");
            }

            _node = (RedirectTaskNode)node;

            textBoxUrl.Text = _node.Url;
        }

        private void textBoxUrl_Leave(object sender, EventArgs e)
        {
            _node.Url = textBoxUrl.Text;
        }
    }
}
