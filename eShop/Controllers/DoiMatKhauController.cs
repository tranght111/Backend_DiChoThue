using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoiMatKhauController : ControllerBase
    {
    private readonly IConfiguration _configuration;
        public DoiMatKhauController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public JsonResult Put(NguoiDung ng)
        {
            string query = @"
                        update NguoiDung set Pass = @NewPass where Username = @username and Pass=@Pass";
            DataTable table = new DataTable();
            string SqlDataSource = _configuration.GetConnectionString("DefaultConnection");
            SqlDataReader myReader;
            using (SqlConnection myConn = new SqlConnection(SqlDataSource))
            {
                myConn.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myConn))
                {
                    myCommand.Parameters.AddWithValue("@NewPass", ng.New_Password);
                    myCommand.Parameters.AddWithValue("@Pass", ng.Password);
                    myCommand.Parameters.AddWithValue("@username", ng.Username);
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
}
