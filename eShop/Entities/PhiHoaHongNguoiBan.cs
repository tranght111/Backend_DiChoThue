using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eShop.Entities
{
    public partial class PhiHoaHongNguoiBan
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int PhiHoaHongNguoiBanId { get; set; }
        public float PhiHoaHong { get; set; }
        public int Thang { get; set; }
        public int Nam { get; set; }
        public int NguoiBanId { get; set; }//fk
        public NguoiBan NguoiBan { get; set; }
        public string TrangThai { get; set; }
    }
}
