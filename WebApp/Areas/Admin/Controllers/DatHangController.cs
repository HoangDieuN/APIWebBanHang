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
        [HttpGet]
        public async Task<ActionResult> _FormView(int id)
        {
            DatHang model = new DatHang();
            if (id > 0)
            {
                DatHang result = await _datHangApiService.GetById(id);
                if (result != null)
                {
                    model = result;
                }
            }
            return PartialView(model);
        }
        [HttpPost]
        public async Task<ActionResult> UpdateStatus(DatHangRequest requestModel)
        {
            try
            {
                requestModel.UpdatedBy = User.UserName;
                //call api
                int result = await _datHangApiService.UpdateStatus(requestModel);
                if (result > 0)
                {
                    return Json(new { result = "success", message = "Cập nhật thành công" });
                }
                return Json(new { result = "error", message = "Cập nhật thất bại" });
            }
            catch (Exception ex)
            {
                return Json(new { result = "error", message = "Có lỗi xảy ra: " + ex.Message });
            }
        }
    }
}