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
    public partial class FormModel : Form
    {
        public FormModel()
        {
            InitializeComponent();
        }

        public Action<TaskModel> GetModel { get; set; }
        
        TaskModel _model;

        public void SetModel(TaskModel model)
        {
            _model = model;

            textBoxName.Text = model.Name;
            maskedTextBoxBegin.Text = model.ExecutionRangeStart.ToString();
            maskedTextBoxEnd.Text = model.ExecutionRangeEnd.ToString();

            SetTaskNodes(model.TaskNodes);
        }

        #region 私有方法

        private void SetTaskNodes(IEnumerable<ITaskNode> taskNodes)
        {
            listViewNodes.Items.Clear();

            foreach (var node in taskNodes)
            {
                var item = CreateListViewItem(node);
                
                listViewNodes.Items.Add(item);
            }
        }

        private ListViewItem CreateListViewItem(ITaskNode node)
        {
            var item = new ListViewItem(node.Mode.GetDescription());
            item.Tag = node;

            if (node is RedirectTaskNode)
            {
                item.SubItems.Add(((RedirectTaskNode)node).Url);
            }
            if (node is RefreshTaskNode)
            {
                
            }
            if (node is ManualTaskNode)
            {

            }
            if (node is ClickTaskNode)
            {
                item.SubItems.Add("");
                item.SubItems.Add(((ClickTaskNode)node).Element.ToString());
            }
            if (node is FocusTaskNode)
            {
                item.SubItems.Add("");
                item.SubItems.Add(((FocusTaskNode)node).Element.ToString());
            }
            if (node is InputTaskNode)
            {
                item.SubItems.Add("");

                var input = (InputTaskNode)node;
                item.SubItems.Add(input.Element.ToString());
                item.SubItems.Add(input.Text);
            }
            if (node is WaitTaskNode)
            {
                item.SubItems.Add("");
                item.SubItems.Add(((WaitTaskNode)node).ToString());
            }

            return item;
        }

        private void EditListViewItem(ListViewItem item, ITaskNode node)
        {
            item.Tag = node;

            if (node is RedirectTaskNode)
            {
                item.SubItems[1].Text = ((RedirectTaskNode)node).Url;
            }
            if (node is RefreshTaskNode)
            {

            }
            if (node is ManualTaskNode)
            {

            }
            if (node is ClickTaskNode)
            {
                item.SubItems[2].Text = ((ClickTaskNode)node).Element.ToString();
            }
            if (node is FocusTaskNode)
            {
                item.SubItems[2].Text = ((FocusTaskNode)node).Element.ToString();
            }
            if (node is InputTaskNode)
            {
                var input = (InputTaskNode)node;
                item.SubItems[2].Text = input.Element.ToString();
                item.SubItems[3].Text = input.Text;
            }
        }

        private bool CanInsert()
        {
            return listViewNodes.SelectedItems.Count > 0;
        }

        private bool CanEdit()
        {
            if (listViewNodes.SelectedItems.Count == 1)
            {
                var node = (ITaskNode)listViewNodes.SelectedItems[0].Tag;
                return node.Mode != TaskNodeMode.RefreshPage && node.Mode != TaskNodeMode.Manual;
            }
            return false;
        }

        private bool CanDelete()
        {
            return listViewNodes.SelectedItems.Count > 0;
        }

        private bool CanCombine(out string text)
        {
            var flag = true;
            text = "";
            if (listViewNodes.SelectedItems.Count > 1)
            {
                InputTaskNode firstNode = null;

                foreach (ListViewItem item in listViewNodes.SelectedItems)
                {
                    var node = (ITaskNode)item.Tag;

                    if (node.Mode == TaskNodeMode.InputElement && node is InputTaskNode)
                    {
                        var inputNode = node as InputTaskNode;
                        if (firstNode == null)
                        {
                            firstNode = inputNode;
                            text += inputNode.Text;
                        }
                        else
                        {
                            if (inputNode.Element == firstNode.Element)
                            {
                                text += inputNode.Text;
                            }
                            else
                            {
                                flag = false;
                                break;
                            }
                        }
                    }
                    else
                    {
                        flag = false;
                        break;
                    }
                }

                return flag;
            }
            else
            {
                return false;
            }
        }
        
        private ITaskNode CreateNode(TaskNodeMode mode)
        {
            ITaskNode node = null;
            var formNode = new FormNode();

            switch (mode)
            {
                case TaskNodeMode.RedirectPage:
                    node = new RedirectTaskNode("");
                    
                    formNode.SetNode(node);
                    if (formNode.ShowDialog() != DialogResult.OK)
                    {
                        node = null;
                    }

                    break;
                case TaskNodeMode.RefreshPage:
                    node = new RefreshTaskNode();
                    break;
                case TaskNodeMode.Manual:
                    node = new ManualTaskNode();
                    break;
                case TaskNodeMode.ClickElement:
                    node = new ClickTaskNode(new TaskElement("BUTTON"));

                    formNode.SetNode(node);
                    if (formNode.ShowDialog() != DialogResult.OK)
                    {
                        node = null;
                    }
                    break;
                case TaskNodeMode.FocusElement:
                    node = new FocusTaskNode(new TaskElement("INPUT", type: "text"));

                    formNode.SetNode(node);
                    if (formNode.ShowDialog() != DialogResult.OK)
                    {
                        node = null;
                    }
                    break;
                case TaskNodeMode.InputElement:
                    node = new InputTaskNode(new TaskElement("INPUT", type: "text"), "");

                    formNode.SetNode(node);
                    if (formNode.ShowDialog() != DialogResult.OK)
                    {
                        node = null;
                    }
                    break;
                case TaskNodeMode.Wait:
                    node = new WaitTaskNode();

                    formNode.SetNode(node);
                    if (formNode.ShowDialog() != DialogResult.OK)
                    {
                        node = null;
                    }
                    break;
            }

            return node;
        }

        private void AddNode(TaskNodeMode mode)
        {
            var node = CreateNode(mode);

            if (node != null)
            {
                _model.TaskNodes.Add(node);

                listViewNodes.Items.Add(CreateListViewItem(node));
            }
        }

        private void InsertNode(TaskNodeMode mode)
        {
            var node = CreateNode(mode);

            if (node != null)
            {
                var index = listViewNodes.SelectedIndices[0];

                _model.TaskNodes.Insert(index, node);

                listViewNodes.Items.Insert(index, CreateListViewItem(node));
            }
        }

        #endregion

        #region 事件处理

        private void contextMenuStripNodes_Opening(object sender, CancelEventArgs e)
        {
            string text;
            toolStripMenuItemInsert.Enabled = CanInsert();
            toolStripMenuItemEdit.Enabled = CanEdit();
            toolStripMenuItemCombine.Enabled = CanCombine(out text);
            toolStripMenuItemDelete.Enabled = CanDelete();
        }
        
        private void ItemAdd_Click(object sender, EventArgs e)
        {
            AddNode((TaskNodeMode)int.Parse(((ToolStripItem)sender).Tag.ToString()));
        }

        private void ItemInsert_Click(object sender, EventArgs e)
        {
            InsertNode((TaskNodeMode)int.Parse(((ToolStripItem)sender).Tag.ToString()));
        }

        private void ItemEdit_Click(object sender, EventArgs e)
        {
            ITaskNode node = listViewNodes.SelectedItems[0].Tag as ITaskNode;
            var formNode = new FormNode();
            formNode.SetNode(node);

            if (formNode.ShowDialog() == DialogResult.OK)
            {
                EditListViewItem(listViewNodes.SelectedItems[0], node);
            }
        }

        private void ItemRemove_Click(object sender, EventArgs e)
        {
            if (listViewNodes.SelectedItems.Count > 0)
            {
                foreach (ListViewItem item in listViewNodes.SelectedItems)
                {
                    listViewNodes.Items.Remove(item);
                }
            }
        }

        private void ItemCombine_Click(object sender, EventArgs e)
        {
            string text;
            if (CanCombine(out text))
            {
                ((InputTaskNode)listViewNodes.SelectedItems[0].Tag).Text = text;
                listViewNodes.SelectedItems[0].SubItems[3].Text = text;

                for (int i = listViewNodes.SelectedItems.Count - 1; i > 0; i--)
                {
                    listViewNodes.Items.Remove(listViewNodes.SelectedItems[i]);
                }
            }
        }
        
        private void listViewNodes_SelectedIndexChanged(object sender, EventArgs e)
        {
            string text;
            menuStripItemInsert.Enabled = CanInsert();
            menuStripItemEdit.Enabled = CanEdit();
            menuStripItemCombine.Enabled = CanCombine(out text);
            menuStripItemDelete.Enabled = CanDelete();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (!textBoxName.Text.HasValue())
            {
                textBoxName.Focus();

                return;
            }

            _model.Name = textBoxName.Text;
            TimeSpan begin;
            if (TimeSpan.TryParse(maskedTextBoxBegin.Text, out begin)) { _model.ExecutionRangeStart = begin; }
            TimeSpan end;
            if (TimeSpan.TryParse(maskedTextBoxEnd.Text, out end)) { _model.ExecutionRangeEnd = end; }
            _model.TaskNodes = listViewNodes.Items.OfType<ListViewItem>().Select(item => (ITaskNode)item.Tag).ToList();

            GetModel?.Invoke(_model);

            Close();
        }

        #endregion

    }
}
