namespace WebApplication2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DropHistories
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public int WeaponId { get; set; }

        public int CaseId { get; set; }

        public virtual Cases Cases { get; set; }

        public virtual Weapons Weapons { get; set; }
    }
}
