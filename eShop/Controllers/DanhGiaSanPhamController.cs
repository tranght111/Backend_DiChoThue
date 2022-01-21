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
    public class DanhGiaSanPhamController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public DanhGiaSanPhamController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        // GET: api/DanhGiaSanPham/
        public JsonResult Get()
        {
            string query = @"
                        select * from DanhGiaSanPham";
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
        // POST api/danhgiasanpham
        [HttpPost]
        public JsonResult Post(DanhGiaSanPham dg)
        {
            string query = @"
                        insert into DanhGiaSanPham ( NoiDung, Diem, NgayDanhGia, ChiTietDonHangId) 
                        values (@NoiDung, @Diem, getdate(), @ChiTietDHID)";
            DataTable table = new DataTable();
            string SqlDataSource = _configuration.GetConnectionString("DefaultConnection");
            SqlDataReader myReader;
            using (SqlConnection myConn = new SqlConnection(SqlDataSource))
            {
                myConn.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myConn))
                {
                    myCommand.Parameters.AddWithValue("@NoiDung", dg.NoiDung);
                    myCommand.Parameters.AddWithValue("@Diem", dg.Diem);
                    myCommand.Parameters.AddWithValue("@ChiTietDHID", dg.ChiTietDonHangId);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myConn.Close();
                }
            }
            return new JsonResult("success");
        }

        [HttpDelete("{id}")]

        public JsonResult Delete(int id)
        {
            string query = @"
                        delete from dbo.[DanhGiaSanPham] where IDDanhGiaSP = @id";
            DataTable table = new DataTable();
            string SqlDataSource = _configuration.GetConnectionString("DefaultConnection");
            SqlDataReader myReader;
            using (SqlConnection myConn = new SqlConnection(SqlDataSource))
            {
                myConn.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myConn))
                {
                    myCommand.Parameters.AddWithValue("@id", id);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myConn.Close();
                }
            }
            return new JsonResult("success");
        }

        //Put api/danhgiasanpham
        [HttpPut]
        public JsonResult Put(DanhGiaSanPham dg)
        {
            string query = @"
                        update dbo.[DanhGiaSanPham] set NoiDung = @nd, Diem = @diem where IDDanhGiaSP = @id";
            DataTable table = new DataTable();
            string SqlDataSource = _configuration.GetConnectionString("DefaultConnection");
            SqlDataReader myReader;
            using (SqlConnection myConn = new SqlConnection(SqlDataSource))
            {
                myConn.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myConn))
                {
                    myCommand.Parameters.AddWithValue("@id", dg.IDDanhGiaSP);
                    myCommand.Parameters.AddWithValue("@nd", dg.NoiDung);
                    myCommand.Parameters.AddWithValue("@diem", dg.Diem);
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
