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
    public partial class ElementControl : UserControl
    {
        public ElementControl()
        {
            InitializeComponent();
        }

        TaskElement _element;

        public void SetElement(TaskElement element)
        {
            _element = element;

            for (int i = 0; i < comboBoxTag.Items.Count; i++)
            {
                if(comboBoxTag.Items[i].ToString() == element.TagName)
                {
                    comboBoxTag.SelectedIndex = i;
                    break;
                }
            }
            textBoxCss.Text = element.CssSelector;
            textBoxId.Text = element.Id;
            textBoxName.Text = element.Name;
            textBoxClass.Text = element.Class;
            textBoxType.Text = element.Type;
            textBoxContent.Text = element.Content;
        }

        private void comboBoxTag_SelectedIndexChanged(object sender, EventArgs e)
        {
            _element.TagName = comboBoxTag.SelectedItem.ToString();
        }

        private void textBoxId_Leave(object sender, EventArgs e)
        {
            _element.Id = textBoxId.Text;
        }

        private void textBoxName_Leave(object sender, EventArgs e)
        {
            _element.Name = textBoxName.Text;
        }

        private void textBoxClass_Leave(object sender, EventArgs e)
        {
            _element.Class = textBoxClass.Text;
        }

        private void textBoxType_Leave(object sender, EventArgs e)
        {
            _element.Type = textBoxType.Text;
        }

        private void textBoxContent_Leave(object sender, EventArgs e)
        {
            _element.Content = textBoxContent.Text;
        }

        private void textBoxCss_Leave(object sender, EventArgs e)
        {
            _element.CssSelector = textBoxCss.Text;
        }
    }
}
