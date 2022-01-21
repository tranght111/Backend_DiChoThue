using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eShop.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;

namespace eShop.Controllers
{
    [Route("api/orderlist")]
    [ApiController]
    public class DonHangController : ControllerBase
    {
        private readonly ModelContext _context;

        public DonHangController(ModelContext context)
        {
            _context = context;
        }

        //GET: api/orderlist
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DonHang>>> GetOrderList(bool? shipping, bool? success, bool? cancel)
        {
            //var list = _context.DonHang.AsQueryable();

            //if (shipping == true)
            //{
            //    list = _context.DonHang.Where<DonHang>(i => i.)
            //}

            return await _context.DonHang.ToListAsync();
        }

        
    }
}
