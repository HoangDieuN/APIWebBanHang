using APIServices;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace WebApp.Controllers
{
    public class SanPhamsController : BaseController
    {
        private readonly ISanPhamApiService _sanPhamApiService;
        public SanPhamsController(ISanPhamApiService sanPhamApiService)
        {
            _sanPhamApiService = sanPhamApiService;
        }

        // GET: SanPham
        public ActionResult Index()
        {
            return View();
        }
        //danh sách sản phẩm cho trang sản phẩm index
        [HttpGet]
        public async Task<ActionResult> DanhSachSanPham(SanPhamRequest sanPhamRequest)
        {
            SanPhamPaging ds = await _sanPhamApiService.GetAll(sanPhamRequest);
            return PartialView("_DanhSachSanPham", ds);
        }
        //menu sản phẩm theo danh mục cho layout
        [HttpGet]
        public async Task<ActionResult> MenuSanPhamByMaDMSanPham(SanPhamRequest sanPhamRequest)
        {
            SanPhamPaging ds = await _sanPhamApiService.GetAll(sanPhamRequest);
            return PartialView("_MenuSanPhamByMaDMSanPham",ds);
        }
        //menu sản phẩm đang sale cho layout
        [HttpGet]
        public async Task<ActionResult> MenuSanPhamDangSale(SanPhamRequest sanPhamRequest)
        {
            SanPhamPaging ds = await _sanPhamApiService.GetAll(sanPhamRequest);
            return PartialView("_MenuSanPhamDangSale", ds);
        }
        //xem chi tiết sản phẩm
        [HttpGet]
        public async Task<ActionResult> SanPham_Detail(int id)
        {
            SanPham result = await _sanPhamApiService.GetById(id);
            return View("_ChiTietSanPham", result);
        }
    }
}