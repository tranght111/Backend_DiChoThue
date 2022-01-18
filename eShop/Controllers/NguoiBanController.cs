using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace eShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NguoiBanController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public NguoiBanController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        // GET: api/NguoiBan/
        public JsonResult Get()
        {
            string query = @"
                        select CapDoVung, count(*) as SoLuong from NguoiBan c, [dbo].[User] u where c.CMNND = u.CMND group by u.CapDoVung";
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

