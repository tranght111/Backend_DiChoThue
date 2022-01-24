using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eShop.Entities;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;


namespace eShop.Controllers
{
    [Route("api/product")]
    [ApiController]
    public class SanPhamController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public SanPhamController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // GET: api/product
        [HttpGet]
        public JsonResult Get()
        {
            string query = @"
                        select * from SanPham";
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

        //// GET: api/product/{id}
        //[HttpGet("{id}")]
        //public JsonResult Get(int id)
        //{
        //    string query = @"
        //                select * from SanPham where SanPhamId = @id";
        //    DataTable table = new DataTable();
        //    string SqlDataSource = _configuration.GetConnectionString("DefaultConnection");
        //    SqlDataReader myReader;
        //    using (SqlConnection myConn = new SqlConnection(SqlDataSource))
        //    {
        //        myConn.Open();
        //        using (SqlCommand myCommand = new SqlCommand(query, myConn))
        //        {
        //            myCommand.Parameters.AddWithValue("@id", id);
        //            myReader = myCommand.ExecuteReader();
        //            table.Load(myReader);
        //            myReader.Close();
        //            myConn.Close();
        //        }
        //    }
        //    return new JsonResult(table);
        //}

        // POST api/product
        [HttpPost]
        public JsonResult Post(SanPham sp)
        {
            string query = @"
                        insert into SanPham ( TenSP, HinhAnh, GiaSP, DonViTinh, MoTa, SoLuongTon, LoaiSanPhamIDLoaiSP, NguoiBanId, TrangThai) 
                        values (@TenSP, @HinhAnh, @GiaSP, @DonViTinh, @MoTa, @SoLuongTon, @LoaiSanPhamId, @NguoiBanId, @TrangThai)";
            DataTable table = new DataTable();
            string SqlDataSource = _configuration.GetConnectionString("DefaultConnection");
            SqlDataReader myReader;
            using (SqlConnection myConn = new SqlConnection(SqlDataSource))
            {
                myConn.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myConn))
                {
                    myCommand.Parameters.AddWithValue("@TenSP", sp.TenSP);
                    myCommand.Parameters.AddWithValue("@HinhAnh", sp.HinhAnh);
                    myCommand.Parameters.AddWithValue("@GiaSP", sp.GiaSP);
                    myCommand.Parameters.AddWithValue("@DonViTinh", sp.DonViTinh);
                    myCommand.Parameters.AddWithValue("@MoTa", sp.MoTa);
                    myCommand.Parameters.AddWithValue("@SoLuongTon", sp.SoLuongTon);
                    myCommand.Parameters.AddWithValue("@LoaiSanPhamId", sp.LoaiSanPhamIDLoaiSP);
                    myCommand.Parameters.AddWithValue("@NguoiBanId", sp.NguoiBanId);
                    myCommand.Parameters.AddWithValue("@TrangThai", sp.TrangThai);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myConn.Close();
                }
            }
            return new JsonResult("success");
        }

        //Put
        [HttpPut]
        public JsonResult Put(SanPham sp)
        {
            string query = @"
                        update dbo.[SanPham] set TenSP = @TenSP, HinhAnh = @HinhAnh, GiaSP = @GiaSP, DonViTinh = @DonViTinh, MoTa = @MoTa, 
                        SoLuongTon = @SoLuongTon, LoaiSanPhamIDLoaiSP = @LoaiSanPhamId, TrangThai = @TrangThai where SanPhamId = @id";
            DataTable table = new DataTable();
            string SqlDataSource = _configuration.GetConnectionString("DefaultConnection");
            SqlDataReader myReader;
            using (SqlConnection myConn = new SqlConnection(SqlDataSource))
            {
                myConn.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myConn))
                {
                    myCommand.Parameters.AddWithValue("@TenSP", sp.TenSP);
                    myCommand.Parameters.AddWithValue("@HinhAnh", sp.HinhAnh);
                    myCommand.Parameters.AddWithValue("@GiaSP", sp.GiaSP);
                    myCommand.Parameters.AddWithValue("@DonViTinh", sp.DonViTinh);
                    myCommand.Parameters.AddWithValue("@MoTa", sp.MoTa);
                    myCommand.Parameters.AddWithValue("@SoLuongTon", sp.SoLuongTon);
                    myCommand.Parameters.AddWithValue("@LoaiSanPhamId", sp.LoaiSanPhamIDLoaiSP);
                    myCommand.Parameters.AddWithValue("@TrangThai", sp.TrangThai);
                    myCommand.Parameters.AddWithValue("@id", sp.SanPhamId);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myConn.Close();
                }
            }
            return new JsonResult("success");
        }

        // DELETE: api/product/3
        [HttpDelete("{id}")]
        /*public void Delete(int id)
        {
        
        }*/
        public JsonResult Delete(int id)
        {
            string query = @"
                        delete from dbo.[SanPham] where SanPhamId = @id";
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
        //GET: api sản phẩm theo id người bán
        // GET: api/product/{id}
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            string query = @"
                        select * from SanPham where NguoiBanId = @id";
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
            return new JsonResult(table);
        }
    }
}
