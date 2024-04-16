using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Models.Framework
{
    public partial class FotosDbContext : DbContext
    {
        public FotosDbContext()
            : base("name=FotosDbContext")
        {
        }

        public virtual DbSet<Album> Albums { get; set; }
        public virtual DbSet<Anh_yeu_thich> Anh_yeu_thich { get; set; }
        public virtual DbSet<Danh_gia_album> Danh_gia_album { get; set; }
        public virtual DbSet<Danh_gia_anh> Danh_gia_anh { get; set; }
        public virtual DbSet<Giao_dich> Giao_dich { get; set; }
        public virtual DbSet<Luot_thich_album> Luot_thich_album { get; set; }
        public virtual DbSet<Luot_thich_anh> Luot_thich_anh { get; set; }
        public virtual DbSet<Nguoi_dung> Nguoi_dung { get; set; }
        public virtual DbSet<Photo> Photos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Album>()
                .HasMany(e => e.Giao_dich)
                .WithRequired(e => e.Album)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Giao_dich>()
                .Property(e => e.gia_tien)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Nguoi_dung>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<Nguoi_dung>()
                .Property(e => e.mat_khau_hashed)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Nguoi_dung>()
                .Property(e => e.salt)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Nguoi_dung>()
                .Property(e => e.so_dien_thoai)
                .IsUnicode(false);

            modelBuilder.Entity<Nguoi_dung>()
                .HasMany(e => e.Albums)
                .WithRequired(e => e.Nguoi_dung)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Nguoi_dung>()
                .HasMany(e => e.Anh_yeu_thich)
                .WithRequired(e => e.Nguoi_dung)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Nguoi_dung>()
                .HasMany(e => e.Danh_gia_album)
                .WithRequired(e => e.Nguoi_dung)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Nguoi_dung>()
                .HasMany(e => e.Danh_gia_anh)
                .WithRequired(e => e.Nguoi_dung)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Nguoi_dung>()
                .HasMany(e => e.Giao_dich)
                .WithRequired(e => e.Nguoi_dung)
                .HasForeignKey(e => e.id_nguoi_ban)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Nguoi_dung>()
                .HasMany(e => e.Giao_dich1)
                .WithRequired(e => e.Nguoi_dung1)
                .HasForeignKey(e => e.id_nguoi_mua)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Nguoi_dung>()
                .HasMany(e => e.Luot_thich_album)
                .WithRequired(e => e.Nguoi_dung)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Nguoi_dung>()
                .HasMany(e => e.Luot_thich_anh)
                .WithRequired(e => e.Nguoi_dung)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Nguoi_dung>()
                .HasMany(e => e.Photos)
                .WithRequired(e => e.Nguoi_dung)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Photo>()
                .Property(e => e.url_anh)
                .IsUnicode(false);

            modelBuilder.Entity<Photo>()
                .HasMany(e => e.Anh_yeu_thich)
                .WithOptional(e => e.Photo)
                .HasForeignKey(e => e.id_anh);

            modelBuilder.Entity<Photo>()
                .HasMany(e => e.Danh_gia_anh)
                .WithOptional(e => e.Photo)
                .HasForeignKey(e => e.id_anh);

            modelBuilder.Entity<Photo>()
                .HasMany(e => e.Luot_thich_anh)
                .WithOptional(e => e.Photo)
                .HasForeignKey(e => e.id_anh);
        }
    }
}
