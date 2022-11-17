using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace FonProje.Models
{
    public partial class FonContext : DbContext
    {
        public FonContext()
            : base("name=FonContext")
        {
        }

        public virtual DbSet<Bagis> Bagis { get; set; }
        public virtual DbSet<ilceler> ilceler { get; set; }
        public virtual DbSet<iller> iller { get; set; }
        public virtual DbSet<Kategori> Kategori { get; set; }
        public virtual DbSet<Kullanici> Kullanici { get; set; }
        public virtual DbSet<Proje> Proje { get; set; }
        public virtual DbSet<Resim> Resim { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Video> Video { get; set; }
        public virtual DbSet<Yetki> Yetki { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bagis>()
                .Property(e => e.baslik)
                .IsUnicode(false);

            modelBuilder.Entity<Bagis>()
                .Property(e => e.resim)
                .IsUnicode(false);

            modelBuilder.Entity<Bagis>()
                .Property(e => e.aciklama)
                .IsUnicode(false);

            modelBuilder.Entity<Bagis>()
                .Property(e => e.bagis1)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Bagis>()
                .Property(e => e.link)
                .IsUnicode(false);

            modelBuilder.Entity<iller>()
                .HasMany(e => e.ilceler)
                .WithRequired(e => e.iller)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Kullanici>()
                .HasMany(e => e.Proje)
                .WithRequired(e => e.Kullanici)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Proje>()
                .Property(e => e.adi)
                .IsUnicode(false);

            modelBuilder.Entity<Proje>()
                .Property(e => e.kisa_aciklama)
                .IsUnicode(false);

            modelBuilder.Entity<Proje>()
                .Property(e => e.aciklama)
                .IsUnicode(false);

            modelBuilder.Entity<Proje>()
                .Property(e => e.kapak_resim)
                .IsUnicode(false);

            modelBuilder.Entity<Proje>()
                .Property(e => e.toplanan)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Proje>()
                .Property(e => e.hedef)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Resim>()
                .Property(e => e.resim1)
                .IsUnicode(false);

            modelBuilder.Entity<Video>()
                .Property(e => e.video1)
                .IsUnicode(false);
        }
    }
}
