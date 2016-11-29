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
    public partial class FormText : Form
    {
        public Func<string> GetContent { get; set; }

        public Action<string> SetContent { get; set; }

        public FormText()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            textBox.Text = GetContent();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            SetContent(textBox.Text);

            Close();
        }
    }
}
