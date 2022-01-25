using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using eShop.Entities;

namespace eShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DatHangController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public DatHangController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpPost]
        // Post: api/DatHang/
        public JsonResult Post(DonHang dh)
        {
            string query = @" exec DatHang @PhiShip, @HinhThucThanhToan, @IDNguoiBan, @IDKhachHang,@SoLuong, @IDSanPham";
            DataTable table = new DataTable();
            string SqlDataSource = _configuration.GetConnectionString("DefaultConnection");
            SqlDataReader myReader;
            using (SqlConnection myConn = new SqlConnection(SqlDataSource))
            {
                myConn.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myConn))
                {
                    myCommand.Parameters.AddWithValue("@PhiShip", dh.PhiShip);
                    myCommand.Parameters.AddWithValue("@HinhThucThanhToan", dh.HinhThucThanhToan);
                    myCommand.Parameters.AddWithValue("@IDNguoiBan", dh.NguoiBanId);
                    myCommand.Parameters.AddWithValue("@IDKhachHang", dh.KhachHangId);
                    myCommand.Parameters.AddWithValue("@SoLuong", dh.SoLuong);
                    myCommand.Parameters.AddWithValue("@IDSanPham", dh.SanPhamId);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myConn.Close();
                }
            }

            return new JsonResult("sucess");
        }
        /*[HttpGet] // xem don hang
        
        public JsonResult Get()
        {
            string query = @"
                        select dh.IDDonHang, dh.NgayDat, dh.PhiShip, dh.TongTien, dh.HinhThucThanhToan, 
                        dh.IDNguoiBan, dh.IDKhachHang, ct.SoLuong, ct.IDSanPham
                        from DonHang dh, ChiTietDonHang ct
                        where dh.IDDonHang= ct.IDDonHang";
            DataTable table = new DataTable();
            string SqlDataSource = _configuration.GetConnectionString("DefaultConnection");
            SqlDataReader myReader;
            using (SqlConnection myConn = new SqlConnection(SqlDataSource))
            {
                myConn.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myConn))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myConn.Close();
                }
            }
            return new JsonResult(table);
        }*/
    }
}
