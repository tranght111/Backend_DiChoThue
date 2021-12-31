using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eShop.Entities
{
    public partial class DanhGiaSanPham
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int DanhGiaSanPhamId { get; set; }
        public DateTime NgayDanhGia { get; set; }
        public string NoiDung { get; set; }
        public float Diem { get; set; }
        public int ChiTietDonHangId { get; set; } //fk 
        public ChiTietDonHang ChiTietDonHang { get; set; }
    }
}
