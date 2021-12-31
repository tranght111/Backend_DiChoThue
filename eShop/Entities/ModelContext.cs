using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace eShop.Entities
{
    public partial class ModelContext : DbContext
    {

        public ModelContext(DbContextOptions<ModelContext> options) : base(options)
        {
        }

        //public DbSet<Account> Account { get; set; }
        //public DbSet<User> User { get; set; }
        public DbSet<ChiTietDonHang> ChiTietDonHang { get; set; }
        public DbSet<ChiTietGioHang> ChiTietGioHang { get; set; }
        public DbSet<DanhGiaDonHang> DanhGiaDonHang { get; set; }
        public DbSet<DanhGiaSanPham> DanhGiaSanPham { get; set; }
        public DbSet<DoanhThuNguoiBan> DoanhThuNguoiBan { get; set; }
        public DbSet<DonHang> DonHang { get; set; }
        public DbSet<HoSoDangKyBanHang> HoSoDangKyBanHang { get; set; }
        public DbSet<HoSoDangKyShipper> HoSoDangKyShipper { get; set; }
        public DbSet<ImageSanPham> ImageSanPham { get; set; }
        public DbSet<KhachHang> KhachHang { get; set; }
        public DbSet<LoaiSanPham> LoaiSanPham { get; set; }
        public DbSet<LuongShipper> LuongShipper { get; set; }
        public DbSet<NguoiBan> NguoiBan { get; set; }
        public DbSet<NguoiDung> NguoiDung { get; set; }
        public DbSet<NhanVien> NhanVien { get; set; }
        public DbSet<PhiHoaHongNguoiBan> PhiHoaHongNguoiBan { get; set; }
        public DbSet<SanPham> SanPham { get; set; }
        public DbSet<Shipper> Shipper { get; set; }
        public DbSet<ThanhToan> ThanhToan { get; set; }
        public DbSet<TrangThaiDonHang> TrangThaiDonHang { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ChiTietDonHang>().ToTable("ChiTietDonHang");
            modelBuilder.Entity<ChiTietGioHang>().ToTable("ChiTietGioHang");
            modelBuilder.Entity<DanhGiaDonHang>().ToTable("DanhGiaDonHang");
            modelBuilder.Entity<DanhGiaSanPham>().ToTable("DanhGiaSanPham");
            modelBuilder.Entity<DoanhThuNguoiBan>().ToTable("DoanhThuNguoiBan");
            modelBuilder.Entity<DonHang>().ToTable("DonHang");
            modelBuilder.Entity<HoSoDangKyBanHang>().ToTable("HoSoDangKyBanHang");
            modelBuilder.Entity<HoSoDangKyShipper>().ToTable("HoSoDangKyShipper");
            modelBuilder.Entity<ImageSanPham>().ToTable("ImageSanPham");
            modelBuilder.Entity<KhachHang>().ToTable("KhachHang");
            modelBuilder.Entity<LoaiSanPham>().ToTable("LoaiSanPham");
            modelBuilder.Entity<LuongShipper>().ToTable("LuongShipper");
            modelBuilder.Entity<NguoiBan>().ToTable("NguoiBan");
            modelBuilder.Entity<NguoiDung>().ToTable("User");
            modelBuilder.Entity<NhanVien>().ToTable("NhanVien");
            modelBuilder.Entity<PhiHoaHongNguoiBan>().ToTable("PhiHoaHongNguoiBan");
            modelBuilder.Entity<SanPham>().ToTable("SanPham");
            modelBuilder.Entity<Shipper>().ToTable("Shipper");
            modelBuilder.Entity<ThanhToan>().ToTable("ThanhToan");
            modelBuilder.Entity<TrangThaiDonHang>().ToTable("TrangThaiDonHang");
        }
    }
}
