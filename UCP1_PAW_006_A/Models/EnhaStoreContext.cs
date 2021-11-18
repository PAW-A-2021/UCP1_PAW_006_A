using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace UCP1_PAW_006_A.Models
{
    public partial class EnhaStoreContext : DbContext
    {
        public EnhaStoreContext()
        {
        }

        public EnhaStoreContext(DbContextOptions<EnhaStoreContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<DetailAlbum> DetailAlbums { get; set; }
        public virtual DbSet<Pembayaran> Pembayarans { get; set; }
        public virtual DbSet<Pemesanan> Pemesanans { get; set; }
        public virtual DbSet<Pengiriman> Pengirimen { get; set; }
        public virtual DbSet<SignIn> SignIns { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Admin>(entity =>
            {
                entity.HasKey(e => e.IdAdmin);

                entity.ToTable("Admin");

                entity.Property(e => e.IdAdmin)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Id_Admin");

                entity.Property(e => e.Nama)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.IdCustomer);

                entity.ToTable("Customer");

                entity.Property(e => e.IdCustomer)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Id_Customer");

                entity.Property(e => e.AlamatLengkap)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("Alamat_Lengkap");

                entity.Property(e => e.IdAlbum)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Id_Album");

                entity.Property(e => e.IdPembayaran)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Id_Pembayaran");

                entity.Property(e => e.IdPemesanan)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Id_Pemesanan");

                entity.Property(e => e.Nama)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NoHp)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("No_Hp");

                entity.Property(e => e.NoResi)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("No_Resi");

                entity.Property(e => e.Username)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdAlbumNavigation)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.IdAlbum)
                    .HasConstraintName("FK_Customer_Detail_Album");

                entity.HasOne(d => d.IdPembayaranNavigation)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.IdPembayaran)
                    .HasConstraintName("FK_Customer_Pembayaran");

                entity.HasOne(d => d.IdPemesananNavigation)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.IdPemesanan)
                    .HasConstraintName("FK_Customer_Pemesanan");

                entity.HasOne(d => d.NoResiNavigation)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.NoResi)
                    .HasConstraintName("FK_Customer_Pengiriman");

                entity.HasOne(d => d.UsernameNavigation)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.Username)
                    .HasConstraintName("FK_Customer_Sign_In");
            });

            modelBuilder.Entity<DetailAlbum>(entity =>
            {
                entity.HasKey(e => e.IdAlbum);

                entity.ToTable("Detail_Album");

                entity.Property(e => e.IdAlbum)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Id_Album");

                entity.Property(e => e.HargaAlbum).HasColumnName("Harga_Album");

                entity.Property(e => e.JenisAlbum)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Jenis_Album");

                entity.Property(e => e.PajakAlbum).HasColumnName("Pajak_Album");
            });

            modelBuilder.Entity<Pembayaran>(entity =>
            {
                entity.HasKey(e => e.IdPembayaran);

                entity.ToTable("Pembayaran");

                entity.Property(e => e.IdPembayaran)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Id_Pembayaran");

                entity.Property(e => e.BuktiPembayaran)
                    .HasColumnType("image")
                    .HasColumnName("Bukti_Pembayaran");

                entity.Property(e => e.JenisPembayaran)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Jenis_Pembayaran");

                entity.Property(e => e.TanggalPembayaran)
                    .HasColumnType("datetime")
                    .HasColumnName("Tanggal_Pembayaran");

                entity.Property(e => e.TotalHarga).HasColumnName("Total_Harga");
            });

            modelBuilder.Entity<Pemesanan>(entity =>
            {
                entity.HasKey(e => e.IdPemesanan);

                entity.ToTable("Pemesanan");

                entity.Property(e => e.IdPemesanan)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Id_Pemesanan");

                entity.Property(e => e.JenisAlbum)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Jenis_Album");

                entity.Property(e => e.JumlahAlbum).HasColumnName("Jumlah_Album");

                entity.Property(e => e.TanggalPemesanan)
                    .HasColumnType("datetime")
                    .HasColumnName("Tanggal_Pemesanan");

                entity.Property(e => e.TotalHarga).HasColumnName("Total_Harga");
            });

            modelBuilder.Entity<Pengiriman>(entity =>
            {
                entity.HasKey(e => e.NoResi);

                entity.ToTable("Pengiriman");

                entity.Property(e => e.NoResi)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("No_Resi");

                entity.Property(e => e.AlamatLengkap)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("Alamat_Lengkap");

                entity.Property(e => e.IdPembayaran)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Id_Pembayaran");

                entity.Property(e => e.JenisPengiriman)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Jenis_Pengiriman");

                entity.Property(e => e.StatusPengiriman)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("Status_Pengiriman");
            });

            modelBuilder.Entity<SignIn>(entity =>
            {
                entity.HasKey(e => e.Username);

                entity.ToTable("Sign_In");

                entity.Property(e => e.Username)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(12)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
