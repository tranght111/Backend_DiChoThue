using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eShop.Entities
{
    public partial class DonHang
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int DonHangId { get; set; }
        public DateTime NgayDat { get; set; }
        public float PhiShip { get; set; }
        public float TongTien { get; set; }
        public string HinhThucThanhToan { get; set; }
        public int NguoiBanId { get; set; } //fk
        public NguoiBan NguoiBan { get; set; }
        public int KhachHangId { get; set; } //fk
        public KhachHang KhachHang { get; set; }
        public List<ChiTietDonHang> ChiTietDonHangs { get; set; }
        public DanhGiaDonHang DanhGiaDonHang { get; set; }
        public ThanhToan ThanhToan { get; set; }
        public List<TrangThaiDonHang> TrangThaiDonHangs { get; set; }
        public ChiTietDonHang chitietdh { get; set; }
        public int SoLuong { get; set; }
        public int SanPhamId { get; set; }
    }
}
