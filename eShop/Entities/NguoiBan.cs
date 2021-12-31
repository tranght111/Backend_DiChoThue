using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eShop.Entities
{
    public partial class NguoiBan
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int NguoiBanId { get; set; }
        public string TenCuaHang { get; set; }
        public int HoSoDangKyBanHangId { get; set; } //fk
        public HoSoDangKyBanHang HoSoDangKyBanHang { get; set; }

        [ForeignKey("NguoiDung")]
        public string CMND { get; set; }//fk
        public NguoiDung NguoiDung { get; set; }
        public List<SanPham> SanPhams { get; set; }
        public List<DoanhThuNguoiBan> DoanhThuNguoiBans { get; set; }
        public List<PhiHoaHongNguoiBan> PhiHoaHongNguoiBans { get; set; }
        public List<DonHang> DonHangs { get; set; }
    }
}
