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
    [Route("api/orderstatus")]
    [ApiController]
    public class TrangThaiDonHangController : ControllerBase
    {
        private readonly ModelContext _context;

        public TrangThaiDonHangController(ModelContext context)
        {
            _context = context;
        }

        //GET: api/orderstatus?idOrder=1
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TrangThaiDonHang>>> GetOrderStatusList(int? idOrder, bool? all)
        {
            var list = _context.TrangThaiDonHang.AsQueryable();

            if (idOrder != null)
            {
                list = _context.TrangThaiDonHang.Where<TrangThaiDonHang>(i => i.TrangThaiDonHangId == idOrder);
            }

            if (all == false)
            {
                int len = list.Count();
                list = list.Skip(len - 1);
            }

            return await list.ToListAsync();
        }
    }
}
