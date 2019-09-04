namespace WebApplication2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DropHistory")]
    public partial class DropHistory
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Required]
        [StringLength(128)]
        public string UserId { get; set; }

        public int WeaponId { get; set; }

        public int CaseId { get; set; }

        public virtual Case Case { get; set; }

        public virtual Weapon Weapon { get; set; }
    }
}
