using APIServices;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace WebApp.Controllers
{
    public class DMModuleController : Controller
    {
        private readonly IDMModuleApiService _dMModuleApiService;
        public DMModuleController(IDMModuleApiService dMModuleApiService)
        {
            _dMModuleApiService = dMModuleApiService;
        }
        // GET: DMModule
        public ActionResult Index()
        {
            return View();
        }
        public async Task<ActionResult> MenuTop(DMModuleRequest dMModuleRequest)
        {
            DMModulePaging ds = await _dMModuleApiService.GetAllActive(dMModuleRequest);
            return PartialView("_MenuTop", ds);
        }
    }
}