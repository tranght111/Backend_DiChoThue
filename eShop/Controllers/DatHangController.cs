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
        // GET: api/DatHang/
        public JsonResult Post(DonHang dh)
        {
            string query = @"
                        insert into DonHang(NgayDat, PhiShip, TongTien, HinhThucThanhToan, IDNguoiBan, IDKhachHang) 
                        values(getdate(), @PhiShip, @TongTien, @HinhThucThanhToan, @IDNguoiBan, @IDKhachHang)";
            DataTable table = new DataTable();
            string SqlDataSource = _configuration.GetConnectionString("DefaultConnection");
            SqlDataReader myReader;
            using (SqlConnection myConn = new SqlConnection(SqlDataSource))
            {
                myConn.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myConn))
                {
                    myCommand.Parameters.AddWithValue("@PhiShip", dh.PhiShip);
                    myCommand.Parameters.AddWithValue("@TongTien", dh.TongTien);
                    myCommand.Parameters.AddWithValue("@HinhThucThanhToan", dh.HinhThucThanhToan);
                    myCommand.Parameters.AddWithValue("@IDNguoiBan", dh.NguoiBanId);
                    myCommand.Parameters.AddWithValue("@IDKhachHang", dh.KhachHangId);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myConn.Close();
                }
            }

            string query2 = @"
                        insert into ChiTietDonHang(SoLuong, IDDonHang, IDSanPham) 
                        values(@SoLuong, @IDDonHang, @IDSanPham)";
            DataTable table2 = new DataTable();
            string SqlDataSource2 = _configuration.GetConnectionString("DefaultConnection");
            SqlDataReader myReader2;
            using (SqlConnection myConn = new SqlConnection(SqlDataSource2))
            {
                myConn.Open();
                using (SqlCommand myCommand = new SqlCommand(query2, myConn))
                {
                    myCommand.Parameters.AddWithValue("@SoLuong", dh.chitietdh.SoLuong);
                    myCommand.Parameters.AddWithValue("@IDSanPham", dh.chitietdh.SanPhamId);
                    myCommand.Parameters.AddWithValue("@IDDonHang", dh.DonHangId);
                    myReader2 = myCommand.ExecuteReader();
                    table2.Load(myReader2);
                    myReader2.Close();
                    myConn.Close();
                }
            }

            return new JsonResult("sucess");
        }
        [HttpGet] // xem ho so don hang

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
        }
    }
}
