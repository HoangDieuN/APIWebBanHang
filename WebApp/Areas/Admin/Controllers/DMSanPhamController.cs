using APIServices;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace WebApp.Areas.Admin.Controllers
{
    public class DMSanPhamController : Controller
    {
        private readonly IDMSanPhamApiService _dMSanPhamApiService;
        public DMSanPhamController(IDMSanPhamApiService dMSanPhamApiService)
        {
            _dMSanPhamApiService = dMSanPhamApiService;
        }
        // GET: Admin/DMSanPham
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> ListDanhMucSanPham(DanhMucSanPhamRequest requestModel)
        {
            //call api
            DanhMucSanPhamPaging model = await _dMSanPhamApiService.GetAll(requestModel);

            return Json(new
            {
                data = model.ListDanhMucSanPham,
                recordsTotal = model.Total,
                recordsFiltered = model.Total,
                draw = requestModel.Draw == 0 ? 1 : requestModel.Draw,
                result = "success",
                message = "Tải dữ liệu thành công"
            });
        }
    }
}