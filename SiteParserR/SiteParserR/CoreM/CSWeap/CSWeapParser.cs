using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AngleSharp.Html.Dom;

namespace Parser.Core.Habra
{
    class CSWeapParser : IParser<string[]>
    {
        public string[] Parse(IHtmlDocument document)
        {
            var list  = new List<string>();
            var items = document.QuerySelectorAll("h3").Where(item => item.ClassName != null && item.ClassName.Contains("weapon_section_name"));

            foreach(var item in items)
            {
                list.Add((item.Children[0] as IHtmlAnchorElement).PathName);
            }
            return list.ToArray();
        }
    }
}
