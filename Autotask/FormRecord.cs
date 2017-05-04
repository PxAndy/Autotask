using Autotask.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Autotask
{
    public partial class FormRecord : Form
    {
        public class DoneEventArgs: EventArgs
        {
            public IEnumerable<ITaskNode> TaskNodes { get; private set; }

            public DoneEventArgs(IEnumerable<ITaskNode> taskNodes)
            {
                TaskNodes = taskNodes;
            }
        }

        public delegate void DoneEventHandler(object sender, DoneEventArgs e);

        /// <summary>
        /// 表示录制完成
        /// </summary>
        public event DoneEventHandler Done;

        public FormRecord()
        {
            InitializeComponent();

            Init();
        }

        List<ITaskNode> _taskNodes = new List<ITaskNode>();

        private void Init()
        {
            textBoxUrl.KeyDown += TextBoxUrl_KeyDown;

            webBrowser.ScriptErrorsSuppressed = false;
            webBrowser.Navigating += WebBrowser_Navigating;
            webBrowser.Navigated += WebBrowser_Navigated;
            webBrowser.ProgressChanged += WebBrowser_ProgressChanged;
            webBrowser.DocumentCompleted += WebBrowser_DocumentCompleted;
            webBrowser.DocumentTitleChanged += WebBrowser_DocumentTitleChanged;
            webBrowser.NewWindow += WebBrowser_NewWindow;
            
            buttonDone.Click += ButtonDone_Click;

            listBoxTaskNodes.ValueMember = "Id";
        }

        private void WebBrowser_ProgressChanged(object sender, WebBrowserProgressChangedEventArgs e)
        {
            if (e.CurrentProgress == e.MaximumProgress)
            {
                Debug.WriteLine("ProgressChanged   Status: {0}", webBrowser.ReadyState);
            }
        }

        private void WebBrowser_NewWindow(object sender, CancelEventArgs e)
        {
            string url = webBrowser.StatusText;
            e.Cancel = true;

            if (MessageBox.Show("是否在新窗口打开？\r\n\r\n如果不需要在新窗口操作，请点击“是”；\r\n否则，点击“否”。", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                FormBrowser.Show(url, 5000);
            }
            else
            {
                webBrowser.Navigate(url);
            }
        }

        private void AddTaskNode(ITaskNode node)
        {
            _taskNodes.Add(node);

            RefreshListBox();
        }

        private void RefreshListBox()
        {
            listBoxTaskNodes.DataSource = null;
            listBoxTaskNodes.DataSource = _taskNodes;
        }

        private void TextBoxUrl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                webBrowser.Navigate(textBoxUrl.Text.Trim());
            }
        }
        
        private void WebBrowser_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            Debug.WriteLine("Navigating: {0}, frame:{1}, Status: {2}    ", e.Url, e.TargetFrameName, webBrowser.ReadyState);
            
            /*if (webBrowser.Document != null && webBrowser.Document.Body != null)
            {
                foreach (HtmlElement element in webBrowser.Document.Body.All)
                {
                    element.Click -= Element_Click;

                    element.KeyPress -= Element_KeyPress;
                }
            }*/
        }

        bool _loaded = true;

        private void WebBrowser_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            Debug.WriteLine("Navigated: {0}, Status: {1}", e.Url, webBrowser.ReadyState);
        }

        private void WebBrowser_DocumentTitleChanged(object sender, EventArgs e)
        {
            textBoxUrl.Text = webBrowser.Url.ToString();
            Text = webBrowser.DocumentTitle;
            Debug.WriteLine("DocumentTitleChanged: {0}, Status: {1}", webBrowser.Url, webBrowser.ReadyState);

            if (webBrowser.ReadyState == WebBrowserReadyState.Loading)
            {
                AddTaskNode(new RedirectTaskNode(webBrowser.Url.ToString()));

                _loaded = false;

                if (webBrowser.Document != null && webBrowser.Document.Body != null)
                {
                    webBrowser.Document.Body.MouseUp -= Body_MouseUp;
                    //webBrowser.Document.Body.KeyDown -= Body_KeyDown;
                }
            }

            if (!_loaded && webBrowser.ReadyState == WebBrowserReadyState.Interactive && webBrowser.Document != null && webBrowser.Document.Body != null)
            {
                _loaded = true;
                //foreach (HtmlElement element in webBrowser.Document.Body.All)
                //{
                //    element.Click += Element_Click;

                //    element.KeyPress += Element_KeyPress;
                //}
                webBrowser.Document.Body.MouseUp += Body_MouseUp;
                //webBrowser.Document.Body.KeyDown += Body_KeyDown;
                Debug.WriteLine("绑定元素事件");
            }
        }

        private void WebBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            Debug.WriteLine("DocumentCompleted Status:" + webBrowser.ReadyState);

            if (!_loaded && webBrowser.ReadyState == WebBrowserReadyState.Complete && webBrowser.Document != null && webBrowser.Document.Body != null)
            {
                _loaded = true;
                //foreach (HtmlElement element in webBrowser.Document.Body.All)
                //{
                //    element.Click += Element_Click;

                //    element.KeyPress += Element_KeyPress;
                //}
                webBrowser.Document.Body.MouseUp += Body_MouseUp;
                //webBrowser.Document.Body.KeyDown += Body_KeyDown;

                Debug.WriteLine("绑定元素事件");
            }
        }
        
        private void Body_MouseUp(object sender, HtmlElementEventArgs e)
        {
            var element = webBrowser.Document.GetElementFromPoint(e.ClientMousePosition);

            if (element != null)
            {
                Debug.WriteLine("Click: {0} id={1} name={2} class={3} text={4}", element.TagName, element.Id, element.Name, element.GetAttribute("class"), element.InnerText);
                Debug.WriteLine("Click: {0}", element.CssPath());

                if (element.TagName == "INPUT" && (element.GetAttribute("type") == "text" || element.GetAttribute("type") == "password"))
                {
                    element.KeyPress -= Element_KeyPress;

                    AddTaskNode(new FocusTaskNode(element.ToTaskElement()));

                    element.KeyPress += Element_KeyPress;
                }
                else
                {
                    AddTaskNode(new ClickTaskNode(element.ToTaskElement()));
                }
            }
        }
        
        private void Body_KeyDown(object sender, HtmlElementEventArgs e)
        {
            var element = webBrowser.Document.GetElementFromPoint(e.ClientMousePosition);

            if (element != null)
            {
                Debug.WriteLine("KeyPress: {0} id={1} name={2} class={3} text={4} {5}", element.TagName, element.Id, element.Name, element.GetAttribute("class"), element.InnerText, (char)e.KeyPressedCode);

                if (element.TagName == "INPUT" && (element.GetAttribute("type") == "text" || element.GetAttribute("type") == "password")
                    || element.TagName == "TEXTAREA")
                {
                    var taskElement = element.ToTaskElement();
                    /*var lastTask = _taskNodes.Last();

                    if (lastTask.Mode == TaskNodeMode.InputElement && ((InputTaskNode)lastTask).Element == taskElement)
                    {
                        ((InputTaskNode)lastTask).Text += ((char)e.KeyPressedCode).ToString();

                        RefreshListBox();
                    }
                    else
                    {
                        AddTaskNode(new InputTaskNode(taskElement, ((char)e.KeyPressedCode).ToString()));
                    }*/

                    AddTaskNode(new InputTaskNode(taskElement, ((char)e.KeyPressedCode).ToString()));
                }
            }
        }

        private void Element_Click(object sender, HtmlElementEventArgs e)
        {
            e.BubbleEvent = false;

            var element = sender as HtmlElement;

            Debug.WriteLine("Click: {0} id={1} name={2} class={3} text={4}", element.TagName, element.Id, element.Name, element.GetAttribute("class"), element.InnerText);
            Debug.WriteLine("Click: {0}", element.CssPath());

            if (element.TagName == "INPUT" && (element.GetAttribute("type") == "text" || element.GetAttribute("type") == "password"))
            {
                AddTaskNode(new FocusTaskNode(element.ToTaskElement()));
            }
            else
            {
                AddTaskNode(new ClickTaskNode(element.ToTaskElement()));
            }
        }

        private void Element_KeyPress(object sender, HtmlElementEventArgs e)
        {
            e.BubbleEvent = false;

            var element = sender as HtmlElement;

            Debug.WriteLine("KeyPress: {0} id={1} name={2} class={3} text={4} {5}", element.TagName, element.Id, element.Name, element.GetAttribute("class"), element.InnerText, (char)e.KeyPressedCode);

            if (element.TagName == "INPUT" && (element.GetAttribute("type") == "text" || element.GetAttribute("type") == "password")
                || element.TagName == "TEXTAREA")
            {
                var taskElement = element.ToTaskElement();
                /*var lastTask = _taskNodes.Last();

                if (lastTask.Mode == TaskNodeMode.InputElement && ((InputTaskNode)lastTask).Element == taskElement)
                {
                    ((InputTaskNode)lastTask).Text += ((char)e.KeyPressedCode).ToString();

                    RefreshListBox();
                }
                else
                {
                    AddTaskNode(new InputTaskNode(taskElement, ((char)e.KeyPressedCode).ToString()));
                }*/

                AddTaskNode(new InputTaskNode(taskElement, ((char)e.KeyPressedCode).ToString()));
            }
        }
        
        private void ButtonDone_Click(object sender, EventArgs e)
        {
            Done?.Invoke(this, new DoneEventArgs(_taskNodes));

            Close();
        }
    }
}
