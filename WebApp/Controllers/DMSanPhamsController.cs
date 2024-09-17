using APIServices;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace WebApp.Controllers
{
    public class DMSanPhamsController : BaseController
    {
        private readonly IDMSanPhamApiService _dmSanPhamApiService;
        private readonly ISanPhamApiService _sanPhamApiService;

        public DMSanPhamsController(IDMSanPhamApiService dmSanPhamApiService, ISanPhamApiService sanPhamApiService)
        {
            _dmSanPhamApiService = dmSanPhamApiService;
            _sanPhamApiService = sanPhamApiService;
        }
        // GET: DMSanPham
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<ActionResult> MenuLeft()
        {
            DanhMucSanPhamRequest request = new DanhMucSanPhamRequest();
            DanhMucSanPhamPaging model = await _dmSanPhamApiService.GetAll(request);
            return PartialView("_PartialMenuLeft", model);
        }
        [HttpGet]
        public async Task<ActionResult> MenuDMSanPham()
        {
            DanhMucSanPhamRequest request = new DanhMucSanPhamRequest();
            DanhMucSanPhamPaging model = await _dmSanPhamApiService.GetAll(request);
            return PartialView("_PartialMenuDanhMucSanPham", model);
        }
        [HttpGet]
        public async Task<ActionResult> MenuArrivalsDMSanPham()
        {
            DanhMucSanPhamRequest request = new DanhMucSanPhamRequest();
            DanhMucSanPhamPaging model = await _dmSanPhamApiService.GetAll(request);
            return PartialView("_PartialMenuArrivalsDMSanPham",model);
        }

        [HttpGet]
        public async Task<ActionResult> DanhSachSanPhamByDanhMucId(int? id)
        {
            SanPhamRequest sanPhamRequest = new SanPhamRequest();
            SanPhamPaging ds = new SanPhamPaging();
            sanPhamRequest.DanhMucId = id.Value;
            ds = await _sanPhamApiService.GetAllActive(sanPhamRequest);
            ViewBag.TenDM = ds.ListSanPham.FirstOrDefault().TenDanhMucSP;
            return View("_DanhSachSanPhamByDanhMucId", ds);
        }

    }
}