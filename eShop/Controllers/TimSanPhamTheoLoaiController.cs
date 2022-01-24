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
    public class TimSanPhamTheoLoaiController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public TimSanPhamTheoLoaiController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public JsonResult Get(ThamSoTimKiem tenloai) //  tim sp theo loai sp
        {
            string query = @"
                        select sp.TenSP, sp.GiaSP, sp.DonViTinh, sp.SoLuongTon, sp.DiemTB, 
                        ng.TenCuaHang
                        from [dbo].[SanPham] sp, [dbo].[LoaiSanPham] lsp, [dbo].[NguoiBan] ng
                        where sp.IDLoaiSP= lsp.IDLoaiSP and lsp.TenLoaiSP=@TenLoai and sp.IDNguoiBan=ng.IDNguoiBan";
            DataTable table = new DataTable();
            string SqlDataSource = _configuration.GetConnectionString("DefaultConnection");
            SqlDataReader myReader;
            using (SqlConnection myConn = new SqlConnection(SqlDataSource))
            {
                myConn.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myConn))
                {
                    myCommand.Parameters.AddWithValue("@TenLoai", tenloai.LoaiSanPham);
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
