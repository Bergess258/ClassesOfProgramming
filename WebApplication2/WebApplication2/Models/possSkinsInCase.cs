namespace WebApplication2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("possSkinsInCase")]
    public partial class possSkinsInCase
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public int? Caseid { get; set; }

        public int? Weaponid { get; set; }

        public virtual Case Case { get; set; }

        public virtual Weapon Weapon { get; set; }
    }
}
