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
    public partial class FormMain : Form
    {
        DbContext _db;

        public FormMain()
        {
            InitializeComponent();

            _db = new DbContext();
            
            /*var taskModel = new TaskModel()
            {
                Name = "百度文库",
                DailyStart = new TimeSpan(9, 0, 0),
                DailyEnd = new TimeSpan(18, 0, 0),
                IsEnabled = true,
                TaskNodes = new List<ITaskNode>()
                {
                    new RedirectTaskNode("http://wenku.baidu.com/task/browse/daily"),
                    new ClickTaskNode(new TaskElement("SPAN", @class: "js-signin-btn", content: "马上签到")) { IsRequired = false },
                    new ClickTaskNode(new TaskElement("A", @class: "weibo")) { IsRequired = false },
                    new ClickTaskNode(new TaskElement("A", @class: "weibo")) { IsRequired = false },
                    new ClickTaskNode(new TaskElement("A", @class: "weibo")) { IsRequired = false },
                    new ClickTaskNode(new TaskElement("A", @class: "weibo")) { IsRequired = false },
                    new ClickTaskNode(new TaskElement("A", @class: "weibo")) { IsRequired = false },
                    new ClickTaskNode(new TaskElement("SPAN", @class: "js-getaward-btn", content: "领取奖励")),
                    new ManualTaskNode()
                }
            };

            _db.Store(taskModel);*/

            var list = _db.List<TaskModel>();

            Bind(list);
        }

        private void Bind(IEnumerable<TaskModel> taskModels)
        {
            listViewTask.Items.Clear();

            if (taskModels.HasValue())
            {
                foreach (var taskModel in taskModels)
                {
                    AppendListViewItem(taskModel);
                }
            }
        }

        private void AppendListViewItem(TaskModel taskModel)
        {
            var item = new ListViewItem(taskModel.Name);
            item.SubItems.Add(taskModel.ExecutionRangeRange);

            item.BackColor = taskModel.IsEnabled ? listViewTask.BackColor : Color.Gray;

            item.Tag = taskModel;

            listViewTask.Items.Add(item);
        }

        private void RemoveTask(TaskModel taskModel)
        {
            _db.Remove(taskModel);
        }

        private void StoreTask(TaskModel taskModel)
        {
            _db.Store(taskModel);
        }

        private void toolStripMenuItemRecord_Click(object sender, EventArgs e)
        {
            var formRecord = new FormRecord();
            formRecord.Done += FormRecord_Done;
            formRecord.Show();
        }

        private void FormRecord_Done(object sender, FormRecord.DoneEventArgs e)
        {
            if (e.TaskNodes.HasValue())
            {
                var formRecord = (FormRecord)sender;
                var taskNodes = e.TaskNodes;
                formRecord.Close();

                TaskModel newTask = new TaskModel() { TaskNodes = taskNodes.ToList(), IsEnabled = true };

                var formModel = new FormModel();
                formModel.SetModel(newTask);
                if (formModel.ShowDialog() == DialogResult.OK)
                {
                    AppendListViewItem(newTask);

                    StoreTask(newTask);
                }
            }
            else
            {
                if (MessageBox.Show("是否放弃录制？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    ((FormRecord)sender).Close();
                }
            }
        }
        
        private void toolStripMenuItemNew_Click(object sender, EventArgs e)
        {
            TaskModel taskModel = new TaskModel() { Name = "新任务", IsEnabled = true };
            var formModel = new FormModel();
            formModel.Text = "新任务";
            formModel.SetModel(taskModel);
            if (formModel.ShowDialog() == DialogResult.OK)
            {
                AppendListViewItem(taskModel);
                StoreTask(taskModel);
            }
        }

        private void toolStripMenuItemEdit_Click(object sender, EventArgs e)
        {
            if (listViewTask.SelectedItems.Count > 0)
            {
                var taskModel = (TaskModel)listViewTask.SelectedItems[0].Tag;

                var formModel = new FormModel();
                formModel.SetModel(taskModel);
                if (formModel.ShowDialog() == DialogResult.OK)
                {
                    listViewTask.SelectedItems[0].SubItems[0].Text = taskModel.Name;
                    listViewTask.SelectedItems[0].SubItems[1].Text = taskModel.ExecutionRangeRange;

                    StoreTask(taskModel);
                }
            }
        }

        private void toolStripMenuItemRemove_Click(object sender, EventArgs e)
        {
            if (listViewTask.SelectedItems.Count > 0)
            {
                foreach (ListViewItem item in listViewTask.SelectedItems)
                {
                    listViewTask.Items.Remove(item);

                    RemoveTask((TaskModel)item.Tag);
                }
            }
        }

        private void toolStripMenuItemEnable_Click(object sender, EventArgs e)
        {
            if (listViewTask.SelectedItems.Count > 0)
            {
                foreach (ListViewItem item in listViewTask.SelectedItems)
                {
                    item.BackColor = listViewTask.BackColor;

                    var taskModel = (TaskModel)item.Tag;
                    taskModel.IsEnabled = true;
                    StoreTask(taskModel);
                }
            }
        }

        private void toolStripMenuItemDisable_Click(object sender, EventArgs e)
        {
            if (listViewTask.SelectedItems.Count > 0)
            {
                foreach (ListViewItem item in listViewTask.SelectedItems)
                {
                    item.BackColor = Color.Gray;

                    var taskModel = (TaskModel)item.Tag;
                    taskModel.IsEnabled = false;
                    StoreTask(taskModel);
                }
            }
        }

        private void toolStripMenuItemRun_Click(object sender, EventArgs e)
        {
            if(listViewTask.SelectedItems.Count == 1)
            {
                var formRun = new FormRun();
                formRun.Show();

                formRun.RunTask((TaskModel)listViewTask.SelectedItems[0].Tag);
            }
        }

        private void listViewTask_SelectedIndexChanged(object sender, EventArgs e)
        {
            toolStripMenuItemEdit.Enabled = listViewTask.SelectedItems.Count == 1;
            toolStripMenuItemRemove.Enabled = toolStripMenuItemEnable.Enabled = toolStripMenuItemDisable.Enabled = toolStripMenuItemRun.Enabled = listViewTask.SelectedItems.Count > 0;
        }
    }
}
