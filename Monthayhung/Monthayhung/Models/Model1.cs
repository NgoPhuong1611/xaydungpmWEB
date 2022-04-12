using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Monthayhung.Models
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<Dathang> Dathangs { get; set; }
        public virtual DbSet<Sanpham> Sanphams { get; set; }
        public virtual DbSet<Thuonghieu> Thuonghieux { get; set; }
        public virtual DbSet<User> Users { get; set; }

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
                .HasMany(e => e.Dathangs)
                .WithRequired(e => e.Sanpham)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Thuonghieu>()
                .Property(e => e.Mathuonghieu)
                .IsFixedLength();

            modelBuilder.Entity<Thuonghieu>()
                .HasMany(e => e.Sanphams)
                .WithRequired(e => e.Thuonghieu)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Matk)
                .IsFixedLength();

            modelBuilder.Entity<User>()
                .Property(e => e.SDT)
                .IsFixedLength();

            modelBuilder.Entity<User>()
                .HasMany(e => e.Dathangs)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);
        }
    }
}
