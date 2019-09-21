using AngleSharp.Html.Dom;
using Parser.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteParserR.CoreM.CSWeap
{
    class SinglWeapParser : IParser<string[,]>
    {
        public string[,] Parse(IHtmlDocument document)
        {
            var listSkinsNames = new List<string>();
            string weapName  = document.QuerySelectorAll("h1").Where(item => item.ClassName != null && item.ClassName.Contains("margin-top-sm")).First().TextContent;
            string[] temp = weapName.Split(' ');
            weapName = temp[1];
            if(temp.Length>2)
                for (int i = 2; i < temp.Length; i++)
                {
                    weapName += " " + temp[i];
                }
            var skinsNames = document.QuerySelectorAll("h3").Where(item => item.ParentElement.ClassName != null && item.ParentElement.ClassName.Contains("well result-box-skins nomargin"));
            var imgsLinks = document.QuerySelectorAll("a").Where(item => item.ParentElement.ClassName != null && item.ParentElement.ClassName.Contains("well result-box-skins nomargin"));
            string[,] result = new string[skinsNames.Count()+1, 2];
            result[0, 0] = weapName;
            int c = 1;
            foreach(var item in skinsNames)
            {
                result[c++, 0] = item.TextContent;
            }
            c = 1;
            foreach(var item in imgsLinks)
            {
                result[c++, 1] = "https://csgohub.ru" + (item as IHtmlAnchorElement).PathName;
            }
            return result;
        }
    }
}
