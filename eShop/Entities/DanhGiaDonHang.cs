using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eShop.Entities
{
    public partial class DanhGiaDonHang
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int DanhGiaDonHangId { get; set; }
        public DateTime NgayDanhGia { get; set; }
        public string NoiDung { get; set; }
        public int Diem { get; set; }
        public int DonHangId { get; set; } //fk
        public DonHang DonHang { get; set; }
    }
}
