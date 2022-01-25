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
    public class TinhLuongShipperController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public TinhLuongShipperController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost]
        // Post: api/TinhLuongShipper/
        public JsonResult Post(LuongShipper lshipper)
        {
            string query = @" exec TinhLuongShipper @IDShipper, @Thang, @Nam";
            DataTable table = new DataTable();
            string SqlDataSource = _configuration.GetConnectionString("DefaultConnection");
            SqlDataReader myReader;
            using (SqlConnection myConn = new SqlConnection(SqlDataSource))
            {
                myConn.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myConn))
                {
                    myCommand.Parameters.AddWithValue("@IDShipper", lshipper.ShipperId);
                    myCommand.Parameters.AddWithValue("@Thang", lshipper.Thang);
                    myCommand.Parameters.AddWithValue("@Nam", lshipper.Nam);
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
