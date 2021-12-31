using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eShop.Entities
{
    public partial class NhanVien
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int IDNhanVien { get; set; }
        public string ChucVu { get; set; }
        [ForeignKey("NguoiDung")]
        public string CMND { get; set; }
        public NguoiDung NguoiDung { get; set; }
    }
}
