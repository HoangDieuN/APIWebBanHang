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
    public class SanPhamController : Controller
    {
        private readonly ISanPhamApiService _sanPhamApiService;
        public SanPhamController(ISanPhamApiService sanPhamApiService)
        {
            _sanPhamApiService = sanPhamApiService;
        }
        // GET: Admin/SanPham
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> ListSanPham(SanPhamRequest requestModel)
        {
            //call api
            SanPhamPaging model = await _sanPhamApiService.GetAll(requestModel);

            return Json(new
            {
                data = model.ListSanPham,
                recordsTotal = model.Total,
                recordsFiltered = model.Total,
                draw = requestModel.Draw == 0 ? 1 : requestModel.Draw,
                result = "success",
                message = "Tải dữ liệu thành công"
            });
        }
        [HttpGet]
        public async Task<ActionResult> _FormSanPham(int id)
        {
            SanPham model = new SanPham();
            if (id > 0)
            {
                SanPham result = await _sanPhamApiService.GetById(id);
                if (result != null)
                {
                    model = result;
                }
            }
            return PartialView(model);
        }
    }
}