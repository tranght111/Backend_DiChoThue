using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using DICHOTHUE_API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using System.Data;
using eShop.Entities;

namespace eShop.Controllers
{
    [Route("api/DKBH")]
    [ApiController]
    public class HoSoDangKyBanHangController : ControllerBase
    {
        private readonly ModelContext _context;
        private readonly IWebHostEnvironment _env;

        public HoSoDangKyBanHangController(ModelContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        //GET: api/DKBH
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HoSoDangKyBanHang>>> GetDSHoSo(string? status)
        {
            var list = _context.HoSoDangKyBanHang.AsQueryable();

            if (status != null)
            {
                list = _context.HoSoDangKyBanHang.Where<HoSoDangKyBanHang>(i => i.TrangThai == status || i.TrangThai == "-"+status);
            }

            return await list.ToListAsync();
        }

        //GET: api/DKBH/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HoSoDangKyBanHang>> GetHoSoDKBH(int id)
        {
            var hoso = await _context.HoSoDangKyBanHang.FindAsync(id);

            if (hoso == null)
            {
                return NotFound();
            }

            return hoso;
        }

        //POST: api/DKBH
        [HttpPost]
        public async Task<ActionResult<HoSoDangKyBanHang>> AddHoSoDKBH(HoSoDangKyBanHang hoso)
        {
            
            _context.HoSoDangKyBanHang.Add(hoso);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHoSoDKBH", new { id = hoso.HoSoDangKyBanHangId }, hoso);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> putHoSo(int id, HoSoDangKyBanHang hoso)
        {
            if (id != hoso.HoSoDangKyBanHangId)
            {
                return BadRequest();
            }

            _context.Entry(hoso).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HoSoDKBH_Exists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return new JsonResult("Cập nhật thành công!");
        }

        private bool HoSoDKBH_Exists(int id)
        {
            return _context.HoSoDangKyBanHang.Any(e => e.HoSoDangKyBanHangId == id);
        }


        [Route("SaveFile")]
        [HttpPost]
        public JsonResult SaveFile()
        {
            var httpRequest = Request.Form;
            var postedFile = httpRequest.Files[0];
            string filename = postedFile.FileName;
            var physicalPath = _env.ContentRootPath + "/Photos/" + filename;

            using (var stream = new FileStream(physicalPath, FileMode.Create))
            {
                postedFile.CopyTo(stream);
            }

            return new JsonResult(filename);
        }
    }
}
