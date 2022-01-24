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
    public class ThongKeNhuCauController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public ThongKeNhuCauController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public JsonResult Get() //  thong ke nhu cau thuc pham cung ky
        {
            string query = @"
                            Select sp.TenSP, Month (dh.NgayDat) as Thang, Year (dh.NgayDat) as Nam, Sum (ct.SoLuong) as TongBanRa, sp.DonViTinh
                            from [dbo].[DonHang] dh,[dbo].[ChiTietDonHang] ct, [dbo].[SanPham] sp
                            where dh.IDDonHang=ct.IDDonHang and sp.IDSanPham= ct.IDSanPham
                             group by sp.TenSP, sp.DonViTinh, Month (dh.NgayDat), Year (dh.NgayDat)";
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
