using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eShop.Entities;
using Microsoft.EntityFrameworkCore;

namespace eShop.Controllers
{
    [Route("api/product")]
    [ApiController]
    public class SanPhamController : ControllerBase
    {
        private readonly ModelContext _context;

        public SanPhamController(ModelContext context)
        {
            _context = context;
        }

        //GET: api/product/4
        [HttpGet("{id}")]
        public async Task<ActionResult<SanPham>> GetProduct(int id)
        {
            var hoso = await _context.SanPham.FindAsync(id);

            if (hoso == null)
            {
                return NotFound();
            }

            return hoso;
        }
    }
}
