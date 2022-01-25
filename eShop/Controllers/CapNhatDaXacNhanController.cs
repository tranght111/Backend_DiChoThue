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
    public class CapNhatDaXacNhanController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public CapNhatDaXacNhanController(IConfiguration configuration)
        {
            _configuration = configuration;
        }




        [HttpGet]
        // GET: api/CapNhatDaXacNhan/
        public JsonResult Get()
        {
            string query = @"
                        select * from TrangThaiDonHang";
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
        // POST api/CapNhatDaXacNhan
        [HttpPost]
        public JsonResult Post(TrangThaiDonHang ttdh)
        {
            string query = @"
                        insert into TrangThaiDonHang (NgayCapNhat, TrangThai, DonHangId) 
                        values (getdate(), 'Đã xác nhận', @DonHangId)";
            DataTable table = new DataTable();
            string SqlDataSource = _configuration.GetConnectionString("DefaultConnection");
            SqlDataReader myReader;
            using (SqlConnection myConn = new SqlConnection(SqlDataSource))
            {
                myConn.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myConn))
                {
                    myCommand.Parameters.AddWithValue("@DonHangId", ttdh.DonHangId);
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
