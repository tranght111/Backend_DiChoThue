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
    public class ShipperController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly ModelContext _context;
        public ShipperController(IConfiguration configuration, ModelContext context)
        {
            _configuration = configuration;
            _context = context;
        }

        [HttpGet]
        // GET: api/Shipper/
        public JsonResult Get()
        {
            string query = @"
                        select CapDoVung, count(*) as SoLuong from Shipper s, [dbo].[User] u where s.CMND = u.CMND group by u.CapDoVung";
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

        //Post: api/Shipper
        [HttpPost]
        public async Task<ActionResult<ShipperController>> AddUser(Shipper shipper)
        {

            _context.Shipper.Add(shipper);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Get", new { id = shipper.CMND }, shipper);
        }
    }
}