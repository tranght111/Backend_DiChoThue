using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eShop.Entities
{
    public partial class LuongShipper
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int LuongShipperId { get; set; }
        public int Thang { get; set; }
        public int Nam { get; set; }
        public float TongLuong { get; set; }
        public string TrangThai { get; set; }
        public DateTime NgayNhan { get; set; }
        public int ShipperId { get; set; } //fk
        public Shipper Shipper { get; set; }
    }
}
