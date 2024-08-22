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
    public class DMSanPhamController : BaseController
    {
        private readonly IDMSanPhamApiService _dmSanPhamApiService;
        public DMSanPhamController(IDMSanPhamApiService dmSanPhamApiService)
        {
            _dmSanPhamApiService = dmSanPhamApiService;
        }
        // GET: DMSanPham
        public ActionResult Index()
        {
            return View();
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
    }
}