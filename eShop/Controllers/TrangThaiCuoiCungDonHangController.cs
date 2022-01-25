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
    public class TrangThaiCuoiCungDonHangController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public TrangThaiCuoiCungDonHangController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet] // Trạng thái cuối cùng của đơn hàng

        public JsonResult Get(TrangThaiDonHang ttdh)
        {
            string query = @"
                        select TrangThai from [dbo].[LayTrangThaiDonHang] (@DonHangId)";
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
            return new JsonResult(table);
        }
    }
}
