namespace WebApplication2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TypeWeapImgs
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Column(TypeName = "image")]
        public byte[] Image { get; set; }

        public int? TypeId { get; set; }

        public int? WeapId { get; set; }

        public virtual Types Types { get; set; }

        public virtual Weapons Weapons { get; set; }
    }
}
