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
    public class DatHangController : BaseController
    {
        private readonly IDatHangApiService _datHangApiService;
        public DatHangController(IDatHangApiService datHangApiService)
        {
            _datHangApiService = datHangApiService;
        }
        // GET: Admin/DatHang
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> ListDatHang(DatHangRequest requestModel)
        {
            //call api
            DatHangPaging model = await _datHangApiService.GetAll(requestModel);

            return Json(new
            {
                data = model.ListDatHang,
                recordsTotal = model.Total,
                recordsFiltered = model.Total,
                draw = requestModel.Draw == 0 ? 1 : requestModel.Draw,
                result = "success",
                message = "Tải dữ liệu thành công"
            });
        }
    }
}