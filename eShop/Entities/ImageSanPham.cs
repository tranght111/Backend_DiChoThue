using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eShop.Entities
{
    public partial class ImageSanPham
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int IDImageSP { get; set; }
        public string NameImageSP { get; set; }
        public string UrlImage { get; set; }
        public int SanPhamId { get; set; } //fk
        public SanPham SanPham { get; set; }
    }
}
