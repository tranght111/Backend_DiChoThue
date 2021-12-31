using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eShop.Entities
{
    public partial class ChiTietDonHang
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int ChiTietDonHangId { get; set; }
        public int SoLuong { get; set; }
        public int SanPhamId { get; set; } //fk
        public SanPham SanPham { get; set; }
        public int DonHangId { get; set; } //fk
        public DonHang DonHang { get; set; }
        public DanhGiaSanPham DanhGiaSanPham { get; set; }
    }
}
