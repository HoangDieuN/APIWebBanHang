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
    [Authorization]
    public class RoleController : Controller
    {
        private readonly IRoleApiService _roleApiService;
        public RoleController(IRoleApiService roleApiService)
        {
            _roleApiService = roleApiService;
        }
        // GET: Admin/Role
        public ActionResult Index()
        {
            return View();
        }
        #region PartialViews
        [HttpPost]
        public async Task<ActionResult> _FormRole(RoleRequest requestModel)
        {
            //call api
            Role model = await _roleApiService.GetByUser(requestModel);
            if (model == null)
            {
                model = new Role()
                {
                    UserId = requestModel.UserId
                };
            }
            return PartialView(model);
        }
        [HttpGet]
        public async Task<ActionResult> _FormThemMoiRole(int id)
        {
            Role model = new Role();
            //call api
            Role result = await _roleApiService.GetById(id);
            if (result !=null)
            {
                model = result;
            }
            return PartialView(model);
        }
        #endregion PartialViews

        #region Select
        [HttpPost]
        public async Task<ActionResult> SelectRole()
        {
            //call api
            List<Role> model = await _roleApiService.GetAll();
            //convert for select2
            List<object> options = new List<object>();
            foreach (var item in model)
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
                recordsTotal = model.Count,
                result = "success",
                message = "Tải dữ liệu thành công"
            });
        }
        #endregion Select
        #region Action
        [HttpPost]
        public async Task<ActionResult> ListQuyen(RoleRequest requestModel)
        {
            //call api
            RolePaging model = await _roleApiService.GetAllPaging(requestModel);
            return Json(new
            {
                data = model.ListQuyen,
                recordsTotal = model.Total,
                recordsFiltered = model.Total,
                draw = requestModel.Draw == 0 ? 1 : requestModel.Draw,
                result = "success",
                message = "Tải dữ liệu thành công"
            });
        }
        [HttpPost]
        public async Task<ActionResult> SaveUserRole(Role requestModel)
        {
            try
            {
                //save
                int result = await _roleApiService.UpdateUserRole(requestModel);
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
        [HttpPost]
        public async Task<ActionResult> CreatUserRole(Role requestModel)
        {
            try
            {
                //save
                int result = await _roleApiService.CreatUserRole(requestModel);
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

        #endregion Action
    }

}