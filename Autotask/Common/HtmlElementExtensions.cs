using Autotask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Autotask
{
    public static class HtmlElementExtensions
    {
        public static TaskElement ToTaskElement(this HtmlElement htmlElement)
        {
            return new TaskElement(htmlElement.TagName, 
                htmlElement.Id, 
                htmlElement.Name, 
                htmlElement.GetAttribute("classname"), 
                htmlElement.InnerText,
                htmlElement.GetAttribute("type"));
        }
    }
}
