using Autotask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Autotask
{
    public static class HtmlElementExtensions
    {
        public static TaskElement ToTaskElement(this HtmlElement element)
        {
            return new TaskElement(element.TagName, 
                element.CssPath(),
                element.Id, 
                element.Name, 
                element.GetAttribute("classname"), 
                element.InnerText,
                element.GetAttribute("type"));
        }

        private static string _whitespace = "[\\x20\\t\\r\\n\\f]";
        private static string _identifier = "(?:\\\\.|[\\w-]|[^\0-\\xa0])+";
        private static string _attributes = "\\[" + _whitespace + "*(" + _identifier + ")(?:" + _whitespace +
		                                    // Operator (capture 2)
		                                    "*([*^$|!~]?=)" + _whitespace +
		                                    // "Attribute values must be CSS identifiers [capture 5] or strings [capture 3 or capture 4]"
		                                    "*(?:'((?:\\\\.|[^\\\\'])*)'|\"((?:\\\\.|[^\\\\\"])*)\"|(" + _identifier + "))|)" + _whitespace +
		                                    "*\\]";
        private static string _pseudos = ":(" + _identifier + ")(?:\\((" +
                                        // To reduce the number of selectors needing tokenize in the preFilter, prefer arguments:
                                        // 1. quoted (capture 3; capture 4 or capture 5)
                                        "('((?:\\\\.|[^\\\\'])*)'|\"((?:\\\\.|[^\\\\\"])*)\")|" +
                                        // 2. simple (capture 6)
                                        "((?:\\\\.|[^\\\\()[\\]]|" + _attributes + ")*)|" +
                                        // 3. anything else (capture 2)
                                        ".*" +
                                        ")\\)|)";

        private static Dictionary<string, Regex> _matchExpr = new Dictionary<string, Regex>()
        {
            { "ID", new Regex("^#(" + _identifier + ")") },
            { "CLASS", new Regex("^\\.(" + _identifier + ")") },
            { "TAG", new Regex("^(" + _identifier + "|[*])") },
            { "CHILD", new Regex("^:nth-child\\(" + _whitespace + "*(\\d+)" + _whitespace + "*\\)") },
            { "COMBINE", new Regex("(>|\\s)") }
        };

        private static Regex _quickExpr = new Regex(@"^(?:#([\w-]+)|(\w+)|\.([\w-]+))$");
        
        private static Dictionary<string, Func<HtmlElement, string, IEnumerable<HtmlElement>>> _filter = new Dictionary<string, Func<HtmlElement, string, IEnumerable<HtmlElement>>>()
        {
            { "ID", (element, selector) => { return element != element.Document.Body && element.Id == selector ? new List<HtmlElement>() { element.Document.GetElementById(selector) } : Enumerable.Empty<HtmlElement>(); } },
            { "TAG", (element, selector) => {  return element.TagName == selector ? new List<HtmlElement>() { element } : Enumerable.Empty<HtmlElement>(); } },
            { "CLASS", (element, selector) => { return element.GetAttribute("classname").Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Contains(selector) ? new List<HtmlElement>() { element } : Enumerable.Empty<HtmlElement>(); } },
            { "CHILD", (element, selector) => { return element.Parent.Children.OfType<HtmlElement>().ToList().IndexOf(element) == int.Parse(selector) ?  new List<HtmlElement>() { element } : Enumerable.Empty<HtmlElement>(); } },
            { "COMBINE", (element, selector) => { return (selector == ">" ? element.Children : element.All).OfType<HtmlElement>().ToArray(); } }
        };

        private static IEnumerable<HtmlElement> FilterById(HtmlElement element, string selector)
        {
            var el = element.Document.GetElementById(selector);

            if (element != element.Document.Body && element.Id == selector)
            {
                return new List<HtmlElement>() { el };
            }

            return Enumerable.Empty<HtmlElement>();
        }

        private static IEnumerable<HtmlElement> FilterByTag(HtmlElement element, string selector, bool isChildren)
        {
            return (isChildren ? element.Children : element.All).OfType<HtmlElement>().ToArray().Where(el => el.TagName == selector).ToArray();
        }

        private static IEnumerable<HtmlElement> FilterByClass(HtmlElement element, string selector, bool isChildren)
        {
            return Enumerable.Empty<HtmlElement>();
        }

        private static IEnumerable<HtmlElement> FilterByChild(HtmlElement element, string selector, bool isChildren)
        {
            
            return Enumerable.Empty<HtmlElement>();
        }

        public static List<HtmlElement> Query(this HtmlDocument document, string cssSelector)
        {
            if(document == null)
            {
                throw new ArgumentNullException("document");
            }
            if(string.IsNullOrEmpty(cssSelector))
            {
                throw new ArgumentNullException("cssSelector");
            }

            cssSelector = Regex.Replace(cssSelector, @"\s*>\s*", ">");
            cssSelector = Regex.Replace(cssSelector, @"\s+", " ");

            var list = new List<HtmlElement>();

            foreach (HtmlElement el in document.Body.All)
            {
                list.AddRange(DoQuery(el, cssSelector));
            }

            return list;
        }

        private static List<HtmlElement> DoQuery(HtmlElement element, string selector)
        {
            var list = new List<HtmlElement>();
            
            if (!selector.IsNullOrEmpty())
            {
                foreach (var key in _matchExpr.Keys)
                {
                    if (_matchExpr[key].IsMatch(selector))
                    {
                        var match = _matchExpr[key].Match(selector);
                        var selectorKey = match.Groups[1].Value;
                        
                        var els = _filter[key](element, selectorKey);

                        foreach (var el in els)
                        {
                            list.AddRange(DoQuery(el, selector.Substring(match.Length)));
                        }
                    }
                }
            }
            else
            {
                list.Add(element);
            }

            return list;
        }

        public static string CssPath(this HtmlElement node)
        {
            bool optimized = true;

            if (node == null)
            {
                return string.Empty;
            }

            var steps = new List<string>();
            var contextNode = node;

            while(contextNode != null)
            {
                string step = string.Empty;
                var flag = CssPathStep(contextNode, optimized, contextNode == node, out step);

                if(string.IsNullOrEmpty(step))
                {
                    break;
                }

                steps.Add(step);

                if (flag)
                {
                    break;
                }

                contextNode = contextNode.Parent;
            }

            steps.Reverse();
            
            return string.Join(" > ", steps);
        }

        #region 私有方法

        private static bool CssPathStep(HtmlElement node, bool optimized, bool isTargetNode, out string step)
        {
            var id = node.Id;

            if (optimized)
            {
                if(!string.IsNullOrEmpty(id))
                {
                    step = IdSelector(id);
                    return true;
                }

                var nodeNameLower = node.TagName.ToLower();

                if(nodeNameLower == "body" || nodeNameLower == "head" || nodeNameLower == "html")
                {
                    step = nodeNameLower;
                    return true;
                }
            }

            var nodeName = node.TagName.ToLower();

            if (!string.IsNullOrEmpty(id))
            {
                step = nodeName + IdSelector(id);
                return true;
            }

            var parent = node.Parent;
            if(parent == null)
            {
                step = nodeName;
                return true;
            }

            var prefixedOwnClassNamesArray = prefixedElementClassNames(node);
            var needsClassNames = false;
            var needsNthChild = false;
            var ownIndex = -1;
            var elementIndex = -1;
            var siblings = parent.Children;

            for (var i = 0; (ownIndex == -1 || !needsNthChild) && i < siblings.Count; i++)
            {
                var sibling = siblings[i];
                elementIndex += 1;

                if (sibling == node)
                {
                    ownIndex = elementIndex;
                    continue;
                }
                if (needsNthChild) { continue; }
                if(sibling.TagName.ToLower() != nodeName) { continue; }

                needsClassNames = true;
                var ownClassNames = prefixedOwnClassNamesArray.ToList();
                var ownClassNameCount = ownClassNames.Count;
                if(ownClassNameCount == 0)
                {
                    needsNthChild = true;
                    continue;
                }

                var siblingClassNamesArray = prefixedElementClassNames(sibling);
                for (int j = 0; j < siblingClassNamesArray.Count; j++)
                {
                    var siblingClass = siblingClassNamesArray[j];
                    if(!ownClassNames.Contains(siblingClass))
                    {
                        continue;
                    }
                    ownClassNames.Remove(siblingClass);
                    if(--ownClassNameCount < 1)
                    {
                        needsNthChild = true;
                        break;
                    }
                }
            }

            var result = nodeName;
            if(isTargetNode && nodeName == "input" && !string.IsNullOrEmpty(node.GetAttribute("type")) && string.IsNullOrEmpty(node.Id) && string.IsNullOrEmpty(node.GetAttribute("class")))
            {
                result += "[type=\"" + node.GetAttribute("type") + "\"]";
            }
            if(needsNthChild)
            {
                result += ":nth-child(" + (ownIndex + 1) + ")";
            }
            else if(needsClassNames)
            {
                result += string.Join("", prefixedOwnClassNamesArray.Select(c => "." + EscapeIdentifierIfNeeded(c.Substring(1))));
            }

            step = result;

            return false;
        }

        private static List<string> prefixedElementClassNames(HtmlElement node)
        {
            var classAttr = node.GetAttribute("classname");

            if(string.IsNullOrEmpty(classAttr))
            {
                return new List<string>();
            }

            return classAttr.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(c => "$" + c).ToList();
        }

        private static string IdSelector(string id)
        {
            return "#" + EscapeIdentifierIfNeeded(id);
        }

        private static string EscapeIdentifierIfNeeded(string ident)
        {
            if (IsCssIdentifier(ident))
            {
                return ident;
            }

            var shouldEscapeFirst = Regex.IsMatch(ident, "^(?:[0-9]|-[0-9-]?)");
            var lastIndex = ident.Length - 1;

            return string.Join("", ident.Select((c, i) => shouldEscapeFirst && i == 0 || IsCssIdentChar(c) ? EscapeAsciiChar(c, i == lastIndex) : c.ToString()));
        }

        private static string EscapeAsciiChar(char c, bool isLast)
        {
            return "\\" + ToHexByte(c) + (isLast ? "" : " ");
        }

        private static string ToHexByte(char c)
        {
            var hexByte = ((byte)c).ToString("x");
            if(hexByte.Length == 1)
            {
                hexByte = "0" + hexByte;
            }
            return hexByte;
        }

        private static bool IsCssIdentChar(char c)
        {
            if(Regex.IsMatch(c.ToString(), "[a-zA-Z0-9_-]"))
            {
                return true;
            }

            return (byte)c >= 0xa0;
        }

        private static bool IsCssIdentifier(string c)
        {
            return Regex.IsMatch(c, "^-?[a-zA-Z_][a-zA-Z0-9_-]*$");
        }

        #endregion
    }
}
