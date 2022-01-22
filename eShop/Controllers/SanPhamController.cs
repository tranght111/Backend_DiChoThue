using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eShop.Entities;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;


namespace eShop.Controllers
{
    [Route("api/product")]
    [ApiController]
    public class SanPhamController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public SanPhamController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        // GET: api/product
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
        // POST api/product
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
