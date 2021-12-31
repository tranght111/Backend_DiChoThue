using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eShop.Entities
{
    public partial class HoSoDangKyShipper
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int HoSoDangKyShipperId { get; set; }
        public string HoTen { get; set; }
        public string CMND { get; set; }
        public string DiaChi { get; set; }
        public string Email { get; set; }
        public string SDT { get; set; }
        public string ImagesGiayXN { get; set; }
        public string ImagesChungNhanTiemVX { get; set; }
        public string TrangThai { get; set; }
        public Shipper Shipper { get; set; }
    }
}
