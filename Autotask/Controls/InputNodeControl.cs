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
    public partial class InputNodeControl : UserControl, ITaskNodeControl
    {
        public InputNodeControl()
        {
            InitializeComponent();
        }

        InputTaskNode _node;

        public void SetNode(ITaskNode node)
        {
            if (!(node is InputTaskNode))
            {
                throw new ArgumentException("参数“node”必须是 InputTaskNode 类型。");
            }

            _node = (InputTaskNode)node;

            elementControl1.SetElement(_node.Element);
        }

        private void textBoxText_Leave(object sender, EventArgs e)
        {
            _node.Text = textBoxText.Text;
        }
    }
}
