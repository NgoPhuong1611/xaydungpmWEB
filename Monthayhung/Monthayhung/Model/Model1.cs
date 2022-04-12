using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Monthayhung.Model
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model11")
        {
        }

        public virtual DbSet<Dathang> Dathang { get; set; }
        public virtual DbSet<Sanpham> Sanpham { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Thuonghieu> Thuonghieu { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Dathang>()
                .Property(e => e.Madonhang)
                .IsFixedLength();

            modelBuilder.Entity<Dathang>()
                .Property(e => e.Matk)
                .IsFixedLength();

            modelBuilder.Entity<Dathang>()
                .Property(e => e.Masp)
                .IsFixedLength();

            modelBuilder.Entity<Sanpham>()
                .Property(e => e.Masp)
                .IsFixedLength();

            modelBuilder.Entity<Sanpham>()
                .Property(e => e.Mathuonghieu)
                .IsFixedLength();

            modelBuilder.Entity<Sanpham>()
                .Property(e => e.Gia)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Sanpham>()
                .HasMany(e => e.Dathang)
                .WithRequired(e => e.Sanpham)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Thuonghieu>()
                .Property(e => e.Mathuonghieu)
                .IsFixedLength();

            modelBuilder.Entity<Thuonghieu>()
                .HasMany(e => e.Sanpham)
                .WithRequired(e => e.Thuonghieu)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Users>()
                .Property(e => e.Matk)
                .IsFixedLength();

            modelBuilder.Entity<Users>()
                .Property(e => e.SDT)
                .IsFixedLength();

            modelBuilder.Entity<Users>()
                .HasMany(e => e.Dathang)
                .WithRequired(e => e.Users)
                .WillCascadeOnDelete(false);
        }
    }
}
