using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eShop.Entities
{
    public partial class Shipper
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int ShipperId { get; set; }
        public int HoSoDangKyShipperId { get; set; }
        public HoSoDangKyShipper HoSoDangKyShipper { get; set; }
        [ForeignKey("NguoiDung")]
        public string CMND { get; set; } //fk
        public NguoiDung NguoiDung { get; set; }
        public List<LuongShipper> LuongShippers { get; set; }
        
    }
}
