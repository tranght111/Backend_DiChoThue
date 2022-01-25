using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace eShop.Entities
{
    [Table("User")]
    public partial class NguoiDung
    {
       [Key]
        public string CMND { get; set; }
        public string HoTen { get; set; }
        public DateTime NgayCapCMND { get; set; } //Ngày cấp CMND
        public string NoiCapCMND { get; set; } //Nơi cấp CNMD
        public DateTime NgaySinh { get; set; }
        public string DiaChi { get; set; }
        public string Email { get; set; }
        public string SoDienThoai { get; set; }
        public string CapDoVung { get; set; }
        public string GioiTinh { get; set; }
        public string ImageAvatar { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string TrangThai { get; set; }
        public NguoiBan NguoiBan { get; set; }
        public NhanVien NhanVien { get; set; }
        public Shipper Shipper { get; set; }
        public KhachHang KhachHang { get; set; }
        public List<ThanhToan> ThanhToan { get; set; }
        public string New_Password { get; set; }
        public DataTable Usertable { set; get; }
    }
}
