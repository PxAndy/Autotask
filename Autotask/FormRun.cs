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

            var cancellationTokenSource = new CancellationTokenSource();
            
            Task<bool> firstTask = Task.Factory.StartNew(() => 
            {
                SpinWait.SpinUntil(() => false, 1000);
                AddLog("开始任务......");

                return true;
            });
            Task<bool> linkedTask = null;

            foreach (var taskNode in taskModel.TaskNodes)
            {
                linkedTask = (linkedTask == null ? firstTask : linkedTask).ContinueWith((task, n) => 
                {
                    SpinWait.SpinUntil(() => false, 1000);

                    var node = (TaskNode)n;

                    if(!cancellationTokenSource.IsCancellationRequested)
                    {
                        if (node.CanRun(webBrowser))
                        {
                            AddLog(node);

                            var flag = node.Run(webBrowser);
                            
                            if (!flag)
                            {
                                FailLastLog();

                                _db.Store(new TaskLog() { TaskId = _taskModel.Id, TaskName = _taskModel.Name, IsSuccessful = false, Remark = node.ToString() });

                                if (node.IsRequired)
                                {
                                    cancellationTokenSource.Cancel();
                                }
                            }

                            return flag;
                        }
                        else
                        {
                            _db.Store(new TaskLog() { TaskId = _taskModel.Id, TaskName = _taskModel.Name, IsSuccessful = false, Remark = node.ToString() });

                            if (node.IsRequired)
                            {
                                cancellationTokenSource.Cancel();
                            }
                        }
                    }

                    AddLog(node, false);

                    return false;
                }, taskNode, cancellationTokenSource.Token);
            }

            linkedTask.ContinueWith(task => 
            {
                if (!cancellationTokenSource.IsCancellationRequested)
                {
                    AddLog("完成！");

                    _db.Store(new TaskLog() { TaskId = _taskModel.Id, TaskName = _taskModel.Name, IsSuccessful = true });

                    Invoke(new Action(Close));
                }
            });
        }

        private void AddLog(ITaskNode taskNode, bool isSuccessfull = true)
        {
            Invoke(new Action(() =>
            {
                var item = new ListViewItem(taskNode.ToString());
                listViewLog.Items.Add(item);

                if (!isSuccessfull)
                {
                    item.BackColor = Color.Gray;

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

                        var node = (ITaskNode)((Button)sender).Tag;
                        if (node.CanRun(webBrowser))
                        {
                            var flag = node.Run(webBrowser);

                            button.Enabled = true;

                            if (!flag)
                            {
                                _db.Store(new TaskLog() { TaskId = _taskModel.Id, TaskName = _taskModel.Name, IsSuccessful = false, Remark = node.ToString() });
                            }
                            else
                            {
                                listViewLog.Controls.Remove(button);
                                item.BackColor = Color.FromKnownColor(KnownColor.Window);
                            }
                        }
                    };
                    
                    //显示窗体
                    Show();
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

        private void AddLog(string str)
        {
            Invoke(new Action(() =>
            {
                var item = new ListViewItem(str);

                listViewLog.Items.Add(item);
            }));
        }

        private void FailLastLog()
        {
            Invoke(new Action(() =>
            {
                listViewLog.Items[listViewLog.Items.Count - 1].BackColor = Color.Gray;

                //显示窗体
                Show();
            }));
        }
    }
}
