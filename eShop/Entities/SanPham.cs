using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eShop.Entities
{
    public partial class SanPham
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int SanPhamId { get; set; }
        public string TenSP { get; set; }
        public float GiaSP { get; set; }
        public string DonViTinh { get; set; }
        public string MoTa { get; set; }
        public int SoLuongTon { get; set; }
        public float DiemTB { get; set; }
        public int LoaiSanPhamIDLoaiSP { get; set; }
        public LoaiSanPham LoaiSanPham { get; set; }
        public int NguoiBanId { get; set; }
        public NguoiBan NguoiBan { get; set; }
        public List<ChiTietDonHang> ChiTietDonHangs { get; set; }
        public List<ChiTietGioHang> ChiTietGioHang { get; set; }
        public List<ImageSanPham> ImageSanPhams { get; set; }
        public string masanpham { get; internal set; }
        public string maloaisanpham { get; internal set; }
    }
}
