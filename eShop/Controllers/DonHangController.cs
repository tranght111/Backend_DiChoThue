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
        public async Task<ActionResult<IEnumerable<DonHang>>> GetOrderList(int? userid, bool? shipping, bool? success, bool? cancel)
        {
            var list = _context.DonHang.AsQueryable();
            //Lấy DS đơn hàng của khách hàng
            //list = _context.DonHang.Where<DonHang>(i => i.KhachHang.KhachHangId == 1); //Thay 1 bằng userid

            //if (shipping == true)
            //{
            //    list = _context.DonHang.Where<DonHang>(i => i.)
            //}

            var listCTDH = _context.ChiTietDonHang.AsQueryable();
            var listTTDH = _context.TrangThaiDonHang.AsQueryable();
            var listSP = _context.SanPham.AsQueryable();
            var listImgSP = _context.ImageSanPham.AsQueryable();
            var listNB = _context.NguoiBan.AsQueryable();
            var listKH = _context.KhachHang.AsQueryable();

            foreach (var dh in list)
            {
                //get Trang thai don hang
                TrangThaiDonHang trangThai = new TrangThaiDonHang();
                foreach (var ttdh in listTTDH)
                {
                    
                    if (dh.DonHangId == ttdh.DonHangId)
                    {
                        trangThai = ttdh;
                    }
                }
                if (trangThai != null)
                {
                    dh.TrangThaiDonHangs.Clear();
                    dh.TrangThaiDonHangs.Add(trangThai);
                }
                    
                //get Nguoi ban
                foreach (var nb in listNB)
                {
                    if (nb.NguoiBanId == dh.NguoiBanId)
                    {
                        dh.NguoiBan = nb;
                        break;
                    }
                }

                foreach (var ctdh in listCTDH)
                {
                    //get Chi tiet san pham
                    if (dh.DonHangId == ctdh.DonHangId)
                    {
                        //get San pham
                        foreach (var sp in listSP)
                            if (sp.SanPhamId == ctdh.SanPhamId)
                            {
                                //get Image san pham

                                foreach (var img in listImgSP)
                                    if (img.SanPhamId == sp.SanPhamId)
                                    {
                                        if (!sp.ImageSanPhams.Contains(img))
                                            sp.ImageSanPhams.Add(img);
                                        break;
                                    }
                                
                                ctdh.SanPham = sp;
                                break;
                            }

                        bool isContains = false;
                        foreach (var chitiet in dh.ChiTietDonHangs)
                        {
                            if (chitiet.ChiTietDonHangId == ctdh.ChiTietDonHangId)
                            {
                                isContains = true;
                                break;
                            }
                        }
                        if (!isContains) dh.ChiTietDonHangs.Add(ctdh);

                    }
                }
            }

            return await list.ToListAsync();
        }


    }
}
