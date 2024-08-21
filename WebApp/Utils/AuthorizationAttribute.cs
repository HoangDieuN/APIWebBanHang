using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Utilities;

namespace WebApp
{
    public class AuthorizationAttribute : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            //1. Check Authorize
            var isAuthorized = false;
            User user = SessionControl.GetSessionUserInfo<User>();
            if (user != null && user.RoleName=="Admin")
            {
                isAuthorized = true;
            }

            return isAuthorized;
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            if (filterContext.HttpContext.Request.IsAjaxRequest())
            {
                filterContext.Result = new JsonResult
                {
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                    Data = new { Status = 403, Message = "Bạn không có quyền truy cập" }
                };
            }
            else
            {
                var requestType = filterContext.HttpContext.Request.ContentType;
                if (string.IsNullOrEmpty(requestType))
                {
                    filterContext.HttpContext.Response.Redirect("/admin/account/login", true);
                }
                base.HandleUnauthorizedRequest(filterContext);
            }
        }
    }
}