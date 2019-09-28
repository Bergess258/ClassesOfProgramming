using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class CaseListForCB
    {
        public Cases[] Cases { get; set; }
        public bool[] selected { get; set; }
    }

    public class caseManagment
    {
        public Cases Case { get; set;}
        public List<Weapons> Weapon { get; set; }
        public bool[] weaponSelect { get; set; }
    }
}