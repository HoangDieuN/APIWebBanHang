using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace WebApp.Areas.Admin.Controllers
{
    public class DMModuleController : Controller
    {
        // GET: Admin/DMModule
        public ActionResult Index()
        {
            return View();
        }
        public async Task<ActionResult> SelectModule()
        {

        }
    }
}