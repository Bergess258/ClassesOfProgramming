namespace WebApplication2.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Base : DbContext
    {
        public Base()
            : base("name=Base")
        {
        }

        public virtual DbSet<Cases> Cases { get; set; }
        public virtual DbSet<DropHistories> DropHistories { get; set; }
        public virtual DbSet<possSkinsInCases> possSkinsInCases { get; set; }
        public virtual DbSet<Rares> Rares { get; set; }
        public virtual DbSet<SkinNs> SkinNs { get; set; }
        public virtual DbSet<Types> Types { get; set; }
        public virtual DbSet<TypeWeapImgs> TypeWeapImgs { get; set; }
        public virtual DbSet<WeapNs> WeapNs { get; set; }
        public virtual DbSet<Weapons> Weapons { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cases>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Cases>()
                .HasMany(e => e.DropHistories)
                .WithRequired(e => e.Cases)
                .HasForeignKey(e => e.CaseId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Cases>()
                .HasMany(e => e.possSkinsInCases)
                .WithOptional(e => e.Cases)
                .HasForeignKey(e => e.Caseid);

            modelBuilder.Entity<Rares>()
                .HasMany(e => e.Weapons)
                .WithRequired(e => e.Rares)
                .HasForeignKey(e => e.RareId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SkinNs>()
                .HasMany(e => e.Weapons)
                .WithRequired(e => e.SkinNs)
                .HasForeignKey(e => e.SkinNameId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Types>()
                .HasMany(e => e.TypeWeapImgs)
                .WithOptional(e => e.Types)
                .HasForeignKey(e => e.TypeId);

            modelBuilder.Entity<Types>()
                .HasMany(e => e.Weapons)
                .WithRequired(e => e.Types)
                .HasForeignKey(e => e.TypeId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<WeapNs>()
                .Property(e => e.Name)
                .IsFixedLength();

            modelBuilder.Entity<WeapNs>()
                .HasMany(e => e.Weapons)
                .WithRequired(e => e.WeapNs)
                .HasForeignKey(e => e.WeapNId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Weapons>()
                .HasMany(e => e.DropHistories)
                .WithRequired(e => e.Weapons)
                .HasForeignKey(e => e.WeaponId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Weapons>()
                .HasMany(e => e.possSkinsInCases)
                .WithOptional(e => e.Weapons)
                .HasForeignKey(e => e.Weaponid);

            modelBuilder.Entity<Weapons>()
                .HasMany(e => e.TypeWeapImgs)
                .WithOptional(e => e.Weapons)
                .HasForeignKey(e => e.WeapId);
        }
    }
}
