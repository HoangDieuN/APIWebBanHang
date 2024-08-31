using APIServices;
using Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Security;
using Utilities;

namespace WebApp.Areas.Admin.Controllers
{
    public class TrangThaiController : Controller
    {
        private readonly ITrangThaiApiService _trangThaiApiService;
        public TrangThaiController(ITrangThaiApiService trangThaiApiService)
        {
            _trangThaiApiService = trangThaiApiService;
        }
        // GET: Admin/TrangThai
        public ActionResult Index()
        {
            return View();
        }
        #region PartialViews
        [HttpPost]
        public async Task<ActionResult> _FormTrangThai(TrangThaiRequest requestModel)
        {
            //call api
            TrangThai model = await _trangThaiApiService.GetByDatHangId(requestModel);
         
            return PartialView(model);
        }
        #endregion PartialViews
        #region Select
        [HttpPost]
        public async Task<ActionResult> SelectTrangThai(TrangThaiRequest trangThaiRequest)
        {
            //call api
            TrangThaiPaging model = await _trangThaiApiService.GetAll(trangThaiRequest);
            //convert for select2
            List<object> options = new List<object>();
            foreach (var item in model.ListTrangThai)
            {
                options.Add(new
                {
                    id = item.Id,
                    text = item.TenTrangThai,
                    data = item
                });
            }
            return Json(new
            {
                data = options,
                recordsTotal = model.ListTrangThai.Count(),
                result = "success",
                message = "Tải dữ liệu thành công"
            });
        }
        #endregion Select
        #region Actions
        [HttpPost]
        public async Task<ActionResult> UpdateStatus(TrangThaiRequest requestModel)
        {
            try
            {
                //save
                int result = await _trangThaiApiService.UpdateTrangThai(requestModel);
                if (result > 0)
                {
                    return Json(new { result = "success", message = Constants.MSG_ERR_UPDATE_SUCCESS });
                }
                return Json(new { result = "error", message = Constants.MSG_ERR_UPDATE_FAILED });
            }
            catch (Exception ex)
            {
                return Json(new { result = "error", message = $"Có lỗi xảy ra: {ex.Message}" });
            }
        }
        #endregion Actions
    }
}