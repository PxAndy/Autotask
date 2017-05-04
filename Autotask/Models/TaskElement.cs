using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autotask.Models
{
    public class TaskElement
    {
        public string TagName { get; set; }

        public string CssSelector { get; set; }

        public string Id { get; set; }

        public string Name { get; set; }

        public string Class { get; set; }

        public string Content { get; set; }

        public string Type { get; set; }

        public TaskElement()
        {

        }

        public TaskElement(string tagName, string cssSelector = "", string id = "", string name = "", string @class = "", string content = "", string type = "")
        {
            TagName = tagName;
            CssSelector = cssSelector;
            Id = id;
            Name = name;
            Class = @class;
            Content = content;
            Type = type;
        }

        public override string ToString()
        {
            if (CssSelector.HasValue())
            {
                return CssSelector;
            }
            else
            {
                return (!Content.IsNullOrEmpty() ? Content : "")
                + "<" + TagName
                + (!Id.IsNullOrEmpty() ? "#" + Id : "")
                + (!Class.IsNullOrEmpty() ? "." + Class : "")
                + (!Name.IsNullOrEmpty() ? "[Name=" + Name + "]" : "")
                + (!Type.IsNullOrEmpty() ? "[Type=" + Type + "]" : "")
                + ">";
            }
        }

        public static bool operator ==(TaskElement element1, TaskElement element2)
        {
            return element1.ToString() == element2.ToString();
        }

        public static bool operator !=(TaskElement element1, TaskElement element2)
        {
            return !(element1 == element2);
        }

    }
}
