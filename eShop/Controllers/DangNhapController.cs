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
    public class DangNhapController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public DangNhapController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet] // Dang Nhap

        public JsonResult Get(NguoiDung ngd)
        {
            string query = @"
                        select CMND, Vaitro from [dbo].[DangNhap] (@username, @password)";
            DataTable table = new DataTable();
            string SqlDataSource = _configuration.GetConnectionString("DefaultConnection");
            SqlDataReader myReader;
            using (SqlConnection myConn = new SqlConnection(SqlDataSource))
            {
                myConn.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myConn))
                {

                    myCommand.Parameters.AddWithValue("@username", ngd.Username);
                    myCommand.Parameters.AddWithValue("@password", ngd.Password);
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
