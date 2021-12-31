using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eShop.Entities
{ 
    public partial class KhachHang
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int KhachHangId { get; set; }

        [ForeignKey("NguoiDung")]
        public string CMND { get; set; }
        public NguoiDung NguoiDung { get; set; }
        public ChiTietGioHang ChiTietGioHang { get; set; }
        public List<DonHang> DonHangs { get; set; }
    }
}
