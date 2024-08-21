using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApp.Areas.Admin.Controllers
{
    [Authorization]
    public class HomeController : Controller
    {
        // GET: Admin/Home
        public ActionResult Index()
        {

            var user = Session["User"] as User;
            if(user == null)
            {
                return RedirectToAction("Login", "Account");
            }
            ViewBag.UserName = user.UserName;
            return View();
        }
        public ActionResult _Header()
        {
            var user = Session["User"] as User;
            ViewBag.UserName = user.UserName;
            return PartialView("~/Areas/Admin/Views/Shared/_Header.cshtml");
        }
    }
}