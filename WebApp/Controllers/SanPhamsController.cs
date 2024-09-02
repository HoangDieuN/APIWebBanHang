using APIServices;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Utilities;

namespace WebApp.Controllers
{
    public class SanPhamsController : BaseController
    {
        private readonly ISanPhamApiService _sanPhamApiService;
        private readonly IAttachedFileApiService _attachedFileApiService;

        public SanPhamsController(ISanPhamApiService sanPhamApiService, IAttachedFileApiService attachedFileApiService)
        {
            _sanPhamApiService = sanPhamApiService;
            _attachedFileApiService = attachedFileApiService;
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
            SanPhamPaging ds = await _sanPhamApiService.GetAllActive(sanPhamRequest);
            return PartialView("_DanhSachSanPham", ds);
        }
        //menu sản phẩm theo danh mục cho layout
        [HttpGet]
        public async Task<ActionResult> MenuSanPhamByMaDMSanPham(SanPhamRequest sanPhamRequest)
        {
            SanPhamPaging ds = await _sanPhamApiService.GetAllActive(sanPhamRequest);
            return PartialView("_MenuSanPhamByMaDMSanPham",ds);
        }
        //menu sản phẩm đang sale cho layout
        [HttpGet]
        public async Task<ActionResult> MenuSanPhamDangSale(SanPhamRequest sanPhamRequest)
        {
            SanPhamPaging ds = await _sanPhamApiService.GetAllActive(sanPhamRequest);
            return PartialView("_MenuSanPhamDangSale", ds);
        }
        //xem chi tiết sản phẩm
        [HttpGet]
        public async Task<ActionResult> SanPham_Detail(string tensanpham, int id)
        {
            //lấy thông tin sản phẩm
            SanPham result = await _sanPhamApiService.GetById(id);
            return View("SanPham_Detail", result);
        }
    }
}