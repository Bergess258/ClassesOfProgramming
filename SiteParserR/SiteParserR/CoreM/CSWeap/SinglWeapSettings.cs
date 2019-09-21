using Parser.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteParserR.CoreM.CSWeap
{
    class SinglWeapSettings : IParserSettings
    {

        public string BaseUrl { get; set; } = "https://csgohub.ru";

        public string Prefix { get; set; } = "{CurrentId}";
    }
}
