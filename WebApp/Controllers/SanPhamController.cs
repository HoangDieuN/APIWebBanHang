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
    public class SanPhamController : Controller
    {
        private readonly ISanPhamApiService _sanPhamApiService;
        public SanPhamController(ISanPhamApiService sanPhamApiService)
        {
            _sanPhamApiService = sanPhamApiService;
        }

        // GET: SanPham
        public ActionResult Index()
        {
            return View();
        }
  
        [HttpPost]
        public async Task<ActionResult> ListGiaiThuong(SanPhamRequest requestModel)
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
    }
}