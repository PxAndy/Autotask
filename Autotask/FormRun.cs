using Autotask.Models;
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
    public partial class FormRun : Form
    {
        public FormRun()
        {
            InitializeComponent();

            Init();

            _syncContext = SynchronizationContext.Current;
        }

        private void Init()
        {
            webBrowser.DocumentTitleChanged += WebBrowser_DocumentTitleChanged;
            webBrowser.NewWindow += WebBrowser_NewWindow;
        }
        
        private void WebBrowser_DocumentTitleChanged(object sender, EventArgs e)
        {
            textBoxUrl.Text = webBrowser.Url.ToString();
            Text = webBrowser.DocumentTitle;
        }
        
        private void WebBrowser_NewWindow(object sender, CancelEventArgs e)
        {
            e.Cancel = true;

            FormBrowser.Show(webBrowser.StatusText, 5000);
        }

        SynchronizationContext _syncContext = null;

        TaskModel _taskModel;

        DbContext _db = new DbContext();

        public void RunTask(TaskModel taskModel)
        {
            _taskModel = taskModel;

            Text = taskModel.Name;

            AddLog("开始任务......");

            Task.Factory.StartNew(() => 
            {
                var result = _taskModel.Run(webBrowser, node => {
                    AddLog(node);
                }, (node, isSuccessful) => {
                    if (!isSuccessful)
                    {
                        FailLastLog();
                    }

                    _db.Store(new TaskLog() { TaskId = _taskModel.Id, TaskName = _taskModel.Name, IsSuccessful = isSuccessful, Remark = node.ToString() });
                });

                if(result)
                {
                    AddLog("完成！");
                }
            });
        }

        private void AddLog(ITaskNode taskNode, bool isSuccessfull = true)
        {
            Invoke(new Action(() =>
            {
                var item = new ListViewItem(taskNode.ToString());
                item.Tag = taskNode;
                listViewLog.Items.Add(item);

                if (!isSuccessfull)
                {
                    DoFailLastLog();
                }

                if (taskNode is ManualTaskNode)
                {
                    var button = new Button();
                    button.Text = "完成";
                    button.Font = new Font("宋体", 9, GraphicsUnit.Point);
                    listViewLog.Controls.Add(button);
                    button.Location = new Point(listViewLog.Width - 42, item.Position.Y);
                    button.Size = new Size(40, 20);
                    button.Tag = taskNode;
                    button.Click += (sender, e) => 
                    {
                        ((ManualTaskNode)((Button)sender).Tag).IsFinished = true;
                        listViewLog.Controls.Remove(button);
                    };

                    //显示窗体
                    Show();
                }
            }));
        }

        private void DoFailLastLog()
        {
            var item = listViewLog.Items[listViewLog.Items.Count - 1];
            item.BackColor = Color.Gray;

            var taskNode = item.Tag as ITaskNode;

            var button = new Button();
            button.Text = "重试";
            button.Font = new Font("宋体", 9, GraphicsUnit.Point);
            listViewLog.Controls.Add(button);
            button.Location = new Point(listViewLog.Width - 42, item.Position.Y);
            button.Size = new Size(40, 20);
            button.Tag = taskNode;
            button.Click += (sender, e) =>
            {
                button.Enabled = false;

                taskNode.Run(webBrowser, node => { }, (node, result) => {
                    button.Enabled = true;

                    if (!result)
                    {
                        _db.Store(new TaskLog() { TaskId = _taskModel.Id, TaskName = _taskModel.Name, IsSuccessful = false, Remark = node.ToString() });
                    }
                    else
                    {
                        listViewLog.Controls.Remove(button);
                        item.BackColor = Color.FromKnownColor(KnownColor.Window);
                    }
                });
            };

            //显示窗体
            Show();
        }

        private void AddLog(string str)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() =>
                {
                    var item = new ListViewItem(str);

                    listViewLog.Items.Add(item);
                }));
            }
            else
            {
                listViewLog.Items.Add(str);
            }
        }

        private void FailLastLog()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() =>
                {
                    DoFailLastLog();
                }));
            }
            else
            {
                DoFailLastLog();
            }
        }
    }
}
