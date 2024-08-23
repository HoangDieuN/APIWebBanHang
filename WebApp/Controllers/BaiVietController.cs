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
    public class BaiVietController : BaseController
    {
        private readonly IBaiVietApiService _baiVietApiService;
        public BaiVietController(IBaiVietApiService baiVietApiService)
        {
                _baiVietApiService = baiVietApiService;
        }
        // GET: BaiViet
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<ActionResult> MenuBaiViet(BaiVietRequest baiVietRequest)
        {
            BaiVietPaging ds = await _baiVietApiService.GetAll(baiVietRequest);
            return PartialView("_MenuBaiViet", ds);
        }
    }
}