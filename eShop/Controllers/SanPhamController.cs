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
    public class SanPhamController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public SanPhamController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        // GET: api/SanPham/
        public JsonResult Get()
        {
            string query = @"
                        select * from SanPham";
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
        // POST api/sanpham
        [HttpPost]
        public JsonResult Post(SanPham sp)
        {
            string query = @"
                        insert into SanPham ( TenSP, GiaSP, DonViTinh, MoTa, SoLuongTon, LoaiSanPhamIDLoaiSP) 
                        values (@TenSP, @GiaSP, @DonViTinh, @MoTa, @SoLuongTon, @LoaiSanPhamId)";
            DataTable table = new DataTable();
            string SqlDataSource = _configuration.GetConnectionString("DefaultConnection");
            SqlDataReader myReader;
            using (SqlConnection myConn = new SqlConnection(SqlDataSource))
            {
                myConn.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myConn))
                {
                    myCommand.Parameters.AddWithValue("@TenSP", sp.TenSP);
                    myCommand.Parameters.AddWithValue("@GiaSP", sp.GiaSP);
                    myCommand.Parameters.AddWithValue("@DonViTinh", sp.DonViTinh);
                    myCommand.Parameters.AddWithValue("@MoTa", sp.MoTa);
                    myCommand.Parameters.AddWithValue("@SoLuongTon", sp.SoLuongTon);
                    myCommand.Parameters.AddWithValue("@LoaiSanPhamId", sp.LoaiSanPhamId);
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
