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
    [Route("api/orderdetails")]
    [ApiController]
    public class ChiTietDonHangController : ControllerBase
    {
        private readonly ModelContext _context;

        public ChiTietDonHangController(ModelContext context)
        {
            _context = context;
        }

        //GET: api/orderdetails?idOrder=4
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ChiTietDonHang>>> GetOrderDetailsList(int? idOrder)
        {
            var list = _context.ChiTietDonHang.AsQueryable();

            if (idOrder != null)
            {
                list = _context.ChiTietDonHang.Where<ChiTietDonHang>(i => i.ChiTietDonHangId == idOrder);
            }

            return await list.ToListAsync();
        }
    }
}
