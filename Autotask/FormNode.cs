using Autotask.Controls;
using Autotask.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Autotask
{
    public partial class FormNode : Form
    {
        public FormNode()
        {
            InitializeComponent();

            
        }

        public void SetNode(ITaskNode node)
        {
            if (node is RedirectTaskNode)
            {
                Height = 100 + 30;

                RedirectNodeControl control = new RedirectNodeControl();
                tableLayoutPanel1.Controls.Add(control, 0, 0);
                control.Dock = DockStyle.Fill;
                control.SetNode(node);
            }
            else if (node is ClickTaskNode)
            {
                Height = 100 + 190;

                ClickNodeControl control = new ClickNodeControl();
                tableLayoutPanel1.Controls.Add(control, 0, 0);
                control.Dock = DockStyle.Fill;
                control.SetNode(node);
            }
            else if (node is InputTaskNode)
            {
                Height = 100 + 220;

                InputNodeControl control = new InputNodeControl();
                tableLayoutPanel1.Controls.Add(control, 0, 0);
                control.Dock = DockStyle.Fill;
                control.SetNode(node);
            }
            else if (node is FocusTaskNode)
            {
                Height = 100 + 220;

                FocusNodeControl control = new FocusNodeControl();
                tableLayoutPanel1.Controls.Add(control, 0, 0);
                control.Dock = DockStyle.Fill;
                control.SetNode(node);
            }
            else if (node is FocusTaskNode)
            {
                Height = 100 + 220;

                FocusNodeControl control = new FocusNodeControl();
                tableLayoutPanel1.Controls.Add(control, 0, 0);
                control.Dock = DockStyle.Fill;
                control.SetNode(node);
            }
            else if (node is InputTaskNode)
            {
                Height = 100 + 250;

                InputNodeControl control = new InputNodeControl();
                tableLayoutPanel1.Controls.Add(control, 0, 0);
                control.Dock = DockStyle.Fill;
                control.SetNode(node);
            }
        }
    }
}
