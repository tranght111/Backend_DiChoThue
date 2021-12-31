using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eShop.Entities
{
    public partial class DoanhThuNguoiBan
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int DoanhThuNguoiBanId { get; set; }
        public int NguoiBanId { get; set; } //fk
        public NguoiBan NguoiBan { get; set; }
        public int Thang { get; set; }
        public int Nam { get; set; }
        public float DoanhThu { get; set; }
    }
}
