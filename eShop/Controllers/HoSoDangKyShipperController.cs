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
using eShop.Entities;

namespace eShop.Controllers
{
    [Route("api/DKShipper")]
    [ApiController]
    public class HoSoDangKyShipperController : ControllerBase
    {
        private readonly ModelContext _context;
        private readonly IWebHostEnvironment _env;

        public HoSoDangKyShipperController(ModelContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        //GET: api/DKShipper
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HoSoDangKyShipper>>> GetDSHoSo(string? status)
        {
            var list = _context.HoSoDangKyShipper.AsQueryable();

            if (status != null)
            {
                list = _context.HoSoDangKyShipper.Where<HoSoDangKyShipper>(i => i.TrangThai == status || i.TrangThai == "-" + status);
            }

            return await list.ToListAsync();
        }

        //GET: api/DKShipper/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HoSoDangKyShipper>> GetHoSoDKShipper(int id)
        {
            var hoso = await _context.HoSoDangKyShipper.FindAsync(id);

            if (hoso == null)
            {
                return NotFound();
            }

            return hoso;
        }

        //POST: api/DKShipper
        [HttpPost]
        public async Task<ActionResult<HoSoDangKyShipper>> AddHoSoDKBH(HoSoDangKyShipper hoso)
        {

            _context.HoSoDangKyShipper.Add(hoso);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHoSoDKShipper", new { id = hoso.HoSoDangKyShipperId }, hoso);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> putHoSo(int id, HoSoDangKyShipper hoso)
        {
            if (id != hoso.HoSoDangKyShipperId)
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
                if (!HoSoDKShipper_Exists(id))
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

        private bool HoSoDKShipper_Exists(int id)
        {
            return _context.HoSoDangKyShipper.Any(e => e.HoSoDangKyShipperId == id);
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
