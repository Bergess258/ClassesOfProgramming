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
    
    public partial class TypeWeapImgs
    {
        public int Id { get; set; }
        public byte[] Image { get; set; }
        public Nullable<int> TypeId { get; set; }
        public Nullable<int> WeapId { get; set; }
    
        public virtual Types Types { get; set; }
        public virtual Weapons Weapons { get; set; }
    }
}
