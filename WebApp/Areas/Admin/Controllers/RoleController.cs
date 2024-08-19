using APIServices;
using Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Security;
using Utilities;

namespace WebApp.Areas.Admin.Controllers
{
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
            return PartialView(requestModel);
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
    }

}