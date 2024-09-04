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
                baiVietRequest.PageSize = 2;
                BaiVietPaging dsactive = await _baiVietApiService.GetAllActive(baiVietRequest);
                return Json(new
                {
                    data = dsactive.ListBaiViet.Skip(baiVietRequest.PageSize * (baiVietRequest.Page - 1)).Take(baiVietRequest.PageSize).ToList(),

                    recordsTotal = dsactive.Total,
                    recordsFiltered = dsactive.Total,
                    draw = baiVietRequest.Draw == 0 ? 1 : baiVietRequest.Draw,
                    totalPages = (int)Math.Ceiling((double)dsactive.Total / baiVietRequest.PageSize),
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

        //chi tiết bài viết
        [HttpGet]
        public async Task<ActionResult> BaiViet_Detail(string tenbaiviet, int id)
        {
            BaiViet result = await _baiVietApiService.GetById(id);
            return View("BaiViet_Detail", result);
        }
        //menu bài viết cho trang chủ
        [HttpGet]
        public async Task<ActionResult> MenuBaiViet(BaiVietRequest baiVietRequest)
        {
            BaiVietPaging ds = await _baiVietApiService.GetAllActive(baiVietRequest);
            return PartialView("_MenuBaiViet", ds);
        }

    }
}