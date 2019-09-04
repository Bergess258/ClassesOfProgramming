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

        public virtual DbSet<Case> Case { get; set; }
        public virtual DbSet<DropHistory> DropHistory { get; set; }
        public virtual DbSet<possSkinsInCase> possSkinsInCase { get; set; }
        public virtual DbSet<Rare> Rare { get; set; }
        public virtual DbSet<SkinN> SkinN { get; set; }
        public virtual DbSet<Type> Type { get; set; }
        public virtual DbSet<WeapN> WeapN { get; set; }
        public virtual DbSet<Weapon> Weapon { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Case>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Case>()
                .HasMany(e => e.DropHistory)
                .WithRequired(e => e.Case)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SkinN>()
                .HasMany(e => e.Weapon)
                .WithRequired(e => e.SkinN)
                .HasForeignKey(e => e.SkinNameId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Type>()
                .HasMany(e => e.Weapon)
                .WithRequired(e => e.Type)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<WeapN>()
                .Property(e => e.Name)
                .IsFixedLength();

            modelBuilder.Entity<WeapN>()
                .HasMany(e => e.Weapon)
                .WithRequired(e => e.WeapN)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Weapon>()
                .HasMany(e => e.DropHistory)
                .WithRequired(e => e.Weapon)
                .WillCascadeOnDelete(false);
        }
    }
}
