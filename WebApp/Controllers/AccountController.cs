using APIServices;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Principal;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Utilities;

namespace WebApp.Controllers
{
    public class AccountController : BaseController
    {
        private readonly IAccountApiService _accountApiService;
        private readonly IRoleApiService _roleApiService;

        public AccountController(IAccountApiService accountApiService, IRoleApiService roleApiService)
        {
            _accountApiService = accountApiService;
            _roleApiService = roleApiService;
        }
        // GET: Authentication
        public ActionResult Index()
        {
            return View();
        }
        //Menu dành cho các công việc register, login, check profile
        public ActionResult FirstTop()
        {
            var user = Session["User"] as User;
            if (user != null)
            {
                ViewBag.UserName = user.UserName;
            }
            else
            {
                ViewBag.UserName = "Khách";
            }
            return PartialView("~/Views/Account/FirstTop.cshtml");
        }
        //Đăng nhập
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> Login(LoginModel requestModel)
        {
            if (ModelState.IsValid)
            {
                User user = await _accountApiService.Login(requestModel);
                if (user != null)
                {
                    // Xác thực thành công, tạo phiên đăng nhập
                    SessionControl.AddNormalSession(CommonConstants.User, user, 160);

                    // Chuyển hướng đến trang chính
                    return RedirectToAction("Index", "Home");
                }
                return Json(new
                {
                    result = "error",
                    message = "Có lỗi xảy ra"
                });
            }
            return View(requestModel);
        }
        //Đăng kí
        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> Register(User requestModel)
        {
            if (ModelState.IsValid)
            {
                //tạo người dùng
                int result = 0;
                int result2 = 0;
                result = await _accountApiService.Creat(requestModel);
                //tạo quyền chp người dùng
                Role roleRequest = new Role();
                roleRequest.UserId = result;
                roleRequest.RoleId = 2;
                result2 =  await _roleApiService.CreatUserRole(roleRequest);
                if(result2 > 0)
                {
                    // Xác thực thành công, tạo phiên đăng nhập
                    SessionControl.AddNormalSession(CommonConstants.User, requestModel, 160);

                    // Chuyển hướng đến trang chính
                    return RedirectToAction("Index", "Home");
                }
                return Json(new
                {
                    result = "error",
                    message = "Có lỗi xảy ra"
                });
            }
            return View(requestModel);
        }
        [AllowAnonymous]
        public ActionResult LogOff()
        {
            SessionControl.DeleteNormalSession(CommonConstants.User);
            return RedirectToAction("Index", "Home");
        }

    }
}