using PagedList;
using APIServices;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using Utilities;

namespace WebApp.Controllers
{
    public class BaiVietsController : BaseController
    {
        private readonly IBaiVietApiService _baiVietApiService;
        public BaiVietsController(IBaiVietApiService baiVietApiService)
        {
                _baiVietApiService = baiVietApiService;
        }
        // GET: BaiViet
        public ActionResult Index()
        {
            return View();
        }
        //Lấy danh sách bài viết
        [HttpGet]
        public async Task<ActionResult> DanhSachBaiViet(BaiVietRequest baiVietRequest)
        {
            try
            {
                BaiVietPaging ds = await _baiVietApiService.GetAll(baiVietRequest);

                return Json(new
                {
                    data = ds.ListBaiViet,
                    recordsTotal = ds.Total,
                    recordsFiltered = ds.Total,
                    draw = baiVietRequest.Draw == 0 ? 1 : baiVietRequest.Draw,
                    result = "success",
                    message = "Tải dữ liệu thành công"
                }, JsonRequestBehavior.AllowGet); 
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    result = "error",
                    message = ex.Message
                }, JsonRequestBehavior.AllowGet);
            }
        }



        //menu bài viết cho trang chủ
        [HttpGet]
        public async Task<ActionResult> MenuBaiViet(BaiVietRequest baiVietRequest)
        {
            BaiVietPaging ds = await _baiVietApiService.GetAll(baiVietRequest);
            return PartialView("_MenuBaiViet", ds);
        }

    }
}