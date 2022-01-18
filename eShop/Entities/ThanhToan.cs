using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eShop.Entities
{
    public partial class ThanhToan
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int ThanhToanId { get; set; }
        [ForeignKey("NguoiDung")]
        public string CMND { get; set; }
        public NguoiDung NguoiDung { get; set; }
        public string STK { get; set; }
        public DateTime NgayThanhToan { get; set; }
        public int DonHangId { get; set; } //fk
        public DonHang DonHang { get; set; }
        public string NganHang { get; set; }
    }
}
