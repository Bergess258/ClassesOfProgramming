//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SiteParserR
{
    using System;
    using System.Collections.Generic;
    
    public partial class Weapons
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Weapons()
        {
            this.DropHistories = new HashSet<DropHistories>();
            this.possSkinsInCases = new HashSet<possSkinsInCases>();
            this.TypeWeapImgs = new HashSet<TypeWeapImgs>();
        }
    
        public int Id { get; set; }
        public int TypeId { get; set; }
        public int SkinNameId { get; set; }
        public byte[] Image { get; set; }
        public int WeapNId { get; set; }
        public double Price { get; set; }
        public int RareId { get; set; }
        public bool Startrack { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DropHistories> DropHistories { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<possSkinsInCases> possSkinsInCases { get; set; }
        public virtual Rares Rares { get; set; }
        public virtual SkinNs SkinNs { get; set; }
        public virtual Types Types { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TypeWeapImgs> TypeWeapImgs { get; set; }
        public virtual WeapNs WeapNs { get; set; }
    }
}
