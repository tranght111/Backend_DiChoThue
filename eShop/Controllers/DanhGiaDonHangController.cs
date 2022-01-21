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
    public class DanhGiaDonHangController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public DanhGiaDonHangController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        // GET: api/DanhGiaDonHang/
        public JsonResult Get()
        {
            string query = @"
                        select * from DanhGiaDonHang";
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
        // POST api/danhgiadonhang
        [HttpPost]
        public JsonResult Post(DanhGiaDonHang dg)
        {
            string query = @"
                        insert into DanhGiaDonHang (NoiDung, Diem, DonHangId, NgayDanhGia) 
                        values (@nd, @diem, @donhangid, getdate())";
            DataTable table = new DataTable();
            string SqlDataSource = _configuration.GetConnectionString("DefaultConnection");
            SqlDataReader myReader;
            using (SqlConnection myConn = new SqlConnection(SqlDataSource))
            {
                myConn.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myConn))
                {
                    myCommand.Parameters.AddWithValue("@nd", dg.NoiDung);
                    myCommand.Parameters.AddWithValue("@diem", dg.Diem);
                    myCommand.Parameters.AddWithValue("@donhangid", dg.DonHangId);
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
