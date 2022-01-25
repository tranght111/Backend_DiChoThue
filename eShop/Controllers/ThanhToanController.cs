using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using eShop.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace eShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ThanhToanController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public ThanhToanController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost]
        // GET: api/ThanhToan/
        public JsonResult Post(ThanhToan t)
        {
            string query = @"
                        insert into ThanhToan(NguoiDungCMND, STK, NgayThanhToan, DonHangId, NganHang) values(@cmnd, @stk, getdate(), @donhang, @nganhang)";
            string query2 = @"
                        insert into TrangThaiDonHang(NgayCapNhat, TrangThai,DonHangId) values(getdate(), N'Đã xác nhận',  @donhang)";
            DataTable table = new DataTable();
            DataTable table2 = new DataTable();
            string SqlDataSource = _configuration.GetConnectionString("DefaultConnection");
            SqlDataReader myReader;
            SqlDataReader myReader2;
            using (SqlConnection myConn = new SqlConnection(SqlDataSource))
            {
                myConn.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myConn))
                {
                    myCommand.Parameters.AddWithValue("@cmnd", t.CMND);
                    myCommand.Parameters.AddWithValue("@stk", t.STK);
                    myCommand.Parameters.AddWithValue("@donhang", t.DonHangId);
                    myCommand.Parameters.AddWithValue("@nganhang", t.NganHang);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    //myReader.Close();
                    //myConn.Close();
                }
                using (SqlCommand myCommand2 = new SqlCommand(query2, myConn))
                {
                    myCommand2.Parameters.AddWithValue("@donhang", t.DonHangId);
                    myReader = myCommand2.ExecuteReader();
                    table2.Load(myReader);
                    myReader.Close();
                    myConn.Close();
                }
            }
            return new JsonResult("sucess");
        }
    }
}
