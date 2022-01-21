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
    [Route("api/productimage")]
    [ApiController]
    public class ImageSanPhamController : ControllerBase
    {
        private readonly ModelContext _context;

        public ImageSanPhamController(ModelContext context)
        {
            _context = context;
        }

        //GET: api/productimage?idsp=4&take=1
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ImageSanPham>>> GetProductImageList(int? idsp, int? take)
        {
            var list = _context.ImageSanPham.AsQueryable();

            if (idsp != null)
            {
                list = _context.ImageSanPham.Where<ImageSanPham>(i => i.ImageSanPhamId == idsp);
            }

            if (take != null)
            {
                list = list.Take((int)take);
            }

            return await list.ToListAsync();
        }
    }
}
