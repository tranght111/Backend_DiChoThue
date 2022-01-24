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
    public class DoanhThuChuDauTuController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        string query;
        public DoanhThuChuDauTuController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        // GET: api/DoanhThuChuDauTu/
        public JsonResult GET(ThamSoThongKeDoanhThu t)
        {
            //string StoredProc = "exec ThongKeDoanhThu " +
            //"@Month = " + t.Month + "," +
            //"@Quarter = '" + t.Quarter + "'," +
            //"@Year= '" + t.Year + "'," +
            //"@IDNguoiBan= '" + t.IDNguoiBan + "'";

            if (t.Quarter == 0 && t.Month != 0 && t.Year != 0)
            {
                query = @"select sum (d.PhiHoaHong) as DoanhThuThang from [dbo].[PhiHoaHongNguoiBan] d 
                    where d.Thang = @Month and d.Nam = @Year";
            }
            if (t.Quarter != 0 && t.Month == 0 && t.Year != 0)
            {
                if (t.Quarter == 1)
                    query = @"select sum(d.PhiHoaHong) as DoanhThuQuy
                            from [dbo].[PhiHoaHongNguoiBan] d
                            where(d.Thang = 1 OR d.Thang = 2 OR d.Thang = 3) and d.Nam = @Year";
                if (t.Quarter == 2)
                    query = @"select sum(d.PhiHoaHong) as DoanhThuQuy
                    from [dbo].[PhiHoaHongNguoiBan] d
                    where(d.Thang = 4 OR d.Thang = 5 OR d.Thang = 6) and d.Nam = @Year";
                if (t.Quarter == 3)
                    query = @"select sum(d.PhiHoaHong) as DoanhThuQuy
                    from [dbo].[PhiHoaHongNguoiBan] d
                    where(d.Thang = 7 OR d.Thang = 8 OR d.Thang = 9) and d.Nam = @Year";
                if (t.Quarter == 4)
                    query = @"select sum(d.PhiHoaHong) as DoanhThuQuy
                    from [dbo].[PhiHoaHongNguoiBan] d
                    where(d.Thang = 10 OR d.Thang = 11 OR d.Thang = 12) and d.Nam = @Year";
            }
            if (t.Quarter == 0 && t.Month == 0 && t.Year != 0)
                query = @"select sum(d.PhiHoaHong) as DoanhThuNam
                from [dbo].[PhiHoaHongNguoiBan] d
                where d.Nam = @Year";
            DataTable table = new DataTable();
            string SqlDataSource = _configuration.GetConnectionString("DefaultConnection");
            SqlDataReader myReader;
            using (SqlConnection myConn = new SqlConnection(SqlDataSource))
            {
                myConn.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myConn))
                {
                    myCommand.Parameters.AddWithValue("@Month", t.Month);
                    myCommand.Parameters.AddWithValue("@Quarter", t.Quarter);
                    myCommand.Parameters.AddWithValue("@Year", t.Year);
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
