using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eShop.Entities
{
    public partial class ChiTietGioHang
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int ChiTietGioHangId { get; set; }
        public int KhachHangId { get; set; } //fk
        public KhachHang KhachHang { get; set; }
        public int SanPhamId { get; set; } //fk
        public SanPham SanPham { get; set; }
        public int SoLuong { get; set; }
        
    }
}
