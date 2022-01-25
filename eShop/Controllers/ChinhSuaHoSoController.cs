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
    public class ChinhSuaHoSoController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly ModelContext _context;

        public ChinhSuaHoSoController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        //Update basic information
        [HttpPut]
        public JsonResult Put(NguoiDung ng)
        {
            string query = @"
                        update dbo.[User] set DiaChi=@address, Email=@mail, SoDienThoai=@sdt, NgaySinh=@dob, GioiTinh=@gender, CapDoVung=@capdovung
                        where CMND=@cmnd";
            DataTable table = new DataTable();
            string SqlDataSource = _configuration.GetConnectionString("DefaultConnection");
            SqlDataReader myReader;
            using (SqlConnection myConn = new SqlConnection(SqlDataSource))
            {
                myConn.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myConn))
                {
                    myCommand.Parameters.AddWithValue("@address", ng.DiaChi);
                    myCommand.Parameters.AddWithValue("@mail", ng.Email);
                    myCommand.Parameters.AddWithValue("@sdt", ng.SoDienThoai);
                    myCommand.Parameters.AddWithValue("@dob", ng.NgaySinh);
                    myCommand.Parameters.AddWithValue("@gender", ng.GioiTinh);
                    myCommand.Parameters.AddWithValue("@capdovung", ng.CapDoVung);
                    myCommand.Parameters.AddWithValue("@cmnd", ng.CMND);
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