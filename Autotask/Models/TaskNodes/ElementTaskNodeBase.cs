using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Autotask.Models
{
    /// <summary>
    /// 表示元素任务节点
    /// </summary>
    public class ElementTaskNodeBase : TaskNode
    {
        public TaskElement Element { get; set; }
        
        public ElementTaskNodeBase(TaskNodeMode mode, TaskElement element)
            : base(mode)
        {
            Element = element;
        }

        public override bool CanRun(WebBrowser browser)
        {
            SpinWait.SpinUntil(() => !browser.IsDisposed && (bool)browser.Invoke(new Func<bool>(() => browser.Document != null && browser.Document.Body != null)), 10000);

            var result = GetElement(browser) != null;

            return result;
        }

        protected HtmlElement GetElement(WebBrowser browser)
        {
            if (browser.IsDisposed)
            {
                return null;
            }
            else
            {
                return (HtmlElement)browser.Invoke(new Func<HtmlElement>(() =>
                {
                    var doc = browser.Document;
                    if (doc == null)
                    {
                        return null;
                    }

                    if (Element.Id.HasValue())
                    {
                        return doc.GetElementById(Element.Id);
                    }
                    if (Element.Name.HasValue())
                    {
                        return doc.GetElementsByTagName(Element.TagName).OfType<HtmlElement>().FirstOrDefault(el => el.Name == Element.Name);
                    }
                    if (Element.Class.HasValue())
                    {
                        return doc.GetElementsByTagName(Element.TagName).OfType<HtmlElement>().FirstOrDefault(el => el.GetAttribute("classname").HasValue() && (el.GetAttribute("classname") == Element.Class || el.GetAttribute("classname").Split(' ').Any(c => c == Element.Class)));
                    }
                    if (Element.Type.HasValue())
                    {
                        return doc.GetElementsByTagName(Element.TagName).OfType<HtmlElement>().FirstOrDefault(el => el.GetAttribute("type") == Element.Type);
                    }
                    if (Element.Content.HasValue())
                    {
                        return doc.GetElementsByTagName(Element.TagName).OfType<HtmlElement>().FirstOrDefault(el => el.InnerText == Element.Content);
                    }

                    return null;
                }));
            }
        }
    }
}
