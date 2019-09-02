using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class CaseListForCB
    {
        public Case[] Cases { get; set; }
        public bool[] selected { get; set; }
    }
}