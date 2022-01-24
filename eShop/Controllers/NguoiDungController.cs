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
    public class NguoiDungController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly ModelContext _context;

        public NguoiDungController(IConfiguration configuration, ModelContext context)
        {
            _configuration = configuration;
            _context = context;
        }
        
        //GET: api/NguoiDung
        [HttpGet]
        /*public IEnumerable<NguoiDung> Get()
        {
            return _context.NguoiDung.ToList();
        }*/

        // GET: api/NguoiDung/
        public JsonResult Get()
        {
            string query = @"
                        select CMND, HoTen, NgaySinh, Email, SoDienThoai, GioiTinh, Username, Password, TrangThai from dbo.[User]";
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

        //Update status
        [HttpPut]
        public JsonResult Put(NguoiDung ng)
        {
            string query = @"
                        update dbo.[User] set TrangThai = @status where CMND = @cmnd";
            DataTable table = new DataTable();
            string SqlDataSource = _configuration.GetConnectionString("DefaultConnection");
            SqlDataReader myReader;
            using (SqlConnection myConn = new SqlConnection(SqlDataSource))
            {
                myConn.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myConn))
                {
                    myCommand.Parameters.AddWithValue("@status", ng.TrangThai);
                    myCommand.Parameters.AddWithValue("@cmnd", ng.CMND);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myConn.Close();
                }
            }
            return new JsonResult("success");
        }
        // DELETE: api/NguoiDung/5
        [HttpDelete("{cmnd}")]
        /*public void Delete(int id)
        {
        
        }*/

        public JsonResult Delete(string cmnd)
        {
            string query = @"
                        delete from dbo.[User] where CMND = @cmnd";
            DataTable table = new DataTable();
            string SqlDataSource = _configuration.GetConnectionString("DefaultConnection");
            SqlDataReader myReader;
            using (SqlConnection myConn = new SqlConnection(SqlDataSource))
            {
                myConn.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myConn))
                {
                    myCommand.Parameters.AddWithValue("@cmnd", cmnd);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myConn.Close();
                }
            }
            return new JsonResult("success");
        }

        //Post: api/NguoiDung
        [HttpPost]
        public async Task<ActionResult<NguoiDungController>> AddUser(NguoiDung user)
        {

            _context.NguoiDung.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Get", new { id = user.CMND }, user);
        }
    }
}
