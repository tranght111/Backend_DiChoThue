using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eShop.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace eShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChiTietGioHangController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly ModelContext _context;

        public ChiTietGioHangController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // GET: api/ChiTietGioHang
        [HttpGet]
        public JsonResult Get()
        {
            string query = @"
                        select distinct sp.TenSP, sp.GiaSP, sp.DonViTinh, sp.MoTa, lsp.TenLoaiSP, ct.SoLuong
                        from dbo.ChiTietGioHang ct, dbo.SanPham sp, dbo.LoaiSanPham lsp, dbo.KhachHang kh, dbo.[User] u
                        where ct.SanPhamId=sp.SanPhamId and sp.LoaiSanPhamIDLoaiSP=lsp.IDLoaiSP and ct.KhachHangId=kh.KhachHangId and kh.CMND=u.CMND";
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

        // POST: api/ChiTietGioHang
        [HttpPost]
        public JsonResult Post(ChiTietGioHang ct)
        {
            string query = @"
                        insert into dbo.ChiTietGioHang(KhachHangId, SanPhamId, SoLuong) values (@idKH, @idSP, 1)";
            DataTable table = new DataTable();
            string SqlDataSource = _configuration.GetConnectionString("DefaultConnection");
            SqlDataReader myReader;
            using (SqlConnection myConn = new SqlConnection(SqlDataSource))
            {
                myConn.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myConn))
                {
                    myCommand.Parameters.AddWithValue("@idKH", ct.KhachHangId);
                    myCommand.Parameters.AddWithValue("@idSP", ct.SanPhamId);
                    // myCommand.Parameters.AddWithValue("@soluong", ct.SoLuong);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myConn.Close();
                }
            }
            return new JsonResult("success");
        }

        // DELETE api/ChiTietGioHang
        [HttpDelete]
        public JsonResult Delete(ChiTietGioHang ct)
        {
            string query = @"exec XoaGioHang @maKH, @maSP";
            DataTable table = new DataTable();
            string SqlDataSource = _configuration.GetConnectionString("DefaultConnection");
            SqlDataReader myReader;
            using (SqlConnection myConn = new SqlConnection(SqlDataSource))
            {
                myConn.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myConn))
                {
                    myCommand.Parameters.AddWithValue("@maKH", ct.KhachHangId);
                    myCommand.Parameters.AddWithValue("@maSP", ct.SanPhamId);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myConn.Close();
                }
            }
            return new JsonResult("success");
        }
    }
}
