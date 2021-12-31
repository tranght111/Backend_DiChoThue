using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eShop.Entities
{
    public partial class LoaiSanPham
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int LoaiSanPhamId { get; set; }
        public string TenLoaiSP { get; set; } //fk
        public List<SanPham> SanPhams { get; set; }
    }
}
