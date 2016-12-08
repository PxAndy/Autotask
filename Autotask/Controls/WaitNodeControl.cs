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
    public partial class WaitNodeControl : UserControl, ITaskNodeControl
    {
        public WaitNodeControl()
        {
            InitializeComponent();
        }

        WaitTaskNode _node;

        public void SetNode(ITaskNode node)
        {
            if (!(node is WaitTaskNode))
            {
                throw new ArgumentException("参数“node”必须是 WaitTaskNode 类型。");
            }

            _node = (WaitTaskNode)node;

            numericMilliseconds.Value = _node.Milliseconds;
        }

        private void numericMilliseconds_ValueChanged(object sender, EventArgs e)
        {
            _node.Milliseconds = (int)numericMilliseconds.Value;
        }
    }
}
