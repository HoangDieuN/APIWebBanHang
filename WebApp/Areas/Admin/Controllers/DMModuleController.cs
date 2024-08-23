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
    [Authorization]
    public class DMModuleController : BaseController
    {
        // GET: Admin/DMModule
        private readonly IDMModuleApiService _dMModuleApiService;
        public DMModuleController(IDMModuleApiService dMModuleApiService)
        {
            _dMModuleApiService = dMModuleApiService;
        }
        // GET: Admin/DMModule
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> ListDMModule(DMModuleRequest requestModel)
        {
            //call api
            DMModulePaging model = await _dMModuleApiService.GetAll(requestModel);

            return Json(new
            {
                data = model.ListModule ,
                recordsTotal = model.Total,
                recordsFiltered = model.Total,
                draw = requestModel.Draw == 0 ? 1 : requestModel.Draw,
                result = "success",
                message = "Tải dữ liệu thành công"
            });
        }
        [HttpGet]
        public async Task<ActionResult> _FormDMModule(int id)
        {
            DMModule model = new DMModule();
            if (id > 0)
            {
                DMModule result = await _dMModuleApiService.GetById(id);
                if (result != null)
                {
                    model = result;
                }
            }
            return PartialView(model);
        }
        [HttpPost]
        public async Task<ActionResult> Save(DMModule requestModel)
        {
            try
            {
                int result = 0;
                if (requestModel.Id > 0)
                {
                    requestModel.UpdatedBy = User.UserName;
                    result = await _dMModuleApiService.Update(requestModel);
                }
                else
                {
                    requestModel.CreatedBy = User.UserName;
                    result = await _dMModuleApiService.Creat(requestModel);
                }
                if (result > 0)
                {
                    return Json(new { result = "success", message = "Lưu thông tin thành công" });
                }
                return Json(new { result = "error", message = "Lưu thông tin thất bại" });

            }
            catch (Exception ex)
            {
                return Json(new { result = "error", message = "Có lỗi xảy ra" + ex.Message });
            }
        }
        [HttpPost]
        public async Task<ActionResult> Delete(DMModuleRequest requestModel)
        {
            try
            {
                requestModel.DeletedBy = User.UserName;
                int result = await _dMModuleApiService.Delete(requestModel);
                if (result > 0)
                {
                    return Json(new { result = "success", message = "Xóa thành công" });
                }
                return Json(new { result = "error", message = "Xóa thất bại" });

            }
            catch (Exception ex)
            {
                return Json(new { result = "error", message = "Có lỗi xảy ra" + ex.Message });
            }
        }
        [HttpPost]
        public async Task<ActionResult> SelectDMModule(DMModuleRequest requestModel)
        {
            DMModulePaging model = await _dMModuleApiService.GetAll(requestModel);
            List<object> options = new List<object>();
            foreach (var item in model.ListModule)
            {
                options.Add(new
                {
                    id = item.Id,
                    text = item.TenViet,
                    data = item
                });
            }
            return Json(new
            {
                data = options,
                recordsTotal = model.ListModule.Count,
                result = "success",
                message = "Tải dữ liệu thành công"
            });
        }
    }
}