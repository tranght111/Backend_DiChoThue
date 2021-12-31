using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eShop.Entities
{
    public partial class HoSoDangKyBanHang
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int HoSoDangKyBanHangId { get; set; }
        public string HoTen { get; set; }
        public string CMND { get; set; }
        public string TenCuaHang { get; set; }
        public string DiaChi { get; set; }
        public string Email { get; set; }
        public string SDT { get; set; }
        public string ImageGiayPhepKD { get; set; }
        public string ImageGiayCNATVSTP { get; set; }
        public string TrangThai { get; set; }
        public NguoiBan NguoiBan { get; set; }
    }
}
