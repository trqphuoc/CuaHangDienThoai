// AppDbContext.cs
using Microsoft.EntityFrameworkCore;
using CuaHangDienThoai.Models;

namespace CuaHangDienThoai.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<NguoiDung> NguoiDungs { get; set; }
        public DbSet<DanhMuc> DanhMucs { get; set; }
        public DbSet<SanPham> SanPhams { get; set; }
        public DbSet<DonHang> DonHangs { get; set; }
        public DbSet<ChiTietDonHang> ChiTietDonHangs { get; set; }
        public DbSet<DanhGia> DanhGias { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SanPham>()
                .HasOne(s => s.DanhMuc)
                .WithMany(d => d.SanPhams)
                .HasForeignKey(s => s.Id_DanhMuc)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<DonHang>()
                .HasOne(d => d.NguoiDung)
                .WithMany(n => n.DonHangs)
                .HasForeignKey(d => d.Id_NguoiDung)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ChiTietDonHang>()
                .HasOne(c => c.DonHang)
                .WithMany(d => d.ChiTietDonHangs)
                .HasForeignKey(c => c.Id_DonHang);

            modelBuilder.Entity<ChiTietDonHang>()
                .HasOne(c => c.SanPham)
                .WithMany(s => s.ChiTietDonHangs)
                .HasForeignKey(c => c.Id_SanPham);

            modelBuilder.Entity<DanhGia>()
                .HasOne(d => d.NguoiDung)
                .WithMany(n => n.DanhGias)
                .HasForeignKey(d => d.Id_NguoiDung)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<DanhGia>()
                .HasOne(d => d.SanPham)
                .WithMany(s => s.DanhGias)
                .HasForeignKey(d => d.Id_SanPham)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<DanhGia>()
                .HasOne(d => d.DonHang)
                .WithMany(h => h.DanhGias)
                .HasForeignKey(d => d.Id_DonHang)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<DanhGia>()
                .HasCheckConstraint("CK_DanhGia_SoSao", "[So_Sao] BETWEEN 1 AND 5");

            base.OnModelCreating(modelBuilder);
        }
    }
}
