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
    public class MenuController : BaseController
    {
        private readonly ISanPhamApiService _sanPhamApiService;
        private readonly IDMSanPhamApiService _dmSanPhamApiService;
        private readonly IBaiVietApiService _baiVietApiService;
        public MenuController(IDMSanPhamApiService dmSanPhamApiService, IBaiVietApiService baiVietApiService,ISanPhamApiService sanPhamApiService)
        {
            _dmSanPhamApiService = dmSanPhamApiService;
            _baiVietApiService = baiVietApiService;
            _sanPhamApiService = sanPhamApiService;
        }
        // GET: _PartialMenu cho layout

        public ActionResult _PartialMenuSanPham()
        {
            return PartialView();
        }
     

        public ActionResult _PartialMenuBaiViet()
        {
            return PartialView();
        }
    }
}