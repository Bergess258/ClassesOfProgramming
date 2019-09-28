namespace WebApplication2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class possSkinsInCases
    {
        public int Id { get; set; }

        public int? Caseid { get; set; }

        public int? Weaponid { get; set; }

        public virtual Cases Cases { get; set; }

        public virtual Weapons Weapons { get; set; }
    }
}
