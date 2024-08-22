using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Utilities;

namespace WebApp.Controllers
{
    public class BaseController : Controller
    {
        protected virtual new User User
        {
            get
            {
                return SessionControl.GetSessionUserInfo<User>();
            }
        }
    }
}