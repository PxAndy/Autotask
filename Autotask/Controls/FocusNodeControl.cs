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
    public partial class FocusNodeControl : UserControl, ITaskNodeControl
    {
        public FocusNodeControl()
        {
            InitializeComponent();
        }

        public void SetNode(ITaskNode node)
        {
            if (!(node is FocusTaskNode))
            {
                throw new ArgumentException("参数“node”必须是 FocusTaskNode 类型。");
            }

            elementControl1.SetElement(((FocusTaskNode)node).Element);
        }
    }
}
